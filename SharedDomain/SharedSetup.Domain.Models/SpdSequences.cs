using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_SEQUENCES")]
	public class SpdSequences : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[InverseProperty("Sequence")]
		public virtual ICollection<SpdSequencesDetails> SpdSequencesDetails { get; set; }

		public SpdSequences()
		{
			SpdSequencesDetails = new HashSet<SpdSequencesDetails>();
		}
	}
}
