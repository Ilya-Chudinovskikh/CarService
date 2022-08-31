using CarService.Models.DTOs;

namespace CarService.Repositories
{
    public interface ICarServiceRepositories
    {
        List<InfoDto> GetInfo(int month);
        Dictionary<long, double> GetMasterWorkloadByMonth(int month, List<long> masterIds);
    }
}
