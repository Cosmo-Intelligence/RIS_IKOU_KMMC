using MigrationTool.Const;
using MigrationTool.Models;
using MigrationTool.Settings;
using MigrationTool.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Services
{
	class OracleDbAccessor
	{
		private readonly string connectionString_ikou;
		private readonly string connectionString_ris;

		public OracleDbAccessor(AppSettings settings)
		{
			connectionString_ikou = settings.ConnectionStringIkou;
			connectionString_ris = settings.ConnectionStringRis;
		}

		private void LogSQL(OracleCommand cmd)
		{
			Logger.Log($"SQL: {cmd.CommandText}");
			foreach (OracleParameter p in cmd.Parameters)
			{
				if (p.Value == null || p.Value == DBNull.Value)
					continue;

				var name = p.ParameterName;
				string value;
				if (p.Value is Array arr)
				{
					int i = 0;
					foreach (var item in arr)
					{
						value = item?.ToString() ?? "NULL";
						Logger.Log($"{name}[{i}] : {value}");
						i++;
					}
				}
				else
				{
					switch (p.Value)
					{
						case DateTime dt:
							value = dt.ToString("yyyy/MM/dd HH:mm:ss");
							break;
						case string s:
							value = s;
							break;
						default:
							value = p.Value.ToString();
							break;
					}
					Logger.Log($"{name} : {value}");
				}
			}
		}

		public List<W_ExamDetail> GetShotConditionMigrationData(DateTime from, DateTime to)
		{
			Logger.Log("移行データ取得 開始");
			List<W_ExamDetail> orderList = new List<W_ExamDetail>();

			try
			{
				string sql = $@"
				SELECT 
					{WExamDetailColumns.OrderNo},
					{WExamDetailColumns.ExamConditionGroup}
				FROM 
					W_ExamDetail
				WHERE 
					{WExamDetailColumns.ActiveFlag} = '1'
				AND 
					{WExamDetailColumns.ExamConditionGroup} IS NOT NULL
				AND
					REGEXP_LIKE({WExamDetailColumns.ExamConditionGroup}, '[^[:space:]]')
				AND
					INSTR({WExamDetailColumns.ExamConditionGroup}, '{XmlKeys.ItemGroup}') > 0
				AND
					TO_DATE({WExamDetailColumns.RecordCreateTimeStamp}, 'YYYY-MM-DD HH24:MI:SS') 
						BETWEEN :targetFrom AND :targetTo
				ORDER BY 
					{WExamDetailColumns.OrderNo} asc,
					{WExamDetailColumns.ExamNo} asc,
					{WExamDetailColumns.ExamDetailNo} asc
				";

				using (var conn = new OracleConnection(connectionString_ikou))
				using (var cmd = new OracleCommand(sql, conn))
				{
					cmd.Parameters.Add("targetFrom", OracleDbType.Date).Value = from;
					cmd.Parameters.Add("targetTo", OracleDbType.Date).Value = to;

					// SQLをログに出す
					LogSQL(cmd);

					conn.Open();

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var examDetail = new W_ExamDetail
							{
								OrderNo = reader[WExamDetailColumns.OrderNo].ToString(),
								ExamConditionGroup = reader[WExamDetailColumns.ExamConditionGroup].ToString()
							};
							orderList.Add(examDetail);
						}
					}
				}
				Logger.Log("移行データ取得 正常終了");
				return orderList;
			}
			catch (Exception e)
			{
				Logger.Log("移行データ取得 エラー終了");
				Logger.LogError(e);
				return orderList;
			}
		}

		public List<W_Exam> GetRequestDepartmentMigrationData(DateTime from, DateTime to)
		{
			Logger.Log("移行データ取得 開始");
			List<W_Exam> examList = new List<W_Exam>();

			try
			{
				string sql = $@"
				SELECT 
					{WExamColumns.OrderNo},
					{WExamColumns.ToolVariableInfo}
				FROM 
					W_ExamDetail
				WHERE 
					{WExamColumns.ActiveFlag} = '1'
				AND 
					{WExamColumns.ToolVariableInfo} IS NOT NULL
				AND
					REGEXP_LIKE({WExamColumns.ToolVariableInfo}, '[^[:space:]]')
				AND
					INSTR({WExamColumns.ToolVariableInfo}, '{XmlKeys.ReqValue}') > 0
				AND
					TO_DATE({WExamColumns.RecordCreateTimeStamp}, 'YYYY-MM-DD HH24:MI:SS') BETWEEN :targetFrom AND :targetTo
				";

				using (var conn = new OracleConnection(connectionString_ikou))
				using (var cmd = new OracleCommand(sql, conn))
				{
					cmd.Parameters.Add("targetFrom", OracleDbType.Date).Value = from;
					cmd.Parameters.Add("targetTo", OracleDbType.Date).Value = to;

					// SQLをログに出す
					LogSQL(cmd);

					conn.Open();

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var exam = new W_Exam
							{
								OrderNo = reader[WExamDetailColumns.OrderNo].ToString(),
								ToolVariableInfo = reader[WExamDetailColumns.ExamConditionGroup].ToString()
							};
							examList.Add(exam);
						}
					}
				}
				Logger.Log("移行データ取得 正常終了");
				return examList;
			}
			catch (Exception e)
			{
				Logger.Log("移行データ取得 エラー終了");
				Logger.LogError(e);
				return examList;
			}
		}

		public int InsertExSatueiTable(List<ExSatueiTable> satueiList)
		{
			Logger.Log("Insert処理 開始");

			if (satueiList == null || satueiList.Count == 0)
			{
				Logger.Log("Insert処理 終了 対象なし");
				return 0;
			}

			try
			{
				string sql = $@"
					INSERT INTO EXSATUEITABLE(
						{ExSatueiTableColumns.RisId},
						{ExSatueiTableColumns.BuiNo},
						{ExSatueiTableColumns.No},
						{ExSatueiTableColumns.SatueiStatus},
						{ExSatueiTableColumns.ExamData01},
						{ExSatueiTableColumns.ExamData02},
						{ExSatueiTableColumns.ExamData03},
						{ExSatueiTableColumns.ExamData04},
						{ExSatueiTableColumns.ExamData05},
						{ExSatueiTableColumns.ExamData06},
						{ExSatueiTableColumns.ExamData07},
						{ExSatueiTableColumns.ExamData08},
						{ExSatueiTableColumns.ExamData09},
						{ExSatueiTableColumns.ExamData10},
						{ExSatueiTableColumns.ExamData11},
						{ExSatueiTableColumns.ExamData12},
						{ExSatueiTableColumns.ExamData13},
						{ExSatueiTableColumns.ExamData14},
						{ExSatueiTableColumns.ExamData15},
						{ExSatueiTableColumns.ExamData16},
						{ExSatueiTableColumns.ExamData17},
						{ExSatueiTableColumns.ExamData18},
						{ExSatueiTableColumns.ExamData19},
						{ExSatueiTableColumns.ExamData20}
					) VALUES (
						:ris_id, :bui_no, :no, :satuei_status,
						:1, :2, :3, :4, :5, :6, :7, :8, :9, :10,
						:11, :12, :13, :14, :15, :16, :17, :18, :19, :20
					)
				";
				using (var conn = new OracleConnection(connectionString_ris))
				using (var cmd = new OracleCommand(sql, conn))
				{
					cmd.ArrayBindCount = satueiList.Count;

					cmd.Parameters.Add("ris_id", OracleDbType.Varchar2, satueiList.Select(x => x.RisId).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("bui_no", OracleDbType.Int16, satueiList.Select(x => x.BuiNo).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("no", OracleDbType.Int16, satueiList.Select(x => x.No).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("satuei_status", OracleDbType.Int16, satueiList.Select(x => x.SatueiStatus).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("1", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData01).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("2", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData02).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("3", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData03).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("4", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData04).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("5", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData05).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("6", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData06).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("7", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData07).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("8", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData08).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("9", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData09).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("10", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData10).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("11", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData11).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("12", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData12).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("13", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData13).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("14", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData14).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("15", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData15).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("16", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData16).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("17", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData17).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("18", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData18).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("19", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData19).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("20", OracleDbType.Varchar2, satueiList.Select(x => x.ExamData20).ToArray(), ParameterDirection.Input);

					// SQLをログに出す
					LogSQL(cmd);

					conn.Open();

					int ret = cmd.ExecuteNonQuery();

					Logger.Log("Insert処理 正常終了");
					return ret;
				}
			}
			catch (Exception e)
			{
				Logger.Log("Insert処理 エラー終了");
				Logger.LogError(e);
				return -1;
			}
		}

		public int UpdateOrderMainTable(List<OrderMainTable> orderList)
		{
			Logger.Log("Update処理 開始");

			if (orderList == null || orderList.Count == 0)
			{
				Logger.Log("Update処理 終了 対象なし");
				return 0;
			}

			try
			{
				string sql = $@"
					UPDATE EXSATUEITABLE SET
						{OrderMainTableColumns.IraiSectionId}   = :irai_section_id,
						{OrderMainTableColumns.IraiDoctorName}  = :irai_doctor_name,
						{OrderMainTableColumns.IraiDoctorNo}    = :irai_doctor_no
					WHERE
						{OrderMainTableColumns.OrderNo} = :order_no
				";

				using (var conn = new OracleConnection(connectionString_ris))
				using (var cmd = new OracleCommand(sql, conn))
				{
					cmd.ArrayBindCount = orderList.Count;

					cmd.Parameters.Add("order_no", OracleDbType.Varchar2, orderList.Select(x => x.OrderNo).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("irai_section_id", OracleDbType.Varchar2, orderList.Select(x => x.IraiSectionId).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("irai_doctor_name", OracleDbType.Varchar2, orderList.Select(x => x.IraiDoctorName).ToArray(), ParameterDirection.Input);
					cmd.Parameters.Add("irai_doctor_no", OracleDbType.Varchar2, orderList.Select(x => x.IraiDoctorNo).ToArray(), ParameterDirection.Input);

					// SQLをログに出す
					LogSQL(cmd);

					conn.Open();

					int ret = cmd.ExecuteNonQuery();

					Logger.Log("Update処理 正常終了");
					return ret;
				}
			}
			catch (Exception e)
			{
				Logger.Log("Update処理 エラー終了");
				Logger.LogError(e);
				return -1;
			}
		}
	}
}
