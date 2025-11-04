using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ENTITIES")]
	public class SstEntities : BaseModel
	{
		[NotMapped]
		public long[] EntityType { get; set; }

		[NotMapped]
		public string KycClearedName { get; set; }

		[NotMapped]
		public string StatusName { get; set; }

		[NotMapped]
		public string StageName { get; set; }

		[Required]
		[Column("SEGMENT_CODE")]
		public string SegmentCode { get; set; }

		[Required]
		[Column("ABBREVIATION")]
		public string Abbreviation { get; set; }

		[Column("TITLE")]
		public byte? Title { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("REGISTER_TYPE")]
		public byte? RegisterType { get; set; }

		[Column("REGISTER_NO")]
		public string RegisterNo { get; set; }

		[Column("ENTITY_NATURE")]
		public byte? EntityNature { get; set; }

		[Column("LEGAL_STATUS")]
		public byte? LegalStatus { get; set; }

		[Column("FREE_ZONE_FLAG")]
		public byte? FreeZoneFlag { get; set; }

		[Column("EMPLOYEES_NO")]
		public byte? EmployeesNo { get; set; }

		[Column("PAID_UP_CAPITAL")]
		public decimal? PaidUpCapital { get; set; }

		[Column("BUSINESS_ACTIVITIES")]
		public string BusinessActivities { get; set; }

		[Column("BUSINESS_SECTOR")]
		public long? BusinessSector { get; set; }

		[Column("SUB_SECTOR")]
		public long? SubSector { get; set; }

		[Column("INCORPORATION_DATE")]
		public DateTime? IncorporationDate { get; set; }

		[Column("COMMENCEMENT_DATE")]
		public DateTime? CommencementDate { get; set; }

		[Column("BANK_TYPE")]
		public byte? BankType { get; set; }

		[Column("REGULATOR")]
		public string Regulator { get; set; }

		[Column("PRIMARY_PHONE")]
		public string PrimaryPhone { get; set; }

		[Column("SECONDARY_PHONE")]
		public string SecondaryPhone { get; set; }

		[Column("PRIMARY_MOBILE")]
		public string PrimaryMobile { get; set; }

		[Column("SECONDARY_MOBILE")]
		public string SecondaryMobile { get; set; }

		[Column("FAX_NO")]
		public string FaxNo { get; set; }

		[Column("PRIMARY_EMAIL")]
		public string PrimaryEmail { get; set; }

		[Column("SECONDARY_EMAIL")]
		public string SecondaryEmail { get; set; }

		[Column("WEBSITE")]
		public string Website { get; set; }

		[Column("COUNTRY")]
		public string Country { get; set; }

		[Column("GOVERNORATE")]
		public long? Governorate { get; set; }

		[Column("CITY")]
		public long? City { get; set; }

		[Column("AREA")]
		public long? Area { get; set; }

		[Column("DISTRICT")]
		public string District { get; set; }

		[Column("STREET")]
		public string Street { get; set; }

		[Column("BUILDING_NO")]
		public string BuildingNo { get; set; }

		[Column("UNIT_NO")]
		public string UnitNo { get; set; }

		[Column("PO_BOX")]
		public string PoBox { get; set; }

		[Column("ZIP_CODE")]
		public string ZipCode { get; set; }

		[Column("LANGUAGE")]
		public byte? Language { get; set; }

		[Column("HOME_COMMUNICATION")]
		public byte? HomeCommunication { get; set; }

		[Column("POSTAL_COMMUNICATION")]
		public byte? PostalCommunication { get; set; }

		[Column("EMAIL_COMMUNICATION")]
		public byte? EmailCommunication { get; set; }

		[Column("SMS_COMMUNICATION")]
		public byte? SmsCommunication { get; set; }

		[Column("PHONE_COMMUNICATION")]
		public byte? PhoneCommunication { get; set; }

		[Column("STATUS")]
		public byte? Status { get; set; }

		[Column("STATUS_DATE")]
		public DateTime? StatusDate { get; set; }

		[Column("STAGE")]
		public byte? Stage { get; set; }

		[Column("STAGE_DATE")]
		public DateTime? StageDate { get; set; }

		[Column("KYC_CLEARED")]
		public byte? KycCleared { get; set; }

		[Column("COMPANY_TYPE")]
		public byte? CompanyType { get; set; }

		[Column("HOLD_COMPANY_NAME")]
		public string HoldCompanyName { get; set; }

		[Column("HOLD_INC_COUNTRY")]
		public string HoldIncCountry { get; set; }

		[Column("HOLD_BUS_COUNTRY")]
		public string HoldBusCountry { get; set; }

		[Column("HOLD_MAJORITY")]
		public string HoldMajority { get; set; }

		[Column("BROKER_ARR_TYPE")]
		public byte? BrokerArrType { get; set; }

		[Column("BROKER_ARR_DATE")]
		public DateTime? BrokerArrDate { get; set; }

		[Column("BROKER_EXP_FLAG")]
		public byte? BrokerExpFlag { get; set; }

		[Column("BROKER_ROLE")]
		public byte? BrokerRole { get; set; }

		[Column("BROKER_YEARS_NO")]
		public byte? BrokerYearsNo { get; set; }

		[Column("BROKER_ROLE_DESC")]
		public string BrokerRoleDesc { get; set; }

		[Column("BROKER_LICENSE_FLAG")]
		public byte? BrokerLicenseFlag { get; set; }

		[Column("BLACKLIST_FLAG")]
		public byte? BlacklistFlag { get; set; }

		[Column("TAXABLE_FLAG")]
		public byte? TaxableFlag { get; set; }

		[Column("CREDIT_LIMIT")]
		public decimal? CreditLimit { get; set; }

		[Column("PRIMARY_ADDRESS")]
		public string PrimaryAddress { get; set; }

		[Column("SECONDARY_ADDRESS")]
		public string SecondaryAddress { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("CUSTOMER_ID")]
		public long? CustomerId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("Entity")]
		public virtual ICollection<SstEntityRoles> SstEntityRoles { get; set; }

		public SstEntities()
		{
			SstEntityRoles = new HashSet<SstEntityRoles>();
		}
	}
}
