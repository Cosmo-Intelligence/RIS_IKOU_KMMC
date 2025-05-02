using MigrationTool.Models;
using MigrationTool.Settings;
using MigrationTool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Services
{
	class MigrationService
	{
		private readonly OracleDbAccessor _db;
		private readonly Form1 _form;
		private readonly AppSettings _settings;

		public MigrationService(Form1 form, AppSettings settings)
		{
			_db = new OracleDbAccessor(settings);
			_form = form;
			_settings = settings;
		}

		public ExecuteResult MigrateShotCondition(DateTime from, DateTime to)
		{
			ExecuteResult result = new ExecuteResult();
			try
			{
				// データ取得
				List<W_ExamDetail> examDetailList = _db.GetShotConditionMigrationData(from, to);
				result.RecordCount = examDetailList.Count;

				// 移行件数表示
				_form.ShowRecordCount(result.RecordCount);

				List<ExSatueiTable> satueiList = new List<ExSatueiTable>();
				string lastOrderNo = "";
				int no = 0;
				foreach (W_ExamDetail examDetail in examDetailList)
				{
					// PK違反対策
					if (lastOrderNo != examDetail.OrderNo)
						no = 0;

					no++;
					lastOrderNo = examDetail.OrderNo;

					// データ加工
					var results = XmlParser.ExtractExamDatas(examDetail.ExamConditionGroup, _settings);

					satueiList.Add(new ExSatueiTable
					{
						RisId = "IKOU" + examDetail.OrderNo,
						BuiNo = 1,
						No = no,
						SatueiStatus = "1",
						ExamDatas = results.ExamDatas
					});
				}

				// 長期処理が予想されるため偽の進捗バーを出す
				_form.SetFakeProgressVisible(true);

				result.InsertedCount = _db.InsertExSatueiTable(satueiList);

				// Insert処理が終わったら進捗バーを隠す
				_form.SetFakeProgressVisible(false);

				return result;
			}
			catch (Exception e)
			{
				Logger.LogError(e);

				return result;
			}
		}

		public ExecuteResult MigrateRequestDepartment(DateTime from, DateTime to)
		{
			ExecuteResult result = new ExecuteResult();
			try
			{
				// データ取得
				List<W_Exam> examList = _db.GetRequestDepartmentMigrationData(from, to);
				result.RecordCount = examList.Count;

				// 移行件数表示
				_form.ShowRecordCount(result.RecordCount);

				List<OrderMainTable> orderMainList = new List<OrderMainTable>();
				foreach (W_Exam order in examList)
				{
					// データ加工
					var results = XmlParser.ExtractRequestDatas(order.ToolVariableInfo, _settings);

					orderMainList.Add(new OrderMainTable
					{
						OrderNo = order.OrderNo,
						IraiSectionId = results.IraiSectionId,
						IraiDoctorName = results.IraiDoctorName,
						IraiDoctorNo = results.IraiDoctorNo
					});
				}

				// 長期処理が予想されるため偽の進捗バーを出す
				_form.SetFakeProgressVisible(true);

				result.InsertedCount = _db.UpdateOrderMainTable(orderMainList);

				// Insert処理が終わったら進捗バーを隠す
				_form.SetFakeProgressVisible(false);

				return result;
			}
			catch (Exception e)
			{
				Logger.LogError(e);

				return result;
			}
		}
	}
}
