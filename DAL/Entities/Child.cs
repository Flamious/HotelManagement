namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Child")]
    public partial class Child
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuestId { get; set; }

        [Required]
        [StringLength(6)]
        public string BirthCertificate { get; set; }

        public virtual Guest Guest { get; set; }
    }
}
