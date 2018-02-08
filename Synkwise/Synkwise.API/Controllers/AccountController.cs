using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Managers.Register;
using Synkwise.API.Models;
using Synkwise.API.Models.Account;
using Synkwise.API.Security;
using Synkwise.Core.Exceptions.Account;
using Synkwise.Core.Exceptions.Login;
using Synkwise.Core.Exceptions.Register;

namespace Synkwise.API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : BaseController
    {
        #region Attributes

        private readonly RegisterManager _registerManager;

        #endregion Attributes

        #region Construtor

        public AccountController(RegisterManager registerManager)
        {
            _registerManager = registerManager;
        }

        #endregion Constructor

        #region Public Methods

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn([FromBody] LogOnModel logon)
        {
            var response = new ResponseModel();

            if (!ModelState.IsValid)
            {
                throw new LoginBadRequestException(GetErrorMessage());
            }
            else
            {
                await _registerManager.LogIn(logon);

                var role = await _registerManager.GetUserRole(logon.Email);
                var userData = await _registerManager.GetUserData(logon.Email);

                if (string.IsNullOrEmpty(role))
                {
                    response.Status = HttpStatusCode.OK;
                    response.Message = "User not complete registration";
                    return BadRequest(response);
                }

                response = new ResponseModel
                {
                    Message = new { email = logon.Email, message = "Login with success" },
                    Status = 200,
                    Token = new Token().GenerateToken(userData)
                };

                return Ok(response);
            }
        }

        [HttpGet("Logoff/{userId}")]
        public async Task<IActionResult> LogOff(string userId)
        {
            var response = new ResponseModel();

            await _registerManager.LogOff();

            return Ok();
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserModel registerUserModel)
        {
            if (ModelState.IsValid)
            {
                ValidateRegistration(registerUserModel);

                string confirmationCode = await _registerManager.Register(registerUserModel);

                return Ok(new
                {
                    confirmationCode = confirmationCode
                });
            }
            else
            {
                throw new AccountBadRequestException(GetErrorMessage());
            }
        }

        [HttpGet("validate/{code}")]
        public async Task<IActionResult> ValidateRegisterCode(string code)
        {
            var response = new ResponseModel
            {
                Message = await _registerManager.ValidateInvitationCode(code)
            };

            return Ok(response);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost("Confirm")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromBody]ConfirmUserModel confirmUserModel)
        {
            ValidateConfirmEmail(confirmUserModel);
            await _registerManager.ConfirmEmail(confirmUserModel);

            var response = new ResponseModel
            {
                Message = new { id = confirmUserModel.UserId },
                Status = HttpStatusCode.OK
            };

            return Ok(response);
        }

        [HttpPost("Forgot")]
        public async Task<ActionResult> ForgotPassword([FromBody]ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var confirmationCode = await _registerManager.ForgotPassword(model);

                return Ok(new
                {
                    confirmationCode = confirmationCode
                });
            }
            else
            {
                throw new AccountBadRequestException(GetErrorMessage());
            }
        }

        [HttpPost("resetpassword")]
        public async Task<ActionResult> ResetPassword([FromBody]ResetPasswordModel resetPasswordModel)
        {
            var response = new ResponseModel() { Status = HttpStatusCode.OK };

            if (ModelState.IsValid)
            {
                response.Message = new
                {
                    id = await _registerManager.ResetPassword(resetPasswordModel)
                };

                return Ok(response);
            }
            else
            {
                throw new RegisterBadRequestException("Invalid model for reset password");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ValidateConfirmEmail(ConfirmUserModel confirmUserModel)
        {
            if (confirmUserModel == null)
            {
                throw new RegisterBadRequestException("Missing data for confirmation!");
            }

            if (string.IsNullOrWhiteSpace(confirmUserModel.UserId))
            {
                throw new RegisterBadRequestException("Missing user id!");
            }

            if (confirmUserModel.InvitationId < 0)
            {
                throw new RegisterBadRequestException("Missing invitation id!");
            }
        }

        private void ValidateRegistration(RegisterUserModel registerUserModel)
        {
            if (registerUserModel == null)
            {
                throw new RegisterBadRequestException("Please provide data for registration!");
            }

            if (string.IsNullOrEmpty(registerUserModel.Email))
            {
                throw new RegisterBadRequestException("Please provide an email!");
            }

            if (string.IsNullOrEmpty(registerUserModel.Password))
            {
                throw new RegisterBadRequestException("Please provide a password!");
            }

            if (string.IsNullOrEmpty(registerUserModel.ConfirmPassword))
            {
                throw new RegisterBadRequestException("Please provide a confirm password!");
            }

            if (!registerUserModel.Password.Equals(registerUserModel.ConfirmPassword))
            {
                throw new RegisterBadRequestException("Passwords did not match!");
            }

            if (string.IsNullOrWhiteSpace(registerUserModel.InvitationCode))
            {
                throw new RegisterBadRequestException("Contact your provider for an invitation code!");
            }
        }

        #endregion Private Methods
    }
}

