namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Guest")]
    public partial class Guest
    {
        public int GuestID { get; set; }

        public int AccountID { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string GuestName { get; set; }

        [Required]
        [StringLength(30)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public virtual Account Account { get; set; }
    }
}
