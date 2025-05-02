using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	class OrderMainTable
	{
		public string RisId { get; set; }
		public string SystemKbn { get; set; }
		public string StudyInstanceUid { get; set; }
		public string OrderNo { get; set; }
		public string AccessionNo { get; set; }
		public int KensaDate { get; set; }
		public int KensaStartTime { get; set; }
		public string KensaTypeId { get; set; }
		public string KensaSituId { get; set; }
		public string KensaKikiId { get; set; }
		public string SyotiSituFld { get; set; }
		public string KanjaId { get; set; }
		public int KensaDateAge { get; set; }
		public string DenpyoNyugaikbn { get; set; }
		public string DenpyoByoutouId { get; set; }
		public string DenpyoByosituId { get; set; }
		public string IraiSectionId { get; set; }
		public string IraiDoctorName { get; set; }
		public string IraiDoctorNo { get; set; }
		public string OrderSectionId { get; set; }
		public string IraiDoctorRenraku { get; set; }
		public string DokueiFlg { get; set; }
	}
}
