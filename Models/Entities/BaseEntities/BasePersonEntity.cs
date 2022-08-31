using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities.BaseEntities
{
    /// <summary>
    /// Базовая сущность человека
    /// </summary>
    public class BasePersonEntity : BaseEntity
    {
        /// <summary>
        /// Имя 
        /// </summary>
        [Column("NAME")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия 
        /// </summary>
        [Column("SURNAME")]
        public string SurName { get; set; }

        /// <summary>
        /// Отчество 
        /// </summary>
        [Column("THIRDNAME")]
        public string? ThirdName { get; set; }

        /// <summary>
        /// Телефон 
        /// </summary>
        [Column("PHONE_NUMBER")]
        public string? PhoneNumber { get; set; }
    }
}
