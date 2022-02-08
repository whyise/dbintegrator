using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Config.Models
{
    public class DataReportingUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }

        [Required]
        public Guid DataRowId { get; set; }
        public DataRow DataRow { get; set; }
    }
}