using CarService.Models.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    /// <summary>
    /// Сущность мастера
    /// </summary>
    [Table("MASTERS")]
    public class MasterEntity : BasePersonEntity
    {
        /// <summary>
        /// Стаж мастера в годах
        /// </summary>
        [Column("WORK_EXPERIENCE")]
        public int WorkExperience { get; set; }
    }
}
