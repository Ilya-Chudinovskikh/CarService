using CarService.Models.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    /// <summary>
    /// Сущность ремонта автомобиля
    /// </summary>
    [Table("REPAIR_SERVICES")]
    public class RepairServiceEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор автомобиля
        /// </summary>
        [Column("ID_CAR")]
        public long CarId { get; set; }

        /// <summary>
        /// Автомобиль
        /// </summary>
        [ForeignKey(nameof(CarId))]
        public virtual CarEntity Car { get; set; }

        /// <summary>
        /// Идентификатор мастера
        /// </summary>
        [Column("ID_MASTER")]
        public long MasterId { get; set; }

        /// <summary>
        /// Мастер
        /// </summary>
        [ForeignKey(nameof(MasterId))]
        public virtual MasterEntity? Master { get; set; }

        /// <summary>
        /// Неисправность авто
        /// </summary>
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        /// <summary>
        /// Стоимость работ
        /// </summary>
        [Column("WORK_PRICE")]
        public decimal? WorkPrice { get; set; }

        /// <summary>
        /// Начало работ
        /// </summary>
        [Column("START_DATE")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Окончание работ
        /// </summary>
        [Column("COMPLETION_DATE")]
        public DateTime? CompletionDate { get; set; }
    }
}
