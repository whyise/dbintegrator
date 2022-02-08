using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Config.Models
{
    public class DataRowField
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Lablel { get; set; }

        [Required]
        [StringLength(500)]
        public string FieldName { get; set; }

        public bool IsCascaded { get; set; }
        public string RelatedFieldsValues { get; set; }
        public Guid? CascadeParentFieldId { get; set; }

        public int FieldType { get; set; }
        public int ActionsforDefultValue { get; set; }
        public int FieldMapValue { get; set; }
        public int FieldOrder { get; set; }
        public int ChartType { get; set; }

        public bool? IsIdentity { get; set; }
        public bool? IsConfidential { get; set; }
        public bool? ShowOnList { get; set; }
        public bool? Use_as_filter { get; set; }
        public bool? UseSearchParameter { get; set; }

        public bool? IsRequired { get; set; }

        public bool? ShowLastValue { get; set; }
        public bool? SavePreviousValue { get; set; }

        public Guid? RelatedField { get; set; }
        public string RelatedValue { get; set; }
        public string RangeField { get; set; }
        public string RangeField2 { get; set; }
        public int ComputedType { get; set; }
        public int RangeDateUnit { get; set; }

        public string Formula { get; set; }

        public int Function { get; set; }
        public string SummaryDataRowFieldId { get; set; }
        public string GroupBy { get; set; }
        public string FilterBy { get; set; }

        public bool? DisplayName { get; set; }
        public string DataRoWForiginKeyMap { get; set; }
        public Guid? DataRoWForiginKeyId { get; set; }
        public Guid? ActivityProfileDataset { get; set; }
        public int ActivityProfileKey { get; set; }
        public int KeyMap { get; set; }
        public bool? SendBySurvey { get; set; }

        [StringLength(4000)]
        public string Notes { get; set; }
        public string DefaultValue { get; set; }

        public Guid? ParentId { get; set; }
        public DataRowField Parent { get; set; }

        public int SectionOrder { get; set; }

        public int? SourceType { get; set; }

        public int? CalculationSummaryMethod { get; set; }

        public string AssingedReportingUnit { get; set; }

        [Required]
        public Guid DataRowId { get; set; }
        public DataRow DataRow { get; set; }

        public Guid? DataRowSectionId { get; set; }

        public bool KeepValueOnDuplicate { get; set; }
    }
}