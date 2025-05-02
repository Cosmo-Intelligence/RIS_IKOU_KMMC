using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	class ExSatueiTable
	{
		public string RisId { get; set; }
		public int BuiNo { get; set; }
		public int No { get; set; }
		public string SatueiStatus { get; set; }
		public string SatueiMenuId { get; set; }
		public string SatueiMenuName { get; set; }
		public string SatueiMenuNameKana { get; set; }
		public string SatueiCode { get; set; }
		public string FilmId { get; set; }
		public int Partition { get; set; }
		public int Used { get; set; }
		public string ReshotFlg { get; set; }

		private string[] _examDatas = new string[20];

		public string[] ExamDatas {
			get => _examDatas;
			set
			{
				// 基本的にサイズは固定で
				for (int i = 0; i < 20; i++)
				{
					_examDatas[i] = value[i];
				}
			}
		}
		public string ExamData01 { get => _examDatas[0]; set => _examDatas[0] = value; }
		public string ExamData02 { get => _examDatas[1]; set => _examDatas[1] = value; }
		public string ExamData03 { get => _examDatas[2]; set => _examDatas[2] = value; }
		public string ExamData04 { get => _examDatas[3]; set => _examDatas[3] = value; }
		public string ExamData05 { get => _examDatas[4]; set => _examDatas[4] = value; }
		public string ExamData06 { get => _examDatas[5]; set => _examDatas[5] = value; }
		public string ExamData07 { get => _examDatas[6]; set => _examDatas[6] = value; }
		public string ExamData08 { get => _examDatas[7]; set => _examDatas[7] = value; }
		public string ExamData09 { get => _examDatas[8]; set => _examDatas[8] = value; }
		public string ExamData10 { get => _examDatas[9]; set => _examDatas[9] = value; }
		public string ExamData11 { get => _examDatas[10]; set => _examDatas[10] = value; }
		public string ExamData12 { get => _examDatas[11]; set => _examDatas[11] = value; }
		public string ExamData13 { get => _examDatas[12]; set => _examDatas[12] = value; }
		public string ExamData14 { get => _examDatas[13]; set => _examDatas[13] = value; }
		public string ExamData15 { get => _examDatas[14]; set => _examDatas[14] = value; }
		public string ExamData16 { get => _examDatas[15]; set => _examDatas[15] = value; }
		public string ExamData17 { get => _examDatas[16]; set => _examDatas[16] = value; }
		public string ExamData18 { get => _examDatas[17]; set => _examDatas[17] = value; }
		public string ExamData19 { get => _examDatas[18]; set => _examDatas[18] = value; }
		public string ExamData20 { get => _examDatas[19]; set => _examDatas[19] = value; }

		public string KensakikiId { get; set; }
		public string CassetteNo { get; set; }
		public string PortableStatus { get; set; }
		public string Kvp { get; set; }
		public string Ua { get; set; }
		public string Msec { get; set; }
		public string Ma { get; set; }
		public string Sec { get; set; }
		public string Mas { get; set; }
		public string MppsInstanceUid { get; set; }
		public int MppsVmNo { get; set; }
		public string MppsSatueiCode { get; set; }
		public string MppsAeTitle { get; set; }
		public string XrayTubeCurrentMa { get; set; }
		public string ExposureTimeSec { get; set; }
		public string ExposureTimeMin { get; set; }
		public string Kv { get; set; }
		public string ExposureNo { get; set; }
		public string Ctdi { get; set; }
		public string Dlp { get; set; }
		public string Fluoroscopy { get; set; }
		public string ImageArea { get; set; }
		public string DDistanceMm { get; set; }
		public string DDistanceCm { get; set; }
		public string EDistanceMm { get; set; }
		public string EntranceDoseDgy { get; set; }
		public string EntranceDoseMgy { get; set; }
		public string ExposedArea { get; set; }
		public string RadiationMode { get; set; }
	}
}
