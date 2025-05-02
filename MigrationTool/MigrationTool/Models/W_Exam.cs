using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	class W_Exam
	{
		public string HospitalCode { get; set; }
		public string PatientID { get; set; }
		public string DocumentUniqueKey { get; set; }
		public string DocNo { get; set; }
		public string DocSeq { get; set; }
		public string PDocNo { get; set; }
		public string ActiveFlag { get; set; }
		public string DeleteFlag { get; set; }
		public string MigrationDiv { get; set; }
		public string OrderNo { get; set; }
		public string DocTypeCategoryCode { get; set; }
		public string ReservationDateTimeSec { get; set; }
		public string DocDateTimeSec { get; set; }
		public string DocEndDateTimeSec { get; set; }
		public string ImageExamRoomCode { get; set; }
		public string ImageExamRoomName { get; set; }
		public string FixedCommentGroup { get; set; }
		public string OperateUserGroup { get; set; }
		public string AccessionNo { get; set; }
		public string PatientNameAlike { get; set; }
		public string ToolVariableInfo { get; set; }
		public string RecordCreateTimeStamp { get; set; }
		public string RecordUpdateTimeStamp { get; set; }
	}
}
