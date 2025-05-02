using MigrationTool.Const;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Utils
{
	public static class Logger
	{
		private static readonly object _lock = new object();
		private static string _logDir;
		private static string _logName;

		private static string logFilePath => Path.Combine(_logDir, _logName);

		public static void Configure(string dir, string name)
		{
			_logDir = dir;
			_logName = $"{name}_{DateTime.Now.ToString("yyyyMMdd")}.log";

			// ディレクトリがなければ作成
			if (!Directory.Exists(_logDir))
				Directory.CreateDirectory(_logDir);
		}

		public static void Log(string message)
		{
			try
			{
				lock (_lock)
				{
					using (var writer = new StreamWriter(logFilePath, append: true))
					{
						writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
					}
				}
			}
			catch (Exception e)
			{
				// とりあえず
				Console.WriteLine($"[Logger Error] {e.Message}");
			}
		}

		public static void LogError(Exception ex)
		{
			Log($"[ERROR] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
		}
	}
}
