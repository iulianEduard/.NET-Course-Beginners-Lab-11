namespace Synkwise.API.Models.Resident.Assessment
{
    public class ResidentAssessmentDetailsModel
    {
        public DetailsActivitiesModel DetailsActivities { get; set; }

        public DetailsBathingModel DetailsBathing { get; set; }

        public DetailsCommunicationModel DetailsCommunication { get; set; }

        public DetailsDressingModel DetailsDressing { get; set; }

        public DetailsEatingModel DetailsEating { get; set; }

        public DetailsEmergencyExitingModel DetailsEmergencyExiting { get; set; }

        public DetailsGroomingModel DetailsGrooming { get; set; }

        public DetailsMentalStatusModel DetailsMentalStatus { get; set; }

        public DetailsMobilityModel DetailsMobility { get; set; }

        public DetailsNightNeedsModel DetailsNightNeeds { get; set; }

        public DetailsToiletingModel DetailsToileting { get; set; }
    }
}
