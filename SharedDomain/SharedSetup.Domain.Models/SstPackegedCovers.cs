using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PACKEGED_COVERS")]
	public class SstPackegedCovers : BaseModel
	{
		[NotMapped]
		public string InsClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string CoverTypeName { get; set; }

		[NotMapped]
		public string RatingTypeName { get; set; }

		[Column("PACKAGED_ID")]
		public long PackagedId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("COVER_TYPE")]
		public long? CoverType { get; set; }

		[Column("RATING_TYPE")]
		public short? RatingType { get; set; }

		[Column("MATRIX_NAME")]
		public string MatrixName { get; set; }

		[Column("FORMULA_RATE")]
		public string FormulaRate { get; set; }

		[Column("MATRIX_ID")]
		public long? MatrixId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstPackegedCovers")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CoverType")]
		[InverseProperty("SstPackegedCovers")]
		public virtual SstCoverTypes CoverTypeNavigation { get; set; }

		[ForeignKey("MatrixId")]
		[InverseProperty("SstPackegedCovers")]
		public virtual SstRatingMatrix Matrix { get; set; }

		[ForeignKey("PackagedId")]
		[InverseProperty("SstPackegedCovers")]
		public virtual SstPackagedPolicy Packaged { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstPackegedCovers")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[InverseProperty("PackagedCover")]
		public virtual ICollection<SstPackegedCoversMatrix> SstPackegedCoversMatrix { get; set; }

		public SstPackegedCovers()
		{
			SstPackegedCoversMatrix = new HashSet<SstPackegedCoversMatrix>();
		}
	}
}
