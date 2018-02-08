using AutoMapper;
using Microsoft.AspNetCore.Http;
using Synkwise.API.Helpers;
using Synkwise.API.Models.Account;
using Synkwise.API.Models.Invitation;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Account;
using Synkwise.Core.Exceptions.Invitation;
using Synkwise.Core.Exceptions.Register;
using Synkwise.Core.Helpers;
using Synkwise.Core.Models.Account;
using Synkwise.Core.Models.Email;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Synkwise.API.Managers.Register
{
    public class RegisterManager : BaseManager
    {
        #region Attributes

        private readonly IUserService _accountService;
        private readonly IInvitationService _invitationService;
        private readonly IRoleService _roleService;
        private readonly IIdentityResetPasswordService _identityResetPasswordService;

        #endregion Attributes

        #region Constructor

        public RegisterManager(IUserService accountService, IInvitationService invitationService,
            IRoleService roleService, IIdentityResetPasswordService identityResetPasswordService)
        {
            _accountService = accountService;
            _invitationService = invitationService;
            _roleService = roleService;
            _identityResetPasswordService = identityResetPasswordService;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<string> Register(RegisterUserModel registerUserModel)
        {
            // Check if invitation code has expired
            await ValidateInvitationCode(registerUserModel.InvitationCode, registerUserModel.Email);

            // Check if email addrress does not exist in system
            await ValidateRegisterEmail(registerUserModel.Email);

            // Register user
            string confirmationCode = await RegisterUser(registerUserModel);

            // Confirm invitation
            await ConfirmInvitationCode(registerUserModel.InvitationCode, registerUserModel.Email, confirmationCode);

            // Send email
            await SendConfirmationEmail(confirmationCode, registerUserModel.Email);

            return confirmationCode;
        }

        public async Task<string> ValidateInvitationCode(string invitationCode)
        {
            var invitation = await _invitationService.GetByCode(invitationCode);
            var invitationModel = Mapper.Map<InvitationModel>(invitation);

            if (invitationModel == null)
            {
                throw new InvitationInternalServerErrorException("Cannot find invitation based on provided code!");
            }

            if (invitationModel.GeneratedDate.AddDays(Common.InvitationExpirationDays) < DateTime.Now)
            {
                throw new InvitationBadRequestException("Invitation code is expired!");
            }

            return invitationModel.EmailTo;
        }

        public async Task ConfirmEmail(ConfirmUserModel confirmUserModel)
        {
            var invitationModel = await _invitationService.Get(confirmUserModel.InvitationId);

            if (invitationModel?.ConfirmedEmailCode == true || string.IsNullOrEmpty(invitationModel.EmailConfirmationCode))
            {
                throw new RegisterInternalServerErrorException("Invalid confirm code!");
            }

            var result = await _accountService.ConfirmEmail(confirmUserModel.UserId, invitationModel.EmailConfirmationCode);

            if (!result)
            {
                throw new RegisterInternalServerErrorException("Cannot confirm email!");
            }

            var roleId = await GetRoleIdFromInvitationUserId(Convert.ToInt32(confirmUserModel.UserId));

            await AssignRoleToUser(Convert.ToInt32(confirmUserModel.UserId), roleId);

            //TODO: Assign Claims to User

            //update confirmationEmailCode flag on invitation
            invitationModel.ConfirmedEmailCode = true;
            await _invitationService.Update(invitationModel);
        }

        public async Task LogIn(LogOnModel logon)
        {
            var user = new User
            {
                Email = logon.Email,
                Password = logon.Password,
                RememberMe = logon.RememberMe
            };

            await _accountService.SignIn(user);
        }

        public async Task LogOff()
        {
            await _accountService.SignOff();
        }

        public async Task<string> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await _accountService.GetUser(model.Email);
            if (user == null || !(await _accountService.CheckIfEmailExists(user.Email)))
            {
                throw new RegisterBadRequestException("Email doesn't exists!");
            }

            var confirmationCode = await _accountService.ForgetPassword(user, model.Email);

            var resetItem = await CreateResetPasswordEntry(confirmationCode, user.Id);

            var emailMessage = base.GenerateEmail("Forgot Password", model.Email, resetItem.Guid.ToString(), "resetpwd", user.Id, user.Email.Split('@')[0], "Views/EmailTemplates/ForgotPassword.html");

            await EmailService.SendEmailAsync(user.Id, emailMessage);

            return confirmationCode;
        }

        public async Task<int> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var user = await _accountService.GetUserById(resetPasswordModel.UserId);

            if (user == null || user.Id == 0)
            {
                throw new RegisterBadRequestException("Invalid data for reset password");
            }

            //update resetcode form database
            var resetEntity = await _identityResetPasswordService.Get(new Guid(resetPasswordModel.Code));

            if (resetEntity == null || resetEntity.ID == 0 || resetEntity.UsedDate != null)
            {
                throw new RegisterBadRequestException("Invalid data for reset password. Your reset code is invalid.");
            }
            resetPasswordModel.Code = resetEntity.PasswordResetToken;

            var result = await _accountService.ResetPassword(user, Mapper.Map<ResetPassword>(resetPasswordModel));

            if (!result)
            {
                throw new RegisterBadRequestException("Invalid model for reset password");
            }

            await CreateResetPasswordEntry(string.Empty, user.Id);

            return user.Id;
        }

        public async Task<string> GetUserRole(string email)
        {
            var roles = await _accountService.GetUserRoles(email);

            return roles.Count > 0 ? roles[0] : String.Empty;
        }

        public async Task<UserDataModel> GetUserData(string email)
        {
            var userDataModel = new UserDataModel
            {
                Email = email
            };

            var user = await GetUser(email);

            if (user == null)
            {
                throw new AccountInternalServerErrorException("User data cannot be retreived from database!");
            }

            userDataModel.UserName = user.UserName;
            userDataModel.UserId = user.UserGuid;
            userDataModel.ContactId = user.ContactId;
            userDataModel.Role = await GetUserRole(email);
            userDataModel.RoleId = await GetRoleId(userDataModel.Role);

            await GetUserWorkingId(userDataModel, user.UserGuid);

            return userDataModel;
        }

        #endregion Public Methods

        #region Private Methods

        private async Task ValidateInvitationCode(string invitationCode, string email)
        {
            var invitation = await _invitationService.GetByCode(invitationCode);
            var invitationModel = Mapper.Map<InvitationModel>(invitation);

            if (invitationModel == null)
            {
                throw new InvitationInternalServerErrorException("Cannot find invitation based on provided code!");
            }

            if (invitation.EmailTo != email)
            {
                throw new InvitationInternalServerErrorException("Please provide the correct email from invitation!");
            }

            if (invitationModel.GeneratedDate.AddDays(Common.InvitationExpirationDays) < DateTime.Now)
            {
                throw new InvitationBadRequestException("Invitation code is expired!");
                //TODO: Delete user and role connection
                //TODO: Delete invitation code
            }
        }

        private async Task ValidateRegisterEmail(string email)
        {
            bool emailExists = await _accountService.CheckIfEmailExists(email);

            if (emailExists)
            {
                throw new RegisterBadRequestException("Email already exists!");
            }
        }

        private async Task<string> RegisterUser(RegisterUserModel registerUserModel)
        {
            var registerModel = Mapper.Map<RegisterUser>(registerUserModel);
            var confirmationCode = await _accountService.RegisterUser(registerModel);

            if (string.IsNullOrWhiteSpace(confirmationCode))
            {
                throw new RegisterInternalServerErrorException("Error occured while generating the confirmation code!");
            }

            return confirmationCode;
        }

        private async Task ConfirmInvitationCode(string invitationCode, string email, string confirmationCode)
        {
            var user = await GetUser(email);

            if (user == null)
            {
                throw new RegisterInternalServerErrorException("No user was found with provided email address!");
            }

            await _invitationService.ConfirmInvitation(invitationCode, user.Id, confirmationCode);
        }

        private async Task AssignRoleToUser(int userId, int roleId)
        {
            var user = await _accountService.GetUserById(userId.ToString());
            var role = await _roleService.Get(roleId);

            await _accountService.AssignRoleToUser(user.Email, role.Name);
        }

        private async Task<User> GetUser(string email)
        {
            var user = await _accountService.GetUser(email);

            return user;
        }

        private async Task<int> GetRoleIdFromInvitationUserId(int userId)
        {
            int roleId = await _invitationService.GetRoleIdByUserId(userId);

            return roleId;
        }

        private async Task SendConfirmationEmail(string confirmationCode, string email)
        {
            var userModel = await _accountService.GetUser(email);

            var invitationModel = await _invitationService.GetbyEmail(email);

            //update invitation with confirmationCode
            //var invitationId = await UpdateInvitationConfirmationEmailCode(confirmationCode, email);

            var emailMessage = base.GenerateEmail("Update from SYNKWISE", email, invitationModel.Id.ToString(), "confirm", userModel.Id, userModel.Email, "Views/EmailTemplates/EmailRegistration.html");

            await EmailService.SendEmailAsync(userModel.Id, emailMessage);
        }

        private async Task<IdentityResetPassword> CreateResetPasswordEntry(string confirmationCode, int userId)
        {
            var result = new IdentityResetPassword();
            var resetPassword = await _identityResetPasswordService.GetByUserId(userId);
            if (resetPassword == null || resetPassword.ID == 0)
            {
                var resetPasswordItem = new IdentityResetPassword()
                {
                    UserID = userId,
                    PasswordResetToken = confirmationCode
                };
                result = await _identityResetPasswordService.Save(resetPasswordItem);
            }
            else
            {
                //update only at forgot password not at to reset password action
                if (!string.IsNullOrEmpty(confirmationCode))
                {
                    resetPassword.PasswordResetToken = confirmationCode;
                    resetPassword.UsedDate = null;
                }
                else
                {
                    resetPassword.UsedDate = DateTime.Now;
                }

                result = await _identityResetPasswordService.Update(resetPassword);
            }

            return result;
        }

        private async Task<int> GetRoleId(string role)
        {
            var roles = await _roleService.GetAll();
            var foundRole = roles.Where(r => r.Name == role).FirstOrDefault();

            if(foundRole == null)
            {
                throw new AccountInternalServerErrorException("Role not found for user!");
            }

            return foundRole.Id;
        }

        private async Task GetUserWorkingId(UserDataModel userDataModel, Guid userId)
        {
            switch (userDataModel.Role)
            {
                case "Provider":
                    int providerId = await _accountService.GetProviderIdByUserId(userId) ?? 0;
                    userDataModel.WorkingId = providerId;
                    break;
                case "Resident Manager":
                    break;
                case "Nurse":
                    break;
                case "Resident":
                    break;
                default:
                    break;
            }
        }

        #endregion Private Methods
    }
}
