using CarService.Models.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    /// <summary>
    /// Сущность владельца автомобиля
    /// </summary>
    [Table("CAR_OWNERS")]
    public class CarOwnerEntity : BasePersonEntity
    {
        /// <summary>
        /// Адрес владельца автомобиля
        /// </summary>
        [Column("ADDRESS")]
        public string? Address { get; set; }

        /// <summary>
        /// Серия паспорта владельца автомобиля
        /// </summary>
        [Column("PASSPORT_SERIES")]
        public string? PassportSeries { get; set; }

        /// <summary>
        /// Номер паспорта владельца автомобиля
        /// </summary>
        [Column("PASSPORT_NUMBER")]
        public string? PassportNumber { get; set; }
    }
}
