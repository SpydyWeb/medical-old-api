using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ALERTS")]
	public class SstAlerts : BaseModel
	{
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("TYPE")]
		public byte Type { get; set; }

		[Column("ICON")]
		public string Icon { get; set; }

		[Column("IMAGE")]
		public string Image { get; set; }

		[Column("COLOR")]
		public string Color { get; set; }

		[Column("DATE_")]
		public DateTime? Date { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstAlerts")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Alert")]
		public virtual ICollection<SstUserAlerts> SstUserAlerts { get; set; }

		public SstAlerts()
		{
			SstUserAlerts = new HashSet<SstUserAlerts>();
		}
	}
}
