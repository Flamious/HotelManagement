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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guest()
        {
            CheckInGuest = new HashSet<CheckInGuest>();
        }

        public int GuestId { get; set; }

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

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string GuestDocument { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckInGuest> CheckInGuest { get; set; }
    }
}
