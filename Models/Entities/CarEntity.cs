using CarService.Models.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    /// <summary>
    /// Сущность автомобиля
    /// </summary>
    [Table("CARS")]
    public class CarEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор владельца автомобиля
        /// </summary>
        [Column("ID_OWNER")]
        public long OwnerId { get; set; }

        /// <summary>
        /// Владелец автомобиля
        /// </summary>
        [ForeignKey(nameof(OwnerId))]
        public virtual CarOwnerEntity Owner { get; set; }

        /// <summary>
        /// Марка автомобиля
        /// </summary>
        [Column("BRAND")]
        public string Brand { get; set; }

        /// <summary>
        /// Модель автомобиля
        /// </summary>
        [Column("MODEL")]
        public string Model { get; set; }

        /// <summary>
        /// Гос. номер
        /// </summary>
        [Column("STATE_NUMBER")]
        public string StateNumber { get; set; }

        /// <summary>
        /// Пробег
        /// </summary>
        [Column("MILEAGE")]
        public int? Mileage { get; set; }

        /// <summary>
        /// Объём двигателя
        /// </summary>
        [Column("EMGINE_VOLUME")]
        public float? EngineVolume { get; set; }
    }
}
