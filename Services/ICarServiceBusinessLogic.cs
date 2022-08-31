namespace CarService.Services
{
    public interface ICarServiceBusinessLogic
    {
        Task<Stream> GetInfo(int month);
    }
}
