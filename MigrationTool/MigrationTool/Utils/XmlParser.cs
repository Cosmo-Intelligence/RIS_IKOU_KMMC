using MigrationTool.Models;
using MigrationTool.Const;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MigrationTool.Settings;

namespace MigrationTool.Utils
{
	public static class XmlParser
	{
		public static XmlParseResult ExtractExamDatas(string xml, AppSettings settings)
		{
			//Logger.Log("XMLデータ加工 開始");

			var result = new XmlParseResult();
			string[] examDatas = result.ExamDatas;

			if (string.IsNullOrWhiteSpace(xml))
			{
				//Logger.Log("XMLデータ加工 終了 xmlなし");
				return result;
			}

			try
			{
				var rawCodes = new Dictionary<string, string[]>();
				var rawColumns = new Dictionary<string, string[]>();

				var mappings = settings.ExamKindMappings;

				foreach (var kv in mappings)
				{
					foreach (var pair in kv.Value.Mappings)
					{
						var doc = XDocument.Parse(xml);
						var groups = doc.Descendants(XmlKeys.ItemGroup).ToList();

						result.ItemGroupCount = groups.Count;

						foreach (var group in groups)
						{
							string code = group.Element(XmlKeys.OrderItemCode)?.Value;
							if (string.IsNullOrWhiteSpace(code) || !code.Equals(pair.TargetCode))
								continue;

							string value = group.Element(XmlKeys.OrderItemName)?.Value;
							if (string.IsNullOrWhiteSpace(value))
								continue;

							// ExamDataxx の xx を数値変換、examDatas[0～19] に格納
							if (int.TryParse(pair.TargetColumn.Substring(pair.TargetColumn.Length - 2, 2), out int targetIndex) &&
								targetIndex >= 1 && targetIndex <= 20)
							{
								examDatas[targetIndex - 1] = value;
							}
						}
					}
				}
			}
			catch(Exception e)
			{
				Logger.Log("XMLデータ加工 エラー終了");
				Logger.LogError(e);
				return result;
			}
			//Logger.Log("XMLデータ加工 正常終了");
			return result;
		}

		public static XmlParseResult ExtractRequestDatas(string xml, AppSettings settings)
		{
			Logger.Log("XMLデータ加工 開始");

			var result = new XmlParseResult();

			if (string.IsNullOrWhiteSpace(xml))
			{
				Logger.Log("XMLデータ加工 終了 xmlなし");
				return result;
			}

			try
			{
				var rawCodes = new Dictionary<string, string[]>();
				var rawColumns = new Dictionary<string, string[]>();

				var mappings = settings.ExamKindMappings;

				var doc = XDocument.Parse(xml);
				var reqValues = doc.Descendants(XmlKeys.ReqValue).ToList();

				result.ItemGroupCount = reqValues.Count;

				foreach (var val in reqValues)
				{
					string deptCode = val.Element(XmlKeys.DeptCode)?.Value;
					string reqDrCode = val.Element(XmlKeys.ReqDrCode)?.Value;
					string reqDrName = val.Element(XmlKeys.ReqDrName)?.Value;

					result.IraiSectionId = deptCode;
					result.IraiDoctorNo = reqDrCode;
					result.IraiDoctorName = reqDrName;
				}
			}
			catch (Exception e)
			{
				Logger.Log("XMLデータ加工 エラー終了");
				Logger.LogError(e);
				return result;
			}
			Logger.Log("XMLデータ加工 正常終了");
			return result;
		}
	}
}
