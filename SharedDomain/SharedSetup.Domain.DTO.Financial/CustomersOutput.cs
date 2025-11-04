using System;
using System.Collections.Generic;
using System.Dynamic;

namespace SharedSetup.Domain.DTO.Financial
{
	public class CustomersOutput
	{
		public int? ID { get; set; }

		public string CustomerNo { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public string NationalId { get; set; }

		public string CommercialName { get; set; }

		public int? CustomerType { get; set; }

		public DateTime? BirthDate { get; set; }

		public string Nationality { get; set; }

		public long? Category { get; set; }

		public string CityCode { get; set; }

		public string CountryCode { get; set; }

		public string Mobile { get; set; }

		public string Email { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public int? BlackList { get; set; }

		public string BlackListReason { get; set; }

		public int? OnHold { get; set; }

		public string HoldReason { get; set; }

		public int? CompanyId { get; set; }

		public int? BranchId { get; set; }

		public string CreatedBy { get; set; }

		public DateTime? CreationDate { get; set; }

		public DateTime? ModificationDate { get; set; }

		public string ModifiedBy { get; set; }

		public string Phone { get; set; }

		public string MainAddress { get; set; }

		public string Fax { get; set; }

		public int? Taxable { get; set; }

		public decimal? TaxPercentage { get; set; }

		public string StreetName { get; set; }

		public string BuildingNo { get; set; }

		public string Website { get; set; }

		public int? CST_SUP_FLAG { get; set; }

		public long? RoleID { get; set; }

		public List<int> DR_CustomerAccounts { get; set; }

		public List<int> CR_CustomerAccounts { get; set; }

		public ExpandoObject Extend { get; set; }

		public int? ParentId { get; set; }
	}
}
