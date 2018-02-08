using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IPlanEngineService
    {
        Task GetPlanForResident(int residentId, int planTypeId);

        Task CreatePlanForResident(int residentId, int planTypeId, int stateId);

        Task SaveSectionPlanForResident();

        Task SavePlanForResident();
    }
}
