namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adult")]
    public partial class Adult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuestId { get; set; }

        [Required]
        [StringLength(10)]
        public string PassportNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string PassportInfo { get; set; }

        public virtual Guest Guest { get; set; }
    }
}
