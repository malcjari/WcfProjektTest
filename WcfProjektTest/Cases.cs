namespace WcfProjektTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cases
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(60)]
        public string lat { get; set; }

        [Required]
        [StringLength(60)]
        public string lng { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public bool isActive { get; set; }

        [StringLength(20)]
        public string contact_phone { get; set; }

        [StringLength(50)]
        public string contact_email { get; set; }

        public int category { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
