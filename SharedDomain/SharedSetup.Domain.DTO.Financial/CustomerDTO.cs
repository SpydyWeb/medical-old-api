using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharedSetup.Domain.DTO.Financial
{
	public class CustomerDTO
	{
		public int ID { get; set; }

		public string CustomerNo { get; set; }

		public object FAX { get; set; }

		public object IBAN { get; set; }

		public string NAME { get; set; }

		public string NAME2 { get; set; }

		public string EMAIL { get; set; }

		public string PHONE { get; set; }

		public object BANK_ID { get; set; }

		public string ADDRESS { get; set; }

		public int ENTITY_ID { get; set; }

		public int BranchId { get; set; }

		public string CITY_CODE { get; set; }

		public object AREA_CODE { get; set; }

		public string Mobile { get; set; }

		public int CUS_STATUS { get; set; }

		public int OnHold { get; set; }

		public int? ACCOUNT_ID { get; set; }

		public string COM_REG_ID { get; set; }

		public DateTime? BIRTH_DATE { get; set; }

		public DateTime StartDate { get; set; }

		public string CREATED_BY { get; set; }

		public object ModifiedBy { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public string NationalId { get; set; }

		public string CUSTOMER_NO { get; set; }

		public string Nationality { get; set; }

		public int? Category { get; set; }

		public string COUNTRY_CODE { get; set; }

		public int CUSTOMER_TYPE { get; set; }

		public DateTime CREATION_DATE { get; set; }

		public DateTime ModificationDate { get; set; }

		public string HoldReason { get; set; }

		public int IS_BLACK_LISTED { get; set; }

		public string ENTITY_NAME { get; set; }

		public string BlackListReason { get; set; }

		public string CUSTOMER_TYPE_NAME { get; set; }

		public List<int> DR_CustomerAccounts { get; set; }

		public int? ParentId { get; set; }

		public string LICENSE_NO { get; set; }

		[JsonProperty("CountryCode")]
		private string CountryCode
		{
			set
			{
				COUNTRY_CODE = value;
			}
		}
	}
}
