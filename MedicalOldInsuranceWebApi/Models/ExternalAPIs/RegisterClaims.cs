using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CORE.DTOs.APIs.MotorClaim;
using CORE.DTOs.MotorClaim.Claims;
using CORE.DTOs.MotorClaim.Integrations.APIs;
using CORE.DTOs.MotorClaim.Integrations.Tables;
using CORE.Interfaces;

namespace InsuranceAPIs.Models.ExternalAPIs
{
	public class RegisterClaims
	{
		public enum InsuranceSurveyed
		{
			Najm = 1,
			Morror,
			Others
		}

		public enum Results
		{
			Success = 1,
			InvalidNajmReport,
			InvalidPolicyNo,
			InvalidClaimant
		}

		public enum Stages
		{
			Operations
		}

		public enum Status
		{
			Rejected,
			MissingInfo,
			Operations
		}

		public enum InsuranceType
		{
			TPL = 1,
			Comprehensive
		}

		public static DateTime? CallDate(string dt)
		{
			if (string.IsNullOrEmpty(dt) || dt.Length < 8)
			{
				return null;
			}
			int year = Convert.ToInt32(dt.Substring(0, 4));
			int Month = Convert.ToInt32(dt.Substring(4, 2));
			int Day = Convert.ToInt32(dt.Substring(6, 2));
			return new DateTime(year, Month, Day);
		}

		public static bool RegisterClaim(string Connection, IMotorClaims motorClaims, string NajmConnection, int insuranceCompanyID)
		{
			DataTable dataTable = new DataTable();
			int Result = 4;
			List<ClaimsMigration> claimsMigrations = new List<ClaimsMigration>();
			ClaimsMigration oClaimsMigrations = new ClaimsMigration();
			dataTable = motorClaims.ClaimsMigration(Connection);
			foreach (DataRow Dr in dataTable.Rows)
			{
				oClaimsMigrations = new ClaimsMigration
				{
					AccidentReport = Convert.ToString(Dr["AccidentReport"]),
					IBANNo = Convert.ToString(Dr["IBANNo"]),
					InsuranceSurveyed = Convert.ToInt32(Dr["InsuranceSurveyed"]),
					Id = Convert.ToInt32(Dr["Id"]),
					InsuranceType = Convert.ToInt32(Dr["InsuranceType"]),
					LicenseExpiryDate = ((Dr["LicenseExpiryDate"] != DBNull.Value) ? new DateTime?(Convert.ToDateTime(Dr["LicenseExpiryDate"])) : null),
					OwnerNationalID = Convert.ToString(Dr["OwnerNationalID"]),
					RecoveryType = Convert.ToInt32(Dr["RecoveryType"]),
					Reference = Convert.ToString(Dr["Reference"]),
					SequenceNumber = Convert.ToString(Dr["SequenceNumber"]),
					TaqdeerNumber = Convert.ToString(Dr["TaqdeerNumber"]),
					Status = Convert.ToInt32(Dr["Id"]),
					CreationDate = Convert.ToDateTime(Dr["CreationDate"])
				};
				NajmResponse najm = new NajmResponse();
				TaqdeerResponse taqdeer = new TaqdeerResponse();
				ClaimSearchResult claimSearchResult = new ClaimSearchResult();
				SearchingObj searchingObj = new SearchingObj();
				Claims claims = new Claims();
				NajmPartiesInfo najmPartiesInfo = new NajmPartiesInfo();
				Claimants claimant = new Claimants();
				try
				{
					if (oClaimsMigrations != null && oClaimsMigrations.InsuranceSurveyed == 1)
					{
						long? partyId;
						if (oClaimsMigrations.InsuranceType == 1)
						{
							najm = motorClaims.LoadNajmData(oClaimsMigrations.AccidentReport);
							if (najm != null && najm.najmAccidentinfo != null)
							{
								partyId = najm.partyInsuranceInfos.Where((PartyInsuranceInfo p) => p.insuranceCompanyID == insuranceCompanyID).FirstOrDefault().PartyId;
								searchingObj = new SearchingObj
								{
									PolicyNo = najm.partyInsuranceInfos.Where((PartyInsuranceInfo p) => p.insuranceCompanyID == insuranceCompanyID && p.caseNumber == oClaimsMigrations.AccidentReport).FirstOrDefault().policyNumber,
									SequenceNo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == partyId && p.caseNumber == oClaimsMigrations.AccidentReport).FirstOrDefault().SequenceNumber
								};
								claimSearchResult = motorClaims.claimSearch(searchingObj, NajmConnection);
								if (claimSearchResult != null && claimSearchResult.Productions.Count > 0)
								{
									PartyInsuranceInfo ours2 = new PartyInsuranceInfo();
									ours2 = najm.partyInsuranceInfos.Where((PartyInsuranceInfo p) => p.insuranceCompanyID == 2).FirstOrDefault();
									NajmPartiesInfo najmParties2 = new NajmPartiesInfo();
									najmParties2 = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == ours2.PartyId).FirstOrDefault();
									string Reason2 = string.Empty;
									if (Convert.ToInt32(najmParties2.Liability) == 0)
									{
										Reason2 = "TP Claim with 0 Liability";
									}
									List<Claims> clms2 = new List<Claims>();
									clms2 = motorClaims.LoadClaims(null, null, oClaimsMigrations.AccidentReport);
									if (clms2.Count > 0)
									{
										claims = clms2.FirstOrDefault();
									}
									else
									{
										claims = new Claims
										{
											AccidentNo = najm.najmAccidentinfo.caseNumber,
											AccidentPlace = najm.najmAccidentinfo.city,
											AssignTo = 0,
											Branch = claimSearchResult.Productions.FirstOrDefault().policy.BranchName,
											BranchId = claimSearchResult.Productions.FirstOrDefault().policy.BranchId,
											ChassisNo = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.ChassisNo,
											City = najm.najmAccidentinfo.city.ToString(),
											CityId = najm.najmAccidentinfo.cityID,
											InsuredId = claimSearchResult.Productions.FirstOrDefault().policy.OwnerId,
											BusinessType = claimSearchResult.Productions.FirstOrDefault().policy.BusinessTypeId,
											BusinessType_desc = claimSearchResult.Productions.FirstOrDefault().policy.BusinessType,
											ClaimStatus = (string.IsNullOrEmpty(Reason2) ? 2 : 0),
											CreationDate = DateTime.Now,
											CreatedBy = "Online",
											ClaimNo = oClaimsMigrations.Reference,
											InsuredName = claimSearchResult.Productions.FirstOrDefault().policy.Insured,
											PolicyNo = claimSearchResult.Productions.FirstOrDefault().policy.PolicyNumber,
											VehicleName = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.Name,
											TaqdeerNo = oClaimsMigrations.TaqdeerNumber,
											RegistrationDate = DateTime.Now,
											ClaimUWYear = DateTime.Now.Year,
											DateOfLoss = (CallDate(najm.najmAccidentinfo.callDate).HasValue ? CallDate(najm.najmAccidentinfo.callDate).Value : DateTime.Now),
											Notes = najm.najmAccidentinfo.AccidentDescription,
											PlateNo = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.PlateNo,
											PolicyEffectiveDate = claimSearchResult.Productions.FirstOrDefault().policy.PolicyEffectiveDate,
											PolicyExpiryDate = claimSearchResult.Productions.FirstOrDefault().policy.PolicyExpiryDate,
											PolicyId = claimSearchResult.Productions.FirstOrDefault().policy.PolicyId,
											SurveyCity = najm.najmAccidentinfo.cityID,
											PolicySI = Convert.ToInt32(claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.SumInsured),
											PolicyUWYear = claimSearchResult.Productions.FirstOrDefault().policy.PolicyUWYear,
											ProductionYear = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.ManufactureYear,
											FraudScore = 0,
											FraudIndicator = "Low",
											ClaimReportType = 1,
											NotificationDate = oClaimsMigrations.CreationDate,
											Owner = claimSearchResult.Productions.FirstOrDefault().policy.Insured,
											StatusReason = Reason2
										};
										claims = motorClaims.InsertUpdateClaims(claims);
										ClaimVehicle claimVehicle2 = new ClaimVehicle
										{
											ClaimId = claims.Id,
											PolicyId = claimSearchResult.Productions.FirstOrDefault().policy.PolicyId,
											RiskId = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.Id
										};
										claimVehicle2 = motorClaims.InsertClaimVehicle(claimVehicle2);
										motorClaims.InsertClaimHistory(new ClaimHistory
										{
											ChangeDate = DateTime.Now,
											ClaimId = claims.Id,
											Reason = "eClaims Transfer",
											Status = 1,
											UserId = 1
										});
									}
									List<Claimants> claimants2 = new List<Claimants>();
									int serial2 = 0;
									foreach (PartyInsuranceInfo item2 in najm.partyInsuranceInfos)
									{
										najmPartiesInfo = new NajmPartiesInfo();
										najmPartiesInfo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault();
										bool clmnts2 = motorClaims.LoadClaimants(null, claims.Id).Any((Claimants p) => p.NationalId == najmPartiesInfo.ID);
										if (najmPartiesInfo != null && !clmnts2 && item2.insuranceCompanyID != 2 && (oClaimsMigrations.OwnerNationalID == najmPartiesInfo.ID || oClaimsMigrations.SequenceNumber == najmPartiesInfo.SequenceNumber))
										{
											Claimants obj = new Claimants
											{
												BenefecieryName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().ownerName,
												ClaimantName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().ownerName,
												ClaimantStatus = (string.IsNullOrEmpty(Reason2) ? 1 : 0),
												CreatedBy = "Online",
												DriverBirthDate = CallDate(najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().DOB),
												DriverAge = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().age,
												DriverLicenseExpiryDate = CallDate(najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().DriverLicenseExpiryDate),
												DriverNationalId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().ID,
												DriverName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().name,
												InsuranceCompanyName = item2.ICArabicName,
												MakeDesc = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().carMake,
												MakeId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().carMakeID,
												ModelDesc = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().carModel,
												ModelId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().carModelID,
												OurPercent = Convert.ToInt32(najmParties2.Liability),
												NationalId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().ID,
												Responsipility = ((Convert.ToInt32(najmParties2.Liability) == 100) ? 1 : ((Convert.ToInt32(najmParties2.Liability) > 0 && Convert.ToInt32(najmParties2.Liability) < 100) ? 2 : 3)),
												SequenceNo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().SequenceNumber,
												Manifacturing = Convert.ToInt32(najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().carMfgYear)
											};
											serial2 = (obj.Serial = serial2 + 1);
											obj.MobileNo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().phoneNo;
											obj.PlateNo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().plateNo;
											obj.InsurancePolicyNumber = item2.policyNumber;
											obj.OwnerName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().ownerName;
											obj.OwnerNationalId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item2.PartyId).FirstOrDefault().ID;
											obj.ClaimId = claims.Id;
											obj.ChassisNo = item2.chassisNo;
											obj.StatusReason = Reason2;
											obj.ClaimantType = 2;
											obj.DamageType = 1;
											obj.NatureofLoss = 1;
											claimant = obj;
											claimant = motorClaims.InsertUpdateClaimants(claimant);
											Result = ((claimant.Id > 0) ? 1 : 4);
											motorClaims.InsertClaimHistory(new ClaimHistory
											{
												ChangeDate = DateTime.Now,
												ClaimId = claims.Id,
												Reason = "eClaims Transfer Claimant : " + claimant.ClaimantName,
												Status = 1,
												UserId = 1
											});
											claimants2.Add(claimant);
											ClaimSubmissionDocuments claimSubmissionDocuments2 = new ClaimSubmissionDocuments
											{
												eClaimId = oClaimsMigrations.Id
											};
											claimSubmissionDocuments2 = motorClaims.LoadClaimSubmissionDocuments(claimSubmissionDocuments2, NajmConnection);
											Attachments attachments2 = new Attachments();
											if (!string.IsNullOrEmpty(claimSubmissionDocuments2.AcciedentReport))
											{
												attachments2 = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments2.AcciedentReport,
													ContentType = "",
													DocumentSetupId = 7,
													IsDeleted = false
												};
												attachments2 = motorClaims.InsertUpdateAttachments(attachments2);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments2.DA))
											{
												attachments2 = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments2.DA,
													ContentType = "",
													DocumentSetupId = 8,
													IsDeleted = false
												};
												attachments2 = motorClaims.InsertUpdateAttachments(attachments2);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments2.IstimaraCopy))
											{
												attachments2 = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments2.IstimaraCopy,
													ContentType = "",
													DocumentSetupId = 3,
													IsDeleted = false
												};
												attachments2 = motorClaims.InsertUpdateAttachments(attachments2);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments2.LicenseCopy))
											{
												attachments2 = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments2.LicenseCopy,
													ContentType = "",
													DocumentSetupId = 4,
													IsDeleted = false
												};
												attachments2 = motorClaims.InsertUpdateAttachments(attachments2);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments2.Others))
											{
												attachments2 = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments2.Others,
													ContentType = "",
													DocumentSetupId = 5,
													IsDeleted = false
												};
												attachments2 = motorClaims.InsertUpdateAttachments(attachments2);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments2.IBAN))
											{
												attachments2 = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments2.IBAN,
													ContentType = "",
													DocumentSetupId = 9,
													IsDeleted = false
												};
												attachments2 = motorClaims.InsertUpdateAttachments(attachments2);
											}
										}
									}
								}
								else
								{
									Result = 3;
								}
								if (!string.IsNullOrEmpty(oClaimsMigrations.TaqdeerNumber) && claims.Id > 0 && claimant.Id > 0)
								{
									ClaimTransactions claimTransactions = new ClaimTransactions();
									taqdeer = motorClaims.LoadTaqdeer(oClaimsMigrations.TaqdeerNumber);
									if (taqdeer != null && !string.IsNullOrEmpty(taqdeer.TaqdeerCase.DACaseNumber))
									{
										claimTransactions = new ClaimTransactions
										{
											isActive = true,
											ClaimId = claims.Id,
											ClaimantID = claimant.Id,
											Collector = 0,
											TransactionDate = DateTime.Now,
											TransactionType = 1,
											TransactionAmount = taqdeer.TaqdeerCase.TotalCost,
											Fees = taqdeer.TaqdeerCase.TaqdeerTotalFees,
											CreatedBy = "Online",
											Note = "Initial Reserve"
										};
										claimTransactions = motorClaims.InsertUpdateClaimTrans(claimTransactions);
									}
									else
									{
										claimTransactions = new ClaimTransactions
										{
											isActive = true,
											ClaimId = claims.Id,
											ClaimantID = claimant.Id,
											Collector = 0,
											TransactionDate = DateTime.Now,
											TransactionType = 1,
											TransactionAmount = 6666m,
											Fees = default(decimal),
											CreatedBy = "Online",
											Note = "Initial Reserve"
										};
										claimTransactions = motorClaims.InsertUpdateClaimTrans(claimTransactions);
									}
									motorClaims.InsertClaimHistory(new ClaimHistory
									{
										ChangeDate = DateTime.Now,
										ClaimId = claims.Id,
										Reason = "Add new Reserve : " + claimTransactions.TransactionAmount + " By Online",
										Status = 1,
										UserId = 1
									});
								}
							}
							else
							{
								Result = 2;
							}
						}
						if (oClaimsMigrations.InsuranceType == 2)
						{
							najm = motorClaims.LoadNajmData(oClaimsMigrations.AccidentReport);
							if (najm != null && najm.najmAccidentinfo != null)
							{
								partyId = najm.partyInsuranceInfos.Where((PartyInsuranceInfo p) => p.insuranceCompanyID == insuranceCompanyID).FirstOrDefault().PartyId;
								searchingObj = new SearchingObj
								{
									NationalId = oClaimsMigrations.OwnerNationalID,
									SequenceNo = oClaimsMigrations.SequenceNumber
								};
								claimSearchResult = motorClaims.claimSearch(searchingObj, NajmConnection);
								if (claimSearchResult != null && claimSearchResult.Productions.Count > 0)
								{
									PartyInsuranceInfo ours = new PartyInsuranceInfo();
									ours = najm.partyInsuranceInfos.Where((PartyInsuranceInfo p) => p.insuranceCompanyID == 2).FirstOrDefault();
									NajmPartiesInfo najmParties = new NajmPartiesInfo();
									najmParties = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == ours.PartyId).FirstOrDefault();
									string Reason = string.Empty;
									List<Claims> clms = new List<Claims>();
									clms = motorClaims.LoadClaims(null, null, oClaimsMigrations.AccidentReport);
									if (clms.Count > 0)
									{
										claims = clms.FirstOrDefault();
									}
									else
									{
										claims = new Claims
										{
											AccidentNo = najm.najmAccidentinfo.caseNumber,
											AccidentPlace = najm.najmAccidentinfo.city,
											AssignTo = 0,
											Branch = claimSearchResult.Productions.FirstOrDefault().policy.BranchName,
											BranchId = claimSearchResult.Productions.FirstOrDefault().policy.BranchId,
											ChassisNo = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.ChassisNo,
											City = najm.najmAccidentinfo.city.ToString(),
											CityId = najm.najmAccidentinfo.cityID,
											InsuredId = claimSearchResult.Productions.FirstOrDefault().policy.OwnerId,
											BusinessType = claimSearchResult.Productions.FirstOrDefault().policy.BusinessTypeId,
											BusinessType_desc = claimSearchResult.Productions.FirstOrDefault().policy.BusinessType,
											ClaimStatus = (string.IsNullOrEmpty(Reason) ? 2 : 0),
											CreationDate = DateTime.Now,
											CreatedBy = "Online",
											ClaimNo = oClaimsMigrations.Reference,
											InsuredName = claimSearchResult.Productions.FirstOrDefault().policy.Insured,
											PolicyNo = claimSearchResult.Productions.FirstOrDefault().policy.PolicyNumber,
											VehicleName = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.Name,
											TaqdeerNo = oClaimsMigrations.TaqdeerNumber,
											RegistrationDate = DateTime.Now,
											ClaimUWYear = DateTime.Now.Year,
											DateOfLoss = (CallDate(najm.najmAccidentinfo.callDate).HasValue ? CallDate(najm.najmAccidentinfo.callDate).Value : DateTime.Now),
											Notes = najm.najmAccidentinfo.AccidentDescription,
											PlateNo = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.PlateNo,
											PolicyEffectiveDate = claimSearchResult.Productions.FirstOrDefault().policy.PolicyEffectiveDate,
											PolicyExpiryDate = claimSearchResult.Productions.FirstOrDefault().policy.PolicyExpiryDate,
											PolicyId = claimSearchResult.Productions.FirstOrDefault().policy.PolicyId,
											SurveyCity = najm.najmAccidentinfo.cityID,
											PolicySI = Convert.ToInt32(claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.SumInsured),
											PolicyUWYear = claimSearchResult.Productions.FirstOrDefault().policy.PolicyUWYear,
											ProductionYear = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.ManufactureYear,
											FraudScore = 0,
											FraudIndicator = "Low",
											ClaimReportType = 1,
											NotificationDate = oClaimsMigrations.CreationDate,
											Owner = claimSearchResult.Productions.FirstOrDefault().policy.Insured,
											StatusReason = Reason
										};
										claims = motorClaims.InsertUpdateClaims(claims);
										ClaimVehicle claimVehicle = new ClaimVehicle
										{
											ClaimId = claims.Id,
											PolicyId = claimSearchResult.Productions.FirstOrDefault().policy.PolicyId,
											RiskId = claimSearchResult.Productions.FirstOrDefault().Vehicles.FirstOrDefault().Vehicle.Id
										};
										claimVehicle = motorClaims.InsertClaimVehicle(claimVehicle);
										motorClaims.InsertClaimHistory(new ClaimHistory
										{
											ChangeDate = DateTime.Now,
											ClaimId = claims.Id,
											Reason = "eClaims Transfer",
											Status = 1,
											UserId = 1
										});
									}
									List<Claimants> claimants = new List<Claimants>();
									claimant = new Claimants();
									int serial = 0;
									foreach (PartyInsuranceInfo item in najm.partyInsuranceInfos)
									{
										najmPartiesInfo = new NajmPartiesInfo();
										najmPartiesInfo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault();
										bool clmnts = motorClaims.LoadClaimants(null, claims.Id).Any((Claimants p) => p.NationalId == najmPartiesInfo.ID);
										if (najmPartiesInfo != null && !clmnts && item.insuranceCompanyID == insuranceCompanyID && (oClaimsMigrations.OwnerNationalID == najmPartiesInfo.ID || oClaimsMigrations.SequenceNumber == najmPartiesInfo.SequenceNumber))
										{
											Claimants obj2 = new Claimants
											{
												BenefecieryName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().ownerName,
												ClaimantName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().ownerName,
												ClaimantStatus = (string.IsNullOrEmpty(Reason) ? 1 : 0),
												CreatedBy = "Online",
												DriverBirthDate = CallDate(najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().DOB),
												DriverAge = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().age,
												DriverLicenseExpiryDate = CallDate(najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().DriverLicenseExpiryDate),
												DriverNationalId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().ID,
												DriverName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().name,
												MakeDesc = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().carMake,
												MakeId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().carMakeID,
												ModelDesc = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().carModel,
												ModelId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().carModelID,
												OurPercent = Convert.ToInt32(najmParties.Liability),
												NationalId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().ID,
												Responsipility = ((Convert.ToInt32(najmParties.Liability) == 100) ? 1 : ((Convert.ToInt32(najmParties.Liability) > 0 && Convert.ToInt32(najmParties.Liability) < 100) ? 2 : 3)),
												SequenceNo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().SequenceNumber,
												Manifacturing = Convert.ToInt32(najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().carMfgYear)
											};
											serial = (obj2.Serial = serial + 1);
											obj2.MobileNo = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().phoneNo;
											obj2.OwnerName = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().ownerName;
											obj2.OwnerNationalId = najm.lsNajmPartiesInfo.Where((NajmPartiesInfo p) => p.PartyId == item.PartyId).FirstOrDefault().ID;
											obj2.ClaimId = claims.Id;
											obj2.ChassisNo = item.chassisNo;
											obj2.ClaimantType = 1;
											obj2.StatusReason = Reason;
											obj2.DamageType = 1;
											obj2.NatureofLoss = 1;
											claimant = obj2;
											claimant = motorClaims.InsertUpdateClaimants(claimant);
											Result = ((claimant.Id > 0) ? 1 : 4);
											motorClaims.InsertClaimHistory(new ClaimHistory
											{
												ChangeDate = DateTime.Now,
												ClaimId = claims.Id,
												Reason = "eClaims Transfer Claimant : " + claimant.ClaimantName,
												Status = 1,
												UserId = 1
											});
											claimants.Add(claimant);
											ClaimSubmissionDocuments claimSubmissionDocuments = new ClaimSubmissionDocuments
											{
												eClaimId = oClaimsMigrations.Id
											};
											claimSubmissionDocuments = motorClaims.LoadClaimSubmissionDocuments(claimSubmissionDocuments, NajmConnection);
											Attachments attachments = new Attachments();
											if (!string.IsNullOrEmpty(claimSubmissionDocuments.AcciedentReport))
											{
												attachments = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments.AcciedentReport,
													ContentType = "",
													DocumentSetupId = 7,
													IsDeleted = false
												};
												attachments = motorClaims.InsertUpdateAttachments(attachments);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments.DA))
											{
												attachments = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments.DA,
													ContentType = "",
													DocumentSetupId = 8,
													IsDeleted = false
												};
												attachments = motorClaims.InsertUpdateAttachments(attachments);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments.IstimaraCopy))
											{
												attachments = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments.IstimaraCopy,
													ContentType = "",
													DocumentSetupId = 3,
													IsDeleted = false
												};
												attachments = motorClaims.InsertUpdateAttachments(attachments);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments.LicenseCopy))
											{
												attachments = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments.LicenseCopy,
													ContentType = "",
													DocumentSetupId = 4,
													IsDeleted = false
												};
												attachments = motorClaims.InsertUpdateAttachments(attachments);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments.Others))
											{
												attachments = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments.Others,
													ContentType = "",
													DocumentSetupId = 5,
													IsDeleted = false
												};
												attachments = motorClaims.InsertUpdateAttachments(attachments);
											}
											if (!string.IsNullOrEmpty(claimSubmissionDocuments.IBAN))
											{
												attachments = new Attachments
												{
													ClaimantId = claimant.Id,
													CreatedBy = "Online",
													CreationDate = DateTime.Now,
													ModuleId = 2,
													FileName = claimSubmissionDocuments.IBAN,
													ContentType = "",
													DocumentSetupId = 9,
													IsDeleted = false
												};
												attachments = motorClaims.InsertUpdateAttachments(attachments);
											}
										}
									}
								}
								else
								{
									Result = 3;
								}
								if (!string.IsNullOrEmpty(oClaimsMigrations.TaqdeerNumber))
								{
									taqdeer = motorClaims.LoadTaqdeer(oClaimsMigrations.TaqdeerNumber);
								}
							}
							else
							{
								Result = 2;
							}
						}
					}
					motorClaims.UpdateClaimsMigration(oClaimsMigrations.Id, Connection, Result);
				}
				catch (Exception)
				{
					motorClaims.UpdateClaimsMigration(oClaimsMigrations.Id, Connection, 2);
				}
			}
			return true;
		}
	}
}
