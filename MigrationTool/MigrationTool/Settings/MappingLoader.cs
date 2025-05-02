using MigrationTool.Const;
using MigrationTool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Settings
{
	public static class MappingLoader
	{
		public static Dictionary<string, ExamKindMapping> LoadFromAppSettings()
		{
			var result = new Dictionary<string, ExamKindMapping>();

			var rawCodes = new Dictionary<string, string[]>();
			var rawColumns = new Dictionary<string, string[]>();

			foreach (var key in ConfigurationManager.AppSettings.AllKeys)
			{
				// xml関連の設定以外は飛ばす
				if (!key.StartsWith(AppConst.ExamKind)) continue;

				var parts = key.Split('_');
				if (parts.Length != 3) throw new Exception($"{key}のKey名が不正です。");

				string type = parts[1]; // SHOTDETAILID or SHOTTARGETCOLUMN
				string id = parts[2];   // FJ1とか

				// 空白を除去
				var values = ConfigurationManager.AppSettings[key].Split(',').Select(x => x.Trim()).ToArray();

				if (type == AppConst.ShotDetailId)
					rawCodes[id] = values;
				else if (type == AppConst.ShotTargetColumn)
					rawColumns[id] = values;
				else
					throw new Exception($"{key}のKey名が不正です。");
			}

			// 項目数不一致でもエラー
			if(rawCodes.Count != rawColumns.Count) throw new Exception($"{AppConst.ShotTargetCodeKey}XXXと{AppConst.ShotTargetColumnKey}XXXの項目数が一致しません。");

			// 登録したKeyが一致しているもののみに絞る
			foreach (var id in rawCodes.Keys.Intersect(rawColumns.Keys))
			{
				var codeArray = rawCodes[id];
				var columnArray = rawColumns[id];
				var mapping = new ExamKindMapping();

				// indexエラー対策、これやらずにエラー起こしてもいいかも
				int count = Math.Min(codeArray.Length, columnArray.Length);
				for (int i = 0; i < count; i++)
				{
					mapping.Mappings.Add(new ExamMappingPair
					{
						TargetCode = codeArray[i],
						TargetColumn = columnArray[i]
					});
				}
				result[id] = mapping;
			}

			return result;
		}
	}
}
