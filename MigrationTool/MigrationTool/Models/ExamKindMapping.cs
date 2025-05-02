using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Models
{
	public class ExamKindMapping
	{
		public List<ExamMappingPair> Mappings { get; set; } = new List<ExamMappingPair>();
		public List<string> TargetCodes { get; set; } = new List<string>();
		public List<string> TargetColumns { get; set; } = new List<string>();
	}
}
