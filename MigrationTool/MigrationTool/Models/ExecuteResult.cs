using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	public class ExecuteResult
	{
		public int RecordCount { get; set; }
		public int InsertedCount { get; set; }
		public bool Result => InsertedCount > 0 && RecordCount == InsertedCount;
	}
}
