using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RATING_MATRIX")]
	public class SstRatingMatrix : BaseModel
	{
		[NotMapped]
		public string ClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string CoverTypeName { get; set; }

		[NotMapped]
		public string StatusName { get; set; }

		[NotMapped]
		public string CustomerRoleName { get; set; }

		[NotMapped]
		public byte? Lob { get; set; }

		[NotMapped]
		public long? OriginalMatrixId { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("COVER_TYPE")]
		public long CoverType { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("STATUS")]
		public bool Status { get; set; }

		[Column("STATUS_DATE")]
		public DateTime StatusDate { get; set; }

		[Column("FIN_CUSTOMER_ROLE")]
		public long? FinCustomerRole { get; set; }

		[Column("FIN_CUSTOMER_ROLE_NAME")]
		public string FinCustomerRoleName { get; set; }

		[Column("FIN_CUSTOMER_ID")]
		public long? FinCustomerId { get; set; }

		[Column("FIN_CUSTOMER_NAME")]
		public string FinCustomerName { get; set; }

		[Column("IS_BUILT")]
		public bool? IsBuilt { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstRatingMatrix")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CoverType")]
		[InverseProperty("SstRatingMatrix")]
		public virtual SstCoverTypes CoverTypeNavigation { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstRatingMatrix")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstRatingMatrix")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Matrix")]
		public virtual ICollection<SstPackegedCovers> SstPackegedCovers { get; set; }

		[InverseProperty("RatingMatrix")]
		public virtual ICollection<SstRatingMatrixParams> SstRatingMatrixParams { get; set; }

		[InverseProperty("RatingMatrix")]
		public virtual ICollection<SstRatingMatrixValues> SstRatingMatrixValues { get; set; }

		public SstRatingMatrix()
		{
			SstPackegedCovers = new HashSet<SstPackegedCovers>();
			SstRatingMatrixParams = new HashSet<SstRatingMatrixParams>();
			SstRatingMatrixValues = new HashSet<SstRatingMatrixValues>();
		}
	}
}
