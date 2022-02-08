using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Config.Models
{
    public class DataRow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string CodeAlt { get; set; }

        public string DefaultLanguageName { get; set; }
        public string StagesTitle { get; set; }
        public int RecordOrder { get; set; }

        [StringLength(4000)]
        public string Notes { get; set; }

        [StringLength(4000)]
        public string SurveyThankYouNote { get; set; }
        public bool? ShowSurveyScore { get; set; }

        public bool? IsPublic { get; set; }
        public bool? IsShared { get; set; }
        public bool? HasEmail { get; set; }
        public DateTime LastSend { get; set; }

        public bool? SendSurvyFrequency { get; set; }

        public bool? RUUnique { get; set; }
        public bool? IssueDateUnique { get; set; }
        public bool? ShowStakeholder { get; set; }

        //[Required]
        public Guid? AccountId { get; set; }

        public Guid? ParentId { get; set; }
        public DataRow Parent { get; set; }

        public bool? SendNotificationByEmail { get; set; }
        public bool? EnableScoring { get; set; }
        public int DefaultReportingFrequencyUnit { get; set; }
        public int DefaultReportingFrequencyReminder { get; set; }
        public int DefaultReportingReminderNumber { get; set; }
        public int CountFrequencyUnit { get; set; }

        public int DataSetType { get; set; }
        public int DataSetFrequency { get; set; }
        public string DataSetParent { get; set; }
        public int ReportingAccess { get; set; }
        public string FilterBy { get; set; }
        public bool? Enable_Run_Formula { get; set; }
        public bool? Enable_Portal_Site { get; set; }
        public bool? Enable_Subscription { get; set; }
        public bool? ForceRecordAddWithParent { get; set; }

        public int ActivityType { get; set; }
        public string ActivityParent { get; set; }
        public bool? AllowSendNotifications { get; set; }
        public int? TotalScore { get; set; }
        public Guid? SurveyScoreField { get; set; }

        #region Microsite Settings
        public string ColorCode { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTile { get; set; }
        public string HeaderTextColor { get; set; }
        public string RegistrationIntroduction { get; set; }
        public bool? Logo { get; set; }

        #endregion

        public ICollection<DataRow> DataRows { get; set; }
        public ICollection<DataRowField> DataRowFields { get; set; }
        public ICollection<DataReportingUnit> DataReportingUnits { get; set; }
    }
}