using Dapper.Core.Base;
using Dapper.Core.Ports;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Synkwise.API.FIlters;
using Synkwise.API.Managers.Invitation;
using Synkwise.API.Managers.Contact;
using Synkwise.API.Managers.Facility;
using Synkwise.API.Managers.Profile;
using Synkwise.API.Managers.Provider;
using Synkwise.API.Managers.Register;
using Synkwise.API.Managers.Validation;
using Synkwise.BLL;
using Synkwise.BLL.Ports;
using Synkwise.Repository;
using Synkwise.Repository.Ports;
using Synkwise.API.Managers.Resident;
using Synkwise.API.Managers.Role;

namespace Synkwise.API.App_Start
{
    public static class DependencyResolver
    {
        public static void Initialize(IServiceCollection services)
        {
            // Inject database
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Inject repositories
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IValidationRepository, ValidationRepository>();
            services.AddScoped<IResidentAssessmentRepository, ResidentAssessmentRepository>();
            services.AddScoped<IIdentityResetPasswordRepository, IdentityResetPasswordRepository>();

            // Inject services
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IUserService, AccountService>();
            services.AddScoped<IResidentService, ResidentService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IInvitationService, InvitationService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IResidentAssessmentService, ResidentAssessmentService>();
            services.AddScoped<IIdentityResetPasswordService, IdentityResetPasswordService>();

            // Inject managers
            services.AddScoped(typeof(RegisterManager));
            services.AddScoped(typeof(InvitationManager));
            services.AddScoped(typeof(ProviderManager));
            services.AddScoped(typeof(ContactManager));
            services.AddScoped(typeof(RoleManagerCustom));
            services.AddScoped(typeof(FacilityManager));
            services.AddScoped(typeof(ProfileManager));
            services.AddScoped(typeof(ResidentManager));
            services.AddScoped(typeof(AssessmentManager));

            // Inject filters
            services.AddScoped(typeof(ProviderAuthorizationFilter));
            services.AddScoped(typeof(AuthorizeActionValidation));
            services.AddScoped(typeof(FacilityAuthorizationFilter));
        }
    }
}
