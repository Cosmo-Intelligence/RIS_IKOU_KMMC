using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	class W_Order
	{
		public string HospitalCode { get; set; }
		public string DocumentUniqueKey { get; set; }
		public string OrderDetailUniqueKey { get; set; }
		public string OrderDetailDisplayOrder { get; set; }
		public string PatientID { get; set; }
		public string DocNo { get; set; }
		public string DocSeq { get; set; }
		public string DocPattern { get; set; }
		public string DocTypeCode { get; set; }
		public string ActiveFlag { get; set; }
		public string DeleteFlag { get; set; }
		public string OrderNo { get; set; }
		public string OrderItemCode { get; set; }
		public string OrderItemAttributeCode { get; set; }
		public string OrderItemName { get; set; }
		public string ToolStaticInfo2 { get; set; }
		public string TagName { get; set; }
		public string ToolVariableInfo { get; set; }
		public string RecordCreateTimeStamp { get; set; }
		public string RecordUpdateTimeStamp { get; set; }
	}
}
