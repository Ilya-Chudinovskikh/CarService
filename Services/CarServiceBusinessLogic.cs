using CarService.Models.DTOs;
using CarService.Repositories;
using Microsoft.AspNetCore.Mvc;
using NPOI.XSSF.UserModel;

namespace CarService.Services
{
    public class CarServiceBusinessLogic : ICarServiceBusinessLogic
    {
        private readonly ICarServiceRepositories _repositories;
        public CarServiceBusinessLogic(ICarServiceRepositories repositories)
        {
            _repositories = repositories;
        }
        public async Task<Stream> GetInfo(int month)
        {
            var info = _repositories.GetInfo(month);
            var masterIds = info.Select(dto => (long)dto.MasterId).ToList();

            var workloads = _repositories.GetMasterWorkloadByMonth(month, masterIds);

            var file = await GenerateExcel(info, workloads);

            return file;
        }
        private async static Task<Stream> GenerateExcel(List<InfoDto> info, Dictionary<long, double> workloads)
        {
            var fileName = @"report.xlsx";
            var memoryStream = new MemoryStream();

            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    var workbook = new XSSFWorkbook();
                    var excelSheet = workbook.CreateSheet("Info");
                    var row = excelSheet.CreateRow(0);

                    for (int i = 0; i < 8; i++)
                    {
                        row.CreateCell(0).SetCellValue("Id");
                        row.CreateCell(1).SetCellValue("WorkPrice");
                        row.CreateCell(2).SetCellValue("StartDate");
                        row.CreateCell(3).SetCellValue("MasterName");
                        row.CreateCell(4).SetCellValue("MasterSurName");
                        row.CreateCell(5).SetCellValue("MasterThirdName");
                        row.CreateCell(6).SetCellValue("CarBrand");
                        row.CreateCell(7).SetCellValue("Workload");
                    }

                    for (int i = 0; i < info.Count; i++)
                    {
                        row = excelSheet.CreateRow(i + 1);

                        row.CreateCell(0).SetCellValue(info[i].Id);
                        row.CreateCell(1).SetCellValue(info[i].WorkPrice.ToString());
                        row.CreateCell(2).SetCellValue(info[i].StartDate.ToString());
                        row.CreateCell(3).SetCellValue(info[i].MasterName);
                        row.CreateCell(4).SetCellValue(info[i].MasterSurName);
                        row.CreateCell(5).SetCellValue(info[i].MasterThirdName);
                        row.CreateCell(6).SetCellValue(info[i].CarBrand);
                        row.CreateCell(7).SetCellValue(workloads[(long)info[i].MasterId]);
                    }

                    workbook.Write(fs);
                }
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0;

                return memoryStream;
            }

            catch
            {
                throw new Exception("Something went wrong during Excel generation :(");
            }
        }
    }
}
