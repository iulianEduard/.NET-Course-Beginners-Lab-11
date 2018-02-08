using AutoMapper;
using Synkwise.API.Models.Account;
using Synkwise.API.Models.Contact;
using Synkwise.API.Models.Facility;
using Synkwise.API.Models.Invitation;
using Synkwise.API.Models.Profile;
using Synkwise.API.Models.Provider;
using Synkwise.API.Models.Resident;
using Synkwise.API.Models.Resident.Assessment;
using Synkwise.Core.Models.Account;
using Synkwise.Core.Models.Contact;
using Synkwise.Core.Models.Facility;
using Synkwise.Core.Models.Invitation;
using Synkwise.Core.Models.Providers;
using Synkwise.Core.Models.Resident;
using Synkwise.Core.Models.Resident.Assessment;

namespace Synkwise.API.App_Start
{
    public static class Mappings
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProviderModel, Provider>();
                cfg.CreateMap<Provider, ProviderModel>();

                cfg.CreateMap<ContactModel, Contact>();
                cfg.CreateMap<Contact, ContactModel>();
                
                cfg.CreateMap<ResidentIdentifier, Contact>();
                cfg.CreateMap<Contact, ResidentIdentifier>();

                cfg.CreateMap<FacilityModel, Facility>();
                cfg.CreateMap<Facility, FacilityModel>();

                cfg.CreateMap<ResidentModel, Resident>();
                cfg.CreateMap<Resident, ResidentModel>();
                cfg.CreateMap<ResidentModel, Contact>();
                cfg.CreateMap<ResidentModel, ResidentCompactModel>().ForMember(dest => dest.Photo,
                                                                               opts => opts.UseValue<string>("https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/557426_461475487207910_1051258564_n.jpg?oh=b673aaff310e9a159ead20daba75e1bf&oe=5AD68E8A")
                                                                               ).
                                                                               ForMember(dest => dest.FirstName,
                                                                               opts => opts.ResolveUsing(el => el.Contact.FirstName))
                                                                               .ForMember(dest => dest.LastName,
                                                                               opts => opts.ResolveUsing(el => el.Contact.LastName));

                cfg.CreateMap<RegisterUserModel, RegisterUser>();

                cfg.CreateMap<InvitationListDetail, InvitationModel>();
                cfg.CreateMap<InvitationListDetail, InvitationListItemModel>();
                cfg.CreateMap<InvitationListItemModel, InvitationListDetail>();
                cfg.CreateMap<Invitation, InvitationModel>();
                cfg.CreateMap<InvitationModel, Invitation>();

                cfg.CreateMap<ResetPasswordModel, ResetPassword>();

                cfg.CreateMap<User, ProfileModel>();
                cfg.CreateMap<ProfileModel, User>();

                cfg.CreateMap<RepresentativesModel, ResidentRepresentatives>();
                cfg.CreateMap<ResidentRepresentatives, RepresentativesModel>();

                cfg.CreateMap<MedicalEquipmentDetailsModel, ResidentMedicalEquipmentDetails>();
                cfg.CreateMap<ResidentMedicalEquipmentDetails, MedicalEquipmentDetailsModel>();

                cfg.CreateMap<InterviewModel, ResidentInterview>();
                cfg.CreateMap<ResidentInterview, InterviewModel>();

                cfg.CreateMap<ResidentDetailsActivities, DetailsActivitiesModel>();
                cfg.CreateMap<DetailsActivitiesModel, ResidentDetailsActivities>();
                cfg.CreateMap<ResidentDetailsBathing, DetailsBathingModel>();
                cfg.CreateMap<DetailsBathingModel, ResidentDetailsBathing>();
                cfg.CreateMap<ResidentDetailsCommunication, DetailsCommunicationModel>();
                cfg.CreateMap<DetailsCommunicationModel, ResidentDetailsCommunication>();
                cfg.CreateMap<ResidentDetailsDressing, DetailsDressingModel>();
                cfg.CreateMap<DetailsDressingModel, ResidentDetailsDressing>();
                cfg.CreateMap<ResidentDetailsEating, DetailsEatingModel>();
                cfg.CreateMap<DetailsEatingModel, ResidentDetailsEating>();
                cfg.CreateMap<ResidentDetailsEmergencyExiting, DetailsEmergencyExitingModel>();
                cfg.CreateMap<DetailsEmergencyExitingModel, ResidentDetailsEmergencyExiting>();
                cfg.CreateMap<ResidentDetailsGrooming, DetailsGroomingModel>();
                cfg.CreateMap<DetailsGroomingModel, ResidentDetailsGrooming>();
                cfg.CreateMap<ResidentDetailsMentalStatus, DetailsMentalStatusModel>();
                cfg.CreateMap<DetailsMentalStatusModel, ResidentDetailsMentalStatus>();
                cfg.CreateMap<ResidentDetailsMobility, DetailsMobilityModel>();
                cfg.CreateMap<DetailsMobilityModel, ResidentDetailsMobility>();
                cfg.CreateMap<ResidentDetailsNightNeeds, DetailsNightNeedsModel>();
                cfg.CreateMap<DetailsNightNeedsModel, ResidentDetailsNightNeeds>();
                cfg.CreateMap<ResidentDetailsToileting, DetailsToiletingModel>();
                cfg.CreateMap<DetailsToiletingModel, ResidentDetailsToileting>();
                cfg.CreateMap<ResidentSummaryOfInformation, SummaryOfInformationModel>();
                cfg.CreateMap<SummaryOfInformationModel, ResidentSummaryOfInformation>();
            });
        }
    }
}