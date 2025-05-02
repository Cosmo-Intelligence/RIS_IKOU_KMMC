using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	public class XmlParseResult
	{
		public string[] ExamDatas { get; set; } = new string[20];
		public int ItemGroupCount { get; set; }
	}
}
