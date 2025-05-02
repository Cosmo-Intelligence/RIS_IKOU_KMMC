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
	public class AppSettings
	{
		public string ConnectionStringIkou { get; }
		public string ConnectionStringRis { get; }
		public string LogFileName { get; }
		public string LogDirectory { get; }
		public Dictionary<string, ExamKindMapping> ExamKindMappings { get; }

		public AppSettings()
		{
			ConnectionStringIkou = ConfigurationManager.ConnectionStrings[AppConst.ConnectionNameIkou]?.ConnectionString
			?? throw new Exception($"{AppConst.ConnectionNameIkou} が未定義です");

			ConnectionStringRis = ConfigurationManager.ConnectionStrings[AppConst.ConnectionNameRis]?.ConnectionString
			?? throw new Exception($"{AppConst.ConnectionNameRis} が未定義です");

			LogFileName = ConfigurationManager.AppSettings[AppConst.LogFileNameKey] ?? "migration.log";

			LogDirectory = ConfigurationManager.AppSettings[AppConst.LogDirectoryKey] ?? @"C:\Logs\Migration";

			ExamKindMappings = MappingLoader.LoadFromAppSettings();
		}
	}
}
