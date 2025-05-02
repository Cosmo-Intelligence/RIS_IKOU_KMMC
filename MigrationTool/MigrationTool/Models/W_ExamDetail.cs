using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	class W_ExamDetail
	{
		public string HospitalCode { get; set; }
		public string DocumentUniqueKey { get; set; }
		public string DocNo { get; set; }
		public string DocSeq { get; set; }
		public string ExamNo { get; set; }
		public string ExamDetailNo { get; set; }
		public string ActiveFlag { get; set; }
		public string DeleteFlag { get; set; }
		public string OrderNo { get; set; }
		public string ExamCategoryAttributeCode { get; set; }
		public string ExamCategoryCode { get; set; }
		public string ExamCategoryName { get; set; }
		public string ExamItemAttributeCode { get; set; }
		public string ExamItemCode { get; set; }
		public string ExamItemName { get; set; }
		public string BodyPositionLRAttributeCode { get; set; }
		public string BodyPositionLRItemCode { get; set; }
		public string BodyPositionLRDisplayName { get; set; }
		public string ExamIndicationGroup { get; set; }
		public string ExamBodyCommentGroup { get; set; }
		public string ExamDetailItemAttributeCode { get; set; }
		public string ExamDetailItemCode { get; set; }
		public string ExamDetailItemName { get; set; }
		public string FilmItemAttribute { get; set; }
		public string FilmTypeCode { get; set; }
		public string FilmItemName { get; set; }
		public string FilmQuantity { get; set; }
		public string UnitCode { get; set; }
		public string UnitName { get; set; }
		public string FilmDivideCount { get; set; }
		public string ExposureCount { get; set; }
		public string ExamConditionGroup { get; set; }
		public string ModalityCode { get; set; }
		public string ExamEndFlag { get; set; }
		public string ToolVariableInfo { get; set; }
		public string OpenArea { get; set; }
		public string FlagOpenArea { get; set; }
		public string UpdateHospitalCode { get; set; }
		public string UpdateUserID { get; set; }
		public string UpdateDateTimeSec { get; set; }
		public string RecordCreateTimeStamp { get; set; }
		public string RecordUpdateTimeStamp { get; set; }
	}
}
