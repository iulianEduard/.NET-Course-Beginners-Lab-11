using AutoMapper;
using Newtonsoft.Json;
using Synkwise.BLL.Ports;
using Synkwise.Core.Models.PlanEngine;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class PlanEngineService : IPlanEngineService
    {
        #region Attributes

        private readonly IPlanEngineRepository _planEngineRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public PlanEngineService(IPlanEngineRepository planEngineRepository)
        {
            _planEngineRepository = planEngineRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        public Task CreatePlanForResident(int residentId, int planTypeId, int stateId)
        {
            throw new NotImplementedException();
        }

        public Task GetPlanForResident(int residentId, int planTypeId)
        {
            throw new NotImplementedException();
        }

        public Task SavePlanForResident()
        {
            throw new NotImplementedException();
        }

        public Task SaveSectionPlanForResident()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Private Methods

        private Plan GeneratePlan(List<PlanSectionResponse> sectionList, List<PlanGroupResponse> groupList)
        {
            var planEngine = new Plan
            {
                PlanSections = new List<Section>()
            };

            foreach (var section in sectionList)
            {
                var planSection = new Section
                {
                    Description = section.Description,
                    Key = section.Key,
                    KeyId = section.KeyId,
                    PlanSectionid = section.Id,
                    Title = section.Title,
                    PlanGroups = GenerateSection(section.Id, groupList.Where(g => g.PlanSectionValueId == section.Id))
                };

                planEngine.PlanSections.Add(planSection);
            }

            return planEngine;
        }

        private SectionData GenerateSection(int sectionId, IEnumerable<PlanGroupResponse> groupList)
        {
            var sectionData = new SectionData
            {
                Groups = new List<PlanGroup>()
            };

            foreach (var group in groupList)
            {
                var sectionGroup = new PlanGroup
                {
                    Key = group.Key,
                    OrderNumber = group.OrderNumber,
                    Inputs = new List<Input>()
                };

                var input = MapInputFromJSON(group.Value);

                sectionGroup.Inputs.Add(input);
                sectionData.Groups.Add(sectionGroup);
            }

            return sectionData;
        }

        private Input MapInputFromJSON(string value)
        {
            var input = new Input();

            input = JsonConvert.DeserializeObject<Input>(value);

            return input;
        }

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Assessment, AssessmentEntity>();
                //cfg.CreateMap<AssessmentEntity, Assessment>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}
