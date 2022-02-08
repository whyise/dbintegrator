using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Config.Models
{
    public class Organisation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }
        public Organisation Parent { get; set; }

        [Required]
        public string Code { get; set; }
        public string CodeAlt { get; set; }

        public int RecordOrder { get; set; }

        [Required]
        public string Name { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Image { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        [StringLength(400)]
        public string Note { get; set; }

        public bool IsActive { get; set; }

        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public string Value8 { get; set; }
        public string Value9 { get; set; }
        public string Value10 { get; set; }

        public string Value11 { get; set; }
        public string Value12 { get; set; }
        public string Value13 { get; set; }
        public string Value14 { get; set; }
        public string Value15 { get; set; }
        public string Value16 { get; set; }
        public string Value17 { get; set; }
        public string Value18 { get; set; }
        public string Value19 { get; set; }
        public string Value20 { get; set; }

        public ICollection<Organisation> Children { get; set; }
    }
}