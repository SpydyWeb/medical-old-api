using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CORE.DTOs.APIs.Business;
using CORE.DTOs.APIs.Process;
using CORE.DTOs.APIs.Process.Approvals;
using CORE.DTOs.APIs.Process.Payments;
using CORE.DTOs.APIs.Unified_Response;
using CORE.DTOs.Authentications;
using CORE.DTOs.Business;
using CORE.Interfaces;
using CORE.Services;
using CORE.TablesObjects;
using DataAccessLayer;
using Fluentx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure.Services
{
    public class Process : Svc, IProcess, ISvc
    {
        public Process(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
            : base(unitOfWork)
        {
        }

        public Results SetApprovalStatus(AddToApprovals approvals)
        {
            AddToApprovals approvals2 = approvals;
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                Results results = new Results();
                try
                {
                    Production Production = (from p in ((DbContext)(object)context2).Set<Production>()
                                             where p.Id == approvals2.approvalHistory.PolicyId
                                             select p).FirstOrDefault();
                    if (Production != null && Production.Status == 1)
                    {
                        ((DbContext)(object)context2).Set<ApprovalHistory>().Add(approvals2.approvalHistory);
                        ((DbContext)(object)context2).SaveChanges();
                    }
                    //Kunal by 22-03-2024 Start updating Status in ApprovalHistory table to keep status in Sync across
                    else if (Production != null && Production.Status != 1)
                    {
                        List<ApprovalHistory> list = (from p in ((DbContext)(object)context2).Set<ApprovalHistory>()
                                                      where (long?)(long)p.PolicyId == approvals2.approvalHistory.PolicyId
                                                      select p).ToList();
                        list.ForEach(delegate (ApprovalHistory item)
                        {
                            item.Status = approvals2.approvalHistory.Status;
                            ((DbContext)(object)context2).Set<ApprovalHistory>().Update(item);
                            ((DbContext)(object)context2).SaveChanges();
                        });
                    }
                    //Kunal by 22-03-2024 End updating Status in ApprovalHistory table to keep status in Sync across
                    if (approvals2.approvalHistory.Status == 3 && Production != null && Production.EndosmentType.HasValue && Production.EndosmentType == 5)
                    {
                        List<Subjects> list = (from p in ((DbContext)(object)context2).Set<Subjects>()
                                               where (long?)(long)p.PolicyId == Production.PolicyId
                                               select p).ToList();
                        list.ForEach(delegate (Subjects item)
                        {
                            item.IsCancelled = true;
                            ((DbContext)(object)context2).Set<Subjects>().Update(item);
                            ((DbContext)(object)context2).SaveChanges();
                        });
                    }
                    ApprovalHistDetails approvalHistDetails = new ApprovalHistDetails();
                    if (approvals2.approvalHistory.Id > 0)
                    {
                        approvalHistDetails.AppHistID = approvals2.approvalHistory.Id;
                    }
                    else
                    {
                        ApprovalHistory approvalHistory = (from p in ((DbContext)(object)context2).Set<ApprovalHistory>()
                                                           where p.PolicyId == approvals2.approvalHistory.PolicyId
                                                           select p).FirstOrDefault();
                        if (approvals2.approvalHistory.Id > 0)
                        {
                            approvalHistDetails.AppHistID = approvals2.approvalHistory.Id;
                        }
                        //approvalHistDetails.AppHistID = approvalHistory.Id;
                    }
                    if (approvals2.approvalHistory.ApprovalUserId.HasValue)
                    {
                        approvalHistDetails.ApprovalUserId = approvals2.approvalHistory.ApprovalUserId;
                    }
                    approvalHistDetails.isSMSSent = approvals2.approvalHistory.isSMSSent;
                    approvalHistDetails.isEmail = approvals2.approvalHistory.isEmail;
                    approvalHistDetails.PolicyId = approvals2.approvalHistory.PolicyId;
                    approvalHistDetails.Attachments = approvals2.approvalHistory.Attachments;
                    approvalHistDetails.RecievedDate = DateTime.Now;
                    approvalHistDetails.UpdatedBy = approvals2.approvalHistory.UpdatedBy;
                    approvalHistDetails.RejectionReason = approvals2.approvalHistory.RejectionReason;
                    approvalHistDetails.Status = approvals2.approvalHistory.Status;
                    approvalHistDetails.UpdateDate = approvals2.approvalHistory.UpdateDate;
                    approvalHistDetails.Comments = approvals2.approvalHistory.Comments;
                    ((DbContext)(object)context2).Add(approvalHistDetails);
                    ((DbContext)(object)context2).SaveChanges();
                    unitOfWork.Commit();
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                    results.ResponseDate = DateTime.Now;
                    results.message = approvalHistDetails.Id.ToString();
                }
                catch (Exception ex)
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = ex.Message;
                }
                return results;
            });
        }
        public Results CheckUserBlackList(string input)
        {
            Results results = new Results();

            return Action(delegate (DataBaseContext context)
            {
                try
                {

                    var user = context.Set<UserBlockID>()
                                      .FirstOrDefault(p => p.UserId == input);

                    if (user != null)
                    {
                        results.status = user.IsBlocked;
                        results.message = user.IsBlocked
                            ? "User is blacklisted."
                            : "User exists but is not blacklisted.";

                    }
                    else
                    {
                        results.status = false;
                        results.message = "User not found in blacklist.";
                    }
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.ResponseDate = DateTime.Now;
                    
                }
                catch(Exception ex)
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = ex.Message;
                }

                return results;
            });

        } 
        public Results InsertUserBlacklistMember(string input)
        {
            Results results = new Results();
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    // Check if user already exists in blacklist
                    bool alreadyExists = context.Set<UserBlockID>()
                                               .Any(u => u.UserId == input);

                    if (alreadyExists)
                    {
                        results.httpStatusCode = HttpStatusCode.Conflict; // 409
                        results.status = false;
                        results.ResponseDate = DateTime.Now;
                        results.message = "User is already blacklisted";
                    }
                    else
                    {
                        var newBlockedUser = new UserBlockID
                        {
                            UserId = input,
                            IsBlocked = true,              // set default block status
                            CreatedOn = DateTime.Now       // set creation date
                        };

                        context.Set<UserBlockID>().Add(newBlockedUser);
                        context.SaveChanges();

                        unitOfWork.SetToBeCommitted();

                        results.httpStatusCode = HttpStatusCode.OK;
                        results.status = true;
                        results.ResponseDate = DateTime.Now;
                        results.message = "User successfully blacklisted";
                    }
                }
                catch (Exception ex)
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = ex.Message;
                }

                return results;
            });


        }

        public bool UpdateApproval(int approvalId, bool? isEmailSent, bool? isSMSSent)
        {
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    ApprovalHistory approvalHistory = (from v in ((DbContext)(object)context).Set<ApprovalHistory>()
                                                       where v.Id == (long)approvalId
                                                       select v).FirstOrDefault();
                    approvalHistory.isSMSSent = (isSMSSent.HasValue ? new bool?(isSMSSent.Value) : approvalHistory.isSMSSent);
                    approvalHistory.isEmail = (isEmailSent.HasValue ? new bool?(isEmailSent.Value) : approvalHistory.isEmail);
                    ((DbContext)(object)context).Set<ApprovalHistory>().Update(approvalHistory);
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

        public List<HealthDeclarations> LoadDeclerations()
        {
            return Action((DataBaseContext context) => ((DbContext)(object)context).Set<HealthDeclarations>().ToList());
        }

        public Production LoadByKey(string key)
        {
            string key2 = key;
            return Action((DataBaseContext context) => (from v in ((DbContext)(object)context).Set<Production>()
                                                        where v.UniqueGuid == key2
                                                        select v).FirstOrDefault());
        }

        public PolicyPaymentResponse LoadPaymentInfo(PolicyPaymentInput input)
        {
            PolicyPaymentInput input2 = input;
            return Action(delegate (DataBaseContext context)
            {
                PolicyPaymentResponse policyPaymentResponse = new PolicyPaymentResponse();
                try
                {
                    Production production = (from v in ((DbContext)(object)context).Set<Production>()
                                             where v.UniqueGuid == input2.Key
                                             select v).FirstOrDefault();
                    policyPaymentResponse.Premium = production.GrossAmount;
                    policyPaymentResponse.Vat = production.VAT;
                    policyPaymentResponse.Total = production.GrossAmount + production.VAT;
                    policyPaymentResponse.message = "";
                    policyPaymentResponse.status = true;
                    policyPaymentResponse.httpStatusCode = HttpStatusCode.OK;
                    policyPaymentResponse.ResponseDate = DateTime.Now;
                    policyPaymentResponse.MembersCount = (from p in ((DbContext)(object)context).Set<Subjects>()
                                                          where p.PolicyId == production.Id
                                                          select p).ToList().Count;
                    return policyPaymentResponse;
                }
                catch (Exception ex)
                {
                    policyPaymentResponse.message = ex.Message;
                    policyPaymentResponse.status = false;
                    policyPaymentResponse.httpStatusCode = HttpStatusCode.InternalServerError;
                    policyPaymentResponse.ResponseDate = DateTime.Now;
                    return policyPaymentResponse;
                }
            });
        }

        public Results SavePaymentLog(PaymentLog input)
        {
            PaymentLog input2 = input;
            return Action(delegate (DataBaseContext context)
            {
                Results results = new Results();
                try
                {
                    EntityEntry<PaymentLog> entityEntry = ((DbContext)(object)context).Set<PaymentLog>().Add(input2);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                    results.httpStatusCode = HttpStatusCode.OK;
                    results.status = true;
                    results.ResponseDate = DateTime.Now;
                    results.message = "";
                }
                catch (Exception ex)
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = ex.Message;
                }
                return results;
            });
        }

        public ApprovalHistory LoadApprovalsHist(int Id)
        {
            return Action(delegate (DataBaseContext context)
            {
                List<ApprovalSet> list = new List<ApprovalSet>();
                List<ApprovalHistory> list2 = new List<ApprovalHistory>();
                try
                {
                    return (from p in ((DbContext)(object)context).Set<ApprovalHistory>()
                            where p.Id == (long)Id
                            select p).FirstOrDefault();
                }
                catch (Exception)
                {
                    return (ApprovalHistory)null;
                }
            });
        }

        public List<ApprovalSet> LoadApprovalsInput(LoadApprovalsInput input)
        {
            LoadApprovalsInput input2 = input;
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                List<ApprovalSet> approvalSet = new List<ApprovalSet>();
                List<ApprovalHistory> history = new List<ApprovalHistory>();
                bool flag = false;
                Production productions = new Production();
                if (!string.IsNullOrEmpty(input2.PolicyNo))
                {
                    productions = (from p in ((DbContext)(object)context2).Set<Production>()
                                   where p.EskaSegment.ToUpper().Contains(input2.PolicyNo.ToUpper()) || p.SeqmentCode.ToUpper().Contains(input2.PolicyNo.ToUpper())
                                   select p).FirstOrDefault();
                }
                try
                {
                    Production production = new Production();
                    List<Production> list = new List<Production>();
                    if (!string.IsNullOrEmpty(input2.CROrAppNo) && input2.CROrAppNo.Substring(0, 1) == "7" && input2.CROrAppNo.Length == 10)
                    {
                        PolicyHolders customer = (from p in ((DbContext)(object)context2).Set<PolicyHolders>()
                                                  where p.CommercialNo.ToUpper().Trim().Contains(input2.CROrAppNo)
                                                  select p).FirstOrDefault();
                        production = (from p in ((DbContext)(object)context2).Set<Production>()
                                      where p.CustomerId == (int?)customer.Id && (input2.UserId.HasValue ? (p.CreatedBy == input2.UserId.Value.ToString()) : (p.CreatedBy == p.CreatedBy))
                                      select p).FirstOrDefault();
                    }
                    else if (input2.UserId.HasValue)
                    {
                        List<int> TeamLeader = (from p in ((DbContext)(object)context2).Set<Users>()
                                                where p.ManagerId == (int?)input2.UserId.Value
                                                select p.Id).ToList();
                        UserRoles userRoles = (from x in ((DbContext)(object)context2).Set<UserRoles>()
                                               where x.UserId == input2.UserId.Value && (x.RoleId == 7 || x.RoleId == 2 || x.RoleId == 6 || x.RoleId == 11)
                                               select x).FirstOrDefault();
                        if (userRoles != null && userRoles.Id > 0)
                        {
                            flag = true;
                        }

                        //|| p.Status == (int?)1 removed from flag ==true query as pending quotation not required

                        list = (flag ? (from p in ((DbContext)(object)context2).Set<Production>()
                                        where p.Status == (int?)2 || p.Status == (int?)5 || p.Status == (int?)6
                                        select p).ToList() : ((TeamLeader.Count <= 0) ? (from p in ((DbContext)(object)context2).Set<Production>()
                                                                                         where p.CreatedBy == input2.UserId.Value.ToString()
                                                                                         select p).ToList() : (from p in ((DbContext)(object)context2).Set<Production>()
                                                                                                               where TeamLeader.Contains(Convert.ToInt32(p.CreatedBy)) || p.CreatedBy == input2.UserId.Value.ToString()
                                                                                                               select p).ToList()));
                    }
                    if (input2.NoOfApprovals.HasValue && input2.NoOfApprovals.Value > 0)
                    {
                        list.ForEach(delegate (Production policy)
                        {
                            Production policy3 = policy;
                            history = (from v in ((DbContext)(object)context2).Set<ApprovalHistory>()
                                       where ((input2.ActionStatus.HasValue && input2.ActionStatus > (int?)0) ? (v.Status == input2.ActionStatus.Value) : (v.Id == v.Id)) && (input2.Fromdate.HasValue ?
                                       (v.RecievedDate >= input2.Fromdate.Value) : (v.Id == v.Id)) && v.PolicyId == policy3.Id && ((productions != null && productions.Id > 0) ? (v.PolicyId == productions.Id) : (v.Id == v.Id))
                                       select v).Take(input2.NoOfApprovals.Value).ToList();
                            if (history.Count > 0)
                            {
                                history.ForEach(delegate (ApprovalHistory hist)
                                {
                                    ApprovalSet approvalSet3 = new ApprovalSet();
                                    approvalSet3.approvalHistory = new ApprovalHistory();
                                    approvalSet3.approvalHistory = hist;
                                    approvalSet3.Production = new Production();
                                    approvalSet3.Production = policy3;
                                    approvalSet.Add(approvalSet3);
                                });
                            }
                        });
                    }
                    else
                    {
                        list.ForEach(delegate (Production policy)
                        {
                            Production policy2 = policy;
                            //history = (from v in ((DbContext)(object)context2).Set<ApprovalHistory>()
                            //	where ((input2.ActionStatus.HasValue && input2.ActionStatus > (int?)0) ? (v.Status == input2.ActionStatus.Value) : (v.Id == v.Id)) && (input2.Fromdate.HasValue ? (v.RecievedDate >= input2.Fromdate.Value) : (v.Id == v.Id)) && v.PolicyId == policy2.Id && ((productions != null && productions.Id > 0) ? (v.PolicyId == productions.Id) : (v.Id == v.Id))
                            //	select v).ToList();
                            history = (from v in ((DbContext)(object)context2).Set<ApprovalHistory>()
                                       where (v.PolicyId == policy2.Id)
                                       select v).ToList();
                            if (history.Count > 0)
                            {
                                history.ForEach(delegate (ApprovalHistory hist)
                                {
                                    ApprovalSet approvalSet2 = new ApprovalSet();
                                    approvalSet2.approvalHistory = new ApprovalHistory();
                                    approvalSet2.approvalHistory = hist;
                                    approvalSet2.Production = new Production();
                                    approvalSet2.Production = policy2;
                                    approvalSet.Add(approvalSet2);
                                });
                            }
                        });
                    }
                    return approvalSet.OrderByDescending((ApprovalSet p) => p.approvalHistory.RecievedDate).ToList();
                }
                catch (Exception)
                {
                    return (List<ApprovalSet>)null;
                }
            });
        }
        //public List<ApprovalSet> LoadApprovalsInput(LoadApprovalsInput input)
        //{
        //    LoadApprovalsInput input2 = input;
        //    return Action(delegate (DataBaseContext context)
        //    {
        //        DataBaseContext context2 = context;
        //        List<ApprovalSet> approvalSet = new List<ApprovalSet>();
        //        List<ApprovalHistory> history = new List<ApprovalHistory>();
        //        bool flag = false;
        //        Production productions = new Production();

        //        if (!string.IsNullOrEmpty(input2.PolicyNo))
        //        {
        //            productions = (from p in ((DbContext)(object)context2).Set<Production>()
        //                           where p.EskaSegment.ToUpper().Contains(input2.PolicyNo.ToUpper())
        //                              || p.SeqmentCode.ToUpper().Contains(input2.PolicyNo.ToUpper())
        //                           select p).FirstOrDefault();
        //        }

        //        try
        //        {
        //            Production production = new Production();
        //            List<Production> list = new List<Production>();

        //            if (!string.IsNullOrEmpty(input2.CROrAppNo) && input2.CROrAppNo.Substring(0, 1) == "7" && input2.CROrAppNo.Length == 10)
        //            {
        //                PolicyHolders customer = (from p in ((DbContext)(object)context2).Set<PolicyHolders>()
        //                                          where p.CommercialNo.ToUpper().Trim().Contains(input2.CROrAppNo)
        //                                          select p).FirstOrDefault();

        //                production = (from p in ((DbContext)(object)context2).Set<Production>()
        //                              where p.CustomerId == (int?)customer.Id &&
        //                                    (input2.UserId.HasValue ? (p.CreatedBy == input2.UserId.Value.ToString()) : true)
        //                              select p).FirstOrDefault();
        //            }
        //            else if (input2.UserId.HasValue)
        //            {
        //                List<int> TeamLeader = (from p in ((DbContext)(object)context2).Set<Users>()
        //                                        where p.ManagerId == (int?)input2.UserId.Value
        //                                        select p.Id).ToList();

        //                UserRoles userRoles = (from x in ((DbContext)(object)context2).Set<UserRoles>()
        //                                       where x.UserId == input2.UserId.Value && (x.RoleId == 7 || x.RoleId == 2 || x.RoleId == 6)
        //                                       select x).FirstOrDefault();

        //                if (userRoles != null && userRoles.Id > 0)
        //                {
        //                    flag = true;
        //                }

        //                list = (flag
        //                    ? (from p in ((DbContext)(object)context2).Set<Production>()
        //                       where p.Status == (int?)2 || p.Status == (int?)5 || p.Status == (int?)6
        //                       select p).ToList()
        //                    : ((TeamLeader.Count <= 0)
        //                        ? (from p in ((DbContext)(object)context2).Set<Production>()
        //                           where p.CreatedBy == input2.UserId.Value.ToString()
        //                           select p).ToList()
        //                        : (from p in ((DbContext)(object)context2).Set<Production>()
        //                           where TeamLeader.Contains(Convert.ToInt32(p.CreatedBy))
        //                              || p.CreatedBy == input2.UserId.Value.ToString()
        //                           select p).ToList()));
        //            }

        //            var subjectsTable = context2.Set<Subjects>();

        //            if (input2.NoOfApprovals.HasValue && input2.NoOfApprovals.Value > 0)
        //            {
        //                list.ForEach(delegate (Production policy)
        //                {
        //                    // Sum of AdditionalPremium from Subjects
        //                    var totalAdditionalPremium = subjectsTable
        //                        .Where(s => s.PolicyId == policy.Id && s.AdditionalPremium.HasValue)
        //                        .Sum(s => s.AdditionalPremium.Value);

        //                    policy.LoadingAmount = totalAdditionalPremium;

        //                    history = (from v in ((DbContext)(object)context2).Set<ApprovalHistory>()
        //                               where ((input2.ActionStatus.HasValue && input2.ActionStatus > 0) ? (v.Status == input2.ActionStatus.Value) : true)
        //                                     && (input2.Fromdate.HasValue ? (v.RecievedDate >= input2.Fromdate.Value) : true)
        //                                     && v.PolicyId == policy.Id
        //                                     && ((productions != null && productions.Id > 0) ? (v.PolicyId == productions.Id) : true)
        //                               select v).Take(input2.NoOfApprovals.Value).ToList();

        //                    if (history.Count > 0)
        //                    {
        //                        history.ForEach(delegate (ApprovalHistory hist)
        //                        {
        //                            approvalSet.Add(new ApprovalSet
        //                            {
        //                                approvalHistory = hist,
        //                                Production = policy
        //                            });
        //                        });
        //                    }
        //                });
        //            }
        //            else
        //            {
        //                list.ForEach(delegate (Production policy)
        //                {
        //                    // Sum of AdditionalPremium from Subjects
        //                    var totalAdditionalPremium = subjectsTable
        //                        .Where(s => s.PolicyId == policy.Id && s.AdditionalPremium.HasValue)
        //                        .Sum(s => s.AdditionalPremium.Value);

        //                    policy.LoadingAmount = totalAdditionalPremium;

        //                    history = (from v in ((DbContext)(object)context2).Set<ApprovalHistory>()
        //                               where v.PolicyId == policy.Id
        //                               select v).ToList();

        //                    if (history.Count > 0)
        //                    {
        //                        history.ForEach(delegate (ApprovalHistory hist)
        //                        {
        //                            approvalSet.Add(new ApprovalSet
        //                            {
        //                                approvalHistory = hist,
        //                                Production = policy
        //                            });
        //                        });
        //                    }
        //                });
        //            }

        //            return approvalSet.OrderByDescending(p => p.approvalHistory.RecievedDate).ToList();
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //        }
        //    });
        //}

        public ApprovalHistDetails insertApprovalHistDetails(ApprovalHistDetails approvalHistDetails)
        {
            ApprovalHistDetails approvalHistDetails2 = approvalHistDetails;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    ((DbContext)(object)context).Set<ApprovalHistDetails>().Add(approvalHistDetails2);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                }
                catch (Exception)
                {
                }
                return approvalHistDetails2;
            });
        }

        public List<approvalhistlist> LoadHistoryApproval(LoadApprovalHistDetails input)
        {
            LoadApprovalHistDetails input2 = input;
            List<approvalhistlist> oLoad = new List<approvalhistlist>();
            return Action(delegate (DataBaseContext context)
            {
                DataBaseContext context2 = context;
                try
                {
                    //List<ApprovalHistDetails> list = (from p in ((DbContext)(object)context2).Set<ApprovalHistDetails>()
                    //	where (input2.PolicyId.HasValue ? ((int?)p.PolicyId == input2.PolicyId) : (p.PolicyId == p.PolicyId)) && (input2.approvalId.HasValue ? ((long?)p.AppHistID == (long?)input2.approvalId) : (p.AppHistID == p.AppHistID)) && (input2.ApproverId.HasValue ? (p.ApprovalUserId == input2.ApproverId) : (p.ApprovalUserId == p.ApprovalUserId))
                    //	select p).ToList();

                    List<ApprovalHistDetails> list = (from p in ((DbContext)(object)context2).Set<ApprovalHistDetails>()
                                                      where (input2.PolicyId.HasValue ? ((int?)p.PolicyId == input2.PolicyId) : (p.PolicyId == p.PolicyId))
                                                         && (input2.approvalId.HasValue ? ((long?)p.AppHistID == (long?)input2.approvalId) : (p.AppHistID == p.AppHistID))
                                                         && (input2.ApproverId.HasValue ? (p.ApprovalUserId == input2.ApproverId) : (p.ApprovalUserId == p.ApprovalUserId))
                                                      orderby p.RecievedDate descending
                                                      select p).ToList();

                    list.ForEach(delegate (ApprovalHistDetails item)
                    {
                        approvalhistlist approvalhistlist = new approvalhistlist();
                        approvalhistlist.approvalHistDetails = new ApprovalHistDetails();
                        approvalhistlist.Production = new Production();
                        approvalhistlist.Production = (from p in ((DbContext)(object)context2).Set<Production>()
                                                       where p.Id == item.PolicyId
                                                       select p).FirstOrDefault();
                        approvalhistlist.approvalHistDetails = item;
                        oLoad.Add(approvalhistlist);
                    });
                    ((DbContext)(object)context2).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                }
                catch (Exception)
                {
                }
                return oLoad;
            });
        }

        public SadadTokens InsertToken(SadadTokens tokens)
        {
            SadadTokens tokens2 = tokens;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    ((DbContext)(object)context).Set<SadadTokens>().Add(tokens2);
                    ((DbContext)(object)context).SaveChanges();
                    unitOfWork.SetToBeCommitted();
                }
                catch (Exception)
                {
                }
                return tokens2;
            });
        }

        public SadadTransactions InsertUpdateSadad(SadadTransactions sadad)
        {
            SadadTransactions sadad2 = sadad;
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    if (sadad2.Id > 0)
                    {
                        ((DbContext)(object)context).Set<SadadTransactions>().Update(sadad2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                    else
                    {
                        ((DbContext)(object)context).Set<SadadTransactions>().Add(sadad2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                    }
                }
                catch (Exception)
                {
                }
                return sadad2;
            });
        }

        public Results InsertUpdateOnline(OnlineTransactions onlineTransactions)
        {
            OnlineTransactions onlineTransactions2 = onlineTransactions;
            return Action(delegate (DataBaseContext context)
            {
                Results results = new Results();
                try
                {
                    if (onlineTransactions2.Id > 0)
                    {
                        ((DbContext)(object)context).Set<OnlineTransactions>().Update(onlineTransactions2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                        results.httpStatusCode = HttpStatusCode.OK;
                        results.status = true;
                        results.ResponseDate = DateTime.Now;
                        results.message = "";
                    }
                    else
                    {
                        ((DbContext)(object)context).Set<OnlineTransactions>().Add(onlineTransactions2);
                        ((DbContext)(object)context).SaveChanges();
                        unitOfWork.SetToBeCommitted();
                        results.httpStatusCode = HttpStatusCode.OK;
                        results.status = true;
                        results.ResponseDate = DateTime.Now;
                        results.message = "";
                    }
                }
                catch (Exception ex)
                {
                    results.httpStatusCode = HttpStatusCode.InternalServerError;
                    results.status = false;
                    results.ResponseDate = DateTime.Now;
                    results.message = ex.Message;
                }
                return results;
            });
        }
        public SadadTokens ValidateToken()
        {
            SadadTokens tokens = new SadadTokens();
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    tokens = (from p in ((DbContext)(object)context).Set<SadadTokens>()
                              where p.ExpiryDate >= DateTime.Now
                              select p).FirstOrDefault();
                }
                catch (Exception)
                {
                }
                return tokens;
            });
        }

        public SadadTransactions ValidateSadad(int? PolicyId, string? InvoiceNo = null, string? InternalCode = null)
        {
            string InvoiceNo2 = InvoiceNo;
            string InternalCode2 = InternalCode;
            SadadTransactions sadadTransactions = new SadadTransactions();
            return Action(delegate (DataBaseContext context)
            {
                try
                {
                    if (PolicyId.HasValue && PolicyId.Value > 0)
                    {
                        sadadTransactions = (from p in ((DbContext)(object)context).Set<SadadTransactions>()
                                             where p.PolicyId == (int?)((int?)PolicyId).Value && p.ExpiryDate >= DateTime.Now
                                             select p).FirstOrDefault();
                    }
                    else
                    {
                        sadadTransactions = (from p in ((DbContext)(object)context).Set<SadadTransactions>()
                                             where p.InvoiceNo == InvoiceNo2 && p.InternalCode == InternalCode2 && p.ExpiryDate >= DateTime.Now
                                             select p).FirstOrDefault();
                    }
                }
                catch (Exception)
                {
                }
                return sadadTransactions;
            });
        }
    }
}
