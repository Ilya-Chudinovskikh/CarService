using CarService.Db;
using CarService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CarService.Models.DTOs;

namespace CarService.Repositories
{
    public class CarServiceRepositories : ICarServiceRepositories
    {
        private readonly CarServiceContext _context;
        public CarServiceRepositories(CarServiceContext context)
        {
            _context = context;
        }

        public List<InfoDto> GetInfo(int month)
        {
            var info = _context.RepairServices
                .Where(rs => rs.StartDate.Month == month && rs.CompletionDate == null)
                .Include(rs=>rs.Car)
                .Include(rs => rs.Master)
                .OrderBy(o => o.StartDate)
                .AsEnumerable()
                .Select(rs => new InfoDto(
                    rs.CarId,
                    rs.WorkPrice,
                    rs.StartDate,
                    rs.Master.Name,
                    rs.Master.SurName,
                    rs.Master.ThirdName,
                    rs.Car.Brand,
                    rs.MasterId));

            return info.ToList();
        }
        public Dictionary<long, double> GetMasterWorkloadByMonth(int month, List<long> masterIds)
        {
            var repairsInMonth = _context.RepairServices
                .Where(rs => rs.StartDate.Month <= month && (rs.CompletionDate == null || ((DateTime)rs.CompletionDate).Month >= month))
                .AsEnumerable()
                .GroupBy(rs => rs.MasterId)
                .Select(g=>new { MasterId = g.Key, Workload = g.Sum(rs => CountDays(rs.StartDate, rs.CompletionDate, month)) });

            var workloads = new Dictionary<long, double>();

            foreach (var masterId in masterIds.Distinct())
            {
                var mostWorkload = (double)repairsInMonth.Max(mw => mw.Workload);
                var masterWorkload = (double)repairsInMonth.SingleOrDefault(mw => mw.MasterId == masterId).Workload;

                workloads.Add(masterId, masterWorkload / mostWorkload);
            }

            return workloads;
        }
        private static int CountDays(DateTime startDate, DateTime? completionDate, int month)
        {
            var startDay = startDate.Day;
            var completionDay = DateTime.DaysInMonth(startDate.Year, month);

            if (startDate.Month < month)
                startDay = 0;

            if (completionDate != null && (((DateTime)completionDate).Month == month))
                completionDay = ((DateTime)completionDate).Day;

            return completionDay - startDay;
        }
    }
}
