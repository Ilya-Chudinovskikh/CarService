namespace CarService.Models.DTOs
{
    public class InfoDto
    {
        public long Id { get; set; }
        public decimal? WorkPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public string? MasterName { get; set; }
        public string? MasterSurName { get; set; }
        public string? MasterThirdName { get; set; }
        public string? CarBrand { get; set; }
        public long? MasterId { get; set; }
        public InfoDto(long id, decimal? workPrice, DateTime? startDate, string? masterName, string? masterSurName, string? masterThirdName, string? carBrand, long? masterId)
        {
            Id = id;
            WorkPrice = workPrice;
            StartDate = startDate;
            MasterName = masterName;
            MasterSurName = masterSurName;
            MasterThirdName = masterThirdName;
            CarBrand = carBrand;
            MasterId = masterId;
        }
    }
}
