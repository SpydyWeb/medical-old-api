using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CORE.DTOs.APIs.MotorClaim;
using CORE.DTOs.Authentications;
using CORE.DTOs.MotorClaim;
using CORE.DTOs.MotorClaim.Claims;
using CORE.DTOs.MotorClaim.Frauds;
using CORE.DTOs.MotorClaim.Integrations.APIs;
using CORE.DTOs.MotorClaim.Integrations.Tables;
using CORE.DTOs.MotorClaim.Productions;
using CORE.DTOs.MotorClaim.Survoyer;
using CORE.DTOs.MotorClaim.WorkFlow;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace InfraStructure.Services
{
	public class MotorClaim : Svc, IMotorClaims, ISvc
	{
		public MotorClaim(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
			: base(unitOfWork)
		{
		}

		public Claims InsertUpdateClaims(Claims claims)
		{
			Claims claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<Claims>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<Claims>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public Claims UpdateAssign(int ClaimId, int UserId)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					UserRoles UserRole = (from p in ((DbContext)(object)context).Set<UserRoles>()
						where p.UserId == UserId
						select p).FirstOrDefault();
					ClaimStatusMapping claimStatusMapping = (from p in ((DbContext)(object)context).Set<ClaimStatusMapping>()
						where p.RoleId == UserRole.RoleId
						select p).FirstOrDefault();
					Claims claims = (from p in ((DbContext)(object)context).Set<Claims>()
						where p.Id == (long)ClaimId
						select p).FirstOrDefault();
					claims.AssignTo = UserId;
					claims.ClaimStatus = claimStatusMapping.ClaimStatus;
					((DbContext)(object)context).Set<Claims>().Update(claims);
					((DbContext)(object)context).SaveChanges();
					return claims;
				}
				catch (Exception)
				{
					return (Claims)null;
				}
			});
		}

		public ClaimVehicle InsertClaimVehicle(ClaimVehicle claimVehicle)
		{
			ClaimVehicle claimVehicle2 = claimVehicle;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					((DbContext)(object)context).Set<ClaimVehicle>().Add(claimVehicle2);
					((DbContext)(object)context).SaveChanges();
					return claimVehicle2;
				}
				catch (Exception)
				{
					return claimVehicle2;
				}
			});
		}

		public ReserveBalance ReserveBalance(int ClaimId, int? ClaimantId)
		{
			ReserveBalance reserve = new ReserveBalance();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					reserve.ClaimLevel = (from p in ((DbContext)(object)context).Set<ClaimTransactions>()
						where p.TransactionType == 1 && p.ClaimId == (long)ClaimId
						select p).Sum((ClaimTransactions p) => p.TransactionAmount);
					reserve.ClaimantLevel = (ClaimantId.HasValue ? (from p in ((DbContext)(object)context).Set<ClaimTransactions>()
						where p.TransactionType == 1 && p.ClaimantID == ((int?)ClaimantId).Value
						select p).Sum((ClaimTransactions p) => p.TransactionAmount) : 0m);
					return reserve;
				}
				catch (Exception)
				{
					return reserve;
				}
			});
		}

		public List<Claims> LoadClaims(long? Id, int? policyId, string? AcciedentReport = null)
		{
			string AcciedentReport2 = AcciedentReport;
			return Action(delegate(DataBaseContext context)
			{
				List<Claims> list = new List<Claims>();
				try
				{
					IQueryable<Claims> source = ((DbContext)(object)context).Set<Claims>().AsQueryable();
					return Id.HasValue ? source.Where((Claims x) => (long?)x.Id == Id).ToList() : (policyId.HasValue ? source.Where((Claims p) => p.PolicyId == policyId).ToList() : (string.IsNullOrEmpty(AcciedentReport2) ? source.ToList() : source.Where((Claims p) => p.AccidentNo.ToUpper() == AcciedentReport2.ToUpper()).ToList()));
				}
				catch (Exception)
				{
					return (List<Claims>)null;
				}
			});
		}

		public List<ClaimMaster> LoadClaimsMaster(string? NationalID, int? Branch, string? chassis, string? claimno, string? mobile, string? policy, DateTime? RegisteredFrom, DateTime? RegisteredTo, int? ClaimStatus, int? Id)
		{
			string NationalID2 = NationalID;
			string claimno2 = claimno;
			string policy2 = policy;
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				List<ClaimMaster> lsClaims = new List<ClaimMaster>();
				ClaimMaster oClaims = new ClaimMaster();
				List<Claims> list = new List<Claims>();
				try
				{
					list = (from v in ((DbContext)(object)context2).Set<Claims>()
						where ((!string.IsNullOrEmpty(NationalID2)) ? (v.Owner == NationalID2) : (v.Id == v.Id)) && ((!string.IsNullOrEmpty(claimno2)) ? (v.ClaimNo == claimno2) : (v.Id == v.Id)) && (((int?)Branch).HasValue ? (v.BranchId == (int?)((int?)Branch).Value) : (v.Id == v.Id)) && (((DateTime?)RegisteredFrom).HasValue ? (v.RegistrationDate >= ((DateTime?)RegisteredFrom).Value) : (v.Id == v.Id)) && (((DateTime?)RegisteredTo).HasValue ? (v.RegistrationDate <= ((DateTime?)RegisteredTo).Value) : (v.Id == v.Id)) && ((!string.IsNullOrEmpty(policy2)) ? (v.PolicyNo == policy2) : (v.Id == v.Id)) && (((int?)ClaimStatus).HasValue ? (v.ClaimStatus == (int?)((int?)ClaimStatus).Value) : (v.Id == v.Id)) && (((int?)Id).HasValue ? (v.Id == (long)((int?)Id).Value) : (v.Id == v.Id))
						select v).ToList();
					list.ForEach(delegate(Claims item)
					{
						Claims item2 = item;
						oClaims = new ClaimMaster();
						ClaimVehicle Veh = (from p in ((DbContext)(object)context2).Set<ClaimVehicle>()
							where p.ClaimId == item2.Id
							select p).FirstOrDefault();
						oClaims.claimants = (from p in ((DbContext)(object)context2).Set<Claimants>()
							where p.ClaimId == item2.Id
							select p).ToList();
						oClaims.vehiclesInfo = (from p in ((DbContext)(object)context2).Set<VehiclesInfo>()
							where p.RiskId == Veh.RiskId && (int?)p.PolicyId == item2.PolicyId
							select p).FirstOrDefault();
						oClaims.productionInfo = (from p in ((DbContext)(object)context2).Set<ProductionInfo>()
							where (int?)p.PolicyId == item2.PolicyId
							select p).FirstOrDefault();
						oClaims.reserveBalance = ReserveBalance(Convert.ToInt32(item2.Id), null);
						oClaims.claims = item2;
						lsClaims.Add(oClaims);
					});
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<ClaimMaster>)null;
				}
			});
		}

		public bool DeleteClaim(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					Claims entity = (from p in ((DbContext)(object)context).Set<Claims>()
						where p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<Claims>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public ClaimHistory InsertClaimHistory(ClaimHistory claims)
		{
			ClaimHistory claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					((DbContext)(object)context).Set<ClaimHistory>().Add(claims2);
					((DbContext)(object)context).SaveChanges();
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public EClaims InsertUpdateEClaims(EClaims claims)
		{
			EClaims claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<EClaims>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<EClaims>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<EClaims> LoadEclaims(long? Id, string? NationalID)
		{
			string NationalID2 = NationalID;
			List<EClaims> lsClaims = new List<EClaims>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<EClaims> source = ((DbContext)(object)context).Set<EClaims>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((EClaims x) => (long?)(long)x.Id == Id).ToList();
					}
					if (!string.IsNullOrEmpty(NationalID2))
					{
						lsClaims = lsClaims.Where((EClaims p) => p.NationalId == NationalID2).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<EClaims>)null;
				}
			});
		}

		public bool DeleteEClaims(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					EClaims entity = (from p in ((DbContext)(object)context).Set<EClaims>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<EClaims>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public Claimants InsertUpdateClaimants(Claimants claims)
		{
			Claimants claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					int num = 1;
					try
					{
						num = (from p in ((DbContext)(object)context).Set<Claimants>()
							where p.ClaimId == claims2.ClaimId
							select p).Max((Claimants p) => p.Serial) + 1;
					}
					catch (Exception)
					{
						num = 1;
					}
					claims2.Serial = num;
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<Claimants>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<Claimants>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<Claimants> LoadClaimants(long? Id, long? ClaimId)
		{
			List<Claimants> lsClaims = new List<Claimants>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<Claimants> source = ((DbContext)(object)context).Set<Claimants>().AsQueryable();
					if (Id.HasValue && Id.Value > 0)
					{
						lsClaims = source.Where((Claimants x) => (long?)(long)x.Id == Id).ToList();
					}
					if (ClaimId.HasValue && ClaimId.Value > 0)
					{
						lsClaims = source.Where((Claimants p) => p.ClaimId == ((long?)ClaimId).Value).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<Claimants>)null;
				}
			});
		}

		public bool Claimants(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					Claimants entity = (from p in ((DbContext)(object)context).Set<Claimants>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<Claimants>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public ClaimTransactions InsertUpdateClaimTrans(ClaimTransactions claims)
		{
			ClaimTransactions claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<ClaimTransactions>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<ClaimTransactions>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<Reserve> LoadReserve(int? Id, int? ClaimId, int? TransactionId)
		{
			List<Reserve> lsClaims = new List<Reserve>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<Reserve> source = ((DbContext)(object)context).Set<Reserve>().AsQueryable();
					if (Id.HasValue && Id.Value > 0)
					{
						lsClaims = source.Where((Reserve x) => (int?)x.Id == Id).ToList();
					}
					if (ClaimId.HasValue && ClaimId.Value > 0)
					{
						lsClaims = lsClaims.Where((Reserve p) => p.ClaimId == ClaimId).ToList();
					}
					if (TransactionId.HasValue && TransactionId.Value > 0)
					{
						lsClaims = lsClaims.Where((Reserve p) => p.TransactionId == TransactionId).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<Reserve>)null;
				}
			});
		}

		public List<ClaimTransactions> LoadClaimTrans(int TransactionType, int ClaimantId)
		{
			List<ClaimTransactions> lsClaims = new List<ClaimTransactions>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					lsClaims = (from p in ((DbContext)(object)context).Set<ClaimTransactions>()
						where p.TransactionType == TransactionType && p.ClaimantID == ClaimantId && p.isActive == true
						orderby p.Id
						select p).ToList();
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<ClaimTransactions>)null;
				}
			});
		}

		public bool DeleteClaimTrans(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					ClaimTransactions entity = (from p in ((DbContext)(object)context).Set<ClaimTransactions>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<ClaimTransactions>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public Collectors InsertUpdateCollectorss(Collectors claims)
		{
			Collectors claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<Collectors>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<Collectors>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<Collectors> LoadCollectors(long? Id, int? CollectorType)
		{
			List<Collectors> lsClaims = new List<Collectors>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<Collectors> source = ((DbContext)(object)context).Set<Collectors>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((Collectors x) => (long?)(long)x.Id == Id).ToList();
					}
					if (CollectorType.HasValue)
					{
						lsClaims = lsClaims.Where((Collectors p) => p.CollectorType == CollectorType).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<Collectors>)null;
				}
			});
		}

		public ClaimVehicle LoadClaimVehicle(long ClaimId)
		{
			ClaimVehicle claimVehicle = new ClaimVehicle();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					claimVehicle = (from p in ((DbContext)(object)context).Set<ClaimVehicle>()
						where p.ClaimId == ClaimId
						select p).FirstOrDefault();
					return claimVehicle;
				}
				catch (Exception)
				{
					return new ClaimVehicle();
				}
			});
		}

		public bool DeleteCollectors(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					Collectors entity = (from p in ((DbContext)(object)context).Set<Collectors>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<Collectors>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public FraudIndicators InsertUpdateFraudIndicators(FraudIndicators claims)
		{
			FraudIndicators claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<FraudIndicators>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<FraudIndicators>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<FraudIndicators> LoadFraudIndicators(long? Id, string? Name = null, int? Status = null)
		{
			string Name2 = Name;
			List<FraudIndicators> lsClaims = new List<FraudIndicators>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<FraudIndicators> source = ((DbContext)(object)context).Set<FraudIndicators>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((FraudIndicators x) => (long?)(long)x.Id == Id).ToList();
					}
					else if (!string.IsNullOrEmpty(Name2))
					{
						lsClaims = source.Where((FraudIndicators x) => x.Name.ToUpper() == Name2.ToUpper() && x.IsActive == true).ToList();
					}
					else if (Status.HasValue)
					{
						lsClaims = source.Where((FraudIndicators x) => x.IsActive == Convert.ToBoolean(((int?)Status).Value)).ToList();
					}
					else
					{
						lsClaims = source.ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<FraudIndicators>)null;
				}
			});
		}

		public bool DeleteFraudIndicators(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					FraudIndicators entity = (from p in ((DbContext)(object)context).Set<FraudIndicators>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<FraudIndicators>().Remove(entity);
					((DbContext)(object)context).SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public FraudSetup InsertUpdateFraudSetup(FraudSetup claims)
		{
			FraudSetup claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<FraudSetup>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<FraudSetup>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<FraudSetup> LoadFraudSetup(int? Id, int? ScoreFrom = null, int? ScoreTo = null)
		{
			List<FraudSetup> lsClaims = new List<FraudSetup>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<FraudSetup> source = ((DbContext)(object)context).Set<FraudSetup>().AsQueryable();
					if (ScoreFrom.HasValue && ScoreTo.HasValue)
					{
						Id = (Id.HasValue ? Id : new int?(0));
						lsClaims = source.Where((FraudSetup x) => x.ScoreFrom >= ((int?)ScoreFrom).Value && x.ScoreTo <= ((int?)ScoreTo).Value && x.Id != ((int?)Id).Value).ToList();
					}
					else if (Id.HasValue)
					{
						lsClaims = source.Where((FraudSetup x) => (int?)x.Id == Id).ToList();
					}
					else
					{
						lsClaims = source.ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<FraudSetup>)null;
				}
			});
		}

		public bool DeleteFraudSetup(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					FraudSetup entity = (from p in ((DbContext)(object)context).Set<FraudSetup>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<FraudSetup>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public ProductionInfo InsertUpdateProductionInfo(ProductionInfo claims)
		{
			ProductionInfo claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<ProductionInfo>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<ProductionInfo>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<ProductionInfo> LoadProductionInfo(long? Id, string? OwnerId, int? PolicyId)
		{
			string OwnerId2 = OwnerId;
			List<ProductionInfo> lsClaims = new List<ProductionInfo>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<ProductionInfo> source = ((DbContext)(object)context).Set<ProductionInfo>().AsQueryable();
					if (Id.HasValue && Id.Value > 0)
					{
						lsClaims = source.Where((ProductionInfo x) => (long?)(long)x.Id == Id).ToList();
					}
					if (!string.IsNullOrEmpty(OwnerId2))
					{
						lsClaims = lsClaims.Where((ProductionInfo p) => p.OwnerId == OwnerId2).ToList();
					}
					if (PolicyId.HasValue && PolicyId.Value > 0)
					{
						lsClaims = source.Where((ProductionInfo x) => x.PolicyId == ((int?)PolicyId).Value).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<ProductionInfo>)null;
				}
			});
		}

		public bool DeleteProductionInfo(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					ProductionInfo entity = (from p in ((DbContext)(object)context).Set<ProductionInfo>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<ProductionInfo>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public VehiclesInfo InsertUpdateVehicleInfo(VehiclesInfo claims)
		{
			VehiclesInfo claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<VehiclesInfo>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<VehiclesInfo>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<VehiclesInfo> LoadVehicleInfo(long? Id, string? Sequence)
		{
			string Sequence2 = Sequence;
			List<VehiclesInfo> lsClaims = new List<VehiclesInfo>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<VehiclesInfo> source = ((DbContext)(object)context).Set<VehiclesInfo>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((VehiclesInfo x) => (long?)(long)x.Id == Id).ToList();
					}
					if (!string.IsNullOrEmpty(Sequence2))
					{
						lsClaims = lsClaims.Where((VehiclesInfo p) => p.SequanceNo == Sequence2).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<VehiclesInfo>)null;
				}
			});
		}

		public bool DeleteVehicleInfo(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					VehiclesInfo entity = (from p in ((DbContext)(object)context).Set<VehiclesInfo>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<VehiclesInfo>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public VehileCovers InsertUpdateVehileCovers(VehileCovers claims)
		{
			VehileCovers claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<VehileCovers>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<VehileCovers>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<VehileCovers> LoadVehileCovers(long? Id, int? PolicyId)
		{
			List<VehileCovers> lsClaims = new List<VehileCovers>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<VehileCovers> source = ((DbContext)(object)context).Set<VehileCovers>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((VehileCovers x) => (long?)(long)x.Id == Id).ToList();
					}
					if (PolicyId.HasValue)
					{
						lsClaims = lsClaims.Where((VehileCovers p) => p.PolicyId == PolicyId).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<VehileCovers>)null;
				}
			});
		}

		public bool DeleteVehileCovers(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					VehileCovers entity = (from p in ((DbContext)(object)context).Set<VehileCovers>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<VehileCovers>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public WorkFlowApprovers InsertWorkFlowApprovers(WorkFlowApprovers claims)
		{
			WorkFlowApprovers claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<WorkFlowApprovers>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<WorkFlowApprovers>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<WorkFlowApprovers> LoadWorkFlowApprovers(long? Id, int? StageId)
		{
			List<WorkFlowApprovers> lsClaims = new List<WorkFlowApprovers>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<WorkFlowApprovers> source = ((DbContext)(object)context).Set<WorkFlowApprovers>().AsQueryable();
					if (Id.HasValue && Id.Value > 0)
					{
						lsClaims = source.Where((WorkFlowApprovers x) => (long)x.Id == ((long?)Id).Value).ToList();
					}
					else if (StageId.HasValue && StageId.Value > 0)
					{
						lsClaims = source.Where((WorkFlowApprovers p) => p.StageId == ((int?)StageId).Value).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<WorkFlowApprovers>)null;
				}
			});
		}

		public bool DeleteWorkFlowApprovers(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					WorkFlowApprovers entity = (from p in ((DbContext)(object)context).Set<WorkFlowApprovers>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<WorkFlowApprovers>().Remove(entity);
					((DbContext)(object)context).SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public WorkFlowHistory InsertWorkFlowHistory(WorkFlowHistory claims)
		{
			WorkFlowHistory claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<WorkFlowHistory>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<WorkFlowHistory>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public WorkFlowStages InsertWorkFlowDelegation(WorkFlowStages claims)
		{
			WorkFlowStages claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<WorkFlowStages>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<WorkFlowStages>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<WorkFlowHistory> LoadWorkFlowHistory(long? Id, int? ClaimId)
		{
			List<WorkFlowHistory> lsClaims = new List<WorkFlowHistory>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<WorkFlowHistory> source = ((DbContext)(object)context).Set<WorkFlowHistory>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((WorkFlowHistory x) => (long?)(long)x.Id == Id).ToList();
					}
					if (ClaimId.HasValue)
					{
						lsClaims = lsClaims.Where((WorkFlowHistory p) => p.ClaimId == ClaimId).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<WorkFlowHistory>)null;
				}
			});
		}

		public bool DeleteWorkFlowHistory(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					WorkFlowHistory entity = (from p in ((DbContext)(object)context).Set<WorkFlowHistory>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<WorkFlowHistory>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public List<WorkFlowStages> LoadWorkFlowStages(long? Id, string? Name = null)
		{
			string Name2 = Name;
			List<WorkFlowStages> lsClaims = new List<WorkFlowStages>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<WorkFlowStages> source = ((DbContext)(object)context).Set<WorkFlowStages>().AsQueryable();
					if (Id.HasValue && Id.Value > 0)
					{
						lsClaims = source.Where((WorkFlowStages x) => (long?)(long)x.Id == Id).ToList();
					}
					else if (!string.IsNullOrEmpty(Name2))
					{
						lsClaims = source.Where((WorkFlowStages x) => x.StageName.ToUpper().Contains(Name2.ToUpper())).ToList();
					}
					else
					{
						lsClaims = source.ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<WorkFlowStages>)null;
				}
			});
		}

		public bool DeleteWorkFlowStages(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					WorkFlowStages entity = (from p in ((DbContext)(object)context).Set<WorkFlowStages>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<WorkFlowStages>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public WorkFlowHistoryDetails InsertUpdateWorkFlowHistoryDetails(WorkFlowHistoryDetails claims)
		{
			WorkFlowHistoryDetails claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<WorkFlowHistoryDetails>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<WorkFlowHistoryDetails>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<WorkFlowHistoryDetails> LoadWorkFlowHistoryDetails(long? Id, int? Status)
		{
			List<WorkFlowHistoryDetails> lsClaims = new List<WorkFlowHistoryDetails>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<WorkFlowHistoryDetails> source = ((DbContext)(object)context).Set<WorkFlowHistoryDetails>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((WorkFlowHistoryDetails x) => (long?)(long)x.Id == Id).ToList();
					}
					if (Status.HasValue)
					{
						lsClaims = lsClaims.Where((WorkFlowHistoryDetails p) => p.Status == Status).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<WorkFlowHistoryDetails>)null;
				}
			});
		}

		public bool DeleteWorkFlowHistoryDetails(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					WorkFlowHistoryDetails entity = (from p in ((DbContext)(object)context).Set<WorkFlowHistoryDetails>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<WorkFlowHistoryDetails>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public WorkFlowReassign InsertUpdateWorkFlowReassign(WorkFlowReassign claims)
		{
			WorkFlowReassign claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<WorkFlowReassign>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<WorkFlowReassign>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<WorkFlowReassign> LoadWorkFlowReassign(long? Id, string? AssignTo)
		{
			string AssignTo2 = AssignTo;
			List<WorkFlowReassign> lsClaims = new List<WorkFlowReassign>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					IQueryable<WorkFlowReassign> source = ((DbContext)(object)context).Set<WorkFlowReassign>().AsQueryable();
					if (Id.HasValue)
					{
						lsClaims = source.Where((WorkFlowReassign x) => (long?)(long)x.Id == Id).ToList();
					}
					if (!string.IsNullOrEmpty(AssignTo2))
					{
						lsClaims = lsClaims.Where((WorkFlowReassign p) => p.AssignTo == AssignTo2).ToList();
					}
					return lsClaims;
				}
				catch (Exception)
				{
					return (List<WorkFlowReassign>)null;
				}
			});
		}

		public bool DeleteWorkFlowReassign(long Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					WorkFlowReassign entity = (from p in ((DbContext)(object)context).Set<WorkFlowReassign>()
						where (long)p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<WorkFlowReassign>().Remove(entity);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public DelegationSetup InsertUpdateDelegation(DelegationSetup claims)
		{
			DelegationSetup claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<DelegationSetup>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<DelegationSetup>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<DelegationSetup> LoadDelegation(int? Id, int? Status = null)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<DelegationSetup> list = new List<DelegationSetup>();
				try
				{
					list = ((Id.HasValue && Id.Value > 0) ? (from x in ((DbContext)(object)context).Set<DelegationSetup>()
						where x.Id == ((int?)Id).Value
						select x).ToList() : ((!Status.HasValue) ? ((DbContext)(object)context).Set<DelegationSetup>().ToList() : ((Status.Value != 1) ? (from x in ((DbContext)(object)context).Set<DelegationSetup>()
						where x.To < DateTime.Now
						select x).ToList() : (from x in ((DbContext)(object)context).Set<DelegationSetup>()
						where x.To >= DateTime.Now
						select x).ToList())));
					((DbContext)(object)context).SaveChanges();
					return list;
				}
				catch (Exception)
				{
					return (List<DelegationSetup>)null;
				}
			});
		}

		public List<AuthorityMatrix> LoadAuthorityMatrix(int? Id, int? ModuleId = null)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<AuthorityMatrix> list = new List<AuthorityMatrix>();
				try
				{
					list = ((Id.HasValue && Id.Value > 0) ? (from x in ((DbContext)(object)context).Set<AuthorityMatrix>()
						where x.Id == ((int?)Id).Value
						select x).ToList() : ((!ModuleId.HasValue || ModuleId.Value <= 0) ? ((DbContext)(object)context).Set<AuthorityMatrix>().ToList() : (from x in ((DbContext)(object)context).Set<AuthorityMatrix>()
						where x.ModuleId == ((int?)ModuleId).Value
						select x).ToList()));
					((DbContext)(object)context).SaveChanges();
					return list;
				}
				catch (Exception)
				{
					return (List<AuthorityMatrix>)null;
				}
			});
		}

		public bool DeleteDelegation(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					DelegationSetup entity = (from p in ((DbContext)(object)context).Set<DelegationSetup>()
						where p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<DelegationSetup>().Remove(entity);
					((DbContext)(object)context).SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public DocumentInfo InsertUpdateDocuments(DocumentInfo claims)
		{
			DocumentInfo claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<DocumentInfo>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<DocumentInfo>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public AuthorityMatrix InsertUpdateAuthorityMatrix(AuthorityMatrix claims)
		{
			AuthorityMatrix claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<AuthorityMatrix>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<AuthorityMatrix>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public Attachments InsertUpdateAttachments(Attachments claims)
		{
			Attachments claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<Attachments>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<Attachments>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public Survoyer InsertUpdateSurvoyerEntry(Survoyer claims)
		{
			Survoyer claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<Survoyer>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<Survoyer>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public WorkFlowApprovers InsertUpdateWorkflowApprover(WorkFlowApprovers claims)
		{
			WorkFlowApprovers claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (claims2.Id > 0)
					{
						((DbContext)(object)context).Set<WorkFlowApprovers>().Update(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					else
					{
						((DbContext)(object)context).Set<WorkFlowApprovers>().Add(claims2);
						((DbContext)(object)context).SaveChanges();
					}
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public List<DocumentInfo> LoadDocuments(int? Id, int? ModuleId = null)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<DocumentInfo> list = new List<DocumentInfo>();
				try
				{
					return (Id.HasValue && Id.Value > 0) ? (from x in ((DbContext)(object)context).Set<DocumentInfo>()
						where x.Id == ((int?)Id).Value
						select x).ToList() : ((!ModuleId.HasValue || ModuleId.Value <= 0) ? ((DbContext)(object)context).Set<DocumentInfo>().ToList() : (from x in ((DbContext)(object)context).Set<DocumentInfo>()
						where x.ModuleId == ((int?)ModuleId).Value
						select x).ToList());
				}
				catch (Exception)
				{
					return (List<DocumentInfo>)null;
				}
			});
		}

		public List<Attachments> LoadAttachments(int? Id, int? ModuleId = null)
		{
			return Action(delegate(DataBaseContext context)
			{
				List<Attachments> result = new List<Attachments>();
				try
				{
					if (Id.HasValue && Id.Value > 0)
					{
						result = (from x in ((DbContext)(object)context).Set<Attachments>()
							where x.Id == ((int?)Id).Value
							select x).ToList();
					}
					else if (ModuleId.HasValue && ModuleId.Value > 0)
					{
						result = (from x in ((DbContext)(object)context).Set<Attachments>()
							where x.ModuleId == ((int?)ModuleId).Value
							select x).ToList();
					}
					return result;
				}
				catch (Exception)
				{
					return (List<Attachments>)null;
				}
			});
		}

		public bool DeleteDocument(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					DocumentInfo entity = (from p in ((DbContext)(object)context).Set<DocumentInfo>()
						where p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<DocumentInfo>().Remove(entity);
					((DbContext)(object)context).SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public bool DeleteAttachment(int Id)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					Attachments entity = (from p in ((DbContext)(object)context).Set<Attachments>()
						where p.Id == Id
						select p).FirstOrDefault();
					((DbContext)(object)context).Set<Attachments>().Remove(entity);
					((DbContext)(object)context).SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public ClaimSearchResult claimSearch(SearchingObj obj, string connection)
		{
			string connection2 = connection;
			SearchingObj obj2 = obj;
			ClaimSearchResult claimSearchResult = new ClaimSearchResult();
			claimSearchResult.Productions = new List<Production>();
			Production productionObj = new Production();
			productionObj.Vehicles = new List<VehicleInfos>();
			DataTable oDataTable = new DataTable();
			return Action(delegate(DataBaseContext context)
			{
				DataBaseContext context2 = context;
				try
				{
					List<int> list = new List<int>();
					List<int> list2 = new List<int>();
					using (SqlConnection sqlConnection = new SqlConnection(connection2))
					{
						SqlCommand sqlCommand = new SqlCommand();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
						sqlCommand = new SqlCommand("SearchClaim", sqlConnection);
						sqlCommand.CommandType = CommandType.StoredProcedure;
						sqlCommand.Parameters.AddWithValue("@PlateNo", (!string.IsNullOrEmpty(obj2.PlateNo)) ? obj2.PlateNo : null);
						sqlCommand.Parameters.AddWithValue("@Sequence", (!string.IsNullOrEmpty(obj2.SequenceNo)) ? obj2.SequenceNo : null);
						sqlCommand.Parameters.AddWithValue("@ClaimNo", (!string.IsNullOrEmpty(obj2.ClaimNo)) ? obj2.ClaimNo : null);
						sqlCommand.Parameters.AddWithValue("@NationalId", (!string.IsNullOrEmpty(obj2.NationalId)) ? obj2.NationalId : null);
						sqlCommand.Parameters.AddWithValue("@MobileNo", (!string.IsNullOrEmpty(obj2.MobileNo)) ? obj2.MobileNo : null);
						sqlCommand.Parameters.AddWithValue("@ComplainNo", (!string.IsNullOrEmpty(obj2.ComplainNo)) ? obj2.ComplainNo : null);
						sqlCommand.Parameters.AddWithValue("@CustomNo", (!string.IsNullOrEmpty(obj2.CustomNo)) ? obj2.CustomNo : null);
						sqlCommand.Parameters.AddWithValue("@ChassisNo", (!string.IsNullOrEmpty(obj2.ChassisNo)) ? obj2.ChassisNo : null);
						sqlCommand.Parameters.AddWithValue("@PolicyNo", (!string.IsNullOrEmpty(obj2.PolicyNo)) ? obj2.PolicyNo : null);
						sqlConnection.Open();
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						while (sqlDataReader.Read())
						{
							ProductionInfo production = new ProductionInfo();
							production.Id = Convert.ToInt32(sqlDataReader["PolicyId"].ToString());
							if (list.Count == 0 || list.Where((int p) => p == production.Id).ToList().Count == 0)
							{
								if (productionObj != null && productionObj.policy != null && productionObj.policy.Id > 0)
								{
									claimSearchResult.Productions.Add(productionObj);
									productionObj = new Production();
								}
								production.PolicyNumber = sqlDataReader["PolicyNumber"].ToString();
								production.PolicyType = Convert.ToInt32(sqlDataReader["PolicyType"].ToString());
								production.PolicyEffectiveDate = Convert.ToDateTime(sqlDataReader["PolicyEffectiveDate"].ToString());
								production.PolicyExpiryDate = Convert.ToDateTime(sqlDataReader["PolicyExpiryDate"].ToString());
								production.OwnerId = sqlDataReader["OwnerId"].ToString();
								production.OwnerName = sqlDataReader["OwnerName"].ToString();
								production.PolicyIssueDate = Convert.ToDateTime(sqlDataReader["PolicyIssueDate"].ToString());
								production.PolicyId = Convert.ToInt32(sqlDataReader["PolicyId"].ToString());
								production.BusinessType = sqlDataReader["BusinessType"].ToString();
								production.PolicyUWYear = Convert.ToInt32(sqlDataReader["PolicyUWYear"].ToString());
								production.TransferDate = Convert.ToDateTime(sqlDataReader["TransferDate"].ToString());
								production.LesseeName = sqlDataReader["LesseeName"].ToString();
								production.LesseeId = sqlDataReader["LesseeId"].ToString();
								production.BenefecieryName = sqlDataReader["BenefecieryName"].ToString();
								production.BusinessTypeId = Convert.ToInt32(sqlDataReader["BusinessTypeId"].ToString());
								production.BranchId = Convert.ToInt32(sqlDataReader["BranchId"].ToString());
								production.BranchName = sqlDataReader["BranchName"].ToString();
								production.InsuredId = Convert.ToInt32(sqlDataReader["InsuredId"].ToString());
								production.Insured = sqlDataReader["Insured"].ToString();
								production.PolicyTypeName = sqlDataReader["PolicyTypeName"].ToString();
								productionObj.policy = production;
								list.Add(production.Id);
							}
							VehicleInfos infos = new VehicleInfos();
							VehiclesInfo vehicleInfo = new VehiclesInfo();
							vehicleInfo.Id = Convert.ToInt32(sqlDataReader["RiskId"].ToString());
							if (list2.Count == 0 || list2.Where((int p) => p == vehicleInfo.Id).ToList().Count == 0)
							{
								vehicleInfo.PolicyId = Convert.ToInt32(sqlDataReader["PolicyId"].ToString());
								vehicleInfo.SequanceNo = sqlDataReader["SequanceNo"].ToString();
								vehicleInfo.CustomNo = sqlDataReader["CustomNo"].ToString();
								vehicleInfo.ChassisNo = sqlDataReader["ChassisNo"].ToString();
								vehicleInfo.ManufactureYear = ((sqlDataReader["ManufactureYear"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["ManufactureYear"].ToString()) : 0);
								vehicleInfo.NoOfSeats = ((sqlDataReader["NoOfSeats"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["NoOfSeats"].ToString()) : 0);
								vehicleInfo.PlateNo = sqlDataReader["PlateNo"].ToString();
								string text = sqlDataReader["DeductibleAmount"].ToString();
								vehicleInfo.DeductibleAmount = ((sqlDataReader["DeductibleAmount"] != DBNull.Value) ? Convert.ToInt32(Convert.ToDecimal(sqlDataReader["DeductibleAmount"].ToString())) : 0);
								vehicleInfo.Color = sqlDataReader["Color"].ToString();
								vehicleInfo.Make = sqlDataReader["Make"].ToString();
								vehicleInfo.Model = sqlDataReader["Model"].ToString();
								vehicleInfo.VehicleBody = sqlDataReader["VehicleBody"].ToString();
								vehicleInfo.NoOfCoveredPassegers = ((sqlDataReader["NoOfCoveredPassegers"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["NoOfCoveredPassegers"].ToString()) : 0);
								vehicleInfo.TransferDate = Convert.ToDateTime(sqlDataReader["TransferDate"].ToString());
								vehicleInfo.VehicleEffectiveDate = Convert.ToDateTime(sqlDataReader["VehicleEffectiveDate"].ToString());
								vehicleInfo.VehicleExpiryDate = Convert.ToDateTime(sqlDataReader["VehicleExpiryDate"].ToString());
								vehicleInfo.SumInsured = ((sqlDataReader["SumInsured"] != DBNull.Value) ? Convert.ToInt32(Convert.ToDecimal(sqlDataReader["SumInsured"].ToString())) : 0);
								vehicleInfo.MakeDesc = sqlDataReader["MakeDesc"].ToString();
								vehicleInfo.ModelDesc = sqlDataReader["ModelDesc"].ToString();
								vehicleInfo.BodyDesc = sqlDataReader["BodyDesc"].ToString();
								vehicleInfo.usageDesc = sqlDataReader["usageDesc"].ToString();
								vehicleInfo.colorDesc = sqlDataReader["colorDesc"].ToString();
								vehicleInfo.RepairCondition = Convert.ToInt32(sqlDataReader["RepairCondition"].ToString());
								vehicleInfo.RepairDesc = sqlDataReader["RepairDesc"].ToString();
								vehicleInfo.Name = sqlDataReader["Name"].ToString();
								infos.Vehicle = vehicleInfo;
								infos.lsClaims = new List<Claims>();
								List<ClaimVehicle> list3 = (from p in ((DbContext)(object)context2).Set<ClaimVehicle>()
									where p.RiskId == vehicleInfo.Id && p.PolicyId == (long)vehicleInfo.PolicyId
									select p).ToList();
								list3.ForEach(delegate(ClaimVehicle item)
								{
									List<Claims> list4 = (from p in ((DbContext)(object)context2).Set<Claims>()
										where p.Id == item.ClaimId
										select p).ToList();
									if (list4 != null && list4.Count > 0)
									{
										infos.lsClaims.AddRange(list4);
									}
								});
								productionObj.Vehicles.Add(infos);
								list2.Add(vehicleInfo.Id);
							}
						}
						sqlConnection.Close();
						if (productionObj.Vehicles.Count > 0)
						{
							claimSearchResult.Productions.Add(productionObj);
						}
					}
					return claimSearchResult;
				}
				catch (Exception)
				{
					return (ClaimSearchResult)null;
				}
			});
		}

		public bool MigrationClaim(string connection, string? PolicyNo, DateTime? Date)
		{
			string connection2 = connection;
			string PolicyNo2 = PolicyNo;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					List<int> list = new List<int>();
					using (OracleConnection oracleConnection = new OracleConnection(connection2))
					{
						OracleCommand oracleCommand = new OracleCommand();
						oracleCommand.Connection = oracleConnection;
						oracleCommand.CommandType = CommandType.StoredProcedure;
						oracleCommand.CommandText = "IGENERAL.MIGRATE_POLICY_CLAIMS";
						oracleCommand.Parameters.Add("P_SEGMENT_CODE", OracleDbType.Varchar2).Value = ((!string.IsNullOrEmpty(PolicyNo2)) ? ((IConvertible)PolicyNo2) : ((IConvertible)DBNull.Value));
						oracleCommand.Parameters.Add("P_DATE", OracleDbType.Date).Value = (Date.HasValue ? ((object)Date) : DBNull.Value);
						oracleCommand.Parameters.Add("P_REF_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
						oracleConnection.Open();
						OracleDataReader adapter = oracleCommand.ExecuteReader();
						while (adapter.Read())
						{
							if (list.Count == 0 || list.Where((int p) => p == Convert.ToInt32(adapter["Id"].ToString())).ToList().Count == 0)
							{
								ProductionInfo productionInfo = new ProductionInfo
								{
									PolicyId = Convert.ToInt32(adapter["Id"].ToString()),
									PolicyNumber = adapter["SEGMENT_CODE"].ToString(),
									PolicyType = Convert.ToInt32(adapter["GST_PLT_CODE"].ToString()),
									PolicyEffectiveDate = Convert.ToDateTime(adapter["EFFECTIVE_DATE"].ToString()),
									PolicyExpiryDate = Convert.ToDateTime(adapter["POL_EXP_DATE"].ToString()),
									OwnerId = adapter["OWNER_ID"].ToString(),
									OwnerName = adapter["OWNER_NAME"].ToString(),
									PolicyIssueDate = Convert.ToDateTime(adapter["POL_ISSUE_DATE"].ToString()),
									BusinessType = "Direct",
									PolicyUWYear = Convert.ToInt32(adapter["UW_YEAR"].ToString()),
									TransferDate = Convert.ToDateTime(adapter["POL_ISSUE_DATE"].ToString()),
									LesseeName = adapter["OWNER_NAME"].ToString(),
									LesseeId = adapter["OWNER_ID"].ToString(),
									BenefecieryName = adapter["OWNER_ID"].ToString(),
									BusinessTypeId = 1,
									BranchId = Convert.ToInt32(adapter["CRG_BRN_ID"].ToString()),
									BranchName = adapter["BRANCH_NAME"].ToString(),
									InsuredId = Convert.ToInt32(adapter["OWNER_ID"].ToString()),
									Insured = adapter["OWNER_NAME"].ToString(),
									PolicyTypeName = adapter["POLICY_TYPE_NAME"].ToString()
								};
								list.Add(productionInfo.PolicyId);
								((DbContext)(object)context).Set<ProductionInfo>().Add(productionInfo);
								((DbContext)(object)context).SaveChanges();
							}
							VehiclesInfo entity = new VehiclesInfo
							{
								PolicyId = Convert.ToInt32(adapter["Id"].ToString()),
								SequanceNo = adapter["MT_SEQUENCE_NO"].ToString(),
								CustomNo = "",
								ChassisNo = adapter["MT_CHASSIS_NO"].ToString(),
								ManufactureYear = 2020,
								NoOfSeats = 5,
								PlateNo = adapter["MT_PLATE_NO"].ToString(),
								DeductibleAmount = 0,
								Color = adapter["MT_COLOR"].ToString(),
								Make = adapter["MT_VEHICLE_TYPE"].ToString(),
								Model = adapter["MT_VEHICLE_MODEL"].ToString(),
								VehicleBody = adapter["VEHICLE_BODY"].ToString(),
								NoOfCoveredPassegers = 5,
								TransferDate = Convert.ToDateTime(adapter["VEH_EFFECTIVE"].ToString()),
								VehicleEffectiveDate = Convert.ToDateTime(adapter["VEH_EFFECTIVE"].ToString()),
								VehicleExpiryDate = Convert.ToDateTime(adapter["VEH_EXPIRY_DATE"].ToString()),
								SumInsured = ((adapter["SUMINSURED_LC"] != DBNull.Value) ? Convert.ToInt32(adapter["SUMINSURED_LC"].ToString()) : 0),
								MakeDesc = adapter["VEHICLE_MAKE"].ToString(),
								ModelDesc = adapter["VEHICLE_MODEL"].ToString(),
								BodyDesc = adapter["VEHICLE_BODY"].ToString(),
								usageDesc = adapter["VEHICLE_USAGE"].ToString(),
								colorDesc = adapter["COLOR"].ToString(),
								RepairCondition = ((adapter["MT_REPAIR_CONDITION"] != DBNull.Value) ? Convert.ToInt32(adapter["MT_REPAIR_CONDITION"].ToString()) : 0),
								RepairDesc = adapter["REPAIR_DESC"].ToString(),
								Name = adapter["VEH_NAME"].ToString()
							};
							((DbContext)(object)context).Set<VehiclesInfo>().Add(entity);
							((DbContext)(object)context).SaveChanges();
						}
						oracleConnection.Close();
					}
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public NajmResponse LoadNajmData(string AccidentCode)
		{
			string AccidentCode2 = AccidentCode;
			return Action(delegate(DataBaseContext context)
			{
				NajmResponse najmResponse = new NajmResponse();
				try
				{
					najmResponse.najmAccidentinfo = new NajmAccidentinfo();
					najmResponse.najmAccidentinfo = (from p in ((DbContext)(object)context).Set<NajmAccidentinfo>()
						where p.caseNumber.ToUpper() == AccidentCode2.ToUpper()
						select p).FirstOrDefault();
					if (najmResponse.najmAccidentinfo != null && najmResponse.najmAccidentinfo.Id > 0)
					{
						najmResponse.lsNajmPartiesInfo = new List<NajmPartiesInfo>();
						najmResponse.lsNajmPartiesInfo = (from p in ((DbContext)(object)context).Set<NajmPartiesInfo>()
							where p.caseNumber.Trim().ToUpper() == AccidentCode2.ToUpper()
							select p).ToList();
						najmResponse.najmDamageInfos = new List<NajmDamageInfo>();
						najmResponse.najmDamageInfos = (from p in ((DbContext)(object)context).Set<NajmDamageInfo>()
							where p.caseNumber.Trim().ToUpper() == AccidentCode2.ToUpper()
							select p).ToList();
						najmResponse.najmImageInfos = new List<NajmImageInfo>();
						najmResponse.najmImageInfos = (from p in ((DbContext)(object)context).Set<NajmImageInfo>()
							where p.CaseNumber.Trim().ToUpper() == AccidentCode2.ToUpper()
							select p).ToList();
						najmResponse.partyInsuranceInfos = new List<PartyInsuranceInfo>();
						najmResponse.partyInsuranceInfos = (from p in ((DbContext)(object)context).Set<PartyInsuranceInfo>()
							where p.caseNumber.Trim().ToUpper() == AccidentCode2.ToUpper()
							select p).ToList();
					}
				}
				catch (Exception)
				{
				}
				return najmResponse;
			});
		}

		public TaqdeerResponse LoadTaqdeer(string DACaseNo)
		{
			string DACaseNo2 = DACaseNo;
			return Action(delegate(DataBaseContext context)
			{
				TaqdeerResponse taqdeerResponse = new TaqdeerResponse
				{
					TaqdeerCase = new TaqdeerCase()
				};
				try
				{
					taqdeerResponse.TaqdeerCase = (from p in ((DbContext)(object)context).Set<TaqdeerCase>()
						where p.DACaseNumber.ToUpper() == DACaseNo2.ToUpper()
						select p).FirstOrDefault();
					if (taqdeerResponse.TaqdeerCase != null && !string.IsNullOrEmpty(taqdeerResponse.TaqdeerCase.DACaseNumber))
					{
						taqdeerResponse.SpareParts = new List<TaqdeerSparePartsInfo>();
						taqdeerResponse.SpareParts = (from p in ((DbContext)(object)context).Set<TaqdeerSparePartsInfo>()
							where p.DACaseNumber.ToUpper() == DACaseNo2.ToUpper()
							select p).ToList();
						taqdeerResponse.Fees = new List<TaqdeerFeesDetail>();
						taqdeerResponse.Fees = (from p in ((DbContext)(object)context).Set<TaqdeerFeesDetail>()
							where p.DACaseNumber.ToUpper() == DACaseNo2.ToUpper()
							select p).ToList();
						taqdeerResponse.taqdeerImageDetailas = new List<TaqdeerImageDetaila>();
						taqdeerResponse.taqdeerImageDetailas = (from p in ((DbContext)(object)context).Set<TaqdeerImageDetaila>()
							where p.DACaseNumber.ToUpper() == DACaseNo2.ToUpper()
							select p).ToList();
					}
				}
				catch (Exception)
				{
					throw;
				}
				return taqdeerResponse;
			});
		}

		public Survoyer InsertUpdateSurvoyer(Survoyer survoyer)
		{
			Survoyer survoyer2 = survoyer;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (survoyer2.Id > 0)
					{
						((DbContext)(object)context).Set<Survoyer>().Update(survoyer2);
					}
					else
					{
						((DbContext)(object)context).Set<Survoyer>().Add(survoyer2);
					}
					((DbContext)(object)context).SaveChanges();
					unitOfWork.SetToBeCommitted();
					return survoyer2;
				}
				catch (Exception)
				{
					return (Survoyer)null;
				}
			});
		}

		public List<Survoyer> LoadSurvoyer(int? survoyerId, long? ClaimID)
		{
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					return (from p in ((DbContext)(object)context).Set<Survoyer>()
						where (((int?)survoyerId).HasValue ? (p.Id == ((int?)survoyerId).Value) : (p.Id == p.Id)) && (((long?)ClaimID).HasValue ? (p.ClaimId == ((long?)ClaimID).Value) : (p.ClaimId == p.ClaimId))
						select p).ToList();
				}
				catch (Exception)
				{
					return (List<Survoyer>)null;
				}
			});
		}

		public List<LookupTable> LoadLookUp(SearchLookUp lookUp)
		{
			SearchLookUp lookUp2 = lookUp;
			List<LookupTable> lookupTables = new List<LookupTable>();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					if (lookUp2.MajorCode.HasValue)
					{
						lookupTables = (from p in ((DbContext)(object)context).Set<LookupTable>()
							where p.MajorCode == (int?)(int)lookUp2.MajorCode && ((lookUp2.Id.HasValue && lookUp2.Id.Value > 0) ? (p.Code == lookUp2.Id.Value.ToString()) : (p.Id == p.Id))
							orderby p.NameEnglish
							select p).ToList();
					}
					else
					{
						lookupTables = (from p in ((DbContext)(object)context).Set<LookupTable>()
							orderby p.NameEnglish
							select p).ToList();
					}
					if (lookUp2.ParentId.HasValue && lookUp2.ParentId > 0)
					{
						lookupTables = (from p in lookupTables
							where p.ParentId == lookUp2.ParentId.Value
							orderby p.NameEnglish
							select p).ToList();
					}
					return lookupTables;
				}
				catch (Exception)
				{
					return (List<LookupTable>)null;
				}
			});
		}

		public Reserve InsertReserve(Reserve claims)
		{
			Reserve claims2 = claims;
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					((DbContext)(object)context).Set<Reserve>().Add(claims2);
					((DbContext)(object)context).SaveChanges();
					return claims2;
				}
				catch (Exception)
				{
					return claims2;
				}
			});
		}

		public Claims UpdateAutoAssign(AutoAssignObj obj, string connection)
		{
			AutoAssignObj obj2 = obj;
			Claims claims = new Claims();
			if (obj2.Status == 0)
			{
				Action(delegate(DataBaseContext context)
				{
					ClaimStatusMapping claimStatusMapping = (from p in ((DbContext)(object)context).Set<ClaimStatusMapping>()
						where p.RoleId == obj2.RoleId
						select p).FirstOrDefault();
					obj2.Status = claimStatusMapping.ClaimStatus;
				});
			}
			using (SqlConnection oConnection = new SqlConnection(connection))
			{
				using SqlCommand oCommand = new SqlCommand();
				oCommand.Connection = oConnection;
				oCommand.CommandType = CommandType.StoredProcedure;
				oCommand.CommandText = "AssignWorkLoad";
				oCommand.Parameters.AddWithValue("@Status", obj2.Status);
				oCommand.Parameters.AddWithValue("@RoleId", obj2.RoleId);
				oCommand.Parameters.AddWithValue("@ClaimId", obj2.ClaimId);
				SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand);
				try
				{
					oConnection.Open();
					oCommand.ExecuteNonQuery();
				}
				catch (Exception)
				{
				}
				finally
				{
					((IDisposable)(object)oDataAdapter)?.Dispose();
				}
			}
			Action(delegate(DataBaseContext context)
			{
				claims = (from p in ((DbContext)(object)context).Set<Claims>()
					where p.Id == (long)obj2.ClaimId
					select p).FirstOrDefault();
			});
			return claims;
		}

		public DataTable ClaimsMigration(string connection)
		{
			DataTable dataTable = new DataTable();
			using (SqlConnection oConnection = new SqlConnection(connection))
			{
				using SqlCommand oCommand = new SqlCommand();
				oCommand.Connection = oConnection;
				oCommand.CommandType = CommandType.StoredProcedure;
				oCommand.CommandText = "ClaimsMigration";
				SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand);
				try
				{
					oConnection.Open();
					oDataAdapter.Fill(dataTable);
				}
				finally
				{
					((IDisposable)(object)oDataAdapter)?.Dispose();
				}
			}
			return dataTable;
		}

		public void UpdateClaimsMigration(int Id, string connection, int status)
		{
			DataTable dataTable = new DataTable();
			using SqlConnection oConnection = new SqlConnection(connection);
			using SqlCommand oCommand = new SqlCommand();
			oCommand.Connection = oConnection;
			oCommand.CommandType = CommandType.StoredProcedure;
			oCommand.CommandText = "UpdateClaimsMigration";
			oCommand.Parameters.Add("P_ID", SqlDbType.Int).Value = Id;
			oCommand.Parameters.Add("@P_Status", SqlDbType.Int).Value = status;
			SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand);
			try
			{
				oConnection.Open();
				oDataAdapter.Fill(dataTable);
			}
			finally
			{
				((IDisposable)(object)oDataAdapter)?.Dispose();
			}
		}

		public ClaimSubmissionDocuments LoadClaimSubmissionDocuments(ClaimSubmissionDocuments obj, string connection)
		{
			ClaimSubmissionDocuments claims = new ClaimSubmissionDocuments();
			DataTable dataTable = new DataTable();
			using (SqlConnection con = new SqlConnection(connection))
			{
				SqlCommand cmd = new SqlCommand();
				SqlDataAdapter da = new SqlDataAdapter();
				cmd = new SqlCommand("GetClaimsAttachments", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@P_eClaimId", obj.eClaimId);
				con.Open();
				SqlDataReader Reader = cmd.ExecuteReader();
				while (Reader.Read())
				{
					claims = new ClaimSubmissionDocuments
					{
						AcciedentReport = Reader["AcciedentReport"].ToString(),
						DA = Reader["DA"].ToString(),
						IBAN = Reader["IBAN"].ToString(),
						IstimaraCopy = Reader["IstimaraCopy"].ToString(),
						LicenseCopy = Reader["LicenseCopy"].ToString(),
						Others = Reader["Others"].ToString(),
						eClaimId = obj.eClaimId,
						Id = Convert.ToInt32(Reader["Id"].ToString())
					};
				}
				con.Close();
			}
			return claims;
		}

		public List<eClaims> LoadeClaims(eClaimsObj obj, string connection)
		{
			List<eClaims> claims = new List<eClaims>();
			try
			{
				using (SqlConnection con = new SqlConnection(connection))
				{
					SqlCommand cmd = new SqlCommand();
					SqlDataAdapter da = new SqlDataAdapter();
					cmd = new SqlCommand("SearcheClaims", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("Status", SqlDbType.Int).Value = (obj.Status.HasValue ? ((object)obj.Status.Value) : DBNull.Value);
					cmd.Parameters.Add("AccidentReport", SqlDbType.NVarChar).Value = ((!string.IsNullOrEmpty(obj.AccidentReport)) ? ((IConvertible)obj.AccidentReport) : ((IConvertible)DBNull.Value));
					cmd.Parameters.Add("Reference", SqlDbType.NVarChar).Value = ((!string.IsNullOrEmpty(obj.Reference)) ? ((IConvertible)obj.Reference) : ((IConvertible)DBNull.Value));
					cmd.Parameters.Add("SequenceNumber", SqlDbType.NVarChar).Value = ((!string.IsNullOrEmpty(obj.SequenceNumber)) ? ((IConvertible)obj.SequenceNumber) : ((IConvertible)DBNull.Value));
					cmd.Parameters.Add("TaqdeerNumber", SqlDbType.NVarChar).Value = ((!string.IsNullOrEmpty(obj.TaqdeerNumber)) ? ((IConvertible)obj.TaqdeerNumber) : ((IConvertible)DBNull.Value));
					cmd.Parameters.Add("OwnerNationalID", SqlDbType.NVarChar).Value = ((!string.IsNullOrEmpty(obj.OwnerNationalID)) ? ((IConvertible)obj.OwnerNationalID) : ((IConvertible)DBNull.Value));
					cmd.Parameters.Add("RegisteredFrom", SqlDbType.DateTime).Value = (obj.RegisteredFrom.HasValue ? ((object)obj.RegisteredFrom.Value) : DBNull.Value);
					cmd.Parameters.Add("RegisteredTo", SqlDbType.DateTime).Value = (obj.RegisteredTo.HasValue ? ((object)obj.RegisteredTo.Value) : DBNull.Value);
					con.Open();
					SqlDataReader Reader = cmd.ExecuteReader();
					while (Reader.Read())
					{
						claims.Add(new eClaims
						{
							InsuranceSurveyed = Convert.ToInt32(Reader["InsuranceSurveyed"]),
							Id = Convert.ToInt32(Reader["Id"]),
							InsuranceType = Convert.ToInt32(Reader["InsuranceType"]),
							RecoveryType = Convert.ToInt32(Reader["RecoveryType"]),
							CreationDate = Convert.ToDateTime(Reader["CreationDate"]),
							AccidentReport = Reader["AccidentReport"].ToString(),
							IBANNo = Reader["IBANNo"].ToString(),
							OwnerNationalID = Reader["OwnerNationalID"].ToString(),
							Reference = Reader["Reference"].ToString(),
							SequenceNumber = Reader["SequenceNumber"].ToString(),
							TaqdeerNumber = Reader["TaqdeerNumber"].ToString(),
							LicenseExpiryDate = ((Reader["LicenseExpiryDate"] == DBNull.Value) ? null : new DateTime?(Convert.ToDateTime(Reader["LicenseExpiryDate"])))
						});
					}
					con.Close();
				}
				return claims;
			}
			catch (Exception)
			{
				return claims;
			}
		}
	}
}
