using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CORE.DTOs.APIs;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.TP_Services;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.DTOs.Setups;
using CORE.Interfaces;
using CORE.Services;
using CORE.TablesObjects;
using DataAccessLayer;
using DataAccessLayer.Oracle.Eskadenia.Issuance;
using DataAccessLayer.Oracle.Eskadenia.Setups;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure.Services
{
    public class Business : Svc, IBusiness, ISvc
    {
        public Business(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
            : base(unitOfWork)
        {
        }

        public bool InsertWatheqData(CRDetails details)
        {
            CRDetails details2 = details;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    ((DbContext)(object)context).Set<CRDetails>().Add(details2);
                    ((DbContext)(object)context).SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public CRDetails getCRDetails(string CR)
        {
            string CR2 = CR;
            CRDetails details = new CRDetails();
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    details = (from p in ((DbContext)(object)context).Set<CRDetails>()
                               where p.CRENTITYNO == CR2.Trim()
                               select p).FirstOrDefault();
                    return details;
                }
                catch (Exception)
                {
                    return details;
                }
            });
        }

        public decimal? GetMMPPrice(MMPPricing obj)
        {
            MMPPricing obj2 = obj;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<MMPPricing>()
                            where p.Idemnity == obj2.Idemnity && p.Aggregator == obj2.Aggregator && (string.IsNullOrEmpty(obj2.Category) ? (p.Id == p.Id) : (p.Category == obj2.Category)) && (string.IsNullOrEmpty(obj2.Proffision) ? (p.Id == p.Id) : (p.Proffision == obj2.Proffision))
                            select p).FirstOrDefault()?.Gross;
                }
                catch (Exception)
                {
                    return (decimal?)null;
                }
            });
        }

        public (Production, string) InsertUpdateProduction(Production prod)
        {
            Production prod2 = prod;
            return Action(delegate (DataBaseContext context)
            {
                string item = string.Empty;
                try
                {
                    if (prod2 != null && prod2.Id > 0)
                    {
                        if (prod2.DocumentType == 2)
                        {
                            int num = (from p in ((DbContext)(object)context).Set<Production>()
                                       where p.PolicyId == prod2.PolicyId
                                       select p).Max((Production p) => p.EndtSerial);
                            ((DbContext)(object)context).SaveChanges();
                            prod2.EndtSerial = num + 1;
                        }
                        ((DbContext)(object)context).Set<Production>().Update(prod2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                    else
                    {
                        Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                                 where p.DocumentType != 2 && p.CustomerId == prod2.CustomerId && DateTime.Now.Date <= p.IssueDate.AddDays(p.Validity.Value) && p.ProductId == prod2.ProductId
                                                 select p).FirstOrDefault();
                        ((DbContext)(object)context).SaveChanges();
                        if (production != null && production.Id > 0 && prod2.DocumentType == 6)
                        {
                            item = "Customer has Draft on other User or Active policy";
                        }
                        else
                        {
                            int num2 = 0;
                            if (prod2.PolicyId.HasValue)
                            {
                                try
                                {
                                    num2 = (from p in ((DbContext)(object)context).Set<Production>()
                                            where p.PolicyId == prod2.PolicyId
                                            select p).Max((Production p) => p.EndtSerial);
                                    prod2.EndtSerial = num2 + 1;
                                }
                                catch (Exception)
                                {
                                    prod2.EndtSerial = 1;
                                }
                            }
                            ((DbContext)(object)context).Set<Production>().Add(prod2);
                            ((DbContext)(object)context).SaveChanges();
                            unitOfWork.SetToBeCommitted();
                        }
                    }
                    return (prod: prod2, item);
                }
                catch (Exception ex2)
                {
                    return (prod: prod2, ex2.Message);
                }
            });
        }

        public CRDetails LoadCRInfo(string cRDetails)
        {
            string cRDetails2 = cRDetails;
            CRDetails details = new CRDetails();
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    details = (from p in ((DbContext)(object)context).Set<CRDetails>().AsQueryable()
                               where p.CRENTITYNO.Trim().ToUpper() == cRDetails2.Trim().ToUpper()
                               select p).FirstOrDefault();
                    return details;
                }
                catch (Exception)
                {
                    return details;
                }
            });
        }

        public void CreateCommand(string connectionString)
        {
            string queryString = "update MPD_CLASS_PREMIUM set relation=2  where MPD_PCL_ID= 9188 and relation=3";
            using SqlConnection oConnection = new SqlConnection(connectionString);
            using SqlCommand oCommand = new SqlCommand();
            oCommand.Connection = oConnection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "update MPD_CLASS_PREMIUM set relation=2  where MPD_PCL_ID= 9188 and relation=3";
            oConnection.Open();
            oCommand.ExecuteNonQuery();
        }

        public (List<Subjects>, string) InsertUpdateMembers(List<Subjects> members, string connection)
        {
            List<Subjects> members2 = members;
            string connection2 = connection;
            Subjects MEM = new Subjects();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                string Error = string.Empty;
                try
                {
                    members2.ForEach(delegate (Subjects member)
                    {
                        Subjects member2 = member;
                        MEM = new Subjects();
                        if (member2.Id > 0)
                        {
                            MEM = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                   where p.Id == member2.Id
                                   select p).FirstOrDefault();
                            MEM.GrossAmount = member2.GrossAmount;
                            MEM.NetPremium = member2.NetPremium;
                            MEM.VAT = member2.VAT;
                            MEM.AdditionalPremium = member2.AdditionalPremium;
                            MEM.EffectiveDate = member2.EffectiveDate;
                            MEM.ExpiryDate = member2.ExpiryDate;
                            MEM.ClassId = member2.ClassId;
                            MEM.InsuranceClassCode = member2.InsuranceClassCode;
                            if (member2.ClassId == 1)
                            {
                            }
                            ((DbContext)(object)context2).Set<Subjects>().Update(MEM);
                            ((DbContext)(object)context2).SaveChanges();
                            unitOfWork.SetToBeCommitted();
                        }
                        else
                        {
                            MEM = member2;
                            //List<Occupations> list = Setups.loadOccupations(connection2, member2.Occupation);
                            //MEM.Occupation = ((list.Count > 0) ? list.FirstOrDefault().Id.ToString() : member2.Occupation);
                            //List<Occupations> list = Setups.loadOccupations(connection2, member2.Occupation);
                            MEM.Occupation = member2.Occupation;
                            Subjects Exists = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                               where p.NationalId == member2.NationalId && p.ExpiryDate >= DateTime.Now
                                               select p).FirstOrDefault();
                            ((DbContext)(object)context2).SaveChanges();
                            if (Exists != null && Exists.Id > 0)
                            {
                                Production production = (from p in ((DbContext)(object)context2).Set<Production>()
                                                         where p.Id == Exists.Id && (p.IsPaid == true || DateTime.Now <= p.IssueDate.AddDays(p.Validity.Value))
                                                         select p).FirstOrDefault();
                                if (production != null && production.Id > 0)
                                {
                                    Error = Error + "National Id " + member2.NationalId + " is already added on Document: " + production.SeqmentCode + " ";
                                }
                                else
                                {
                                    MEM.ClassId = member2.ClassId;
                                    ((DbContext)(object)context2).Set<Subjects>().Add(MEM);
                                    ((DbContext)(object)context2).SaveChanges();
                                    unitOfWork.SetToBeCommitted();
                                }
                            }
                            else
                            {
                                ((DbContext)(object)context2).Set<Subjects>().Add(MEM);
                                ((DbContext)(object)context2).SaveChanges();
                                unitOfWork.SetToBeCommitted();
                            }
                        }
                    });
                    return (members: members2, Error: Error);
                }
                catch (Exception)
                {
                    return (members: members2, Error: Error);
                }
            });
        }

        public List<Production> LoadProduction(string UserId)
        {
            string UserId2 = UserId;
            return Action(delegate (DataBaseContext context)
            {
                List<Production> list = new List<Production>();
                try
                {
                    int Id = Convert.ToInt32(UserId2);
                    List<Production> list2 = (from p in ((DbContext)(object)context).Set<Production>()
                                              where p.CreatedBy.Trim() == UserId2.Trim()
                                              select p).ToList();
                    if (list2.Count > 0)
                    {
                        list.AddRange(list2);
                    }
                    List<Users> list3 = (from p in ((DbContext)(object)context).Set<Users>()
                                         where p.ManagerId == (int?)Id
                                         select p).ToList();
                    foreach (Users current in list3)
                    {
                        List<Production> list4 = (from p in ((DbContext)(object)context).Set<Production>()
                                                  where p.CreatedBy.Trim() == UserId2.Trim()
                                                  select p).ToList();
                        if (list4.Count > 0)
                        {
                            list.AddRange(list2);
                        }
                    }
                    return list2;
                }
                catch (Exception)
                {
                    return (List<Production>)null;
                }
            });
        }

        public List<Production> LoadProductionBySegment(string Segment)
        {
            string Segment2 = Segment;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Production>()
                            where p.SeqmentCode.Trim() == Segment2.Trim()
                            select p).ToList();
                }
                catch (Exception)
                {
                    return (List<Production>)null;
                }
            });
        }

        public List<Production> LoadPendingForSyncProduction()
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Production>()
                            where p.IsPaid == false && p.PushToEska == (int?)2 && p.ProductId == 1 && p.EskaId == null
                            select p).ToList();
                }
                catch (Exception)
                {
                    return (List<Production>)null;
                }
            });
        }

        public List<Production> LoadProductionById(int Id, bool Eska)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Production>()
                            where p.IsPaid == false && p.Id == Id && (Eska ? (p.EskaId == null || p.EskaId == 0) : true)
                            select p).ToList();
                }
                catch (Exception)
                {
                    return (List<Production>)null;
                }
            });
        }

        public List<Policy> LoadPendingForSyncSubject()
        {
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                List<Policy> policies = new List<Policy>();
                try
                {
                    List<Production> list = (from p in ((DbContext)(object)context2).Set<Production>()
                                             where p.PushToYakeen == (int?)2
                                             select p).ToList();
                    list.ForEach(delegate (Production item)
                    {
                        List<Subjects> members = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                  where p.PolicyId == item.Id && p.PushedToYakeen == (bool?)false && p.NeedsReCalculation == (bool?)false
                                                  select p).ToList();
                        policies.Add(new Policy
                        {
                            Members = members,
                            production = item
                        });
                    });
                    return policies;
                }
                catch (Exception)
                {
                    return (List<Policy>)null;
                }
            });
        }

        public DocumentTree documentTreeTeamLeader(LoadDocumentTreeInput loadDocumentTreeInput)
        {
            LoadDocumentTreeInput loadDocumentTreeInput2 = loadDocumentTreeInput;
            DocumentTree documentTree = new DocumentTree();
            documentTree.Policies = new List<Policy>();
            documentTree.Quotations = new List<Policy>();
            documentTree.LatestTransactions = new List<Policy>();
            documentTree.LatestNotPayed = new List<Policy>();
#pragma warning disable CS8603 // Possible null reference return.
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    int teamleaderid = Convert.ToInt32(loadDocumentTreeInput2.UserId);
                    List<Users> list = (from p in ((DbContext)(object)context2).Set<Users>()
                                        where p.ManagerId == (int?)teamleaderid
                                        orderby p.Id descending
                                        select p).ToList();
                    list.ForEach(delegate (Users item)
                    {
                        List<Production> list2 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == item.Id.ToString().Trim() && p.DocumentType == 1 && p.IsPaid == true && p.ExpiryDate >= DateTime.Now
                                                  orderby p.Id descending
                                                  select p).ToList();
                        List<Production> list3 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == item.Id.ToString().Trim() && p.IsPaid == true
                                                  orderby p.CreationDate descending
                                                  select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                        List<Production> list4 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == item.Id.ToString().Trim() && p.IsPaid == false && DateTime.Now <= p.IssueDate.AddDays(p.Validity.Value)
                                                  orderby p.Id descending
                                                  select p).ToList();
                        list2.ForEach(delegate (Production doc)
                        {
                            Policy policy4 = new Policy();
                            policy4.Members = new List<Subjects>();
                            policy4.production = new Production();
                            List<Subjects> collection6 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            policy4.Members.AddRange(collection6);
                            policy4.production.Id = doc.Id;
                            policy4.production.ProductId = doc.ProductId;
                            policy4.production.CreatedBy = doc.CreatedBy;
                            policy4.production.CreationDate = doc.CreationDate;
                            policy4.production.DocumentType = doc.DocumentType;
                            policy4.production.EndtSerial = doc.EndtSerial;
                            policy4.production.UWYear = doc.UWYear;
                            policy4.production.SeqmentCode = doc.SeqmentCode;
                            policy4.production.IssueDate = doc.IssueDate;
                            policy4.production.EffectiveDate = doc.EffectiveDate;
                            policy4.production.ExpiryDate = doc.ExpiryDate;
                            policy4.production.InsuredName = doc.InsuredName;
                            policy4.production.AccountedFor = doc.AccountedFor;
                            policy4.production.GrossAmount = doc.GrossAmount;
                            policy4.production.TotalFees = doc.TotalFees;
                            policy4.production.CommissionAmount = doc.CommissionAmount;
                            policy4.production.VAT = doc.VAT;
                            policy4.production.DiscountAmount = doc.DiscountAmount;
                            policy4.production.LoadingAmount = doc.DiscountAmount;
                            policy4.production.NetPremium = doc.NetPremium;
                            policy4.production.PolicyId = doc.PolicyId;
                            policy4.production.QuotationId = doc.QuotationId;
                            policy4.production.CustomerId = doc.CustomerId;
                            policy4.production.PaymentMethod = doc.PaymentMethod;
                            policy4.production.OfficeId = doc.OfficeId;
                            policy4.production.Validity = doc.Validity;
                            policy4.production.IsPaid = doc.IsPaid;
                            policy4.production.ChartOfAccount = doc.ChartOfAccount;
                            policy4.production.PlanId = doc.PlanId;
                            policy4.production.CCHIPolicyNo = doc.CCHIPolicyNo;
                            policy4.production.Status = doc.Status;
                            policy4.Endors = new List<Endorsment>();
                            List<Production> list8 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                      where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.DocumentType == 3 && (long?)p.OrginalPolicy == doc.PolicyId
                                                      orderby p.Id descending
                                                      select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                            list8.ForEach(delegate (Production doc)
                            {
                                Endorsment endorsment3 = new Endorsment();
                                endorsment3.Members = new List<Subjects>();
                                endorsment3.Production = new Production();
                                List<Subjects> collection7 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                              where p.PolicyId == doc.Id
                                                              select p).ToList();
                                endorsment3.Members.AddRange(collection7);
                                endorsment3.Production.Id = doc.Id;
                                endorsment3.Production.ProductId = doc.ProductId;
                                endorsment3.Production.CreatedBy = doc.CreatedBy;
                                endorsment3.Production.CreationDate = doc.CreationDate;
                                endorsment3.Production.DocumentType = doc.DocumentType;
                                endorsment3.Production.EndtSerial = doc.EndtSerial;
                                endorsment3.Production.UWYear = doc.UWYear;
                                endorsment3.Production.SeqmentCode = doc.SeqmentCode;
                                endorsment3.Production.IssueDate = doc.IssueDate;
                                endorsment3.Production.EffectiveDate = doc.EffectiveDate;
                                endorsment3.Production.ExpiryDate = doc.ExpiryDate;
                                endorsment3.Production.InsuredName = doc.InsuredName;
                                endorsment3.Production.AccountedFor = doc.AccountedFor;
                                endorsment3.Production.GrossAmount = doc.GrossAmount;
                                endorsment3.Production.TotalFees = doc.TotalFees;
                                endorsment3.Production.CommissionAmount = doc.CommissionAmount;
                                endorsment3.Production.VAT = doc.VAT;
                                endorsment3.Production.DiscountAmount = doc.DiscountAmount;
                                endorsment3.Production.LoadingAmount = doc.DiscountAmount;
                                endorsment3.Production.NetPremium = doc.NetPremium;
                                endorsment3.Production.PolicyId = doc.PolicyId;
                                endorsment3.Production.QuotationId = doc.QuotationId;
                                endorsment3.Production.CustomerId = doc.CustomerId;
                                endorsment3.Production.PaymentMethod = doc.PaymentMethod;
                                endorsment3.Production.OfficeId = doc.OfficeId;
                                endorsment3.Production.Validity = doc.Validity;
                                endorsment3.Production.IsPaid = doc.IsPaid;
                                endorsment3.Production.ChartOfAccount = doc.ChartOfAccount;
                                endorsment3.Production.PlanId = doc.PlanId;
                                endorsment3.Production.CCHIPolicyNo = doc.CCHIPolicyNo;
                                endorsment3.Production.Status = doc.Status;
                                policy4.Endors.Add(endorsment3);
                            });
                            documentTree.Policies.Add(policy4);
                        });
                        List<Production> list5 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == item.Id.ToString().Trim() && p.DocumentType == 2
                                                  orderby p.CreationDate descending
                                                  select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                        list5.ForEach(delegate (Production doc)
                        {
                            Policy policy3 = new Policy();
                            policy3.Members = new List<Subjects>();
                            policy3.production = new Production();
                            List<Subjects> collection5 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            policy3.Members.AddRange(collection5);
                            policy3.production.Id = doc.Id;
                            policy3.production.ProductId = doc.ProductId;
                            policy3.production.CreatedBy = doc.CreatedBy;
                            policy3.production.CreationDate = doc.CreationDate;
                            policy3.production.DocumentType = doc.DocumentType;
                            policy3.production.EndtSerial = doc.EndtSerial;
                            policy3.production.UWYear = doc.UWYear;
                            policy3.production.SeqmentCode = doc.SeqmentCode;
                            policy3.production.IssueDate = doc.IssueDate;
                            policy3.production.EffectiveDate = doc.EffectiveDate;
                            policy3.production.ExpiryDate = doc.ExpiryDate;
                            policy3.production.InsuredName = doc.InsuredName;
                            policy3.production.AccountedFor = doc.AccountedFor;
                            policy3.production.GrossAmount = doc.GrossAmount;
                            policy3.production.TotalFees = doc.TotalFees;
                            policy3.production.CommissionAmount = doc.CommissionAmount;
                            policy3.production.VAT = doc.VAT;
                            policy3.production.DiscountAmount = doc.DiscountAmount;
                            policy3.production.LoadingAmount = doc.DiscountAmount;
                            policy3.production.NetPremium = doc.NetPremium;
                            policy3.production.PolicyId = doc.PolicyId;
                            policy3.production.QuotationId = doc.QuotationId;
                            policy3.production.CustomerId = doc.CustomerId;
                            policy3.production.PaymentMethod = doc.PaymentMethod;
                            policy3.production.OfficeId = doc.OfficeId;
                            policy3.production.Validity = doc.Validity;
                            policy3.production.IsPaid = doc.IsPaid;
                            policy3.production.ChartOfAccount = doc.ChartOfAccount;
                            policy3.production.PlanId = doc.PlanId;
                            policy3.production.CCHIPolicyNo = doc.CCHIPolicyNo;
                            policy3.production.Status = doc.Status;
                            documentTree.Quotations.Add(policy3);
                        });
                        list3.ForEach(delegate (Production doc)
                        {
                            Policy policy2 = new Policy();
                            policy2.Members = new List<Subjects>();
                            policy2.production = new Production();
                            List<Subjects> collection3 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            policy2.Members.AddRange(collection3);
                            policy2.production.Id = doc.Id;
                            policy2.production.ProductId = doc.ProductId;
                            policy2.production.CreatedBy = doc.CreatedBy;
                            policy2.production.CreationDate = doc.CreationDate;
                            policy2.production.DocumentType = doc.DocumentType;
                            policy2.production.EndtSerial = doc.EndtSerial;
                            policy2.production.UWYear = doc.UWYear;
                            policy2.production.SeqmentCode = doc.SeqmentCode;
                            policy2.production.IssueDate = doc.IssueDate;
                            policy2.production.EffectiveDate = doc.EffectiveDate;
                            policy2.production.ExpiryDate = doc.ExpiryDate;
                            policy2.production.InsuredName = doc.InsuredName;
                            policy2.production.AccountedFor = doc.AccountedFor;
                            policy2.production.GrossAmount = doc.GrossAmount;
                            policy2.production.TotalFees = doc.TotalFees;
                            policy2.production.CommissionAmount = doc.CommissionAmount;
                            policy2.production.VAT = doc.VAT;
                            policy2.production.DiscountAmount = doc.DiscountAmount;
                            policy2.production.LoadingAmount = doc.DiscountAmount;
                            policy2.production.NetPremium = doc.NetPremium;
                            policy2.production.PolicyId = doc.PolicyId;
                            policy2.production.QuotationId = doc.QuotationId;
                            policy2.production.CustomerId = doc.CustomerId;
                            policy2.production.PaymentMethod = doc.PaymentMethod;
                            policy2.production.OfficeId = doc.OfficeId;
                            policy2.production.Validity = doc.Validity;
                            policy2.production.IsPaid = doc.IsPaid;
                            policy2.production.ChartOfAccount = doc.ChartOfAccount;
                            policy2.production.PlanId = doc.PlanId;
                            policy2.production.CCHIPolicyNo = doc.CCHIPolicyNo;
                            policy2.production.Status = doc.Status;
                            policy2.Endors = new List<Endorsment>();
                            List<Production> list7 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                      where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.DocumentType == 3 && (long?)p.OrginalPolicy == doc.PolicyId
                                                      orderby p.Id descending
                                                      select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                            list7.ForEach(delegate (Production doc)
                            {
                                Endorsment endorsment2 = new Endorsment();
                                endorsment2.Members = new List<Subjects>();
                                endorsment2.Production = new Production();
                                List<Subjects> collection4 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                              where p.PolicyId == doc.Id
                                                              select p).ToList();
                                endorsment2.Members.AddRange(collection4);
                                endorsment2.Production.Id = doc.Id;
                                endorsment2.Production.ProductId = doc.ProductId;
                                endorsment2.Production.CreatedBy = doc.CreatedBy;
                                endorsment2.Production.CreationDate = doc.CreationDate;
                                endorsment2.Production.DocumentType = doc.DocumentType;
                                endorsment2.Production.EndtSerial = doc.EndtSerial;
                                endorsment2.Production.UWYear = doc.UWYear;
                                endorsment2.Production.SeqmentCode = doc.SeqmentCode;
                                endorsment2.Production.IssueDate = doc.IssueDate;
                                endorsment2.Production.EffectiveDate = doc.EffectiveDate;
                                endorsment2.Production.ExpiryDate = doc.ExpiryDate;
                                endorsment2.Production.InsuredName = doc.InsuredName;
                                endorsment2.Production.AccountedFor = doc.AccountedFor;
                                endorsment2.Production.GrossAmount = doc.GrossAmount;
                                endorsment2.Production.TotalFees = doc.TotalFees;
                                endorsment2.Production.CommissionAmount = doc.CommissionAmount;
                                endorsment2.Production.VAT = doc.VAT;
                                endorsment2.Production.DiscountAmount = doc.DiscountAmount;
                                endorsment2.Production.LoadingAmount = doc.DiscountAmount;
                                endorsment2.Production.NetPremium = doc.NetPremium;
                                endorsment2.Production.PolicyId = doc.PolicyId;
                                endorsment2.Production.QuotationId = doc.QuotationId;
                                endorsment2.Production.CustomerId = doc.CustomerId;
                                endorsment2.Production.PaymentMethod = doc.PaymentMethod;
                                endorsment2.Production.OfficeId = doc.OfficeId;
                                endorsment2.Production.Validity = doc.Validity;
                                endorsment2.Production.IsPaid = doc.IsPaid;
                                endorsment2.Production.ChartOfAccount = doc.ChartOfAccount;
                                endorsment2.Production.PlanId = doc.PlanId;
                                endorsment2.Production.CCHIPolicyNo = doc.CCHIPolicyNo;
                                endorsment2.Production.Status = doc.Status;
                                policy2.Endors.Add(endorsment2);
                            });
                            documentTree.LatestTransactions.Add(policy2);
                        });
                        list4.ForEach(delegate (Production doc)
                        {
                            Policy policy = new Policy();
                            policy.Members = new List<Subjects>();
                            policy.production = new Production();
                            List<Subjects> collection = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                         where p.PolicyId == doc.Id
                                                         select p).ToList();
                            policy.Members.AddRange(collection);
                            policy.production.Id = doc.Id;
                            policy.production.ProductId = doc.ProductId;
                            policy.production.CreatedBy = doc.CreatedBy;
                            policy.production.CreationDate = doc.CreationDate;
                            policy.production.DocumentType = doc.DocumentType;
                            policy.production.EndtSerial = doc.EndtSerial;
                            policy.production.UWYear = doc.UWYear;
                            policy.production.SeqmentCode = doc.SeqmentCode;
                            policy.production.IssueDate = doc.IssueDate;
                            policy.production.EffectiveDate = doc.EffectiveDate;
                            policy.production.ExpiryDate = doc.ExpiryDate;
                            policy.production.InsuredName = doc.InsuredName;
                            policy.production.AccountedFor = doc.AccountedFor;
                            policy.production.GrossAmount = doc.GrossAmount;
                            policy.production.TotalFees = doc.TotalFees;
                            policy.production.CommissionAmount = doc.CommissionAmount;
                            policy.production.VAT = doc.VAT;
                            policy.production.DiscountAmount = doc.DiscountAmount;
                            policy.production.LoadingAmount = doc.DiscountAmount;
                            policy.production.NetPremium = doc.NetPremium;
                            policy.production.PolicyId = doc.PolicyId;
                            policy.production.QuotationId = doc.QuotationId;
                            policy.production.CustomerId = doc.CustomerId;
                            policy.production.PaymentMethod = doc.PaymentMethod;
                            policy.production.OfficeId = doc.OfficeId;
                            policy.production.Validity = doc.Validity;
                            policy.production.IsPaid = doc.IsPaid;
                            policy.production.ChartOfAccount = doc.ChartOfAccount;
                            policy.production.PlanId = doc.PlanId;
                            policy.production.CCHIPolicyNo = doc.CCHIPolicyNo;
                            policy.production.Status = doc.Status;
                            policy.Endors = new List<Endorsment>();
                            List<Production> list6 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                      where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.DocumentType == 3 && (long?)p.OrginalPolicy == doc.PolicyId
                                                      orderby p.Id descending
                                                      select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                            list6.ForEach(delegate (Production doc)
                            {
                                Endorsment endorsment = new Endorsment();
                                endorsment.Members = new List<Subjects>();
                                endorsment.Production = new Production();
                                List<Subjects> collection2 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                              where p.PolicyId == doc.Id
                                                              select p).ToList();
                                endorsment.Members.AddRange(collection2);
                                endorsment.Production.Id = doc.Id;
                                endorsment.Production.ProductId = doc.ProductId;
                                endorsment.Production.CreatedBy = doc.CreatedBy;
                                endorsment.Production.CreationDate = doc.CreationDate;
                                endorsment.Production.DocumentType = doc.DocumentType;
                                endorsment.Production.EndtSerial = doc.EndtSerial;
                                endorsment.Production.UWYear = doc.UWYear;
                                endorsment.Production.SeqmentCode = doc.SeqmentCode;
                                endorsment.Production.IssueDate = doc.IssueDate;
                                endorsment.Production.EffectiveDate = doc.EffectiveDate;
                                endorsment.Production.ExpiryDate = doc.ExpiryDate;
                                endorsment.Production.InsuredName = doc.InsuredName;
                                endorsment.Production.AccountedFor = doc.AccountedFor;
                                endorsment.Production.GrossAmount = doc.GrossAmount;
                                endorsment.Production.TotalFees = doc.TotalFees;
                                endorsment.Production.CommissionAmount = doc.CommissionAmount;
                                endorsment.Production.VAT = doc.VAT;
                                endorsment.Production.DiscountAmount = doc.DiscountAmount;
                                endorsment.Production.LoadingAmount = doc.DiscountAmount;
                                endorsment.Production.NetPremium = doc.NetPremium;
                                endorsment.Production.PolicyId = doc.PolicyId;
                                endorsment.Production.QuotationId = doc.QuotationId;
                                endorsment.Production.CustomerId = doc.CustomerId;
                                endorsment.Production.PaymentMethod = doc.PaymentMethod;
                                endorsment.Production.OfficeId = doc.OfficeId;
                                endorsment.Production.Validity = doc.Validity;
                                endorsment.Production.IsPaid = doc.IsPaid;
                                endorsment.Production.ChartOfAccount = doc.ChartOfAccount;
                                endorsment.Production.PlanId = doc.PlanId;
                                endorsment.Production.CCHIPolicyNo = doc.CCHIPolicyNo;
                                endorsment.Production.Status = doc.Status;
                                policy.Endors.Add(endorsment);
                            });
                            documentTree.LatestNotPayed.Add(policy);
                        });
                    });
                    return documentTree;
                }
                catch (Exception)
                {
                    return (DocumentTree)null;
                }
            });
        }

        public bool updateFinancialDate(UpdateFinancialPayment updateFinancial)
        {
            UpdateFinancialPayment updateFinancial2 = updateFinancial;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    long EskaID = Convert.ToInt64(updateFinancial2.EskaId);
                    Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                             where p.EskaId == (long?)EskaID
                                             select p).FirstOrDefault();
                    production.EffectiveDate = updateFinancial2.EffectiveDate;
                    production.ExpiryDate = updateFinancial2.EffectiveDate.AddYears(1).AddDays(-1.0);
                    ((DbContext)(object)context).Set<Production>().Update(production);
                    ((DbContext)(object)context).SaveChanges();
                    PolicyHolders policyHolders = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                   where (int?)p.Id == production.CustomerId
                                                   select p).FirstOrDefault();
                    policyHolders.VatNumber = updateFinancial2.VAT;
                    policyHolders.IBAN = updateFinancial2.IBAN;
                    policyHolders.BankNameAr = updateFinancial2.BankNameAr;
                    policyHolders.BankNameEn = updateFinancial2.BankNameEn;
                    ((DbContext)(object)context).Set<PolicyHolders>().Update(policyHolders);
                    ((DbContext)(object)context).SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    return false;
                }
            });
        }

        public DocumentTree documentTree(LoadDocumentTreeInput loadDocumentTreeInput)
        {
            LoadDocumentTreeInput loadDocumentTreeInput2 = loadDocumentTreeInput;
            DocumentTree documentTree = new DocumentTree();
            documentTree.Policies = new List<Policy>();
            documentTree.Quotations = new List<Policy>();
            documentTree.LatestTransactions = new List<Policy>();
            documentTree.LatestNotPayed = new List<Policy>();
#pragma warning disable CS8603 // Possible null reference return.
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    List<Production> list = (from p in ((DbContext)(object)context2).Set<Production>()
                                             where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.DocumentType == 1 && p.IsPaid == true && p.ExpiryDate >= DateTime.Now
                                             orderby p.Id descending
                                             select p).ToList();
                    List<Production> list2 = (from p in ((DbContext)(object)context2).Set<Production>()
                                              where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.DocumentType == 2
                                              orderby p.CreationDate descending
                                              select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                    List<Production> list3 = (from p in ((DbContext)(object)context2).Set<Production>()
                                              where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.IsPaid == false && DateTime.Now <= p.IssueDate.AddDays(p.Validity.Value) && p.DocumentType == 6
                                              orderby p.Id descending
                                              select p).ToList();
                    list.ForEach(delegate (Production doc)
                    {
                        Policy policy4 = new Policy();
                        policy4.Members = new List<Subjects>();
                        policy4.production = new Production();
                        List<Subjects> collection6 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                      where p.PolicyId == doc.Id && p.IsCancelled != (bool?)true
                                                      select p).ToList();
                        policy4.Members.AddRange(collection6);
                        policy4.production = doc;
                        policy4.Endors = new List<Endorsment>();
                        List<Production> list7 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.EndosmentType == 3 && p.EskaSegment == doc.EskaSegment && (long?)p.OrginalPolicy == doc.PolicyId
                                                  orderby p.Id descending
                                                  select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                        list7.ForEach(delegate (Production doc)
                        {
                            Endorsment endorsment3 = new Endorsment();
                            endorsment3.Members = new List<Subjects>();
                            endorsment3.Production = new Production();
                            List<Subjects> collection7 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            endorsment3.Members.AddRange(collection7);
                            endorsment3.Production = doc;
                            policy4.Endors.Add(endorsment3);
                        });
                        documentTree.Policies.Add(policy4);
                    });
                    List<Production> list4 = (from p in ((DbContext)(object)context2).Set<Production>()
                                              where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.DocumentType == 2
                                              orderby p.CreationDate descending
                                              select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                    list4.ForEach(delegate (Production doc)
                    {
                        Policy policy3 = new Policy();
                        policy3.Members = new List<Subjects>();
                        policy3.production = new Production();
                        List<Subjects> collection5 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                      where p.PolicyId == doc.Id && p.IsCancelled != (bool?)true
                                                      select p).ToList();
                        policy3.Members.AddRange(collection5);
                        policy3.production = doc;
                        documentTree.Quotations.Add(policy3);
                    });
                    list2.ForEach(delegate (Production doc)
                    {
                        Policy policy2 = new Policy();
                        policy2.Members = new List<Subjects>();
                        policy2.production = new Production();
                        List<Subjects> collection3 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                      where p.PolicyId == doc.Id && p.IsCancelled != (bool?)true
                                                      select p).ToList();
                        policy2.Members.AddRange(collection3);
                        policy2.production = doc;
                        policy2.Endors = new List<Endorsment>();
                        List<Production> list6 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.EndosmentType == 3 && p.EskaSegment == doc.EskaSegment && (long?)p.OrginalPolicy == doc.PolicyId
                                                  orderby p.Id descending
                                                  select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                        list6.ForEach(delegate (Production doc)
                        {
                            Endorsment endorsment2 = new Endorsment();
                            endorsment2.Members = new List<Subjects>();
                            endorsment2.Production = new Production();
                            List<Subjects> collection4 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            endorsment2.Members.AddRange(collection4);
                            endorsment2.Production = doc;
                            policy2.Endors.Add(endorsment2);
                        });
                        documentTree.LatestTransactions.Add(policy2);
                    });
                    list3.ForEach(delegate (Production doc)
                    {
                        Policy policy = new Policy();
                        policy.Members = new List<Subjects>();
                        policy.production = new Production();
                        List<Subjects> collection = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                     where p.PolicyId == doc.Id && p.IsCancelled != (bool?)true
                                                     select p).ToList();
                        policy.Members.AddRange(collection);
                        policy.production = doc;
                        policy.Endors = new List<Endorsment>();
                        List<Production> list5 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == loadDocumentTreeInput2.UserId.Trim() && p.EndosmentType == 3 && p.EskaSegment == doc.EskaSegment && (long?)p.OrginalPolicy == doc.PolicyId
                                                  orderby p.Id descending
                                                  select p).Take(loadDocumentTreeInput2.PageNo).ToList();
                        list5.ForEach(delegate (Production doc)
                        {
                            Endorsment endorsment = new Endorsment();
                            endorsment.Members = new List<Subjects>();
                            endorsment.Production = new Production();
                            List<Subjects> collection2 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            endorsment.Members.AddRange(collection2);
                            endorsment.Production = doc;
                            policy.Endors.Add(endorsment);
                        });
                        documentTree.LatestNotPayed.Add(policy);
                    });
                    return documentTree;
                }
                catch (Exception ex)
                {
                    return (DocumentTree)null;
                }
            });
#pragma warning restore CS8603 // Possible null reference return.
        }

        public LoadPolicyBusiness LoadProductionBusinessChecker(string UserId, int CustomerId)
        {
            string UserId2 = UserId;
            LoadPolicyBusiness loadPolicyBusiness = new LoadPolicyBusiness();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    loadPolicyBusiness.Headers = new List<Production>();
                    loadPolicyBusiness.Subjects = new List<Subjects>();
                    loadPolicyBusiness.Headers = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == UserId2.Trim() && p.DocumentType == 6 && p.CustomerId == (int?)CustomerId
                                                  select p).ToList();
                    if (loadPolicyBusiness.Headers != null && loadPolicyBusiness.Headers.Count > 0)
                    {
                        loadPolicyBusiness.Headers.ForEach(delegate
                        {
                            loadPolicyBusiness.Subjects.AddRange((from p in ((DbContext)(object)context2).Set<Subjects>()
                                                                  where p.PolicyId == p.Id
                                                                  select p).ToList());
                        });
                    }
                    ((DbContext)(object)context2).SaveChanges();
                    return loadPolicyBusiness;
                }
                catch (Exception)
                {
                    return (LoadPolicyBusiness)null;
                }
            });
        }

        public LoadPolicyBusiness LoadProductionBusiness(string UserId)
        {
            string UserId2 = UserId;
            LoadPolicyBusiness loadPolicyBusiness = new LoadPolicyBusiness();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    loadPolicyBusiness.Headers = new List<Production>();
                    loadPolicyBusiness.Subjects = new List<Subjects>();
                    loadPolicyBusiness.Headers = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == UserId2.Trim() && p.DocumentType == 1
                                                  select p).ToList();
                    if (loadPolicyBusiness.Headers != null && loadPolicyBusiness.Headers.Count > 0)
                    {
                        loadPolicyBusiness.Headers.ForEach(delegate
                        {
                            loadPolicyBusiness.Subjects.AddRange((from p in ((DbContext)(object)context2).Set<Subjects>()
                                                                  where p.PolicyId == p.Id
                                                                  select p).ToList());
                        });
                    }
                    return loadPolicyBusiness;
                }
                catch (Exception)
                {
                    return (LoadPolicyBusiness)null;
                }
            });
        }

        public LoadPolicyBusiness LoadProductionTeam(string UserId)
        {
            string UserId2 = UserId;
            LoadPolicyBusiness loadPolicyBusiness = new LoadPolicyBusiness();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    loadPolicyBusiness.Headers = new List<Production>();
                    loadPolicyBusiness.Subjects = new List<Subjects>();
                    int ManagerID = Convert.ToInt32(UserId2);
                    List<Users> list = (from p in ((DbContext)(object)context2).Set<Users>()
                                        where p.ManagerId == (int?)ManagerID
                                        select p).ToList();
                    list.ForEach(delegate (Users item)
                    {
                        List<Production> collection = (from p in ((DbContext)(object)context2).Set<Production>()
                                                       where p.CreatedBy.Trim() == item.ToString().Trim() && p.DocumentType == 1
                                                       select p).ToList();
                        loadPolicyBusiness.Headers.AddRange(collection);
                    });
                    if (loadPolicyBusiness.Headers != null && loadPolicyBusiness.Headers.Count > 0)
                    {
                        loadPolicyBusiness.Headers.ForEach(delegate
                        {
                            loadPolicyBusiness.Subjects.AddRange((from p in ((DbContext)(object)context2).Set<Subjects>()
                                                                  where p.PolicyId == p.Id
                                                                  select p).ToList());
                        });
                    }
                    return loadPolicyBusiness;
                }
                catch (Exception)
                {
                    return (LoadPolicyBusiness)null;
                }
            });
        }

        public List<ServicesLink> LoadAPIs()
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return ((DbContext)(object)context).Set<ServicesLink>().ToList();
                }
                catch (Exception)
                {
                    return (List<ServicesLink>)null;
                }
            });
        }

        public Production LoadDocument(string? DocumentNo, int? Id, int? DocumentType)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from v in ((DbContext)(object)context).Set<Production>()
                            where (((int?)Id).HasValue ? (v.Id == ((int?)Id).Value) : (v.Id == v.Id)) && (((int?)DocumentType).HasValue ? (v.DocumentType == ((int?)DocumentType).Value) : (v.DocumentType == v.DocumentType))
                            select v).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (Production)null;
                }
            });
        }

        public List<MembersList> LoadMemberTree(int PolicyId, string princible, string NationalId)
        {
            string NationalId2 = NationalId;
            string princible2 = princible;
            List<MembersList> members = new List<MembersList>();
            List<string> dep = new List<string>();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    List<Subjects> membersDirect = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                                    where ((!string.IsNullOrEmpty(NationalId2)) ? (v.NationalId == NationalId2) : true) && ((!string.IsNullOrEmpty(princible2)) ? (v.Princible == princible2) : true) && v.Relation == (int?)1 && v.PolicyId == PolicyId
                                                    select v).ToList();
                    membersDirect.ForEach(delegate (Subjects member)
                    {
                        MembersList membersList2 = new MembersList();
                        membersList2.Member = new Subjects();
                        membersList2.Dependent = new List<Subjects>();
                        List<Subjects> list3 = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                                where v.Princible == member.NationalId && v.PolicyId == PolicyId
                                                select v).ToList();
                        membersList2.Member = member;
                        if (list3 != null && list3.Count > 0)
                        {
                            membersList2.Dependent.AddRange(list3);
                            foreach (Subjects current in list3)
                            {
                                dep.Add(current.NationalId.ToString());
                            }
                        }
                        members.Add(membersList2);
                    });
                    List<Subjects> list = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                           where ((!string.IsNullOrEmpty(NationalId2)) ? (v.NationalId == NationalId2) : true) && ((!string.IsNullOrEmpty(princible2)) ? (v.Princible == princible2) : true) && v.Relation != (int?)1 && v.PolicyId == PolicyId
                                           select v).ToList();
                    list.ForEach(delegate (Subjects member)
                    {
                        if (!membersDirect.Any((Subjects p) => p.NationalId == member.NationalId) && !dep.Any((string p) => p == member.NationalId))
                        {
                            MembersList membersList = new MembersList();
                            membersList.Member = new Subjects();
                            membersList.Dependent = new List<Subjects>();
                            List<Subjects> list2 = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                                    where v.Princible == member.NationalId && v.PolicyId == PolicyId
                                                    select v).ToList();
                            membersList.Member = member;
                            if (list2 != null && list2.Count > 0)
                            {
                                membersList.Dependent.AddRange(list2);
                            }
                            members.Add(membersList);
                        }
                    });
                    return members;
                }
                catch (Exception)
                {
                    return (List<MembersList>)null;
                }
            });
        }

        public List<MembersList> LoadMemberTreeByCRno(string princible)
        {
            List<MembersList> members = new List<MembersList>();
            List<string> dep = new List<string>();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    var policyIds = (from s in ((DbContext)(object)context).Set<Subjects>()
                                     where s.Princible == princible
                                     select s.PolicyId).Distinct().ToList();

                    // Step 2: Get all members whose PolicyId exists in that list
                    var memberslist = (from s in ((DbContext)(object)context).Set<Subjects>()
                                       where policyIds.Contains(s.PolicyId)
                                       select s).ToList();

                    List<Subjects> membersDirect = memberslist.Where(s => s.Princible == princible).ToList();

                    membersDirect.ForEach(delegate (Subjects member)
                    {
                        MembersList membersList2 = new MembersList();
                        membersList2.Member = new Subjects();
                        membersList2.Dependent = new List<Subjects>();
                        List<Subjects> list3 = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                                where v.Princible == member.NationalId && v.PolicyId == member.PolicyId
                                                select v).ToList();
                        membersList2.Member = member;
                        if (list3 != null && list3.Count > 0)
                        {
                            membersList2.Dependent.AddRange(list3);

                        }
                        members.Add(membersList2);
                    });

                    return members;
                }
                catch (Exception)
                {
                    return (List<MembersList>)null;
                }
            });
        }
        public List<MembersList> LoadMemberTreeByPolicyid(long policyid)
        {
            List<MembersList> members = new List<MembersList>();
            List<string> dep = new List<string>();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {

                    var memberslist = (from s in ((DbContext)(object)context).Set<Subjects>()
                                       where s.PolicyId == policyid
                                       select s).ToList();
                    memberslist.ForEach(delegate (Subjects member)
                  {
                      MembersList membersList2 = new MembersList();
                      membersList2.Member = new Subjects();
                      membersList2.Dependent = new List<Subjects>();
                      List<Subjects> list3 = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                              where v.Princible == member.NationalId && v.PolicyId == member.PolicyId
                                              select v).ToList();
                      membersList2.Member = member;
                      if (list3 != null && list3.Count > 0)
                      {
                          membersList2.Dependent.AddRange(list3);

                      }
                      members.Add(membersList2);
                  });

                    return members;
                }
                catch (Exception)
                {
                    return (List<MembersList>)null;
                }
            });
        }


        public List<MembersList> LoadMemberTreeSearch(string Name, string? NationalID, int PolicyId)
        {
            string NationalID2 = NationalID;
            List<MembersList> members = new List<MembersList>();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    List<Subjects> list = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                           where ((!string.IsNullOrEmpty(NationalID2)) ? (v.NationalId == NationalID2) : (v.NationalId == v.NationalId)) && v.PolicyId == PolicyId && v.Relation == (int?)1
                                           select v).ToList();
                    list.ForEach(delegate (Subjects member)
                    {
                        MembersList membersList = new MembersList();
                        membersList.Member = new Subjects();
                        membersList.Dependent = new List<Subjects>();
                        List<Subjects> list2 = (from v in ((DbContext)(object)context2).Set<Subjects>()
                                                where v.Princible == member.NationalId && v.PolicyId == PolicyId
                                                select v).ToList();
                        membersList.Member.Id = member.Id;
                        membersList.Member.SumInsured = member.SumInsured;
                        membersList.Member.MemberNo = member.MemberNo;
                        membersList.Member.Name = member.Name;
                        membersList.Member.Name2 = member.Name2;
                        membersList.Member.NationalId = member.NationalId;
                        membersList.Member.PassportNo = member.PassportNo;
                        membersList.Member.Occupation = member.Occupation;
                        membersList.Member.Height = member.Height;
                        membersList.Member.Weight = member.Weight;
                        membersList.Member.Mobile = member.Mobile;
                        membersList.Member.CreatedBy = member.CreatedBy;
                        membersList.Member.CreationDate = member.CreationDate;
                        membersList.Member.NationalityCode = member.NationalityCode;
                        membersList.Member.IdentityExpiryDate = member.IdentityExpiryDate;
                        membersList.Member.PolicyId = member.PolicyId;
                        membersList.Member.IssueDate = member.IssueDate;
                        membersList.Member.EffectiveDate = member.EffectiveDate;
                        membersList.Member.ExpiryDate = member.ExpiryDate;
                        membersList.Member.GrossAmount = member.GrossAmount;
                        membersList.Member.TotalFees = member.TotalFees;
                        membersList.Member.CommissionAmount = member.CommissionAmount;
                        membersList.Member.VAT = member.VAT;
                        membersList.Member.DiscountAmount = member.DiscountAmount;
                        membersList.Member.LoadingAmount = member.LoadingAmount;
                        membersList.Member.NetPremium = member.NetPremium;
                        membersList.Member.PlateNo = member.PlateNo;
                        membersList.Member.ChassisNo = member.ChassisNo;
                        membersList.Member.NoOfSeats = member.NoOfSeats;
                        membersList.Member.OwnerName = member.OwnerName;
                        membersList.Member.ProductionYear = member.ProductionYear;
                        membersList.Member.Usage = member.Usage;
                        membersList.Member.BodyType = member.BodyType;
                        membersList.Member.Make = member.Make;
                        membersList.Member.Model = member.Model;
                        membersList.Member.RepaireCondition = member.RepaireCondition;
                        membersList.Member.Deductible = member.Deductible;
                        membersList.Member.SequanceNo = member.SequanceNo;
                        membersList.Member.CustomNo = member.CustomNo;
                        membersList.Member.Princible = member.Princible;
                        membersList.Member.ClassId = member.ClassId;
                        membersList.Member.Relation = member.Relation;
                        membersList.Member.MartialStatus = member.MartialStatus;
                        membersList.Member.DateOfBirth = member.DateOfBirth;
                        membersList.Member.Age = member.Age;
                        membersList.Member.Gender = member.Gender;
                        if (list2 != null && list2.Count > 0)
                        {
                            membersList.Dependent = list2;
                        }
                        members.Add(membersList);
                    });
                    return members;
                }
                catch (Exception)
                {
                    return (List<MembersList>)null;
                }
            });
        }

        public DocumentTree FilterDocument(string? PolicyChar, DateTime? FromEffectiveDate, DateTime? FromIssueDate, DateTime? ToEffectiveDate, DateTime? ToIssueDate, int? Status, int? DocumentType, int UserId, bool? IsPaid)
        {
            string PolicyChar2 = PolicyChar;
#pragma warning disable CS8603 // Possible null reference return.
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                DocumentTree documentTree = new DocumentTree();
                try
                {
                    List<Production> list = (from v in ((DbContext)(object)context2).Set<Production>()
                                             where ((!string.IsNullOrEmpty(PolicyChar2)) ? (v.SeqmentCode.ToUpper().Contains(PolicyChar2.ToUpper()) || (!string.IsNullOrEmpty(v.EskaSegment) && v.EskaSegment.ToUpper().Contains(PolicyChar2.ToUpper()))) : true) && (((DateTime?)FromEffectiveDate).HasValue ? (v.EffectiveDate >= ((DateTime?)FromEffectiveDate).Value) : true) && (((DateTime?)ToEffectiveDate).HasValue ? (v.EffectiveDate <= ((DateTime?)ToEffectiveDate).Value) : true) && (((DateTime?)FromIssueDate).HasValue ? (v.IssueDate >= ((DateTime?)FromIssueDate).Value) : true) && (((DateTime?)ToIssueDate).HasValue ? (v.IssueDate <= ((DateTime?)ToIssueDate).Value) : true) && (((int?)Status).HasValue ? (v.Status == (int?)((int?)Status).Value) : true) && (((int?)DocumentType).HasValue ? ((int?)v.DocumentType == DocumentType) : true) && v.CreatedBy == ((int)UserId).ToString() && (((bool?)IsPaid).HasValue ? ((bool?)v.IsPaid == IsPaid) : true)
                                             select v).ToList();
                    list.ForEach(delegate (Production doc)
                    {
                        Policy policy2 = new Policy();
                        policy2.Members = new List<Subjects>();
                        policy2.production = new Production();
                        List<Subjects> collection2 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                      where p.PolicyId == doc.Id
                                                      select p).ToList();
                        policy2.Members.AddRange(collection2);
                        policy2.production = doc;
                        policy2.Endors = new List<Endorsment>();
                        List<Production> list3 = (from p in ((DbContext)(object)context2).Set<Production>()
                                                  where p.CreatedBy.Trim() == ((int)UserId).ToString() && p.DocumentType == 3 && (long?)p.OrginalPolicy == doc.PolicyId
                                                  select p).ToList();
                        list3.ForEach(delegate (Production doc)
                        {
                            Endorsment endorsment = new Endorsment();
                            endorsment.Members = new List<Subjects>();
                            endorsment.Production = new Production();
                            List<Subjects> collection3 = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                          where p.PolicyId == doc.Id
                                                          select p).ToList();
                            endorsment.Members.AddRange(collection3);
                            endorsment.Production = doc;
                            policy2.Endors.Add(endorsment);
                        });
                        documentTree.Policies.Add(policy2);
                    });
                    List<Production> list2 = (from p in ((DbContext)(object)context2).Set<Production>()
                                              where p.CreatedBy.Trim() == ((int)UserId).ToString() && p.DocumentType == 2
                                              select p).ToList();
                    list2.ForEach(delegate (Production doc)
                    {
                        Policy policy = new Policy();
                        policy.Members = new List<Subjects>();
                        policy.production = new Production();
                        List<Subjects> collection = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                                     where p.PolicyId == doc.Id
                                                     select p).ToList();
                        policy.Members.AddRange(collection);
                        policy.production = doc;
                        documentTree.Quotations.Add(policy);
                    });
                    return documentTree;
                }
                catch (Exception)
                {
                    return (DocumentTree)null;
                }
            });
        }

        public List<Subjects> LoadMemberBusiness(int PolicyId, string? Princible)
        {
            string Princible2 = Princible;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Subjects>()
                            where p.PolicyId == PolicyId && ((!string.IsNullOrEmpty(Princible2)) ? (p.Princible == Princible2) : (p.Princible == p.Princible))
                            select p).ToList();
                }
                catch (Exception)
                {
                    return (List<Subjects>)null;
                }
            });
        }

        public PolicyHolders InsertUpdatePolicyHolder(PolicyHolders holder)
        {
            PolicyHolders holder2 = holder;
            return Action(delegate (DataBaseContext context)
            {
                PolicyHolders policyHolders = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                               where p.CommercialNo == holder2.CommercialNo
                                               select p).FirstOrDefault();
                if (policyHolders != null && policyHolders.Id > 0)
                {
                    holder2.Id = policyHolders.Id;
                    policyHolders.VatNumber = holder2.VatNumber;
                    policyHolders.Name = holder2.Name;
                    policyHolders.Email = holder2.Email;
                    policyHolders.IBAN = holder2.IBAN;
                    policyHolders.LicenseExpiryDate = holder2.LicenseExpiryDate;
                    policyHolders.MobileNo = holder2.MobileNo;
                    ((DbContext)(object)context).Set<PolicyHolders>().Update(policyHolders);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    holder2.Id = policyHolders.Id;
                }
                else
                {
                    ((DbContext)(object)context).Set<PolicyHolders>().Add(holder2);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                }
                return holder2;
            });
        }

        public PolicyHolders LoadPolicyHolder(string CommercialRegisteration)
        {
            string CommercialRegisteration2 = CommercialRegisteration;
            return Action((DataBaseContext context) => (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                        where p.CommercialNo == CommercialRegisteration2
                                                        select p).FirstOrDefault());
        }

        public PolicyHolders LoadPolicyHolders(int Id)
        {
            return Action((DataBaseContext context) => (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                        where p.Id == Id
                                                        select p).FirstOrDefault());
        }

        public PolicyHolders LoadPolicyHolder(int id)
        {
            return Action((DataBaseContext context) => (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                        where p.Id == id
                                                        select p).FirstOrDefault());
        }

        public List<MemberValidation> memberValidations(List<Subjects> memberValidationList, string connection)
        {
            List<Subjects> memberValidationList2 = memberValidationList;
            string connection2 = connection;
            List<MemberValidation> memberValidations = new List<MemberValidation>();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                memberValidationList2.ForEach(delegate (Subjects memberValidation)
                {
                    Subjects memberValidation2 = memberValidation;
                    MemberValidation memberValidation3 = new MemberValidation();
                    Subjects subjects = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                         where p.NationalId == memberValidation2.NationalId
                                         select p).FirstOrDefault();
                    if (subjects != null && subjects.Id > 0)
                    {
                        memberValidation3.members = memberValidation2;
                        memberValidation3.Error += "Member Already Exists on different policy";
                        memberValidations.Add(memberValidation3);
                    }
                    else
                    {
                        bool flag = true;
                        MemberDublication memberDublication = new MemberDublication();
                        if (!memberDublication.CheckExistsMember(memberValidation2.NationalId, connection2))
                        {
                            memberValidation3.members = memberValidation2;
                            memberValidation3.Error += "Member Already Exists on different Document";
                            memberValidations.Add(memberValidation3);
                        }
                    }
                    if (!string.IsNullOrEmpty(memberValidation2.Princible))
                    {
                        if (memberValidation2.Relation == 1)
                        {
                            memberValidation3.members = memberValidation2;
                            memberValidation3.Error += " Dependent Cant have relation as Employee";
                            memberValidations.Add(memberValidation3);
                        }
                        if (memberValidationList2.Where((Subjects p) => p.NationalId == memberValidation2.Princible).FirstOrDefault().MartialStatus != 2)
                        {
                            memberValidation3.members = memberValidation2;
                            memberValidation3.Error += " Princible Cant be single";
                            memberValidations.Add(memberValidation3);
                        }
                        if (memberValidation2.Relation == 2 && memberValidation2.MartialStatus != 2)
                        {
                            memberValidation3.members = memberValidation2;
                            memberValidation3.Error += " Spouse Cant be single";
                            memberValidations.Add(memberValidation3);
                        }
                    }
                });
                return memberValidations;
            });
        }

        public NationalityMapping GetEskaNationality(int Nationality)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<NationalityMapping>()
                            where p.Id == Nationality
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (NationalityMapping)null;
                }
            });
        }

        public NationalityMapping GetEskaNationalityByEska(string EskaNatCode)
        {
            string EskaNatCode2 = EskaNatCode;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<NationalityMapping>()
                            where p.EskaCode == EskaNatCode2
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (NationalityMapping)null;
                }
            });
        }

        public bool insertCRInfo(CRDetails cRDetails)
        {
            CRDetails cRDetails2 = cRDetails;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    ((DbContext)(object)context).Set<CRDetails>().Add(cRDetails2);
                    ((DbContext)(object)context).SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public Discount Discount(DateTime? FromDate)
        {
            return Action(delegate (DataBaseContext context)
            {
                Discount result = new Discount();
                try
                {
                    result = ((!FromDate.HasValue) ? (from p in ((DbContext)(object)context).Set<Discount>()
                                                      where p.ExpiryDate >= DateTime.Now
                                                      select p).FirstOrDefault() : (from p in ((DbContext)(object)context).Set<Discount>()
                                                                                    where p.ExpiryDate >= FromDate
                                                                                    select p).FirstOrDefault());
                    return result;
                }
                catch (Exception)
                {
                    return result;
                }
            });
        }

        public bool AddDeclarations(MembersDeclarations declarations)
        {
            MembersDeclarations declarations2 = declarations;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    MembersDeclarations membersDeclarations = (from p in ((DbContext)(object)context).Set<MembersDeclarations>()
                                                               where p.PolicyId == declarations2.PolicyId && p.MemberId == declarations2.MemberId
                                                               select p).FirstOrDefault();
                    Production productions = (from p in ((DbContext)(object)context).Set<Production>()
                                              where p.PolicyId == declarations2.PolicyId
                                              select p).FirstOrDefault();
                    if (membersDeclarations != null && membersDeclarations.Id > 0)
                    {
                        membersDeclarations.QuestionOne = declarations2.QuestionOne;
                        membersDeclarations.QuestionTwo = declarations2.QuestionTwo;
                        membersDeclarations.QuestionThree = declarations2.QuestionThree;
                        membersDeclarations.QuestionFour = declarations2.QuestionFour;
                        membersDeclarations.QuestionFive = declarations2.QuestionFive;
                        membersDeclarations.QuestionSix = declarations2.QuestionSix;
                        membersDeclarations.QuestionSeven = declarations2.QuestionSeven;
                        membersDeclarations.QuestionEight = declarations2.QuestionEight;
                        membersDeclarations.QuestionNine = declarations2.QuestionNine;
                        membersDeclarations.MedicalReportPath = declarations2.MedicalReportPath;
                        membersDeclarations.AdditionalPremium = declarations2.AdditionalPremium;
                        ((DbContext)(object)context).Set<MembersDeclarations>().Update(membersDeclarations);
                        ((DbContext)(object)context).SaveChanges();
                        if (productions != null && productions.Id > 0)
                        {
                            productions.LoadingAmount = (productions.LoadingAmount ?? 0) + (declarations2.AdditionalPremium ?? 0);
                            ((DbContext)(object)context).Set<Production>().Update(productions);
                            ((DbContext)(object)context).SaveChanges();
                        }
                        unitOfWork.SetToBeCommitted();
                    }
                    else
                    {
                        ((DbContext)(object)context).Set<MembersDeclarations>().Add(declarations2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public Subjects LoadMembersubject(int Id)
        {
            return Action((DataBaseContext context) => (from p in ((DbContext)(object)context).Set<Subjects>()
                                                        where p.Id == Id
                                                        select p).FirstOrDefault());
        }

        public int GetPlanId(int Id)
        {
            return Action((DataBaseContext context) => (from p in ((DbContext)(object)context).Set<Production>()
                                                        where p.Id == Id
                                                        select p).FirstOrDefault().PlanId.Value);
        }

        public bool RemoveDraftMember(int MemberId, string? connection = null)
        {
            string connection2 = connection;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Subjects checkExists = (from p in ((DbContext)(object)context).Set<Subjects>()
                                            where p.Id == MemberId
                                            select p).FirstOrDefault();
                    if (checkExists == null || checkExists.Id <= 0)
                    {
                        return true;
                    }
                    Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                             where p.Id == checkExists.PolicyId
                                             select p).FirstOrDefault();
                    List<Subjects> list = (from p in ((DbContext)(object)context).Set<Subjects>()
                                           where p.Princible == checkExists.NationalId && p.PolicyId == checkExists.PolicyId
                                           select p).ToList();
                    foreach (Subjects current in list)
                    {
                        if (production != null && production.EskaId.HasValue)
                        {
                            bool flag = Productions.DeleteMember(current.NationalId, production.EskaId.Value, connection2);
                        }
                        ((DbContext)(object)context).Set<Subjects>().Remove(current);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                    ((DbContext)(object)context).Set<Subjects>().Remove(checkExists);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public bool RemoveDeclarations(int MemberId)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    MembersDeclarations membersDeclarations = (from p in ((DbContext)(object)context).Set<MembersDeclarations>()
                                                               where p.MemberId == MemberId
                                                               select p).FirstOrDefault();
                    if (membersDeclarations == null || membersDeclarations.Id <= 0)
                    {
                        return true;
                    }
                    ((DbContext)(object)context).Set<MembersDeclarations>().Remove(membersDeclarations);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public bool RemoveMember(int MemberId, string? connection = null)
        {
            string connection2 = connection;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Subjects checkExists = (from p in ((DbContext)(object)context).Set<Subjects>()
                                            where p.Id == MemberId
                                            select p).FirstOrDefault();
                    if (checkExists == null || checkExists.Id <= 0)
                    {
                        return true;
                    }
                    Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                             where p.Id == checkExists.PolicyId
                                             select p).FirstOrDefault();
                    if (checkExists.Relation == 1)
                    {
                        List<Subjects> list = (from p in ((DbContext)(object)context).Set<Subjects>()
                                               where p.Princible == checkExists.NationalId
                                               select p).ToList();
                        foreach (Subjects current in list)
                        {
                            if (production != null && production.EskaId.HasValue)
                            {
                                bool flag = Productions.DeleteMember(current.NationalId, production.EskaId.Value, connection2);
                            }
                            ((DbContext)(object)context).Set<Subjects>().Remove(current);
                            ((DbContext)(object)context).SaveChanges();
                            unitOfWork.SetToBeCommitted();
                        }
                    }
                    ((DbContext)(object)context).Set<Subjects>().Remove(checkExists);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public MembersDeclarations LoadDeclarationByMember(int MemberId)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    MembersDeclarations membersDeclarations = new MembersDeclarations();
                    return (from p in ((DbContext)(object)context).Set<MembersDeclarations>()
                            where p.MemberId == MemberId
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (MembersDeclarations)null;
                }
            });
        }

        public List<MembersDeclarations> LoadDecleration(LoadDecleration loadDecleration)
        {
            LoadDecleration loadDecleration2 = loadDecleration;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    List<MembersDeclarations> list = new List<MembersDeclarations>();
                    return (from p in ((DbContext)(object)context).Set<MembersDeclarations>()
                            where ((loadDecleration2 != null && loadDecleration2.PolicyId.HasValue) ? (p.PolicyId == loadDecleration2.PolicyId) : (p.PolicyId == p.PolicyId)) && ((loadDecleration2 != null && loadDecleration2.MemberId.HasValue) ? ((int?)p.MemberId == loadDecleration2.MemberId) : (p.MemberId == p.MemberId)) && (loadDecleration2.Id.HasValue ? (p.Id == loadDecleration2.Id.Value) : (p.Id == p.Id))
                            select p).ToList();
                }
                catch (Exception)
                {
                    return (List<MembersDeclarations>)null;
                }
            });
        }

        public bool AddUpdateYakeenMembers(YakeenLogsMember yakeenMembers)
        {
            YakeenLogsMember yakeenMembers2 = yakeenMembers;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    if (yakeenMembers2.Id > 0)
                    {
                        ((DbContext)(object)context).Set<YakeenLogsMember>().Update(yakeenMembers2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                    else
                    {
                        ((DbContext)(object)context).Set<YakeenLogsMember>().Add(yakeenMembers2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public YakeenMembers getYakeenMembers(string nationalId, string sponsor)
        {
            string nationalId2 = nationalId;
            string sponsor2 = sponsor;
            return Action(delegate (DataBaseContext context)
            {
                YakeenMembers yakeenMembers = new YakeenMembers();
                try
                {
                    if (nationalId2[0] == '1')
                    {
                        yakeenMembers.Members = (from p in ((DbContext)(object)context).Set<YakeenLogsMember>()
                                                 where p.NationalId == nationalId2
                                                 select p).FirstOrDefault();
                    }
                    else
                    {
                        yakeenMembers.Members = (from p in ((DbContext)(object)context).Set<YakeenLogsMember>()
                                                 where p.NationalId == nationalId2 && p.Sponsor == sponsor2
                                                 select p).FirstOrDefault();
                    }
                    if (yakeenMembers.Members != null && yakeenMembers.Members.Id > 0)
                    {
                        List<YakeenLogsMember> list = (from p in ((DbContext)(object)context).Set<YakeenLogsMember>()
                                                       where p.Sponsor == nationalId2
                                                       select p).ToList();
                        if (list != null && list.Count > 0)
                        {
                            yakeenMembers.Dependent.AddRange(list);
                        }
                    }
                    return yakeenMembers;
                }
                catch (Exception)
                {
                    return (YakeenMembers)null;
                }
            });
        }

        public Production getDocumentByKey(string key)
        {
            string key2 = key;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Production>()
                            where p.UniqueGuid == key2
                            select p).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                    //return (Production)null;
                }
            });
        }
        public List<Production> getDocumentByPolicyNo(string key)
        {
            string key2 = key;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Production>()
                            where p.EskaSegment == key2
                            select p).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                    //return (Production)null;
                }
            });
        }

        public Production getDocumentByKey(int key)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<Production>()
                            where p.Id == key
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (Production)null;
                }
            });
        }


        public Production getDocumentByCrnumber(string Crnumber)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from s in ((DbContext)(object)context).Set<Subjects>()
                            join p in ((DbContext)(object)context).Set<Production>() on s.PolicyId equals p.Id
                            where s.Princible == Crnumber
                            orderby p.Id descending
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (Production)null;
                }
            });
        }

        public bool MarkasPushToYakeen(string key)
        {
            string key2 = key;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                             where p.UniqueGuid == key2
                                             select p).FirstOrDefault();
                    production.PushToYakeen = 2;
                    ((DbContext)(object)context).Set<Production>().Update(production);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public bool MarkasPushToEska(string key)
        {
            string key2 = key;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                             where p.UniqueGuid == key2
                                             select p).FirstOrDefault();
                    production.PushToEska = 2;
                    ((DbContext)(object)context).Set<Production>().Update(production);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public (Production, string) CancellationMember(int MemberId, int policyid, int Cancellation, string CreatedBy)
        {
            string CreatedBy2 = CreatedBy;
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    Subjects subjects = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                         where p.Id == MemberId && p.PolicyId == policyid && p.IsCancelled == (bool?)true
                                         select p).FirstOrDefault();
                    (Production, string) production = (new Production(), string.Empty);
                    if (subjects != null && subjects.Id > 0)
                    {
                        production.Item2 = "Member already cancelled or pending for cancellation";
                        return production;
                    }
                    Subjects Member = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                       where p.Id == MemberId && p.PolicyId == policyid
                                       select p).FirstOrDefault();
                    Member.IsCancelled = false;
                    ((DbContext)(object)context2).Set<Subjects>().Update(Member);
                    List<Subjects> list = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                           where p.Princible == Member.NationalId && p.PolicyId == policyid
                                           select p).ToList();
                    list.ForEach(delegate (Subjects dependent)
                    {
                        dependent.IsCancelled = false;
                        ((DbContext)(object)context2).Set<Subjects>().Update(dependent);
                    });
                    Production production2 = (from p in ((DbContext)(object)context2).Set<Production>()
                                              where p.Id == Member.PolicyId
                                              select p).FirstOrDefault();
                    production.Item1.PolicyId = production2.Id;
                    ((DbContext)(object)context2).SaveChanges();
                    production.Item1 = production2;
                    production.Item1.Id = 0;
                    production.Item1.CancellationReason = Cancellation;
                    production.Item1.EndosmentType = 5;
                    production.Item1.CreationDate = DateTime.Now;
                    production.Item1.CreatedBy = CreatedBy2;
                    production.Item1.EndtSerial = (from p in ((DbContext)(object)context2).Set<Production>()
                                                   where p.Id == Member.PolicyId
                                                   select p).Max((Production p) => p.EndtSerial) + 1;
                    production.Item1.EskaId = null;
                    production.Item1.IsPaid = false;
                    production.Item1.Status = 1;
                    production.Item1.PolicyId = policyid;
                    production.Item1.DocumentType = 2;
                    production.Item1.UniqueGuid = Guid.NewGuid().ToString();
                    ((DbContext)(object)context2).Set<Production>().Add(production.Item1);
                    ((DbContext)(object)context2).SaveChanges();
                    Subjects subjects2 = new Subjects();
                    subjects2 = Member;
                    subjects2.Id = 0;
                    subjects2.CreatedBy = CreatedBy2;
                    subjects2.CreationDate = DateTime.Now;
                    subjects2.PolicyId = production.Item1.Id;
                    ((DbContext)(object)context2).Set<Subjects>().Add(subjects2);
                    ((DbContext)(object)context2).SaveChanges();
                    list.ForEach(delegate (Subjects item)
                    {
                        Subjects subjects3 = new Subjects();
                        subjects3 = item;
                        subjects3.Id = 0;
                        subjects3.CreatedBy = CreatedBy2;
                        subjects3.CreationDate = DateTime.Now;
                        subjects3.PolicyId = production.Item1.Id;
                        ((DbContext)(object)context2).Set<Subjects>().Add(subjects3);
                        ((DbContext)(object)context2).SaveChanges();
                    });
                    unitOfWork.SetToBeCommitted();
                    return production;
                }
                catch (Exception ex)
                {
                    return (new Production(), ex.Message);
                }
            });
        }

        public bool DeletePolicyBusiness(long Id)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Production entity = (from p in ((DbContext)(object)context).Set<Production>()
                                         where (long)p.Id == Id
                                         select p).FirstOrDefault();
                    List<Subjects> entities = (from p in ((DbContext)(object)context).Set<Subjects>()
                                               where (long)p.PolicyId == Id
                                               select p).ToList();
                    List<ApprovalHistory> entities2 = (from p in ((DbContext)(object)context).Set<ApprovalHistory>()
                                                       where (long)p.PolicyId == Id
                                                       select p).ToList();
                    List<ApprovalHistDetails> entities3 = (from p in ((DbContext)(object)context).Set<ApprovalHistDetails>()
                                                           where (long)p.PolicyId == Id
                                                           select p).ToList();
                    ((DbContext)(object)context).Set<ApprovalHistDetails>().RemoveRange(entities3);
                    ((DbContext)(object)context).SaveChanges();
                    ((DbContext)(object)context).Set<ApprovalHistory>().RemoveRange(entities2);
                    ((DbContext)(object)context).SaveChanges();
                    ((DbContext)(object)context).Set<Subjects>().RemoveRange(entities);
                    ((DbContext)(object)context).SaveChanges();
                    ((DbContext)(object)context).Set<Production>().Remove(entity);
                    ((DbContext)(object)context).SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            });
        }

        public (bool, string) ValidatePolicyHolder(string CRNational, int UserId)
        {
            string CRNational2 = CRNational;
            string error = string.Empty;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    PolicyHolders policyHolder = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                  where p.CommercialNo == CRNational2
                                                  select p).FirstOrDefault();
                    string UserIds = UserId.ToString();
                    DateTime PeriodChecking = DateTime.Now.AddDays(-30.0);
                    if (policyHolder != null && policyHolder.Id > 0)
                    {
                        List<Production> list = (from p in ((DbContext)(object)context).Set<Production>()
                                                 where p.CustomerId == (int?)policyHolder.Id && p.CreatedBy == UserIds && p.IssueDate >= PeriodChecking && p.IssueDate <= DateTime.Now
                                                 select p).ToList();
                        if (list.Count > 1)
                        {
                            error = "Two active quotation within last 30 days";
                            return (false, error);
                        }
                        //List<Production> list2 = (from p in ((DbContext)(object)context).Set<Production>()
                        //                              where p.CustomerId == (int?)policyHolder.Id && p.IsPaid == true && (p.ExpiryDate < PeriodChecking2)
                        //                          select p).ToList();

                        List<Production> list2 = context.Set<Production>()
                                                 .Where(p => p.CustomerId == (int?)policyHolder.Id && p.IsPaid)
                                                 .ToList()
                                                 .Where(p => (p.ExpiryDate - DateTime.Now).TotalDays >= 60)
                                                 .ToList();

                        if (list2 != null && list2.Count > 0)
                        {
                            error = "There is active policy for this customer & PolicyNumber " + list2[0].EskaSegment + "& Expiry Date " + list2[0].ExpiryDate;
                            return (false, error);
                        }
                        List<Production> list3 = (from p in ((DbContext)(object)context).Set<Production>()
                                                  where p.CustomerId == (int?)policyHolder.Id && DateTime.Now <= p.IssueDate.AddDays(p.Validity.Value)
                                                  select p).ToList();
                        if (list3 != null && list3.Count > 0)
                        {
                            error = "There are active quotation for this customer";
                            return (false, error);
                        }
                        return (true, error);
                    }
                    return (true, error);
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            });
        }

        public LoadDocsBusiness LoadPolicyBusiness(int? RoleId, string? CreatedBy, string? PolicyNo, DateTime? issuedate, int? status, int? count, string? ClientName, string? SponserNo)
        {
            string ClientName2 = ClientName;
            string SponserNo2 = SponserNo;
            string CreatedBy2 = CreatedBy;
            string PolicyNo2 = PolicyNo;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    LoadDocsBusiness loadDocsBusiness = new LoadDocsBusiness();
                    List<Production> list = new List<Production>();
                    loadDocsBusiness.productions = new List<Production>();
                    PolicyHolders policyHolders = new PolicyHolders();
                    if (!string.IsNullOrEmpty(ClientName2))
                    {
                        policyHolders = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                         where p.Name.ToUpper() == ClientName2.ToUpper()
                                         select p).FirstOrDefault();
                    }
                    if (!string.IsNullOrEmpty(SponserNo2))
                    {
                        policyHolders = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                         where p.CommercialNo == SponserNo2
                                         select p).FirstOrDefault();
                    }
                    if (RoleId.HasValue)
                    {
                        loadDocsBusiness.productions.AddRange((from p in ((DbContext)(object)context).Set<Production>()
                                                               where p.IsPaid == true && p.ExpiryDate > DateTime.Now
                                                               select p).ToList());
                        loadDocsBusiness.productions.AddRange((from p in ((DbContext)(object)context).Set<Production>()
                                                               where p.DocumentType != 1 && p.IsPaid != true && DateTime.Now <= p.IssueDate.AddDays(p.Validity.Value)
                                                               select p).ToList());
                    }
                    else
                    {
                        loadDocsBusiness.productions.AddRange((from p in ((DbContext)(object)context).Set<Production>()
                                                               where p.IsPaid == true && p.ExpiryDate > DateTime.Now && ((CreatedBy2 == "200" || CreatedBy2 == "201" || CreatedBy2 == "438") ? (p.CreatedBy == p.CreatedBy) : (p.CreatedBy == CreatedBy2))
                                                               select p).ToList());
                        loadDocsBusiness.productions.AddRange((from p in ((DbContext)(object)context).Set<Production>()
                                                               where p.DocumentType != 1 && p.IsPaid != true && DateTime.Now <= p.IssueDate.AddDays(p.Validity.Value) && ((CreatedBy2 == "200" || CreatedBy2 == "201" || CreatedBy2 == "438") ? (p.CreatedBy == p.CreatedBy) : (p.CreatedBy == CreatedBy2))
                                                               select p).ToList());
                    }
                    list.AddRange(loadDocsBusiness.productions.Where((Production p) => (string.IsNullOrEmpty(PolicyNo2) || p.SeqmentCode.ToUpper().Contains(PolicyNo2.ToUpper()) || string.IsNullOrEmpty(p.EskaSegment) || string.IsNullOrEmpty(PolicyNo2) || p.EskaSegment.ToUpper().Contains(PolicyNo2.ToUpper())) && (issuedate.HasValue ? (p.IssueDate >= issuedate.Value) : (p.IssueDate == p.IssueDate)) && (status.HasValue ? (p.Status == status.Value) : (p.Status == p.Status)) && ((policyHolders != null && policyHolders.Id > 0) ? (p.CustomerId == policyHolders.Id) : (p.CustomerId == p.CustomerId))).Take(count.HasValue ? count.Value : 30).ToList());
                    loadDocsBusiness.productions = new List<Production>();
                    loadDocsBusiness.productions = ((list.Count > 0) ? list.OrderByDescending((Production p) => p.CreationDate).ToList() : list);
                    return loadDocsBusiness;
                }
                catch (Exception)
                {
                    return (LoadDocsBusiness)null;
                }
            });
        }

        public bool DeleteEskaSQL(long EskaId)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Production production = (from x in ((DbContext)(object)context).Set<Production>()
                                             where x.EskaId == (long?)EskaId
                                             select x).FirstOrDefault();
                    if (production != null)
                    {
                        production.EskaId = null;
                        production.PushToEska = null;
                        ((DbContext)(object)context).SaveChanges();
                        ((DbContext)(object)context).Set<Production>().Update(production);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public bool CheckExistMember(string National, int PolicyId)
        {
            string National2 = National;
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    bool status = false;
                    List<Production> list = (from x in ((DbContext)(object)context2).Set<Production>()
                                             where (x.Id == PolicyId) || (x.PolicyId == (long?)(long)PolicyId && x.EndosmentType == (int?)3)
                                             select x).ToList();
                    list.ForEach(delegate (Production member)
                    {
                        Subjects subjects = (from x in ((DbContext)(object)context2).Set<Subjects>()
                                             where x.PolicyId == member.Id && x.NationalId == National2
                                             select x).FirstOrDefault();
                        if (subjects != null && subjects.Id > 0)
                        {
                            status = true;
                        }
                    });
                    return status;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public bool UpdateDiscountMember(int Id, decimal Percent)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    Subjects subjects = (from p in ((DbContext)(object)context).Set<Subjects>()
                                         where p.Id == Id
                                         select p).FirstOrDefault();
                    ((DbContext)(object)context).SaveChanges();
                    subjects.DiscountAmount = Percent;
                    ((DbContext)(object)context).Set<Subjects>().Update(subjects);
                    ((DbContext)(object)context).SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public bool CheckPolicyHolder(string CR, int Product, int Id)
        {
            string CR2 = CR;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    PolicyHolders PolicyHolders = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                   where p.CommercialNo == CR2
                                                   select p).FirstOrDefault();
                    if (PolicyHolders != null && PolicyHolders.Id > 0)
                    {
                        Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                                 where p.CustomerId == (int?)PolicyHolders.Id && p.IssueDate.AddDays(p.Validity.Value) > DateTime.Now && p.IsPaid != true && p.ProductId == Product && ((Id > 0) ? (p.Id != Id) : (p.Id == p.Id))
                                                 select p).FirstOrDefault();
                        if (production != null && production.Id > 0)
                        {
                            return false;
                        }
                        Production production2 = (from p in ((DbContext)(object)context).Set<Production>()
                                                  where p.CustomerId == (int?)PolicyHolders.Id && p.ExpiryDate >= DateTime.Now.AddDays(30.0) && p.IsPaid == true && p.ProductId == Product && ((Id > 0) ? (p.Id != Id) : (p.Id == p.Id))
                                                  select p).FirstOrDefault();
                        if (production2 != null && production2.Id > 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public string GetUserNameByCR(string CR)
        {
            string CR2 = CR;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    PolicyHolders PolicyHolders = (from p in ((DbContext)(object)context).Set<PolicyHolders>()
                                                   where p.CommercialNo == CR2
                                                   select p).FirstOrDefault();
                    Production production = (from p in ((DbContext)(object)context).Set<Production>()
                                             where p.CustomerId == (int?)PolicyHolders.Id && p.ExpiryDate >= DateTime.Now
                                             select p).FirstOrDefault();
                    int userId = Convert.ToInt32(production.CreatedBy);
                    Users users = (from p in ((DbContext)(object)context).Set<Users>()
                                   where p.Id == userId
                                   select p).FirstOrDefault();
                    if (users != null)
                    {
                        return users.UserName;
                    }
                    return "";
                }
                catch (Exception)
                {
                    return "";
                }
            });
        }

        public PremiumOutcome GetPlanPremium(int relation, int MaritalStatus, int Gender, int classId, int age, string connection)
        {
            PremiumOutcome premiumOutcome = new PremiumOutcome();
            DataTable oDataTable = new DataTable();
            using (SqlConnection oConnection = new SqlConnection(connection))
            {
                using SqlCommand oCommand = new SqlCommand();
                oCommand.Connection = oConnection;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "GetPlanPremium";
                oCommand.Parameters.AddWithValue("@P_gender", Gender);
                oCommand.Parameters.AddWithValue("@P_relation", relation);
                oCommand.Parameters.AddWithValue("@P_maritalStatus", MaritalStatus);
                oCommand.Parameters.AddWithValue("@P_age", age);
                oCommand.Parameters.AddWithValue("@P_classId", classId);
                SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand);
                try
                {
                    oConnection.Open();
                    oDataAdapter.Fill(oDataTable);
                    foreach (DataRow Dr in oDataTable.Rows)
                    {
                        premiumOutcome.Gross = Convert.ToDecimal(Dr["gross"]);
                        premiumOutcome.Net = Convert.ToDecimal(Dr["Net"]);
                        premiumOutcome.Gross = Convert.ToDecimal(Dr["loading"]);
                    }
                }
                catch (Exception)
                {
                    premiumOutcome.Gross = 0m;
                    premiumOutcome.Net = 0m;
                    premiumOutcome.Gross = 0m;
                }
                finally
                {
                    ((IDisposable)(object)oDataAdapter)?.Dispose();
                }
            }
            return premiumOutcome;
        }

        public PlanHistory LoadPlanHistory(int PlanId, int NationalityType, int classType)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from p in ((DbContext)(object)context).Set<PlanHistory>()
                            where p.PlanId == PlanId && p.NationalityType == NationalityType
                            && p.ClassType == classType // && p.ClassType == (PlanId == 8652 ? classType : p.ClassType)
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (PlanHistory)null;
                }
            });
        }


        public Production LoadOriginalPolicy(int customerId)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    return (from v in ((DbContext)(object)context).Set<Production>()
                            where (v.CustomerId == customerId && v.SeqmentCode.StartsWith("D"))
                            select v).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (Production)null;
                }
            });
        }

        public t_Yakeen_AddressInfo GetYakeen_AddressInfo(long CrNumber)
        {
            return Action((DataBaseContext context) => (from p in ((DbContext)(object)context).Set<t_Yakeen_AddressInfo>()
                                                        where p.CR_NUMBER == CrNumber
                                                        select p).FirstOrDefault());
        }
    }
}
