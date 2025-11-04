using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Domain.Models;
using Domain.Models.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using ProviderCCHI;
using Repository.Interfaces;
using Service.Common;
using Service.Interfaces;
using Service.UnitOfWork;
using Service.Validators;
using SharedSetup.Domain.DTO.Core;
//using WISDL_Policy;

namespace Service.Services
{
	public class WSIntegrationService : IWSIntegrationService
	{
		private readonly IServiceUnitOfWork _serviceUnitOfWork;

		private readonly IRepositoryUnitOfWork repositoryUnitOfWork;

		private readonly IEwsService _MailService;

		private readonly ILogger<WSIntegrationService> _Logger;

		private readonly ITPServiceUnitOfWork _tPServiceUnitOfWork;

		public MpdMembersCchi SelectedMember = new MpdMembersCchi();

		public MpdSponsorsCchi SelectedSponsor = new MpdSponsorsCchi();

		private string _strBasicPath_Write = SharedSettings.Keys.AttachmentPathWriting;

		private string _strBasicPath_Read = SharedSettings.Keys.AttachmentPathReading;

		public WSIntegrationService(IServiceUnitOfWork serviceUnitOfWork, IRepositoryUnitOfWork _repositoryUnitOfWork, ITPServiceUnitOfWork tPServiceUnitOfWork, ILogger<WSIntegrationService> _logger, IEwsService mailService)
		{
			_serviceUnitOfWork = serviceUnitOfWork;
			repositoryUnitOfWork = _repositoryUnitOfWork;
			_tPServiceUnitOfWork = tPServiceUnitOfWork;
			_MailService = mailService;
			_Logger = _logger;
		}

		//public async Task<ResponseResult<HRSDResponse>> GetSponsorsDetailsFromCCHIV3(string NationalID)
		//{
		//	BasicHttpBinding binding = new BasicHttpBinding
		//	{
		//		MaxBufferSize = int.MaxValue,
		//		ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//		MaxReceivedMessageSize = 2147483647L,
		//		Security = 
		//		{
		//			Mode = BasicHttpSecurityMode.Transport
		//		},
		//		TransferMode = TransferMode.Buffered
		//	};
		//	EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//	try
		//	{
		//		using MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address);
		//		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//		try
		//		{
		//			_Logger.LogInformation("-------------------------Request GetSponsorsDetailsV3-----------------------------");
		//			_Logger.LogInformation("_strSponsorNationalId " + NationalID);
		//			_Logger.LogInformation("_strCchiAccessKey " + SharedSettings.GovernmentIntegrationSection.LiveAccessKey);
		//			_Logger.LogInformation("_strCCHICompanyID " + SharedSettings.GovernmentIntegrationSection.UserCompanyID);
		//			HRSDResponse oSponsorDetails = await oMOCServiceClient.GetSponsorsDetailsV3Async(NationalID, SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString(), SharedSettings.GovernmentIntegrationSection.LiveAccessKey);
		//			_Logger.LogInformation("-------------------------Response GetSponsorsDetailsV3-----------------------------");
		//			if (!string.IsNullOrEmpty(oSponsorDetails.Error))
		//			{
		//				_Logger.LogInformation("oSponsorDetails.Error " + oSponsorDetails.Error);
		//				return new ResponseResult<HRSDResponse>
		//				{
		//					Errors = new List<string>(),
		//					Data = null,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			_Logger.LogInformation("oSponsorDetails.Required_Main " + oSponsorDetails.Required_Main);
		//			_Logger.LogInformation("oSponsorDetails.Remaining_Main " + oSponsorDetails.Remaining_Main);
		//			_Logger.LogInformation("oSponsorDetails.Required_Dependents " + oSponsorDetails.Required_Dependents);
		//			_Logger.LogInformation("oSponsorDetails.Remaining_Dependents " + oSponsorDetails.Remaining_Dependents);
		//			return new ResponseResult<HRSDResponse>
		//			{
		//				Errors = new List<string>(),
		//				Data = oSponsorDetails,
		//				Status = ResultStatus.Success,
		//				TotalRecords = 1L
		//			};
		//		}
		//		catch (Exception ex3)
		//		{
		//			Exception ex2 = ex3;
		//			_Logger.LogInformation("Catch Exception :: GetSponsorsDetailsFromCCHIV3 :: Message >> " + ex2.Message + " ,StackTrace >> " + ex2.StackTrace);
		//			string ErrorMessage = $"{ex2.Message}, SponsorNationalId: {NationalID}";
		//			MessageBody message2 = new MessageBody();
		//			message2.AddMessageLine("Error Message ", ex2.Message);
		//			message2.AddMessageLine("Method Name ", "GetSponsorsDetailsFromCCHIV3");
		//			message2.AddMessageLine("National ID ", NationalID);
		//			_MailService.SendEmail(message2.CreateMessageBody());
		//			return new ResponseResult<HRSDResponse>
		//			{
		//				Errors = new List<string> { ErrorMessage },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}
		//	catch (Exception ex3)
		//	{
		//		Exception ex = ex3;
		//		MessageBody message = new MessageBody();
		//		message.AddMessageLine("Error Message ", ex.Message);
		//		message.AddMessageLine("Method Name ", "GetSponsorsDetailsFromCCHIV3");
		//		message.AddMessageLine("National ID ", NationalID);
		//		_MailService.SendEmail(message.CreateMessageBody());
		//		return new ResponseResult<HRSDResponse>
		//		{
		//			Errors = new List<string> { ex.Message },
		//			Data = null,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}
		//}

		//public async Task<ResponseResult<UploadReuslt>> UploadNetwork(long NetworkID, string NetworkName, string username)
		//{
		//	_Logger.LogInformation("Network ID : " + NetworkID);
		//	UploadReuslt oUploadReuslt = new UploadReuslt();
		//	UploadHealthcareProviderNetworksResponse Response = new UploadHealthcareProviderNetworksResponse(oUploadReuslt);
		//	string Key = CCHIKey.GenerateKey();
		//	_Logger.LogInformation("Authorization : " + Key);
		//	try
		//	{
		//		UploadEntity oUploadEntity = new UploadEntity();
		//		UploadHealthcareProviderNetworksRequest oUploadHealthcareProviderNetworksRequest = new UploadHealthcareProviderNetworksRequest(oUploadEntity);
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.ProviderServiceURL);
		//		SPServiceClient client = new SPServiceClient(binding, address);
		//		UploadContract oUploadContract = new UploadContract();
		//		using (new OperationContextScope(client.InnerChannel))
		//		{
		//			HttpRequestMessageProperty prop = new HttpRequestMessageProperty();
		//			prop.Headers["Authorization"] = Key;
		//			OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, prop);
		//			string CchiAccessKey = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//			int CompanyId = SharedSettings.GovernmentIntegrationSection.UserCompanyID;
		//			oUploadContract.NetworkNumber = NetworkID.ToString();
		//			oUploadContract.NetworkName = NetworkName;
		//			oUploadHealthcareProviderNetworksRequest.HealthcareProvidersNetworksEntity.AccessKey = CchiAccessKey;
		//			oUploadHealthcareProviderNetworksRequest.HealthcareProvidersNetworksEntity.CompanyID = CompanyId.ToString();
		//			oUploadHealthcareProviderNetworksRequest.HealthcareProvidersNetworksEntity.UploadHPN = oUploadContract;
		//			_Logger.LogInformation("Key CchiAccessKey : " + CchiAccessKey);
		//			_Logger.LogInformation("Key CompanyId : " + CompanyId);
		//			_Logger.LogInformation("NetworkID : " + NetworkID);
		//			_Logger.LogInformation("NetworkName : " + NetworkName);
		//			try
		//			{
		//				Response = await client.UploadHealthcareProviderNetworksAsync(oUploadHealthcareProviderNetworksRequest);
		//				_Logger.LogInformation("CchiResult " + Response.UploadHealthcareProviderNetworksResult.NetworkName + Response.UploadHealthcareProviderNetworksResult.NetworkNumber + Response.UploadHealthcareProviderNetworksResult.ReferenceNumber + Response.UploadHealthcareProviderNetworksResult.Status);
		//				if (Response != null && (Response.UploadHealthcareProviderNetworksResult.Status.ToUpper() == "APPROVE" || Response.UploadHealthcareProviderNetworksResult.Status.ToUpper() == "APPROVED"))
		//				{
		//					MntNetCchi mntNetCchi3 = new MntNetCchi
		//					{
		//						CreationDate = DateTime.Now,
		//						CreationUser = username.ToUpper(),
		//						Name = NetworkName,
		//						MntNetId = NetworkID,
		//						Status = Response.UploadHealthcareProviderNetworksResult.Status.ToUpper(),
		//						StatusDate = DateTime.Now,
		//						ErrorCode = null,
		//						ErrorDesc = null,
		//						ReferenceNo = Response.UploadHealthcareProviderNetworksResult.ReferenceNumber
		//					};
		//					bool ISAddMntNetCchi3 = AddUpdateMntNetCchi(mntNetCchi3);
		//					MntNetCchiHist mntNetCchiHist3 = new MntNetCchiHist
		//					{
		//						MntNetCchiId = mntNetCchi3.Id,
		//						CreationUser = username.ToUpper(),
		//						CreationDate = DateTime.Now,
		//						TransactionType = "Upload",
		//						Status = Response.UploadHealthcareProviderNetworksResult.Status.ToUpper(),
		//						StatusDate = DateTime.Now,
		//						ErrorCode = null,
		//						ErrorDesc = null
		//					};
		//					bool ISAddMntNetCchiHist3 = AddMntNetCchiHist(mntNetCchiHist3);
		//					_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi3);
		//					_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist3);
		//				}
		//				else
		//				{
		//					MntNetCchi mntNetCchi4 = new MntNetCchi
		//					{
		//						CreationDate = DateTime.Now,
		//						CreationUser = username.ToUpper(),
		//						Name = NetworkName,
		//						MntNetId = NetworkID,
		//						Status = Response.UploadHealthcareProviderNetworksResult.Status.ToUpper(),
		//						StatusDate = DateTime.Now,
		//						ErrorCode = null,
		//						ErrorDesc = null,
		//						ReferenceNo = Response.UploadHealthcareProviderNetworksResult.ReferenceNumber
		//					};
		//					bool ISAddMntNetCchi4 = AddUpdateMntNetCchi(mntNetCchi4);
		//					MntNetCchiHist mntNetCchiHist4 = new MntNetCchiHist
		//					{
		//						MntNetCchiId = mntNetCchi4.Id,
		//						CreationUser = username.ToUpper(),
		//						CreationDate = DateTime.Now,
		//						TransactionType = "Upload",
		//						Status = Response.UploadHealthcareProviderNetworksResult.Status.ToUpper(),
		//						StatusDate = DateTime.Now,
		//						ErrorCode = null,
		//						ErrorDesc = null
		//					};
		//					bool ISAddMntNetCchiHist4 = AddMntNetCchiHist(mntNetCchiHist4);
		//					_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi4);
		//					_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist4);
		//				}
		//			}
		//			catch (FaultException<CCHISPFaultContract> ex3)
		//			{
		//				FaultException<CCHISPFaultContract> ex2 = ex3;
		//				_Logger.LogInformation("***************************Region First Catch*********************************  : " + ex2.Message);
		//				ProviderCCHI.FaultContract[] faultContracts = ex2.Detail.FaultContracts;
		//				int num = 0;
		//				if (num < faultContracts.Length)
		//				{
		//					ProviderCCHI.FaultContract item = faultContracts[num];
		//					string ListErrorCodes = $"ErrorCode: {item.ErrorCode} ErrorMessage: {item.ErrorMessage}";
		//					_Logger.LogInformation("Response : " + Response);
		//					_ = ListErrorCodes + " " + item.ErrorCode + " ";
		//					MntNetCchi mntNetCchi2 = new MntNetCchi
		//					{
		//						CreationDate = DateTime.Now,
		//						CreationUser = username.ToUpper(),
		//						Name = NetworkName,
		//						MntNetId = NetworkID,
		//						Status = "FAILED",
		//						StatusDate = DateTime.Now,
		//						ErrorCode = Convert.ToByte(item.ErrorCode),
		//						ErrorDesc = ex2.Message,
		//						ReferenceNo = null
		//					};
		//					bool ISAddMntNetCchi2 = AddUpdateMntNetCchi(mntNetCchi2);
		//					MntNetCchiHist mntNetCchiHist2 = new MntNetCchiHist
		//					{
		//						MntNetCchiId = mntNetCchi2.Id,
		//						CreationUser = username.ToUpper(),
		//						CreationDate = DateTime.Now,
		//						TransactionType = "Upload",
		//						Status = "FAILED",
		//						StatusDate = DateTime.Now,
		//						ErrorCode = Convert.ToByte(item.ErrorCode),
		//						ErrorDesc = item.ErrorMessage
		//					};
		//					bool ISAddMntNetCchiHist2 = AddMntNetCchiHist(mntNetCchiHist2);
		//					_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi2);
		//					_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist2);
		//					MessageBody message2 = new MessageBody();
		//					message2.AddMessageLine("Error Message ", ex2.Message);
		//					message2.AddMessageLine("Method Name ", "UploadNetwork");
		//					message2.AddMessageLine("Network Id  ", NetworkID.ToString());
		//					message2.AddMessageLine("Network Name  ", NetworkName.ToString());
		//					message2.AddMessageLine("Error Desc ", mntNetCchiHist2.ToString());
		//					_MailService.SendEmail(message2.CreateMessageBody());
		//					return new ResponseResult<UploadReuslt>
		//					{
		//						Errors = new List<string> { ex2.Message },
		//						Data = null,
		//						Status = ResultStatus.Failed,
		//						TotalRecords = 0L
		//					};
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex4)
		//	{
		//		Exception ex = ex4;
		//		_Logger.LogInformation("***************************Region Second Catch*********************************   : " + ex.Message);
		//		MntNetCchi mntNetCchi = new MntNetCchi
		//		{
		//			CreationDate = DateTime.Now,
		//			CreationUser = username.ToUpper(),
		//			Name = NetworkName,
		//			MntNetId = NetworkID,
		//			Status = "FAILED",
		//			StatusDate = DateTime.Now,
		//			ErrorCode = null,
		//			ErrorDesc = ex.Message,
		//			ReferenceNo = null
		//		};
		//		bool ISAddMntNetCchi = AddUpdateMntNetCchi(mntNetCchi);
		//		MntNetCchiHist mntNetCchiHist = new MntNetCchiHist
		//		{
		//			MntNetCchiId = mntNetCchi.Id,
		//			CreationUser = username.ToUpper(),
		//			CreationDate = DateTime.Now,
		//			TransactionType = "Upload",
		//			Status = "FAILED",
		//			StatusDate = DateTime.Now,
		//			ErrorCode = null,
		//			ErrorDesc = ex.Message
		//		};
		//		bool ISAddMntNetCchiHist = AddMntNetCchiHist(mntNetCchiHist);
		//		_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi);
		//		_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist);
		//		MessageBody message = new MessageBody();
		//		message.AddMessageLine("Error Message ", ex.Message);
		//		message.AddMessageLine("Method Name ", "UploadNetwork");
		//		message.AddMessageLine("Network Id  ", NetworkID.ToString());
		//		message.AddMessageLine("Network Name  ", NetworkName.ToString());
		//		message.AddMessageLine("Error Desc ", "Error In upload network");
		//		_MailService.SendEmail(message.CreateMessageBody());
		//		return new ResponseResult<UploadReuslt>
		//		{
		//			Errors = new List<string> { "Error In Upload Network: " + ex.Message },
		//			Data = null,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}
		//	return new ResponseResult<UploadReuslt>
		//	{
		//		Errors = new List<string>(),
		//		Data = null,
		//		Status = ResultStatus.Success,
		//		TotalRecords = 0L
		//	};
		//}

		//public async Task<ResponseResult<CHPNReuslt>> CancelNetwork(long NetworkID, string CCHI_REFERENCE_NO, string NetworkName, string username)
		//{
		//	MntNetCchi mntNetCchi = repositoryUnitOfWork.MntNetCchi.Value.Find((MntNetCchi x) => x.MntNetId == NetworkID).FirstOrDefault();
		//	string Key = CCHIKey.GenerateKey();
		//	_Logger.LogInformation("Key Authorization Headers : " + Key);
		//	CHPNReuslt oCHPNReuslt = new CHPNReuslt();
		//	CancelHealthcareProviderNetworksResponse Response = new CancelHealthcareProviderNetworksResponse(oCHPNReuslt);
		//	try
		//	{
		//		CHPNEntity oCHPNEntity = new CHPNEntity();
		//		CancelHealthcareProviderNetworksRequest oCancelHealthcareProviderNetworksRequest = new CancelHealthcareProviderNetworksRequest(oCHPNEntity);
		//		CHPNContract oCHPNContract = new CHPNContract();
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.ProviderServiceURL);
		//		SPServiceClient client = new SPServiceClient(binding, address);
		//		using (new OperationContextScope(client.InnerChannel))
		//		{
		//			HttpRequestMessageProperty prop = new HttpRequestMessageProperty();
		//			prop.Headers["Authorization"] = Key;
		//			OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, prop);
		//			string CchiAccessKey = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//			int CompanyId = SharedSettings.GovernmentIntegrationSection.UserCompanyID;
		//			_Logger.LogInformation("Key CchiAccessKey : " + CchiAccessKey);
		//			_Logger.LogInformation("Key CompanyId : " + CompanyId);
		//			oCancelHealthcareProviderNetworksRequest.HealthcareProvidersNetworksEntity.AccessKey = CchiAccessKey;
		//			oCHPNContract.ReferenceNumber = CCHI_REFERENCE_NO;
		//			oCancelHealthcareProviderNetworksRequest.HealthcareProvidersNetworksEntity.CHPN = oCHPNContract;
		//			oCancelHealthcareProviderNetworksRequest.HealthcareProvidersNetworksEntity.CompanyID = CompanyId.ToString();
		//			try
		//			{
		//				Response = await client.CancelHealthcareProviderNetworksAsync(oCancelHealthcareProviderNetworksRequest);
		//				_Logger.LogInformation("oCHPNReuslt : " + Response.CancelHealthcareProviderNetworksResult.NetworkName + Response.CancelHealthcareProviderNetworksResult.ReferenceNumber + Response.CancelHealthcareProviderNetworksResult.ReferenceNumber + Response.CancelHealthcareProviderNetworksResult.Status);
		//				if (Response != null && (Response.CancelHealthcareProviderNetworksResult.Status.ToUpper() == "APPROVE" || Response.CancelHealthcareProviderNetworksResult.Status.ToUpper() == "APPROVED"))
		//				{
		//					mntNetCchi.Status = Response.CancelHealthcareProviderNetworksResult.Status.ToUpper();
		//					mntNetCchi.StatusDate = DateTime.Now;
		//					mntNetCchi.ReferenceNo = Response.CancelHealthcareProviderNetworksResult.ReferenceNumber;
		//					bool ISAddMntNetCchi3 = AddUpdateMntNetCchi(mntNetCchi);
		//					MntNetCchiHist mntNetCchiHist3 = new MntNetCchiHist
		//					{
		//						MntNetCchiId = mntNetCchi.Id,
		//						CreationUser = username.ToUpper(),
		//						CreationDate = DateTime.Now,
		//						TransactionType = "Cancel",
		//						Status = Response.CancelHealthcareProviderNetworksResult.Status.ToUpper(),
		//						StatusDate = DateTime.Now,
		//						ErrorCode = null,
		//						ErrorDesc = null
		//					};
		//					bool ISAddMntNetCchiHist3 = AddMntNetCchiHist(mntNetCchiHist3);
		//					_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi3);
		//					_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist3);
		//				}
		//				else
		//				{
		//					mntNetCchi.Status = Response.CancelHealthcareProviderNetworksResult.Status.ToUpper();
		//					mntNetCchi.StatusDate = DateTime.Now;
		//					mntNetCchi.ReferenceNo = Response.CancelHealthcareProviderNetworksResult.ReferenceNumber;
		//					bool ISAddMntNetCchi4 = AddUpdateMntNetCchi(mntNetCchi);
		//					MntNetCchiHist mntNetCchiHist4 = new MntNetCchiHist
		//					{
		//						MntNetCchiId = mntNetCchi.Id,
		//						CreationUser = username.ToUpper(),
		//						CreationDate = DateTime.Now,
		//						TransactionType = "Cancel",
		//						Status = Response.CancelHealthcareProviderNetworksResult.Status.ToUpper(),
		//						StatusDate = DateTime.Now,
		//						ErrorCode = null,
		//						ErrorDesc = null
		//					};
		//					bool ISAddMntNetCchiHist4 = AddMntNetCchiHist(mntNetCchiHist4);
		//					_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi4);
		//					_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist4);
		//				}
		//			}
		//			catch (FaultException<CCHISPFaultContract> ex3)
		//			{
		//				FaultException<CCHISPFaultContract> ex2 = ex3;
		//				_Logger.LogInformation("***************************Region First Catch*********************************  : " + ex2.Message);
		//				ProviderCCHI.FaultContract[] faultContracts = ex2.Detail.FaultContracts;
		//				int num = 0;
		//				if (num < faultContracts.Length)
		//				{
		//					ProviderCCHI.FaultContract item = faultContracts[num];
		//					string ListErrorCodes = $"ErrorCode: {item.ErrorCode} ErrorMessage: {item.ErrorMessage}";
		//					_ = ListErrorCodes + " " + item.ErrorCode + " ";
		//					mntNetCchi.Status = "FAILED";
		//					mntNetCchi.StatusDate = DateTime.Now;
		//					mntNetCchi.ErrorDesc = item.ErrorMessage;
		//					bool ISAddMntNetCchi2 = AddUpdateMntNetCchi(mntNetCchi);
		//					MntNetCchiHist mntNetCchiHist2 = new MntNetCchiHist
		//					{
		//						MntNetCchiId = mntNetCchi.Id,
		//						CreationUser = username.ToUpper(),
		//						CreationDate = DateTime.Now,
		//						TransactionType = "Cancel",
		//						Status = "FAILED",
		//						StatusDate = DateTime.Now,
		//						ErrorCode = Convert.ToByte(item.ErrorCode),
		//						ErrorDesc = item.ErrorMessage
		//					};
		//					bool ISAddMntNetCchiHist2 = AddMntNetCchiHist(mntNetCchiHist2);
		//					_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi2);
		//					_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist2);
		//					MessageBody message2 = new MessageBody();
		//					message2.AddMessageLine("Error Message ", ex2.Message);
		//					message2.AddMessageLine("Method Name ", "CancelNetwork");
		//					message2.AddMessageLine("Network Id  ", NetworkID.ToString());
		//					message2.AddMessageLine("Network Name  ", NetworkName.ToString());
		//					message2.AddMessageLine("Error Desc ", mntNetCchiHist2.ToString());
		//					_MailService.SendEmail(message2.CreateMessageBody());
		//					return new ResponseResult<CHPNReuslt>
		//					{
		//						Errors = new List<string> { ex2.Message },
		//						Data = null,
		//						Status = ResultStatus.Failed,
		//						TotalRecords = 0L
		//					};
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex4)
		//	{
		//		Exception ex = ex4;
		//		_Logger.LogInformation("***************************Region Second Catch*********************************  : " + ex.Message);
		//		mntNetCchi.Status = "FAILED";
		//		mntNetCchi.StatusDate = DateTime.Now;
		//		mntNetCchi.ErrorDesc = ex.Message;
		//		bool ISAddMntNetCchi = AddUpdateMntNetCchi(mntNetCchi);
		//		MntNetCchiHist mntNetCchiHist = new MntNetCchiHist
		//		{
		//			MntNetCchiId = mntNetCchi.Id,
		//			CreationUser = username.ToUpper(),
		//			CreationDate = DateTime.Now,
		//			TransactionType = "Cancel",
		//			Status = "FAILED",
		//			StatusDate = DateTime.Now,
		//			ErrorCode = null,
		//			ErrorDesc = ex.Message
		//		};
		//		bool ISAddMntNetCchiHist = AddMntNetCchiHist(mntNetCchiHist);
		//		_Logger.LogInformation("IS Add MntNetCchi = : " + ISAddMntNetCchi);
		//		_Logger.LogInformation("IS Add MntNetCchiHist = : " + ISAddMntNetCchiHist);
		//		MessageBody message = new MessageBody();
		//		message.AddMessageLine("Error Message ", ex.Message);
		//		message.AddMessageLine("Method Name ", "CancelNetwork");
		//		message.AddMessageLine("Network Id  ", NetworkID.ToString());
		//		message.AddMessageLine("Network Name  ", NetworkName.ToString());
		//		_MailService.SendEmail(message.CreateMessageBody());
		//		return new ResponseResult<CHPNReuslt>
		//		{
		//			Errors = new List<string> { ex.Message },
		//			Data = null,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}
		//	return new ResponseResult<CHPNReuslt>
		//	{
		//		Errors = new List<string>(),
		//		Data = Response.CancelHealthcareProviderNetworksResult,
		//		Status = ResultStatus.Success,
		//		TotalRecords = 0L
		//	};
		//}

		//public async Task<ResponseResult<UploadHPReuslt>> UploadProviders(int CompanyId, List<Provider> dtProviders, string CchiRefNo, long NetworkID, string username)
		//{
		//	UploadHPReuslt oUploadHPReuslt = new UploadHPReuslt();
		//	UploadHealthcareProvidersResponse Response = new UploadHealthcareProvidersResponse(oUploadHPReuslt);
		//	Provider TempProvider = new Provider();
		//	int count = 0;
		//	try
		//	{
		//		string Key = CCHIKey.GenerateKey();
		//		string CchiAccessKey = SharedSettings.AccessKeyCCHI;
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.ProviderServiceURL);
		//		SPServiceClient client = new SPServiceClient(binding, address);
		//		UploadHPEEntity oUploadHPEEntity = new UploadHPEEntity();
		//		UploadHealthcareProvidersRequest oUploadHealthcareProvidersRequest = new UploadHealthcareProvidersRequest(oUploadHPEEntity);
		//		HPContract HPContract = new HPContract();
		//		UHPContract UHPContract = new UHPContract();
		//		using (new OperationContextScope(client.InnerChannel))
		//		{
		//			HttpRequestMessageProperty prop = new HttpRequestMessageProperty();
		//			prop.Headers["Authorization"] = Key;
		//			_Logger.LogInformation(" CchiRefNo : " + CchiRefNo + " NetworkID: " + NetworkID + " username:  " + username);
		//			_Logger.LogInformation(" Authorization Key : " + prop.Headers["Authorization"]);
		//			OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, prop);
		//			new Provider();
		//			string failedUploaded = null;
		//			for (int row = 0; row < dtProviders.Count; row++)
		//			{
		//				count = row;
		//				Provider provider = dtProviders[row];
		//				TempProvider = provider;
		//				_Logger.LogInformation(" ProviderID  : " + provider.ID + "   HOID   " + provider.HOID);
		//				if ((provider.CCHIStatus == null || provider.CCHIStatus == "FAILED") && provider.STATUS == 1)
		//				{
		//					HPContract.AccreditationNumber = provider.HOID;
		//					_Logger.LogInformation(" HPContract.AccreditationNumber   " + HPContract.AccreditationNumber + " HOID  " + provider.HOID);
		//					UHPContract.ReferenceNumber = CchiRefNo;
		//					oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.AccessKey = CchiAccessKey;
		//					_Logger.LogInformation("Uploadentity.AccessKey  : " + oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.AccessKey);
		//					oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.CompanyID = CompanyId.ToString();
		//					_Logger.LogInformation(" Uploadentity.CompanyID: " + oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.CompanyID);
		//					oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPE = HPContract;
		//					_Logger.LogInformation(" Uploadentity.HPE.AccreditationNumber : " + oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPE.AccreditationNumber);
		//					oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPN = UHPContract;
		//					_Logger.LogInformation(" Uploadentity.HPN.ReferenceNumber :  " + oUploadHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPN.ReferenceNumber);
		//					try
		//					{
		//						Response = await client.UploadHealthcareProvidersAsync(oUploadHealthcareProvidersRequest);
		//						_Logger.LogInformation(" Response Inside  If  : " + provider.ID + " Status   :  " + Response.UploadHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper());
		//						ResponseResult<MntNetCchi> mntNetCchi2 = await _serviceUnitOfWork.MntNetCchiService.Value.GetByNetId(NetworkID);
		//						MntPrvNetCchi mntPrvNetCchi3 = new MntPrvNetCchi
		//						{
		//							CreationDate = DateTime.Now,
		//							CreationUser = username.ToUpper(),
		//							MntPrvNetId = provider.ID,
		//							MntNetCchiId = ((mntNetCchi2.Data != null) ? new long?(mntNetCchi2.Data.Id) : null),
		//							ReferenceNo = Response.UploadHealthcareProvidersResult.HealthCareProviderNetwork.ReferenceNumber,
		//							Hoid = provider.HOID,
		//							Status = Response.UploadHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper(),
		//							StatusDate = DateTime.Now,
		//							ErrorCode = null,
		//							ErrorDesc = null,
		//							EndDate = null
		//						};
		//						bool ISAddMntPrvNetCchi3 = AddUpdateMntPrvNetCchi(mntPrvNetCchi3);
		//						MntPrvNetCchiHist mntPrvNetCchiHist3 = new MntPrvNetCchiHist
		//						{
		//							MntPrvNetCchiId = mntPrvNetCchi3.Id,
		//							CreationUser = username.ToUpper(),
		//							CreationDate = DateTime.Now,
		//							TransactionType = "Upload",
		//							Status = Response.UploadHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper(),
		//							StatusDate = DateTime.Now,
		//							ErrorCode = null,
		//							ErrorDesc = null
		//						};
		//						bool ISAddMntPrvNetCchiHist3 = AddMntPrvNetCchiHist(mntPrvNetCchiHist3);
		//						_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchi3);
		//						_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchiHist3);
		//					}
		//					catch (FaultException<CCHISPFaultContract> ex2)
		//					{
		//						_Logger.LogInformation("***************************Region First Catch*********************************   : " + ex2.Message);
		//						ResponseResult<MntNetCchi> mntNetCchi = await _serviceUnitOfWork.MntNetCchiService.Value.GetByNetId(NetworkID);
		//						ProviderCCHI.FaultContract[] faultContracts = ex2.Detail.FaultContracts;
		//						int num = 0;
		//						if (num < faultContracts.Length)
		//						{
		//							ProviderCCHI.FaultContract item = faultContracts[num];
		//							MntPrvNetCchi mntPrvNetCchi2 = new MntPrvNetCchi
		//							{
		//								CreationDate = DateTime.Now,
		//								CreationUser = username.ToUpper(),
		//								MntPrvNetId = provider.ID,
		//								MntNetCchiId = ((mntNetCchi.Data != null) ? new long?(mntNetCchi.Data.Id) : null),
		//								ReferenceNo = null,
		//								Hoid = provider.HOID,
		//								Status = "FAILED",
		//								StatusDate = DateTime.Now,
		//								ErrorCode = Convert.ToByte(item.ErrorCode),
		//								ErrorDesc = item.ErrorMessage,
		//								EndDate = null
		//							};
		//							bool ISAddMntPrvNetCchi2 = AddUpdateMntPrvNetCchi(mntPrvNetCchi2);
		//							MntPrvNetCchiHist mntPrvNetCchiHist2 = new MntPrvNetCchiHist
		//							{
		//								MntPrvNetCchiId = mntPrvNetCchi2.Id,
		//								CreationUser = username.ToUpper(),
		//								CreationDate = DateTime.Now,
		//								TransactionType = "Upload",
		//								Status = item.ErrorCode,
		//								StatusDate = DateTime.Now,
		//								ErrorCode = Convert.ToByte(item.ErrorCode),
		//								ErrorDesc = item.ErrorMessage
		//							};
		//							bool ISAddMntPrvNetCchiHist2 = AddMntPrvNetCchiHist(mntPrvNetCchiHist2);
		//							_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchi2);
		//							_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchiHist2);
		//							MessageBody message2 = new MessageBody();
		//							message2.AddMessageLine("Error Message ", ex2.Message);
		//							message2.AddMessageLine("Method Name ", "UploadProviders");
		//							message2.AddMessageLine("Network Id  ", NetworkID.ToString());
		//							message2.AddMessageLine("Provicder Name  ", TempProvider.NAME);
		//							message2.AddMessageLine("Provicder Id  ", TempProvider.ID.ToString());
		//							message2.AddMessageLine("Error Desc ", mntPrvNetCchiHist2.ErrorDesc);
		//							_MailService.SendEmail(message2.CreateMessageBody());
		//							_ = failedUploaded + " " + item.ErrorCode + " ";
		//							return new ResponseResult<UploadHPReuslt>
		//							{
		//								Errors = new List<string> { ex2.Message },
		//								Data = null,
		//								Status = ResultStatus.Failed,
		//								TotalRecords = 0L
		//							};
		//						}
		//					}
		//					continue;
		//				}
		//				_Logger.LogInformation(" Provider is already Uploaded  or unactive:  " + provider.ID);
		//				MessageBody message3 = new MessageBody();
		//				message3.AddMessageLine("Error Message ", "Provider is already Uploaded  or unactive " + provider.ID);
		//				message3.AddMessageLine("Method Name ", "UploadProviders");
		//				message3.AddMessageLine("Network Id  ", NetworkID.ToString());
		//				message3.AddMessageLine("Provicder Name  ", TempProvider.NAME);
		//				message3.AddMessageLine("Provicder Id  ", TempProvider.ID.ToString());
		//				_MailService.SendEmail(message3.CreateMessageBody());
		//				return new ResponseResult<UploadHPReuslt>
		//				{
		//					Errors = new List<string> { " Provider is already Uploaded  or unactive:  " + provider.NAME },
		//					Data = null,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//		}
		//	}
		//	catch (Exception ex3)
		//	{
		//		Exception ex = ex3;
		//		_Logger.LogInformation("***************************Region Second Catch*********************************   : " + ex.Message);
		//		_Logger.LogInformation("_serviceUnitOfWork.MntNetCchiService.Value.GetByNetId(NetworkID).Result.Data.Id: " + _serviceUnitOfWork.MntNetCchiService.Value.GetByNetId(NetworkID).Result.Data.Id);
		//		MntPrvNetCchi mntPrvNetCchi = new MntPrvNetCchi
		//		{
		//			CreationDate = DateTime.Now,
		//			CreationUser = username.ToUpper(),
		//			MntPrvNetId = dtProviders[count].ID,
		//			MntNetCchiId = _serviceUnitOfWork.MntNetCchiService.Value.GetByNetId(NetworkID).Result.Data.Id,
		//			ReferenceNo = null,
		//			Hoid = dtProviders[count].HOID,
		//			Status = "FAILED",
		//			StatusDate = DateTime.Now,
		//			ErrorCode = null,
		//			ErrorDesc = ex.Message,
		//			EndDate = null
		//		};
		//		bool ISAddMntPrvNetCchi = AddUpdateMntPrvNetCchi(mntPrvNetCchi);
		//		MntPrvNetCchiHist mntPrvNetCchiHist = new MntPrvNetCchiHist
		//		{
		//			MntPrvNetCchiId = mntPrvNetCchi.Id,
		//			CreationUser = username.ToUpper(),
		//			CreationDate = DateTime.Now,
		//			TransactionType = "Upload",
		//			Status = "FAILED",
		//			StatusDate = DateTime.Now,
		//			ErrorCode = null,
		//			ErrorDesc = ex.Message
		//		};
		//		bool ISAddMntPrvNetCchiHist = AddMntPrvNetCchiHist(mntPrvNetCchiHist);
		//		_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchi);
		//		_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchiHist);
		//		MessageBody message = new MessageBody();
		//		message.AddMessageLine("Error Message ", "Error In UploadProviders");
		//		message.AddMessageLine("Method Name ", "UploadProviders");
		//		message.AddMessageLine("Network Id  ", NetworkID.ToString());
		//		message.AddMessageLine("Provicder Name  ", TempProvider.NAME);
		//		message.AddMessageLine("Provicder Id  ", TempProvider.ID.ToString());
		//		_MailService.SendEmail(message.CreateMessageBody());
		//		return new ResponseResult<UploadHPReuslt>
		//		{
		//			Errors = new List<string> { ex.Message },
		//			Data = null,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}
		//	return new ResponseResult<UploadHPReuslt>
		//	{
		//		Errors = new List<string>(),
		//		Data = Response.UploadHealthcareProvidersResult,
		//		Status = ResultStatus.Success,
		//		TotalRecords = 0L
		//	};
		//}

		//public async Task<ResponseResult<bool>> CancelProviders(int CompanyId, List<Provider> dtProviders, string UserName)
		//{
		//	List<MntPrvNetCchi> SelectedProviders = _serviceUnitOfWork.MntPrvNetCchiService.Value.GetAll().Data.Where((MntPrvNetCchi x) => dtProviders.Any((Provider z) => z.ID == x.MntPrvNetId)).ToList();
		//	string Key = CCHIKey.GenerateKey();
		//	_Logger.LogInformation("Key Authorization Headers : " + Key);
		//	BasicHttpBinding binding = new BasicHttpBinding
		//	{
		//		MaxBufferSize = int.MaxValue,
		//		ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//		MaxReceivedMessageSize = 2147483647L,
		//		Security = 
		//		{
		//			Mode = BasicHttpSecurityMode.Transport
		//		},
		//		TransferMode = TransferMode.Buffered
		//	};
		//	EndpointAddress address = new EndpointAddress(SharedSettings.ProviderServiceURL);
		//	SPServiceClient client = new SPServiceClient(binding, address);
		//	CHPEntity oCHPEntity = new CHPEntity();
		//	UploadHPReuslt oUploadHPReuslt = new UploadHPReuslt();
		//	CancelHealthcareProvidersRequest oCancelHealthcareProvidersRequest = new CancelHealthcareProvidersRequest(oCHPEntity);
		//	new CancelHealthcareProvidersResponse(oUploadHPReuslt);
		//	HPContract oHpContract = new HPContract();
		//	UHPContract oUhpContract = new UHPContract();
		//	MntPrvNetCchi ProviderTemp = new MntPrvNetCchi();
		//	try
		//	{
		//		using (new OperationContextScope(client.InnerChannel))
		//		{
		//			_Logger.LogInformation(" CchiAccessKey from body :  " + SharedSettings.AccessKeyCCHI + "Company ID  : " + CompanyId + " Authorization key  : " + Key);
		//			HttpRequestMessageProperty prop = new HttpRequestMessageProperty();
		//			prop.Headers["Authorization"] = Key;
		//			OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, prop);
		//			if (SelectedProviders.Count == 0)
		//			{
		//				return new ResponseResult<bool>
		//				{
		//					Errors = new List<string> { "Warning: The selected providers are not uploaded to CCHI" },
		//					Data = false,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			for (int row = 0; row < SelectedProviders.Count; row++)
		//			{
		//				MntPrvNetCchi Provider = SelectedProviders[row];
		//				ProviderTemp = Provider;
		//				oCancelHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.AccessKey = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//				oCancelHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.CompanyID = CompanyId.ToString();
		//				oHpContract.AccreditationNumber = Provider.Hoid;
		//				oCancelHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPE = oHpContract;
		//				oUhpContract.ReferenceNumber = Provider.ReferenceNo;
		//				oCancelHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPN = oUhpContract;
		//				_Logger.LogInformation(" HOID :  " + Provider.Hoid + " Reference NO :  " + Provider.ReferenceNo);
		//				_Logger.LogInformation(" network_ID :  " + Provider.MntNetCchiId.Value + " provider_ID :  " + Provider.MntPrvNetId);
		//				_Logger.LogInformation("  oHpContract.AccreditationNumber  :  " + oHpContract.AccreditationNumber + "  oCHPNEntity.HPE.AccreditationNumber    : " + oCancelHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPE.AccreditationNumber);
		//				_Logger.LogInformation("  oUhpContract.ReferenceNumber  :  " + oUhpContract.ReferenceNumber + " oCHPNEntity.HPN.ReferenceNumber   : " + oCancelHealthcareProvidersRequest.HealthcareProvidersNetworksEntity.HPN.ReferenceNumber);
		//				try
		//				{
		//					CancelHealthcareProvidersResponse oCancelHealthcareProvidersResponse = await client.CancelHealthcareProvidersAsync(oCancelHealthcareProvidersRequest);
		//					_Logger.LogInformation(" Response  " + oCancelHealthcareProvidersResponse);
		//					if (oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper() == "APPROVED" || oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper() == "APPROVE" || oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper() == "SUCCESSED" || oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper() == "SUUCESS" || oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper().Contains("APPROVE") || oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper().Contains("SUCCESS"))
		//					{
		//						_Logger.LogInformation(" Response  : " + Provider.Id + " Status   :  " + oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper());
		//						Provider.Status = "CANCELLED";
		//						Provider.StatusDate = DateTime.Now;
		//						Provider.EndDate = DateTime.Now;
		//						bool ISAddMntPrvNetCchi = AddUpdateMntPrvNetCchi(Provider);
		//						MntPrvNetCchiHist mntPrvNetCchiHist = new MntPrvNetCchiHist
		//						{
		//							MntPrvNetCchiId = Provider.Id,
		//							TransactionType = "Cancel",
		//							CreationUser = Provider.CreationUser.ToUpper(),
		//							CreationDate = DateTime.Now,
		//							Status = "CANCELLED",
		//							StatusDate = DateTime.Now,
		//							ErrorCode = null,
		//							ErrorDesc = null
		//						};
		//						bool ISAddMntPrvNetCchiHist = AddMntPrvNetCchiHist(mntPrvNetCchiHist);
		//						_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchi);
		//						_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchiHist);
		//					}
		//					else
		//					{
		//						_Logger.LogInformation(" Response   Status   :  " + oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToUpper());
		//						Provider.Status = oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToString();
		//						Provider.StatusDate = DateTime.Now;
		//						Provider.ErrorDesc = oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToString();
		//						bool ISAddMntPrvNetCchi2 = AddUpdateMntPrvNetCchi(Provider);
		//						MntPrvNetCchiHist mntPrvNetCchiHist2 = new MntPrvNetCchiHist
		//						{
		//							MntPrvNetCchiId = Provider.Id,
		//							TransactionType = "Cancel",
		//							CreationUser = Provider.CreationUser.ToUpper(),
		//							CreationDate = DateTime.Now,
		//							Status = oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToString(),
		//							StatusDate = DateTime.Now,
		//							ErrorCode = null,
		//							ErrorDesc = oCancelHealthcareProvidersResponse.CancelHealthcareProvidersResult.HealthProviderEntity.Status.ToString()
		//						};
		//						bool ISAddMntPrvNetCchiHist2 = AddMntPrvNetCchiHist(mntPrvNetCchiHist2);
		//						_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchi2);
		//						_Logger.LogInformation("ISAddMntPrvNetCchi = : " + ISAddMntPrvNetCchiHist2);
		//					}
		//				}
		//				catch (FaultException<CCHISPFaultContract> ex2)
		//				{
		//					_Logger.LogInformation("***************************Region First Catch*********************************  : " + ex2.Message);
		//					ProviderCCHI.FaultContract[] faultContracts = ex2.Detail.FaultContracts;
		//					int num = 0;
		//					if (num < faultContracts.Length)
		//					{
		//						ProviderCCHI.FaultContract item = faultContracts[num];
		//						string ListErrorCodes = $"ErrorCode: {item.ErrorCode} ErrorMessage: {item.ErrorMessage}";
		//						_Logger.LogInformation("ListErrorCodes " + ListErrorCodes);
		//						_ = ListErrorCodes + " " + item.ErrorCode + " ";
		//						MntPrvNetCchiHist prvNetCchiHist2 = new MntPrvNetCchiHist
		//						{
		//							MntPrvNetCchiId = Provider.Id,
		//							CreationUser = UserName,
		//							CreationDate = DateTime.Now,
		//							TransactionType = "Cancel",
		//							Status = "FAILED",
		//							StatusDate = DateTime.Now,
		//							ErrorCode = Convert.ToByte(item.ErrorCode),
		//							ErrorDesc = item.ErrorMessage
		//						};
		//						bool IsAddMntPrvNetCchiHist2 = AddMntPrvNetCchiHist(prvNetCchiHist2);
		//						_Logger.LogInformation("IS Add MntNetCchiHist = : " + IsAddMntPrvNetCchiHist2);
		//						MessageBody message2 = new MessageBody();
		//						message2.AddMessageLine("Error Message ", ex2.Message);
		//						message2.AddMessageLine("Method Name ", "CancelProviders");
		//						message2.AddMessageLine("Error Description ", prvNetCchiHist2.ErrorDesc);
		//						message2.AddMessageLine("Provider Id ", ProviderTemp.Id.ToString());
		//						message2.AddMessageLine("Network Id  ", ProviderTemp.MntPrvNetId.ToString());
		//						_MailService.SendEmail(message2.CreateMessageBody());
		//						return new ResponseResult<bool>
		//						{
		//							Errors = new List<string> { ex2.Message },
		//							Data = false,
		//							Status = ResultStatus.Failed,
		//							TotalRecords = 0L
		//						};
		//					}
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex3)
		//	{
		//		Exception ex = ex3;
		//		_Logger.LogInformation("***************************Region Second Catch*********************************  : " + ex.Message);
		//		MntPrvNetCchiHist prvNetCchiHist = new MntPrvNetCchiHist
		//		{
		//			MntPrvNetCchiId = ProviderTemp.Id,
		//			CreationUser = UserName,
		//			CreationDate = DateTime.Now,
		//			TransactionType = "Cancel",
		//			Status = "FAILED",
		//			StatusDate = DateTime.Now,
		//			ErrorCode = null,
		//			ErrorDesc = ex.Message
		//		};
		//		bool IsAddMntPrvNetCchiHist = AddMntPrvNetCchiHist(prvNetCchiHist);
		//		_Logger.LogInformation("IS Add MntNetCchiHist = : " + IsAddMntPrvNetCchiHist);
		//		MessageBody message = new MessageBody();
		//		message.AddMessageLine("Error Message ", ex.Message);
		//		message.AddMessageLine("Method Name ", "CancelProviders");
		//		message.AddMessageLine("Provider Id ", ProviderTemp.Id.ToString());
		//		message.AddMessageLine("Network Id  ", ProviderTemp.MntPrvNetId.ToString());
		//		_MailService.SendEmail(message.CreateMessageBody());
		//		return new ResponseResult<bool>
		//		{
		//			Errors = new List<string> { ex.Message },
		//			Data = false,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}
		//	return new ResponseResult<bool>
		//	{
		//		Errors = new List<string>(),
		//		Data = true,
		//		Status = ResultStatus.Success,
		//		TotalRecords = 0L
		//	};
		//}

		//	public async Task<ResponseResult<XMLReturnResult>> UploadPolicyNew(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo)
		//	{
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		try
		//		{
		//			XMLReturnResult oXMLReturnResult = new XMLReturnResult();
		//			using (MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address))
		//			{
		//				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//				string CCHI_ACCESS_KEY = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//				oXMLReturnResult = await oMOCServiceClient.UploadPolicyNewAsync(arrUploadPolicyNew, CCHI_ACCESS_KEY);
		//				_Logger.LogInformation(" oXMLReturnResult Status from CCHI: " + oXMLReturnResult.status + " and CCHI_ID= " + oXMLReturnResult.result);
		//				if (oXMLReturnResult.status.ToUpper().Trim() == "PASS")
		//				{
		//					_Logger.LogInformation("*********************** Try Region - Upload Policy New *****************************");
		//					_Logger.LogInformation(" status : PASS");
		//					_Logger.LogInformation(" UplodedPolicies : " + UplodedPolicies);
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, oXMLReturnResult.result, oXMLReturnResult.status, "PASS", "Upload", UplodedPolicies.CreationUser, SeqNo);
		//				}
		//				else
		//				{
		//					_Logger.LogInformation("*********************** Try Region (FAILED) - Upload Policy New *****************************");
		//					IResponseResult<string> x = repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, oXMLReturnResult.status, oXMLReturnResult.result, "Upload", UplodedPolicies.CreationUser, null);
		//					if (x.Status == ResultStatus.Failed)
		//					{
		//						_Logger.LogInformation("after UpdatePoliciesStatus: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//					}
		//				}
		//			}
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string>(),
		//				Data = oXMLReturnResult,
		//				Status = ResultStatus.Success,
		//				TotalRecords = 0L
		//			};
		//		}
		//		catch (Exception ex2)
		//		{
		//			Exception ex = ex2;
		//			_Logger.LogInformation("*********************** Catch Region - Upload Policy New *****************************");
		//			_Logger.LogInformation("ex: " + ex.Message);
		//			_Logger.LogInformation("ex: StackTrace" + ex.StackTrace);
		//			_Logger.LogInformation("ex: Source " + ex.Source);
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", ex.Message);
		//			message.AddMessageLine("Method Name ", "UploadPolicyNew");
		//			message.AddMessageLine("Policy ID", UplodedPolicies.Id.ToString());
		//			message.AddMessageLine("Segment Code", UplodedPolicies.SegmentCode);
		//			message.AddMessageLine("Plan Name", UplodedPolicies.PlanName);
		//			_MailService.SendEmail(message.CreateMessageBody());
		//			repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, "FAILED", ex.Message, "Upload", UplodedPolicies.CreationUser, null);
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string> { ex.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}

		//	public async Task<ResponseResult<XMLReturnResult>> UpdatePolicy(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo)
		//	{
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		try
		//		{
		//			XMLReturnResult oXMLReturnResult = new XMLReturnResult();
		//			using (MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address))
		//			{
		//				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//				string CCHI_ACCESS_KEY = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//				oXMLReturnResult = await oMOCServiceClient.UpdatePolicyAsync(arrUploadPolicyNew, CCHI_ACCESS_KEY);
		//				_Logger.LogInformation(" oXMLReturnResult Status: " + oXMLReturnResult.status + " and CCHI_ID= " + oXMLReturnResult.result);
		//				if (oXMLReturnResult.status.ToUpper().Trim() == "PASS")
		//				{
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, oXMLReturnResult.result, oXMLReturnResult.status, "PASS", "Update", UplodedPolicies.CreationUser, SeqNo);
		//				}
		//				else
		//				{
		//					_Logger.LogInformation(" status : FAILED");
		//					_Logger.LogInformation(" UplodedPolicies : " + UplodedPolicies);
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, oXMLReturnResult.status, oXMLReturnResult.result, "Update", UplodedPolicies.CreationUser, null);
		//				}
		//			}
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string>(),
		//				Data = oXMLReturnResult,
		//				Status = ResultStatus.Success,
		//				TotalRecords = 0L
		//			};
		//		}
		//		catch (Exception ex)
		//		{
		//			Exception exPolicyIssuance = ex;
		//			_Logger.LogInformation("Exception.Message.PolicyIssuance: " + exPolicyIssuance.Message);
		//			_Logger.LogInformation("Exception.Source.PolicyIssuance : " + exPolicyIssuance.Source);
		//			_Logger.LogInformation("Exception.StackTrace.PolicyIssuance : " + exPolicyIssuance.StackTrace);
		//			_Logger.LogInformation("FAILD ");
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", exPolicyIssuance.Message);
		//			message.AddMessageLine("Method Name ", "UpdatePolicy");
		//			message.AddMessageLine("Policy ID", UplodedPolicies.Id.ToString());
		//			message.AddMessageLine("Segment Code", UplodedPolicies.SegmentCode);
		//			message.AddMessageLine("Plan Name", UplodedPolicies.PlanName);
		//			_MailService.SendEmail(message.CreateMessageBody());
		//			repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, "FAILED", exPolicyIssuance.Message, "Update", UplodedPolicies.CreationUser, null);
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string> { exPolicyIssuance.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}

		//	public async Task<ResponseResult<XMLReturnResult>> PolicyCancel(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo)
		//	{
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		try
		//		{
		//			XMLReturnResult oXMLReturnResult = new XMLReturnResult();
		//			using (MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address))
		//			{
		//				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//				string CCHI_ACCESS_KEY = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//				oXMLReturnResult = await oMOCServiceClient.PolicyCancelAsync(arrUploadPolicyNew, CCHI_ACCESS_KEY);
		//				_Logger.LogInformation(" oXMLReturnResult Status: " + oXMLReturnResult.status + " and CCHI_ID= " + oXMLReturnResult.result);
		//				if (oXMLReturnResult.status.ToUpper().Trim() == "PASS")
		//				{
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, oXMLReturnResult.result, oXMLReturnResult.status, "PASS", "Cancel", UplodedPolicies.CreationUser, SeqNo);
		//				}
		//				else
		//				{
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, oXMLReturnResult.status, oXMLReturnResult.result, "Cancel", UplodedPolicies.CreationUser, null);
		//				}
		//			}
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string>(),
		//				Data = oXMLReturnResult,
		//				Status = ResultStatus.Success,
		//				TotalRecords = 0L
		//			};
		//		}
		//		catch (Exception ex)
		//		{
		//			Exception exPolicyIssuance = ex;
		//			_Logger.LogInformation("Exception.Message.PolicyIssuance: " + exPolicyIssuance.Message);
		//			_Logger.LogInformation("Exception.Source.PolicyIssuance : " + exPolicyIssuance.Source);
		//			_Logger.LogInformation("Exception.StackTrace.PolicyIssuance : " + exPolicyIssuance.StackTrace);
		//			_Logger.LogInformation("FAILED ");
		//			_Logger.LogInformation(" status : FAILED");
		//			_Logger.LogInformation(" UplodedPolicies : " + UplodedPolicies);
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", exPolicyIssuance.Message);
		//			message.AddMessageLine("Method Name ", "PolicyCancel");
		//			message.AddMessageLine("Policy ID", UplodedPolicies.Id.ToString());
		//			message.AddMessageLine("Segment Code", UplodedPolicies.SegmentCode);
		//			message.AddMessageLine("Plan Name", UplodedPolicies.PlanName);
		//			_MailService.SendEmail(message.CreateMessageBody());
		//			repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, "FAILED", exPolicyIssuance.Message, "Cancel", UplodedPolicies.CreationUser, null);
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string> { exPolicyIssuance.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}

		//	public async Task<ResponseResult<XMLReturnResult>> ReNewPolicy(byte[] arrUploadPolicyNew, MpdPoliciesCchi UplodedPolicies, long? SeqNo)
		//	{
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		try
		//		{
		//			XMLReturnResult oXMLReturnResult = new XMLReturnResult();
		//			using (MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address))
		//			{
		//				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//				string CCHI_ACCESS_KEY = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//				oXMLReturnResult = await oMOCServiceClient.ReNewPolicyAsync(arrUploadPolicyNew, CCHI_ACCESS_KEY, UplodedPolicies.SegmentCode.ToString());
		//				_Logger.LogInformation(" oXMLReturnResult Status: " + oXMLReturnResult.status + " and CCHI_ID= " + oXMLReturnResult.result);
		//				if (oXMLReturnResult.status.ToUpper().Trim() == "PASS")
		//				{
		//					_Logger.LogInformation(" status : PASS");
		//					_Logger.LogInformation(" UplodedPolicies : " + UplodedPolicies);
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, oXMLReturnResult.result, oXMLReturnResult.status, "PASS", "Renew", UplodedPolicies.CreationUser, SeqNo);
		//				}
		//				else
		//				{
		//					_Logger.LogInformation(" status : FAILED");
		//					_Logger.LogInformation(" UplodedPolicies : " + UplodedPolicies);
		//					repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, oXMLReturnResult.status, oXMLReturnResult.result, "Renew", UplodedPolicies.CreationUser, null);
		//				}
		//			}
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string>(),
		//				Data = oXMLReturnResult,
		//				Status = ResultStatus.Success,
		//				TotalRecords = 0L
		//			};
		//		}
		//		catch (Exception ex)
		//		{
		//			Exception exPolicyIssuance = ex;
		//			_Logger.LogInformation("Exception.Message.PolicyIssuance: " + exPolicyIssuance.Message);
		//			_Logger.LogInformation("Exception.Source.PolicyIssuance : " + exPolicyIssuance.Source);
		//			_Logger.LogInformation("Exception.StackTrace.PolicyIssuance : " + exPolicyIssuance.StackTrace);
		//			_Logger.LogInformation("FAILED ");
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", exPolicyIssuance.Message);
		//			message.AddMessageLine("Method Name ", "ReNewPolicy");
		//			message.AddMessageLine("Policy ID", UplodedPolicies.Id.ToString());
		//			message.AddMessageLine("Segment Code", UplodedPolicies.SegmentCode);
		//			message.AddMessageLine("Plan Name", UplodedPolicies.PlanName);
		//			_MailService.SendEmail(message.CreateMessageBody());
		//			repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(UplodedPolicies.Id, null, "FAILED", exPolicyIssuance.Message, "Renew", UplodedPolicies.CreationUser, null);
		//			return new ResponseResult<XMLReturnResult>
		//			{
		//				Errors = new List<string> { exPolicyIssuance.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}

		//	public string GetMemberNameAndSetDefaultSelected(MpdMembersCchi mpdMembers)
		//	{
		//		SelectedMember = mpdMembers;
		//		return mpdMembers.Name;
		//	}

		//	public string GetSponsorNameAndSetDefaultSelected(MpdSponsorsCchi mpdSponsors)
		//	{
		//		SelectedSponsor = mpdSponsors;
		//		return mpdSponsors.Name;
		//	}

		//	public Dictionary<MpdPoliciesCchi, byte[]> GenerateCCHIData(out int IntegrationMethod, out long? SeqNo)
		//	{
		//		IntegrationMethod = 0;
		//		SeqNo = 0L;
		//		Dictionary<MpdPoliciesCchi, byte[]> result = new Dictionary<MpdPoliciesCchi, byte[]>();
		//		MpdPoliciesCchi TempPolicies = new MpdPoliciesCchi();
		//		try
		//		{
		//			_Logger.LogInformation("GenerateCCHIData Service Start --");
		//			List<MpdPoliciesCchi> ListOfPolicies = repositoryUnitOfWork.MpdPoliciesCchi.Value.LoadPolicies();
		//			_Logger.LogInformation("CCHI_INTEGRATION.LoadPoliciesForCCHI DONE --");
		//			string strXmlFileName = string.Empty;
		//			for (int i = 0; i < ListOfPolicies.Count; i++)
		//			{
		//				TempPolicies = ListOfPolicies[i];
		//				_Logger.LogInformation("CCHI Table Filled With Data to Upload -1- Policy ID: " + TempPolicies.Id);
		//				List<MpdMembersCchi> ListOfMembers = repositoryUnitOfWork.MpdMembersCchi.Value.LoadMembers((int)TempPolicies.Id);
		//				_Logger.LogInformation("Load Members for policy Count: " + ListOfMembers.Count);
		//				List<MpdClassesCchi> ListOfClasses = repositoryUnitOfWork.MpdClassesCchi.Value.LoadClasses((int)TempPolicies.Id);
		//				_Logger.LogInformation("Load Classes for policy Count: " + ListOfClasses.Count);
		//				List<MpdSponsorsCchi> ListOfSponsors = repositoryUnitOfWork.MpdSponsorsCchi.Value.LoadSponsors((int)TempPolicies.Id);
		//				_Logger.LogInformation("Load Sponsors for policy Count: " + ListOfSponsors.Count);
		//				List<MpdSponsorsCchi> ListOfDefaultSponsors = ListOfSponsors.Where((MpdSponsorsCchi x) => x.IsDefault == 1).ToList();
		//				if (SharedSettings.GovernmentIntegrationSection.EnableSponsorsCheck)
		//				{
		//					if (ListOfDefaultSponsors.Count <= 0 || ListOfMembers.Count <= 0)
		//					{
		//						IResponseResult<string> x5 = repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(TempPolicies.Id, null, "FAILED", "Sponsor issues: No default sposnor or no members defined for this policy", "Upload", TempPolicies.CreationUser, null);
		//						if (x5.Status == ResultStatus.Failed)
		//						{
		//							_Logger.LogInformation("after UpdatePoliciesStatus: STATUS: " + x5.Status.ToString() + " ERRORS: " + x5.Errors[0]);
		//						}
		//						return new Dictionary<MpdPoliciesCchi, byte[]>();
		//					}
		//					if (TempPolicies.MstNdtId == EndorsementTypes.PolicyIssue.GetHashCode() || TempPolicies.MstNdtId == EndorsementTypes.PolicyRenewal.GetHashCode() || TempPolicies.MstNdtId == EndorsementTypes.MemberAddition.GetHashCode())
		//					{
		//						long mainCount = ListOfMembers.Where((MpdMembersCchi x) => x.Relation == Relations.Self.GetHashCode()).ToList().Count();
		//						long dependentCount = ListOfMembers.Where((MpdMembersCchi x) => x.Relation != Relations.Self.GetHashCode()).ToList().Count();
		//						Task<ResponseResult<HRSDResponse>> sponsorResult = GetSponsorsDetailsFromCCHIV3(ListOfDefaultSponsors[0].SponsorNo);
		//						if (sponsorResult.Result.Data == null)
		//						{
		//							IResponseResult<string> x3 = repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(TempPolicies.Id, null, "FAILED", "Sponsor Number:" + ListOfDefaultSponsors[0].SponsorNo + " is not registered", "Upload", TempPolicies.CreationUser, null);
		//							if (x3.Status == ResultStatus.Failed)
		//							{
		//								_Logger.LogInformation("after UpdatePoliciesStatus: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//							}
		//							return new Dictionary<MpdPoliciesCchi, byte[]>();
		//						}
		//						if (TempPolicies.MstNdtId == EndorsementTypes.MemberAddition.GetHashCode())
		//						{
		//							if (mainCount < sponsorResult.Result.Data.Remaining_Main || dependentCount < sponsorResult.Result.Data.Remaining_Dependents)
		//							{
		//								IResponseResult<string> x4 = repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(TempPolicies.Id, null, "FAILED", "Sponsor Number:" + ListOfDefaultSponsors[0].SponsorNo + " -Members is less than remaining", "Upload", TempPolicies.CreationUser, null);
		//								if (x4.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("after UpdatePoliciesStatus: STATUS: " + x4.Status.ToString() + " ERRORS: " + x4.Errors[0]);
		//								}
		//								return new Dictionary<MpdPoliciesCchi, byte[]>();
		//							}
		//						}
		//						else if (mainCount < sponsorResult.Result.Data.Required_Main || dependentCount < sponsorResult.Result.Data.Required_Dependents)
		//						{
		//							IResponseResult<string> x6 = repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(TempPolicies.Id, null, "FAILED", "Sponsor Number:" + ListOfDefaultSponsors[0].SponsorNo + " -Members is less than required", "Upload", TempPolicies.CreationUser, null);
		//							if (x6.Status == ResultStatus.Failed)
		//							{
		//								_Logger.LogInformation("after UpdatePoliciesStatus: STATUS: " + x6.Status.ToString() + " ERRORS: " + x6.Errors[0]);
		//							}
		//							return new Dictionary<MpdPoliciesCchi, byte[]>();
		//						}
		//					}
		//				}
		//				strXmlFileName = string.Empty;
		//				if (TempPolicies.MstNdtId == EndorsementTypes.PolicyIssue.GetHashCode() && string.IsNullOrEmpty(ListOfMembers[0].ActionType.ToString()))
		//				{
		//					_Logger.LogInformation("Start Create XML File UploadPolicyNew / No ACTION_TYPE [Policy ID] : " + TempPolicies.Id);
		//					XElement XUploadPolicyNew = new XElement("policy", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("policy_type_id", TempPolicies.PolicyType), new XElement("issue_date", TempPolicies.EffectiveDate.Value.ToString("yyyy-MM-dd")), new XElement("policy_expiry_date", TempPolicies.ExpiryDate.Value.ToString("yyyy-MM-dd")), new XElement("sponsor_owner_number", TempPolicies.CustomerNationalId), new XElement("policy_number", TempPolicies.CchiPolicyNo.ToString()), new XElement("beneficiaries", ListOfMembers.Select((MpdMembersCchi oMem) => new XElement("beneficiary", new XElement("name", GetMemberNameAndSetDefaultSelected(oMem)), new XElement("date_of_birth", oMem.BirthDate.Value.ToString("yyyy-MM-dd")), new XElement("hijri_dob", oMem.HijriBirthDate.Value.ToString("yyyy-MM-dd")), new XElement("gender", oMem.Gender), new XElement("premium", oMem.GrossPremium), new XElement("identity_type", GetIdentityType(oMem.NationalId, oMem.NationalityId)), new XElement("identity_number", oMem.NationalId), new XElement("identity_expiry_date", oMem.IdentityExpiryDate.HasValue ? oMem.IdentityExpiryDate.Value.ToString("yyyy-MM-dd") : "1900-01-01"), new XElement("border_entry_number", oMem.NationalId), new XElement("beneficiary_type", (oMem.Relation == Relations.Self.GetHashCode()) ? 1 : 2), new XElement("insurance_number", oMem.SegmentCode), new XElement("main_insurance_number", oMem.ParentSegmentCode), new XElement("nationality_id", oMem.NationalityId), new XElement("marital_status", oMem.MaritalStatus), new XElement("mobile", HandleMobileNumber(oMem.Mobile)), new XElement("phone", string.IsNullOrEmpty(oMem.PhoneNo) ? HandleMobileNumber(oMem.Mobile) : oMem.PhoneNo), new XElement("email", string.IsNullOrEmpty(oMem.Email) ? "mail@domain.com" : oMem.Email), new XElement("city_id", 101), new XElement("is_there_dependents", (oMem.Relation == Relations.Self.GetHashCode() && oMem.MaritalStatus == MaritalStatus.Married.GetHashCode()) ? 1 : 0), new XElement("class_number", oMem.MpdPclId), new XElement("relation_type", GetRelationType(Convert.ToInt16(oMem.Gender), Convert.ToInt16(oMem.Relation))), new XElement("sponsor_number", oMem.SponserNo), new XElement("job_code", (oMem.Occupation != null && oMem.Occupation != string.Empty) ? oMem.Occupation : "2320"), new XElement("low_premium_reason", 2), new XElement("remarks", " "), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("network_id", from x in repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => x.MpdPclId == oMem.MpdPclId && x.MpdPlcCchiId == (long?)TempPolicies.Id)
		//						select x.NetworkId)))), new XElement("classes", ListOfClasses.Select((MpdClassesCchi oClasses) => new XElement("class", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("deductable_rate", oClasses.IntMaxDeductable.HasValue ? oClasses.IntMaxDeductable.Value : 0m), new XElement("max_limit", oClasses.MaxCoverLimit), new XElement("class_name", oClasses.Name), new XElement("class_number", oClasses.PlanClass), new XElement("cchi_class_number", oClasses.CchiPlanClass)))), new XElement("sponsors", ListOfSponsors.Select((MpdSponsorsCchi oSponsers) => new XElement("sponsor", new XElement("name", GetSponsorNameAndSetDefaultSelected(oSponsers)), new XElement("phone", HandleMobileNumber(oSponsers.PhoneNo)), new XElement("mobile", HandleMobileNumber(oSponsers.MobileNo)), new XElement("email", "mail@domain.com"), new XElement("city_id", 101), new XElement("registry_type", oSponsers.RegistryType), new XElement("registry_number", oSponsers.RegistryNo), new XElement("sponsor_number", oSponsers.SponsorNo), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("unit_no", 0)))));
		//					string HostName = SharedSettings.Keys.HostName;
		//					strXmlFileName = "CCHI_INTEGRATION_ISSUANCE_" + TempPolicies.CchiPolicyNo.ToString() + "_" + Guid.NewGuid().ToString() + ".xml";
		//					string strFullxmlPath = TempPath(string.Empty) + strXmlFileName;
		//					XUploadPolicyNew.Save(strFullxmlPath);
		//					XUploadPolicyNew.Save(PolicyDocumentsPath(TempPolicies.Id, string.Empty) + strXmlFileName);
		//					_Logger.LogInformation(" CCHI INTEGRATION ISSUANCE 1 File Saved : " + strFullxmlPath);
		//					byte[] arrUploadPolicyNew = Encoding.UTF8.GetBytes(XUploadPolicyNew.ToString());
		//					IntegrationMethod = CCHIIntegrationMethod.UploadPolicyNew.GetHashCode();
		//					SeqNo = ListOfMembers[0].SeqNo;
		//					result.Add(TempPolicies, arrUploadPolicyNew);
		//					return result;
		//				}
		//				if (TempPolicies.MstNdtId == EndorsementTypes.PolicyIssue.GetHashCode() && !string.IsNullOrEmpty(ListOfMembers[0].ActionType.ToString()))
		//				{
		//					_Logger.LogInformation("Start Create XML File Issuance 2 [Policy ID] : " + TempPolicies.Id);
		//					XElement XUploadPolicyNew2 = new XElement("policy", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("policy_number", TempPolicies.CchiPolicyNo.ToString()), new XElement("beneficiaries", ListOfMembers.Select((MpdMembersCchi oMem) => new XElement("beneficiary", new XAttribute("action_type", "1"), new XElement("name", GetMemberNameAndSetDefaultSelected(oMem)), new XElement("date_of_birth", oMem.BirthDate.Value.ToString("yyyy-MM-dd")), new XElement("hijri_dob", oMem.HijriBirthDate.Value.ToString("yyyy-MM-dd")), new XElement("gender", oMem.Gender), new XElement("premium", oMem.GrossPremium), new XElement("identity_type", GetIdentityType(oMem.NationalId, oMem.NationalityId)), new XElement("identity_number", oMem.NationalId), new XElement("identity_expiry_date", oMem.IdentityExpiryDate.HasValue ? oMem.IdentityExpiryDate.Value.ToString("yyyy-MM-dd") : "1900-01-01"), new XElement("border_entry_number", oMem.NationalId), new XElement("beneficiary_type", (oMem.Relation == Relations.Self.GetHashCode()) ? 1 : 2), new XElement("insurance_number", oMem.SegmentCode), new XElement("main_insurance_number", oMem.ParentSegmentCode), new XElement("nationality_id", oMem.NationalityId), new XElement("marital_status", oMem.MaritalStatus), new XElement("mobile", HandleMobileNumber(oMem.Mobile)), new XElement("phone", string.IsNullOrEmpty(oMem.PhoneNo) ? HandleMobileNumber(oMem.Mobile) : oMem.PhoneNo), new XElement("email", string.IsNullOrEmpty(oMem.Email) ? "mail@domain.com" : oMem.Email), new XElement("city_id", 101), new XElement("is_there_dependents", (oMem.Relation == Relations.Self.GetHashCode() && oMem.MaritalStatus == MaritalStatus.Married.GetHashCode()) ? 1 : 0), new XElement("class_number", oMem.MpdPclId), new XElement("relation_type", GetRelationType(Convert.ToInt16(oMem.Gender), Convert.ToInt16(oMem.Relation))), new XElement("sponsor_number", oMem.SponserNo), new XElement("job_code", (oMem.Occupation != null && oMem.Occupation != string.Empty) ? oMem.Occupation : "2320"), new XElement("low_premium_reason", 2), new XElement("cancellation_reason_code", oMem.CancellationReason.HasValue ? oMem.CancellationReason.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.MemberCancellation.GetHashCode()) ? "6" : " ")), new XElement("cancellation_reason", (!string.IsNullOrEmpty(oMem.CancellationReasonDesc)) ? oMem.CancellationReasonDesc.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.MemberCancellation.GetHashCode()) ? "ALTERNATIVE INSURANCE" : " ")), new XElement("transaction_amount", Convert.ToDecimal(Math.Round(oMem.CchiGrossPremium.Value, 0).ToString())), new XElement("transaction_date", oMem.EffectiveDate.Value.ToString("yyyy-MM-dd")), new XElement("remarks", " "), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("network_id", from x in repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => x.MpdPclId == oMem.MpdPclId && x.MpdPlcCchiId == (long?)TempPolicies.Id)
		//						select x.NetworkId)))), new XElement("classes", ListOfClasses.Select((MpdClassesCchi oClasses) => new XElement("class", new XAttribute("action_type", HandleClassActionType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oClasses.PlanClass).Result), new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("deductable_rate", oClasses.IntMaxDeductable.HasValue ? oClasses.IntMaxDeductable.Value : 0m), new XElement("max_limit", oClasses.MaxCoverLimit), new XElement("class_name", oClasses.Name), new XElement("class_number", oClasses.PlanClass), new XElement("cchi_class_number", oClasses.CchiPlanClass)))), new XElement("sponsors", ListOfSponsors.Select((MpdSponsorsCchi oSponsers) => new XElement("sponsor", new XAttribute("action_type", HandleSponsorType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oSponsers.SponsorNo).Result), new XElement("name", GetSponsorNameAndSetDefaultSelected(oSponsers)), new XElement("phone", HandleMobileNumber(oSponsers.PhoneNo)), new XElement("mobile", HandleMobileNumber(oSponsers.MobileNo)), new XElement("email", "mail@domain.com"), new XElement("city_id", 101), new XElement("sponsor_number", oSponsers.SponsorNo), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("unit_no", 0)))));
		//					string HostName2 = SharedSettings.Keys.HostName;
		//					strXmlFileName = "CCHI_INTEGRATION_ISSUANCE2_" + TempPolicies.CchiPolicyNo.ToString() + "_" + Guid.NewGuid().ToString() + ".xml";
		//					string strFullxmlPath2 = TempPath(string.Empty) + strXmlFileName;
		//					_Logger.LogInformation(" CCHI INTEGRATION ISSUANCE 2 File Saved : " + strFullxmlPath2);
		//					XUploadPolicyNew2.Save(strFullxmlPath2);
		//					XUploadPolicyNew2.Save(PolicyDocumentsPath(TempPolicies.Id, string.Empty) + strXmlFileName);
		//					byte[] arrUploadPolicyNew2 = Encoding.UTF8.GetBytes(XUploadPolicyNew2.ToString());
		//					IntegrationMethod = CCHIIntegrationMethod.UpdatePolicy.GetHashCode();
		//					SeqNo = ListOfMembers[0].SeqNo;
		//					result.Add(TempPolicies, arrUploadPolicyNew2);
		//					return result;
		//				}
		//				if (TempPolicies.MstNdtId == EndorsementTypes.PolicyCancellation.GetHashCode())
		//				{
		//					_Logger.LogInformation("Start Create XML File Cancellation [Policy ID] : " + TempPolicies.Id);
		//					XElement XUploadPolicyNew5 = new XElement("policy", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("policy_number", TempPolicies.CchiPolicyNo.ToString()), new XElement("beneficiaries", ListOfMembers.Select((MpdMembersCchi oMem) => new XElement("beneficiary", new XAttribute("action_type", HandleEndorsementActionType(TempPolicies.MstNdtId.Value, Convert.ToInt64(oMem.MpdPlmId))), new XElement("name", GetMemberNameAndSetDefaultSelected(oMem)), new XElement("identity_type", GetIdentityType(oMem.NationalId, oMem.NationalityId)), new XElement("identity_number", oMem.NationalId), new XElement("insurance_number", oMem.SegmentCode), new XElement("cancellation_reason_code", oMem.CancellationReason.HasValue ? oMem.CancellationReason.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.PolicyCancellation.GetHashCode()) ? "6" : " ")), new XElement("cancellation_reason", (!string.IsNullOrEmpty(oMem.CancellationReasonDesc)) ? oMem.CancellationReasonDesc.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.PolicyCancellation.GetHashCode()) ? "ALTERNATIVE INSURANCE" : " ")), new XElement("transaction_amount", oMem.GrossPremium), new XElement("transaction_date", oMem.EffectiveDate.Value.ToString("yyyy-MM-dd"))))));
		//					string HostName5 = SharedSettings.Keys.HostName;
		//					strXmlFileName = "CCHI_INTEGRATION_CANCELLATION_" + TempPolicies.CchiPolicyNo.ToString() + "_" + Guid.NewGuid().ToString() + ".xml";
		//					string strFullxmlPath4 = TempPath(string.Empty) + strXmlFileName;
		//					_Logger.LogInformation(" CCHI INTEGRATION CANCELLATION  File Saved : " + strFullxmlPath4);
		//					XUploadPolicyNew5.Save(strFullxmlPath4);
		//					XUploadPolicyNew5.Save(PolicyDocumentsPath(TempPolicies.Id, string.Empty) + strXmlFileName);
		//					byte[] arrUploadPolicyNew4 = Encoding.UTF8.GetBytes(XUploadPolicyNew5.ToString());
		//					IntegrationMethod = CCHIIntegrationMethod.PolicyCancel.GetHashCode();
		//					SeqNo = ListOfMembers[0].SeqNo;
		//					result.Add(TempPolicies, arrUploadPolicyNew4);
		//					return result;
		//				}
		//				if (TempPolicies.MstNdtId == EndorsementTypes.PolicyRenewal.GetHashCode() && string.IsNullOrEmpty(ListOfMembers[0].ActionType.ToString()))
		//				{
		//					_Logger.LogInformation("Start Create XML File Renewal [Policy ID] : " + TempPolicies.Id);
		//					XElement XUploadPolicyNew6 = new XElement("policy", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("policy_type_id", TempPolicies.PolicyType), new XElement("issue_date", TempPolicies.EffectiveDate.Value.ToString("yyyy-MM-dd")), new XElement("policy_expiry_date", TempPolicies.ExpiryDate.Value.ToString("yyyy-MM-dd")), new XElement("sponsor_owner_number", TempPolicies.CustomerNationalId), new XElement("policy_number", TempPolicies.CchiPolicyNo.ToString()), new XElement("beneficiaries", ListOfMembers.Select((MpdMembersCchi oMem) => new XElement("beneficiary", new XAttribute("action_type", "8"), new XElement("name", GetMemberNameAndSetDefaultSelected(oMem)), new XElement("date_of_birth", oMem.BirthDate.Value.ToString("yyyy-MM-dd")), new XElement("hijri_dob", oMem.HijriBirthDate.Value.ToString("yyyy-MM-dd")), new XElement("gender", oMem.Gender), new XElement("premium", oMem.GrossPremium), new XElement("identity_type", GetIdentityType(oMem.NationalId, oMem.NationalityId)), new XElement("identity_number", oMem.NationalId), new XElement("identity_expiry_date", oMem.IdentityExpiryDate.HasValue ? oMem.IdentityExpiryDate.Value.ToString("yyyy-MM-dd") : "1900-01-01"), new XElement("border_entry_number", oMem.NationalId), new XElement("beneficiary_type", (oMem.Relation == Relations.Self.GetHashCode()) ? 1 : 2), new XElement("insurance_number", oMem.SegmentCode), new XElement("main_insurance_number", oMem.ParentSegmentCode), new XElement("nationality_id", oMem.NationalityId), new XElement("marital_status", oMem.MaritalStatus), new XElement("mobile", HandleMobileNumber(oMem.Mobile)), new XElement("phone", string.IsNullOrEmpty(oMem.PhoneNo) ? HandleMobileNumber(oMem.Mobile) : oMem.PhoneNo), new XElement("email", string.IsNullOrEmpty(oMem.Email) ? "mail@domain.com" : oMem.Email), new XElement("city_id", 101), new XElement("is_there_dependents", (oMem.Relation == Relations.Self.GetHashCode() && oMem.MaritalStatus == MaritalStatus.Married.GetHashCode()) ? 1 : 0), new XElement("class_number", oMem.MpdPclId), new XElement("relation_type", GetRelationType(Convert.ToInt16(oMem.Gender), Convert.ToInt16(oMem.Relation))), new XElement("sponsor_number", oMem.SponserNo), new XElement("job_code", (oMem.Occupation != null && oMem.Occupation != string.Empty) ? oMem.Occupation : "2320"), new XElement("low_premium_reason", 2), new XElement("remarks", " "), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("network_id", from x in repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => x.MpdPclId == oMem.MpdPclId && x.MpdPlcCchiId == (long?)TempPolicies.Id)
		//						select x.NetworkId)))), new XElement("classes", ListOfClasses.Select((MpdClassesCchi oClasses) => new XElement("class", new XAttribute("action_type", HandleClassActionType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oClasses.PlanClass).Result), new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("deductable_rate", oClasses.IntMaxDeductable.HasValue ? oClasses.IntMaxDeductable.Value : 0m), new XElement("max_limit", oClasses.MaxCoverLimit), new XElement("class_name", oClasses.Name), new XElement("class_number", oClasses.PlanClass), new XElement("cchi_class_number", oClasses.CchiPlanClass)))), new XElement("sponsors", ListOfSponsors.Select((MpdSponsorsCchi oSponsers) => new XElement("sponsor", new XAttribute("action_type", HandleSponsorType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oSponsers.SponsorNo).Result), new XElement("name", GetSponsorNameAndSetDefaultSelected(oSponsers)), new XElement("phone", oSponsers.PhoneNo), new XElement("mobile", HandleMobileNumber(oSponsers.MobileNo)), new XElement("email", oSponsers.Email), new XElement("city_id", 101), new XElement("registry_type", oSponsers.RegistryType), new XElement("registry_number", oSponsers.RegistryNo), new XElement("sponsor_number", oSponsers.SponsorNo), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("unit_no", 0)))));
		//					string b2 = XUploadPolicyNew6.Value;
		//					string HostName6 = SharedSettings.Keys.HostName;
		//					strXmlFileName = "CCHI_INTEGRATION_RENEWAL_" + TempPolicies.CchiPolicyNo.ToString() + "_" + Guid.NewGuid().ToString() + ".xml";
		//					string strFullxmlPath6 = TempPath(string.Empty) + strXmlFileName;
		//					_Logger.LogInformation(" CCHI INTEGRATION RENEWAL File Saved : " + strFullxmlPath6);
		//					XUploadPolicyNew6.Save(strFullxmlPath6);
		//					XUploadPolicyNew6.Save(PolicyDocumentsPath(TempPolicies.Id, string.Empty) + strXmlFileName);
		//					byte[] arrUploadPolicyNew6 = Encoding.UTF8.GetBytes(XUploadPolicyNew6.ToString());
		//					IntegrationMethod = CCHIIntegrationMethod.ReNewPolicy.GetHashCode();
		//					SeqNo = ListOfMembers[0].SeqNo;
		//					result.Add(TempPolicies, arrUploadPolicyNew6);
		//					return result;
		//				}
		//				if (TempPolicies.MstNdtId == EndorsementTypes.PolicyRenewal.GetHashCode() && !string.IsNullOrEmpty(ListOfMembers[0].ActionType.ToString()))
		//				{
		//					_Logger.LogInformation("Start Create XML File Renewal 2 [Policy ID] : " + TempPolicies.Id);
		//					XElement XUploadPolicyNew4 = new XElement("policy", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("policy_number", TempPolicies.SegmentCode.ToString()), new XElement("beneficiaries", ListOfMembers.Select((MpdMembersCchi oMem) => new XElement("beneficiary", new XAttribute("action_type", "8"), new XElement("name", GetMemberNameAndSetDefaultSelected(oMem)), new XElement("date_of_birth", oMem.BirthDate.Value.ToString("yyyy-MM-dd")), new XElement("hijri_dob", oMem.HijriBirthDate.Value.ToString("yyyy-MM-dd")), new XElement("gender", oMem.Gender), new XElement("premium", oMem.GrossPremium), new XElement("identity_type", GetIdentityType(oMem.NationalId, oMem.NationalityId)), new XElement("identity_number", oMem.NationalId), new XElement("identity_expiry_date", oMem.IdentityExpiryDate.HasValue ? oMem.IdentityExpiryDate.Value.ToString("yyyy-MM-dd") : "1900-01-01"), new XElement("border_entry_number", oMem.NationalId), new XElement("beneficiary_type", (oMem.Relation == Relations.Self.GetHashCode()) ? 1 : 2), new XElement("insurance_number", oMem.SegmentCode), new XElement("main_insurance_number", oMem.ParentSegmentCode), new XElement("nationality_id", oMem.NationalityId), new XElement("marital_status", oMem.MaritalStatus), new XElement("mobile", HandleMobileNumber(oMem.Mobile)), new XElement("phone", string.IsNullOrEmpty(oMem.PhoneNo) ? HandleMobileNumber(oMem.Mobile) : oMem.PhoneNo), new XElement("email", string.IsNullOrEmpty(oMem.Email) ? "mail@domain.com" : oMem.Email), new XElement("city_id", 101), new XElement("is_there_dependents", (oMem.Relation == Relations.Self.GetHashCode() && oMem.MaritalStatus == MaritalStatus.Married.GetHashCode()) ? 1 : 0), new XElement("class_number", oMem.MpdPclId), new XElement("relation_type", GetRelationType(Convert.ToInt16(oMem.Gender), Convert.ToInt16(oMem.Relation))), new XElement("sponsor_number", oMem.SponserNo), new XElement("job_code", (oMem.Occupation != null && oMem.Occupation != string.Empty) ? oMem.Occupation : "2320"), new XElement("low_premium_reason", 2), new XElement("cancellation_reason_code", oMem.CancellationReason.HasValue ? oMem.CancellationReason.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.MemberCancellation.GetHashCode()) ? "6" : " ")), new XElement("cancellation_reason", (!string.IsNullOrEmpty(oMem.CancellationReasonDesc)) ? oMem.CancellationReasonDesc.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.MemberCancellation.GetHashCode()) ? "ALTERNATIVE INSURANCE" : " ")), new XElement("transaction_amount", Convert.ToDecimal(Math.Round(oMem.CchiGrossPremium.Value, 0).ToString())), new XElement("transaction_date", oMem.EffectiveDate.Value.ToString("yyyy-MM-dd")), new XElement("remarks", " "), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("network_id", from x in repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => x.MpdPclId == oMem.MpdPclId && x.MpdPlcCchiId == (long?)TempPolicies.Id)
		//						select x.NetworkId)))), new XElement("classes", ListOfClasses.Select((MpdClassesCchi oClasses) => new XElement("class", new XAttribute("action_type", HandleClassActionType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oClasses.PlanClass).Result), new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("deductable_rate", oClasses.IntMaxDeductable.HasValue ? oClasses.IntMaxDeductable.Value : 0m), new XElement("max_limit", oClasses.MaxCoverLimit), new XElement("class_name", oClasses.Name), new XElement("class_number", oClasses.PlanClass), new XElement("cchi_class_number", oClasses.CchiPlanClass)))), new XElement("sponsors", ListOfSponsors.Select((MpdSponsorsCchi oSponsers) => new XElement("sponsor", new XAttribute("action_type", HandleSponsorType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oSponsers.SponsorNo).Result), new XElement("name", GetSponsorNameAndSetDefaultSelected(oSponsers)), new XElement("phone", oSponsers.PhoneNo), new XElement("mobile", HandleMobileNumber(oSponsers.MobileNo)), new XElement("email", oSponsers.Email), new XElement("city_id", 101), new XElement("sponsor_number", oSponsers.SponsorNo), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("unit_no", 0)))));
		//					string b = XUploadPolicyNew4.Value;
		//					string HostName4 = SharedSettings.Keys.HostName;
		//					strXmlFileName = "CCHI_INTEGRATION_RENEWAL2_" + TempPolicies.CchiPolicyNo.ToString() + "_" + Guid.NewGuid().ToString() + ".xml";
		//					string strFullxmlPath5 = TempPath(string.Empty) + strXmlFileName;
		//					_Logger.LogInformation(" CCHI INTEGRATION RENEWAL 2 File Saved : " + strFullxmlPath5);
		//					XUploadPolicyNew4.Save(strFullxmlPath5);
		//					XUploadPolicyNew4.Save(PolicyDocumentsPath(TempPolicies.Id, string.Empty) + strXmlFileName);
		//					byte[] arrUploadPolicyNew5 = Encoding.UTF8.GetBytes(XUploadPolicyNew4.ToString());
		//					IntegrationMethod = CCHIIntegrationMethod.UpdatePolicy.GetHashCode();
		//					SeqNo = ListOfMembers[0].SeqNo;
		//					result.Add(TempPolicies, arrUploadPolicyNew5);
		//					return result;
		//				}
		//				if (TempPolicies.MstNdtId != EndorsementTypes.MemberAddition.GetHashCode() && TempPolicies.MstNdtId != EndorsementTypes.MemberCancellation.GetHashCode() && TempPolicies.MstNdtId != EndorsementTypes.MemberCorrection.GetHashCode() && TempPolicies.MstNdtId != EndorsementTypes.PolicyExtension.GetHashCode() && TempPolicies.MstNdtId != EndorsementTypes.PolicyCorrection.GetHashCode())
		//				{
		//					continue;
		//				}
		//				_Logger.LogInformation("Start Create XML File Endorsement [Policy ID] : " + TempPolicies.Id);
		//				XElement XUploadPolicyNew3 = new XElement("policy", new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("policy_number", TempPolicies.CchiPolicyNo.ToString()), new XElement("beneficiaries", ListOfMembers.Select((MpdMembersCchi oMem) => new XElement("beneficiary", new XAttribute("action_type", HandleEndorsementActionType(TempPolicies.MstNdtId.Value, Convert.ToInt64(oMem.MpdPlmId))), new XElement("name", GetMemberNameAndSetDefaultSelected(oMem)), new XElement("date_of_birth", oMem.BirthDate.Value.ToString("yyyy-MM-dd")), new XElement("hijri_dob", oMem.HijriBirthDate.Value.ToString("yyyy-MM-dd")), new XElement("gender", oMem.Gender), new XElement("premium", oMem.GrossPremium), new XElement("identity_type", GetIdentityType(oMem.NationalId, oMem.NationalityId)), new XElement("identity_number", oMem.NationalId), new XElement("identity_expiry_date", oMem.IdentityExpiryDate.HasValue ? oMem.IdentityExpiryDate.Value.ToString("yyyy-MM-dd") : "1900-01-01"), new XElement("border_entry_number", oMem.NationalId), new XElement("beneficiary_type", (oMem.Relation == Relations.Self.GetHashCode()) ? 1 : 2), new XElement("insurance_number", oMem.SegmentCode), new XElement("main_insurance_number", oMem.ParentSegmentCode), new XElement("nationality_id", oMem.NationalityId), new XElement("marital_status", oMem.MaritalStatus), new XElement("mobile", HandleMobileNumber(oMem.Mobile)), new XElement("phone", string.IsNullOrEmpty(oMem.PhoneNo) ? HandleMobileNumber(oMem.Mobile) : oMem.PhoneNo), new XElement("email", string.IsNullOrEmpty(oMem.Email) ? "mail@domain.com" : oMem.Email), new XElement("city_id", 101), new XElement("is_there_dependents", (oMem.Relation == Relations.Self.GetHashCode() && oMem.MaritalStatus == MaritalStatus.Married.GetHashCode()) ? 1 : 0), new XElement("class_number", oMem.MpdPclId), new XElement("relation_type", GetRelationType(Convert.ToInt16(oMem.Gender), Convert.ToInt16(oMem.Relation))), new XElement("sponsor_number", oMem.SponserNo), new XElement("job_code", (oMem.Occupation != null && oMem.Occupation != string.Empty) ? oMem.Occupation : "2320"), new XElement("low_premium_reason", 2), new XElement("cancellation_reason_code", oMem.CancellationReason.HasValue ? oMem.CancellationReason.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.MemberCancellation.GetHashCode()) ? "6" : " ")), new XElement("cancellation_reason", (!string.IsNullOrEmpty(oMem.CancellationReasonDesc)) ? oMem.CancellationReasonDesc.ToString() : ((TempPolicies.MstNdtId == EndorsementTypes.MemberCancellation.GetHashCode()) ? "ALTERNATIVE INSURANCE" : " ")), new XElement("transaction_amount", Convert.ToDecimal(Math.Round(oMem.CchiGrossPremium.Value, 0).ToString())), new XElement("transaction_date", oMem.EffectiveDate.Value.ToString("yyyy-MM-dd")), new XElement("remarks", " "), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("network_id", from x in repositoryUnitOfWork.MpdClassesCchi.Value.Find((MpdClassesCchi x) => x.MpdPclId == oMem.MpdPclId && x.MpdPlcCchiId == (long?)TempPolicies.Id)
		//					select x.NetworkId)))), new XElement("classes", ListOfClasses.Select((MpdClassesCchi oClasses) => new XElement("class", new XAttribute("action_type", HandleClassActionType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oClasses.PlanClass).Result), new XElement("company_id", SharedSettings.GovernmentIntegrationSection.UserCompanyID.ToString()), new XElement("deductable_rate", oClasses.IntMaxDeductable.HasValue ? oClasses.IntMaxDeductable.Value : 0m), new XElement("max_limit", oClasses.MaxCoverLimit), new XElement("class_name", oClasses.Name), new XElement("class_number", oClasses.PlanClass), new XElement("cchi_class_number", oClasses.CchiPlanClass)))), new XElement("sponsors", ListOfSponsors.Select((MpdSponsorsCchi oSponsers) => new XElement("sponsor", new XAttribute("action_type", HandleSponsorType(SharedSettings.GovernmentIntegrationSection.AccessKey, TempPolicies.CchiPolicyNo, oSponsers.SponsorNo).Result), new XElement("name", GetSponsorNameAndSetDefaultSelected(oSponsers)), new XElement("phone", HandleMobileNumber(oSponsers.PhoneNo)), new XElement("mobile", HandleMobileNumber(oSponsers.MobileNo)), new XElement("email", "mail@domain.com"), new XElement("city_id", 101), new XElement("sponsor_number", oSponsers.SponsorNo), new XElement("additional_number", 0), new XElement("building_number", 0), new XElement("district", " "), new XElement("post_code", 0), new XElement("street_name", " "), new XElement("unit_no", 0)))));
		//				string HostName3 = SharedSettings.Keys.HostName;
		//				strXmlFileName = "CCHI_INTEGRATION_END_" + TempPolicies.CchiPolicyNo.ToString() + "_" + Guid.NewGuid().ToString() + ".xml";
		//				string strFullxmlPath3 = TempPath(string.Empty) + strXmlFileName;
		//				_Logger.LogInformation(" CCHI INTEGRATION Endorsement File Saved : " + strFullxmlPath3);
		//				XUploadPolicyNew3.Save(strFullxmlPath3);
		//				XUploadPolicyNew3.Save(PolicyDocumentsPath(TempPolicies.Id, string.Empty) + strXmlFileName);
		//				byte[] arrUploadPolicyNew3 = Encoding.UTF8.GetBytes(XUploadPolicyNew3.ToString());
		//				IntegrationMethod = CCHIIntegrationMethod.UpdatePolicy.GetHashCode();
		//				SeqNo = ListOfMembers[0].SeqNo;
		//				result.Add(TempPolicies, arrUploadPolicyNew3);
		//				return result;
		//			}
		//			return new Dictionary<MpdPoliciesCchi, byte[]>();
		//		}
		//		catch (Exception ex)
		//		{
		//			_Logger.LogInformation("*****************************GenerateCCHIData Catch region: Policy ID:" + TempPolicies.Id + "*****************************");
		//			IntegrationMethod = 0;
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", ex.Message);
		//			message.AddMessageLine("Method Name ", "GenerateCCHIData");
		//			message.AddMessageLine("Policy Number ", TempPolicies.PolicyNo.ToString());
		//			message.AddMessageLine("Plan Name ", TempPolicies.PlanName);
		//			message.AddMessageLine("Member Id ", SelectedMember.Id.ToString());
		//			if (SelectedSponsor.SponsorNo != null)
		//			{
		//				message.AddMessageLine("Sponsor Number ", SelectedSponsor.SponsorNo.ToString());
		//			}
		//			_MailService.SendEmail(message.CreateMessageBody());
		//			_Logger.LogInformation("Member ID : " + SelectedMember.Id);
		//			_Logger.LogInformation("Exception.Message : " + ex.Message);
		//			_Logger.LogInformation("Exception.Source : " + ex.Source);
		//			_Logger.LogInformation("Exception.StackTrace : " + ex.StackTrace);
		//			IResponseResult<string> x2 = repositoryUnitOfWork.MpdPoliciesCchi.Value.UpdatePoliciesStatus(TempPolicies.Id, null, "FAILED", ex?.ToString() + ex.Message + ex.StackTrace, "Upload", TempPolicies.CreationUser, null);
		//			if (x2.Status == ResultStatus.Failed)
		//			{
		//				_Logger.LogInformation("after UpdatePoliciesStatus: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//			}
		//			return new Dictionary<MpdPoliciesCchi, byte[]>();
		//		}
		//	}

		//	public bool GenerateMemberStatus()
		//	{
		//		try
		//		{
		//			_Logger.LogInformation("StartUpdateMemberStatus");
		//			List<MpdPoliciesCchi> lstTransactions = repositoryUnitOfWork.MpdPoliciesCchi.Value.LoadTransactionsForCCHI();
		//			if (lstTransactions != null)
		//			{
		//				_Logger.LogInformation("CCHI_INTEGRATION.LoadTransactionsForCCHI DONE lstTransactions.Count: " + lstTransactions.Count);
		//				for (int i = 0; i < lstTransactions.Count; i++)
		//				{
		//					if (!string.IsNullOrEmpty(lstTransactions[i].Id.ToString()) && !string.IsNullOrEmpty(lstTransactions[i].CchiId.ToString()))
		//					{
		//						Task<ResponseResult<PolicyTransactionStatusWithResult>> Result = UpdateMemberStatusCCHI(Convert.ToInt64(lstTransactions[i].Id.ToString()), lstTransactions[i].CchiPolicyNo.ToString(), lstTransactions[i].CchiId.ToString());
		//					}
		//				}
		//			}
		//			return true;
		//		}
		//		catch (Exception ex)
		//		{
		//			_Logger.LogInformation("Exception.Message.GenerateMemberStatus : " + ex.Message);
		//			_Logger.LogInformation("Exception.Source.GenerateMemberStatus : " + ex.Source);
		//			_Logger.LogInformation("Exception.StackTrace.GenerateMemberStatus : " + ex.StackTrace);
		//			return true;
		//		}
		//	}

		//	public async Task<ResponseResult<PolicyTransactionStatusWithResult>> UpdateMemberStatusCCHI(long MpdPlcCchiId, string CchiPolicyNo, string TransactionName)
		//	{
		//		_Logger.LogInformation("Update Member status CCHI method insert");
		//		string CCHI_ACCESS_KEY = SharedSettings.GovernmentIntegrationSection.AccessKey;
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		using MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address);
		//		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//		try
		//		{
		//			if (!string.IsNullOrEmpty(TransactionName))
		//			{
		//				_Logger.LogInformation("Update Member status CCHI method TransactionName: " + TransactionName);
		//				if (TransactionName.StartsWith("T"))
		//				{
		//					_Logger.LogInformation("Update Member status CCHI method TransactionName:Starts with T ");
		//					PolicyTransactionStatusWithResult oPolicyTransactionStatusWithResult = await oMOCServiceClient.PolicyTransactionStatusAsync(CchiPolicyNo, CCHI_ACCESS_KEY, TransactionName.Substring(17));
		//					_Logger.LogInformation("Update Member status CCHI method PolicyTransactionStatusAsync after oPolicyTransactionStatusWithResult.TransactionStatusList.Length: " + oPolicyTransactionStatusWithResult.TransactionStatusList.Length);
		//					PolicyTransactionStatus[] arrPolicyTransactionStatus = oPolicyTransactionStatusWithResult.TransactionStatusList;
		//					for (int I = 0; I < arrPolicyTransactionStatus.Length; I++)
		//					{
		//						ApprovedBeneficiaries[] arrApprovedBeneficiaries = arrPolicyTransactionStatus[I].ApprovedBeneficiaries;
		//						RejectedBeneficiaries[] arrRejectedBeneficiaries = arrPolicyTransactionStatus[I].RejectedBeneficiaries;
		//						_Logger.LogInformation("UpdateMemberStatusCCHI arrApprovedBeneficiaries 1 : " + arrApprovedBeneficiaries);
		//						_Logger.LogInformation("UpdateMemberStatusCCHI arrRejectedBeneficiaries 1 : " + arrRejectedBeneficiaries);
		//						if (arrApprovedBeneficiaries != null && arrApprovedBeneficiaries.Length != 0)
		//						{
		//							for (int X = 0; X < arrApprovedBeneficiaries.Length; X++)
		//							{
		//								IResponseResult<string> x4 = repositoryUnitOfWork.MpdMembersCchi.Value.UpdateMembersStatusDB(MpdPlcCchiId, arrApprovedBeneficiaries[X].BeneficiaryNumber.Trim(), "APPROVED", null, "Update member Status", null);
		//								if (x4.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("after UpdateMembersStatusDB: STATUS: " + x4.Status.ToString() + " ERRORS: " + x4.Errors[0]);
		//								}
		//								_Logger.LogInformation("UpdateMemberStatusCCHI arrApprovedBeneficiaries SegmentCode: " + arrApprovedBeneficiaries[X].BeneficiaryNumber.Trim());
		//							}
		//						}
		//						if (arrRejectedBeneficiaries == null || arrRejectedBeneficiaries.Length == 0)
		//						{
		//							continue;
		//						}
		//						int Z;
		//						for (Z = 0; Z < arrRejectedBeneficiaries.Length; Z++)
		//						{
		//							RejectedBeneficiaries[] result = Array.FindAll(arrRejectedBeneficiaries, (RejectedBeneficiaries element) => element.BeneficiaryNumber.Trim() == arrRejectedBeneficiaries[Z].BeneficiaryNumber.Trim());
		//							if (result.Length > 1)
		//							{
		//								string resultStatus = "";
		//								for (int i = 0; i < result.Length; i++)
		//								{
		//									resultStatus = ((i != result.Length - 1) ? (resultStatus + result[i].RejectionReason + ", ") : (resultStatus + result[i].RejectionReason + " "));
		//								}
		//								IResponseResult<string> x2 = repositoryUnitOfWork.MpdMembersCchi.Value.UpdateMembersStatusDB(MpdPlcCchiId, arrRejectedBeneficiaries[Z].BeneficiaryNumber.Trim(), "FAILED", resultStatus, "Update member Status", null);
		//								if (x2.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("after UpdateMembersStatusDB: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//								}
		//								_Logger.LogInformation("UpdateMemberStatusCCHI arrRejectedBeneficiaries SegmentCode: " + arrRejectedBeneficiaries[Z].BeneficiaryNumber.Trim());
		//							}
		//							else
		//							{
		//								IResponseResult<string> x3 = repositoryUnitOfWork.MpdMembersCchi.Value.UpdateMembersStatusDB(MpdPlcCchiId, arrRejectedBeneficiaries[Z].BeneficiaryNumber.Trim(), "FAILED", (!string.IsNullOrEmpty(arrRejectedBeneficiaries[Z].RejectionReason)) ? arrRejectedBeneficiaries[Z].RejectionReason.Trim() : string.Empty, "Update member Status", null);
		//								if (x3.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("after UpdateMembersStatusDB: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//								}
		//								_Logger.LogInformation("UpdateMemberStatusCCHI arrRejectedBeneficiaries SegmentCode: " + arrRejectedBeneficiaries[Z].BeneficiaryNumber.Trim());
		//							}
		//						}
		//					}
		//				}
		//			}
		//		}
		//		catch (Exception ex2)
		//		{
		//			Exception ex = ex2;
		//			_Logger.LogInformation("*****************Update Member Status - Catch Region*****************");
		//			IResponseResult<string> x = repositoryUnitOfWork.MpdMembersCchi.Value.UpdateMembersStatusDB(MpdPlcCchiId, null, "FAILED", null, "Update member Status", null);
		//			if (x.Status == ResultStatus.Failed)
		//			{
		//				_Logger.LogInformation("after UpdateMembersStatusDB: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//			}
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", ex.Message);
		//			message.AddMessageLine("Method Name ", "UpdateMemberStatusCCHI");
		//			message.AddMessageLine("Error Descriptions ", ex.Message);
		//			message.AddMessageLine("CCHI Policy Id", MpdPlcCchiId.ToString());
		//			message.AddMessageLine("Cchi Policy Number", CchiPolicyNo.ToString());
		//			_MailService.SendEmail(message.CreateMessageBody());
		//			_Logger.LogInformation("ex.PolicyID : " + MpdPlcCchiId);
		//			_Logger.LogInformation("ex.PolicyNumber : " + CchiPolicyNo);
		//			_Logger.LogInformation("ex.TransactionName : " + TransactionName);
		//			_Logger.LogInformation("ex.Message.UpdateMemberStatusCCHI : " + ex.Message);
		//			_Logger.LogInformation("ex.Source.UpdateMemberStatusCCHI : " + ex.Source);
		//			_Logger.LogInformation("ex.Message.UpdateMemberStatusCCHI : " + ex.Message);
		//			_Logger.LogInformation("ex.StackTrace.UpdateMemberStatusCCHI : " + ex.StackTrace);
		//			return new ResponseResult<PolicyTransactionStatusWithResult>
		//			{
		//				Errors = new List<string> { "Error in get member status: " + ex.Message + ex.Source + ex.StackTrace },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//		return new ResponseResult<PolicyTransactionStatusWithResult>
		//		{
		//			Errors = new List<string>(),
		//			Data = null,
		//			Status = ResultStatus.Success,
		//			TotalRecords = 0L
		//		};
		//	}

		//	public bool StartCCHIService()
		//	{
		//		int IntegrationMethod = 0;
		//		long? SeqNo = 0L;
		//		Dictionary<MpdPoliciesCchi, byte[]> DataResult = GenerateCCHIData(out IntegrationMethod, out SeqNo);
		//		switch (IntegrationMethod)
		//		{
		//		case 1:
		//		{
		//			Task<ResponseResult<XMLReturnResult>> x3 = UploadPolicyNew(DataResult.ElementAt(0).Value, DataResult.ElementAt(0).Key, SeqNo);
		//			break;
		//		}
		//		case 2:
		//		{
		//			Task<ResponseResult<XMLReturnResult>> x4 = UpdatePolicy(DataResult.ElementAt(0).Value, DataResult.ElementAt(0).Key, SeqNo);
		//			break;
		//		}
		//		case 3:
		//		{
		//			Task<ResponseResult<XMLReturnResult>> x2 = PolicyCancel(DataResult.ElementAt(0).Value, DataResult.ElementAt(0).Key, SeqNo);
		//			break;
		//		}
		//		case 4:
		//		{
		//			Task<ResponseResult<XMLReturnResult>> x = ReNewPolicy(DataResult.ElementAt(0).Value, DataResult.ElementAt(0).Key, SeqNo);
		//			break;
		//		}
		//		}
		//		return true;
		//	}

		//	public bool StartCCHIGetClassInfoService(int Flag = 0)
		//	{
		//		string Response = string.Empty;
		//		int intStatusCode = 0;
		//		string oResponseJson = string.Empty;
		//		string PolicyId = string.Empty;
		//		string CCHIPolicyNo = null;
		//		CCHIGetClassInfoResponse oCCHIGetClassInfoResponse = new CCHIGetClassInfoResponse();
		//		CCHIBenefitResponseInvalid oCCHIBenefitResponseInvalid = new CCHIBenefitResponseInvalid();
		//		List<CCHIGetClassInfoResponse> lstResponse = new List<CCHIGetClassInfoResponse>();
		//		try
		//		{
		//			List<MpdPoliciesCchi> dtPoliciesNumber = repositoryUnitOfWork.MpdPoliciesCchi.Value.CollectClassesInfo(Flag);
		//			_Logger.LogInformation("*******API::StartCCHIGetClassInfoService******* After collect classes count: " + dtPoliciesNumber.Count);
		//			if (dtPoliciesNumber.Count > 0)
		//			{
		//				for (int i = 0; i < dtPoliciesNumber.Count; i++)
		//				{
		//					CCHIPolicyNo = dtPoliciesNumber[i].CchiPolicyNo;
		//					_Logger.LogInformation("*******API::StartCCHIGetClassInfoService*******CCHIPolicyNo:" + dtPoliciesNumber[i].CchiPolicyNo);
		//					string BenefitURL = SharedSettings.CCHIBenefitConfig.BenefitApiUrl + SharedSettings.CCHIBenefitConfig.GetClassInformationsUrl;
		//					string fullPath = BenefitURL + "?COMPANYNUMBER=" + SharedSettings.GovernmentIntegrationSection.UserCompanyID + "&POLICYNUMBER=" + dtPoliciesNumber[i].CchiPolicyNo + "&user_key=" + SharedSettings.CCHIBenefitConfig.UserKey;
		//					string auth = SharedSettings.CCHIBenefitConfig.Authorization;
		//					bool UseSSL = SharedSettings.CCHIBenefitConfig.UseSSL;
		//					_Logger.LogInformation("*******API::CCHIGetClassInfoService*******  Start SendWebRequest CCHIPolicyNo:" + dtPoliciesNumber[i].CchiPolicyNo + " URL:" + fullPath);
		//					oResponseJson = Utilities.SendWebRequest(ref intStatusCode, fullPath, HttpMethodType.GET, _Logger, null, null, auth, null, encodeAuth: false, "application/json", UseSSL);
		//					Response = "StatusCode:" + intStatusCode + ",ResponseData:" + oResponseJson;
		//					_Logger.LogInformation("*******API::CCHIGetClassInfoService*******  End SendWebRequest CCHIPolicyNo:" + dtPoliciesNumber[i].CchiPolicyNo + " intStatusCode:" + intStatusCode + " ,oResponseJson:" + oResponseJson);
		//					if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode == 200 && oResponseJson.Length > 0)
		//					{
		//						_Logger.LogInformation("*******API:CCHIGetClassInfoService******* Before Deserialize oResponse :" + oResponseJson);
		//						lstResponse = JsonConvert.DeserializeObject<List<CCHIGetClassInfoResponse>>(oResponseJson);
		//						if (oCCHIGetClassInfoResponse != null && lstResponse.Count > 0)
		//						{
		//							for (int z = 0; z < lstResponse.Count; z++)
		//							{
		//								_Logger.LogInformation("*******API::CCHIGetClassInfoService******* After Deserialize oCCHIGetClassInfoResponse CCHIPolicyNo= " + dtPoliciesNumber[i].CchiPolicyNo + " oCCHIGetClassInfoResponse.Classes.Count " + lstResponse.Count + " oCCHIGetClassInfoResponse.Classes[z].CCHICLASSID " + lstResponse[z].CCHICLASSID);
		//								IResponseResult<string> x2 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassesInfo(dtPoliciesNumber[i].CchiPolicyNo, lstResponse[z].CCHICLASSID, lstResponse[z].CLASSID, lstResponse[z].ISBENEFIT, "SUCCESS", null, null);
		//								if (x2.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("after UpdateClassesInfoDB: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//								}
		//							}
		//						}
		//						else
		//						{
		//							_Logger.LogInformation("*******API::CCHIGetClassInfoService******* After Deserialize oResponse Empty JSON data");
		//						}
		//					}
		//					else if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode != 200 && oResponseJson.Length > 0)
		//					{
		//						_Logger.LogInformation("*******API::CCHIGetClassInfoService*******Response: " + oResponseJson);
		//						oCCHIBenefitResponseInvalid = JsonConvert.DeserializeObject<CCHIBenefitResponseInvalid>(oResponseJson);
		//						if (oCCHIBenefitResponseInvalid == null || oCCHIBenefitResponseInvalid.Errors.Count <= 0)
		//						{
		//							continue;
		//						}
		//						foreach (BENEFITErrorResponse ErrorResponse in oCCHIBenefitResponseInvalid.Errors)
		//						{
		//							IResponseResult<string> x3 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassesInfo(dtPoliciesNumber[i].CchiPolicyNo, null, null, "FALSE", oCCHIBenefitResponseInvalid.STATUS, "ERR CODE: " + ErrorResponse.ErrorCode + " ERROR: " + ErrorResponse.Message, null);
		//							if (x3.Status == ResultStatus.Failed)
		//							{
		//								_Logger.LogInformation("after UpdateClassesInfoDB: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//							}
		//							_Logger.LogInformation("*******API::CCHIGetClassInfoService******* CCHIPolicyNo= " + dtPoliciesNumber[i].CchiPolicyNo + " After Deserialize oCCHIGetClassInfoResponse.Errors ErrorResponseCode:" + ErrorResponse.ErrorCode + " ErrorResponseMessage " + ErrorResponse.Message);
		//						}
		//					}
		//					else
		//					{
		//						_Logger.LogInformation("*******API:CCHIGetClassInfoService******* HTTP FAIL intStatusCode:" + intStatusCode + " ,RESPONSE:" + oResponseJson);
		//					}
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			IResponseResult<string> x = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassesInfo(CCHIPolicyNo, null, null, "FALSE", "FAIL", ex.Message, null);
		//			if (x.Status == ResultStatus.Failed)
		//			{
		//				_Logger.LogInformation("after UpdateClassesInfoDB: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//			}
		//			_Logger.LogInformation("*******API::StartCCHIGetClassInfoService******* Catch ERROR ::: Message::" + ex.Message + "STACK TRACE::" + ex.StackTrace);
		//		}
		//		finally
		//		{
		//			_Logger.LogInformation("*******API::EndCCHIGetClassInfoService******* END CCHIPolicyNo :" + CCHIPolicyNo);
		//		}
		//		_Logger.LogInformation("*******API::EndCCHIGetClassInfoService******* END oCCHIGetClassInfoResponse :" + oCCHIGetClassInfoResponse);
		//		_Logger.LogInformation("*******API::EndCCHIGetClassInfoService******* END oCCHIGetClassInfoResponseInvalid :" + oCCHIBenefitResponseInvalid);
		//		return true;
		//	}

		//	public ResponseResult<List<CCHIGetClassInfoResponse>> CCHIGetClassInfoByPolicyNo(string PolicyNumber)
		//	{
		//		string Response = string.Empty;
		//		int intStatusCode = 0;
		//		string oResponseJson = string.Empty;
		//		string PolicyId = string.Empty;
		//		CCHIGetClassInfoResponse oCCHIGetClassInfoResponse = new CCHIGetClassInfoResponse();
		//		CCHIBenefitResponseInvalid oCCHIBenefitResponseInvalid = new CCHIBenefitResponseInvalid();
		//		List<CCHIGetClassInfoResponse> lstResponse = new List<CCHIGetClassInfoResponse>();
		//		try
		//		{
		//			_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo*******");
		//			string BenefitURL = SharedSettings.CCHIBenefitConfig.BenefitApiUrl + SharedSettings.CCHIBenefitConfig.GetClassInformationsUrl;
		//			string fullPath = BenefitURL + "?COMPANYNUMBER=" + SharedSettings.GovernmentIntegrationSection.UserCompanyID + "&POLICYNUMBER=" + PolicyNumber + "&user_key=" + SharedSettings.CCHIBenefitConfig.UserKey;
		//			string auth = SharedSettings.CCHIBenefitConfig.Authorization;
		//			bool UseSSL = SharedSettings.CCHIBenefitConfig.UseSSL;
		//			_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo*******  Start SendWebRequest CCHIPolicyNo:" + PolicyNumber + " URL:" + fullPath);
		//			oResponseJson = Utilities.SendWebRequest(ref intStatusCode, fullPath, HttpMethodType.GET, _Logger, null, null, auth, null, encodeAuth: false, "application/json", UseSSL);
		//			Response = "StatusCode:" + intStatusCode + ",ResponseData:" + oResponseJson;
		//			_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo*******  End SendWebRequest CCHIPolicyNo:" + PolicyNumber + " intStatusCode:" + intStatusCode + " ,oResponseJson:" + oResponseJson);
		//			if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode == 200 && oResponseJson.Length > 0)
		//			{
		//				_Logger.LogInformation("*******API:CCHIGetClassInfoByPolicyNo******* Before Deserialize oResponse :" + oResponseJson);
		//				lstResponse = JsonConvert.DeserializeObject<List<CCHIGetClassInfoResponse>>(oResponseJson);
		//				if (oCCHIGetClassInfoResponse != null && lstResponse.Count > 0)
		//				{
		//					for (int z = 0; z < lstResponse.Count; z++)
		//					{
		//						_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo******* After Deserialize oCCHIGetClassInfoResponse CCHIPolicyNo= " + PolicyNumber + " oCCHIGetClassInfoResponse.Classes.Count " + lstResponse.Count + " oCCHIGetClassInfoResponse.Classes[z].CCHICLASSID " + lstResponse[z].CCHICLASSID);
		//						IResponseResult<string> x2 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassesInfo(PolicyNumber, lstResponse[z].CCHICLASSID, lstResponse[z].CLASSID, lstResponse[z].ISBENEFIT, "SUCCESS", null, null);
		//						if (x2.Status == ResultStatus.Failed)
		//						{
		//							_Logger.LogInformation("after UpdateClassesInfoDB: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//						}
		//					}
		//					return new ResponseResult<List<CCHIGetClassInfoResponse>>
		//					{
		//						Errors = new List<string>(),
		//						Data = lstResponse,
		//						Status = ResultStatus.Success,
		//						TotalRecords = lstResponse.Count
		//					};
		//				}
		//				_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo******* After Deserialize oResponse Empty JSON data");
		//				return new ResponseResult<List<CCHIGetClassInfoResponse>>
		//				{
		//					Errors = new List<string>(),
		//					Data = lstResponse,
		//					Status = ResultStatus.Success,
		//					TotalRecords = lstResponse.Count
		//				};
		//			}
		//			if (string.IsNullOrEmpty(oResponseJson) || intStatusCode == 200 || oResponseJson.Length <= 0)
		//			{
		//				_Logger.LogInformation("*******API:CCHIGetClassInfoByPolicyNo******* HTTP FAIL intStatusCode:" + intStatusCode + " ,RESPONSE:" + oResponseJson);
		//				return new ResponseResult<List<CCHIGetClassInfoResponse>>
		//				{
		//					Errors = new List<string> { "Error in Get Class Info: No Reponse " },
		//					Data = null,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo*******Response: " + oResponseJson);
		//			oCCHIBenefitResponseInvalid = JsonConvert.DeserializeObject<CCHIBenefitResponseInvalid>(oResponseJson);
		//			if (oCCHIBenefitResponseInvalid != null && oCCHIBenefitResponseInvalid.Errors.Count > 0)
		//			{
		//				foreach (BENEFITErrorResponse ErrorResponse in oCCHIBenefitResponseInvalid.Errors)
		//				{
		//					IResponseResult<string> x3 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassesInfo(PolicyNumber, null, null, "FALSE", oCCHIBenefitResponseInvalid.STATUS, "ERR CODE: " + ErrorResponse.ErrorCode + " ERROR: " + ErrorResponse.Message, null);
		//					if (x3.Status == ResultStatus.Failed)
		//					{
		//						_Logger.LogInformation("after UpdateClassesInfoDB: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//					}
		//					_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo******* CCHIPolicyNo= " + PolicyNumber + " After Deserialize oCCHIGetClassInfoResponse.Errors ErrorResponseCode:" + ErrorResponse.ErrorCode + " ErrorResponseMessage " + ErrorResponse.Message);
		//				}
		//				return new ResponseResult<List<CCHIGetClassInfoResponse>>
		//				{
		//					Errors = new List<string> { "Error in Get Class Info: " + oCCHIBenefitResponseInvalid.Errors[0].Message },
		//					Data = null,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			IResponseResult<string> x = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassesInfo(PolicyNumber, null, null, "FALSE", "FAIL", ex.Message, null);
		//			if (x.Status == ResultStatus.Failed)
		//			{
		//				_Logger.LogInformation("after UpdateClassesInfoDB: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//			}
		//			_Logger.LogInformation("*******API::CCHIGetClassInfoByPolicyNo******* Catch ERROR ::: Message::" + ex.Message + "STACK TRACE::" + ex.StackTrace);
		//			return new ResponseResult<List<CCHIGetClassInfoResponse>>
		//			{
		//				Errors = new List<string> { "Error in Get Class Info: " + ex.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//		finally
		//		{
		//			_Logger.LogInformation("*******API::ENDCCHIGetClassInfoByPolicyNo******* END CCHIPolicyNo :" + PolicyNumber);
		//		}
		//		_Logger.LogInformation("*******API::ENDCCHIGetClassInfoByPolicyNo******* END oCCHIGetClassInfoResponse :" + oCCHIGetClassInfoResponse);
		//		_Logger.LogInformation("*******API::ENDCCHIGetClassInfoByPolicyNo******* END oCCHIGetClassInfoResponseInvalid :" + oCCHIBenefitResponseInvalid);
		//		return new ResponseResult<List<CCHIGetClassInfoResponse>>
		//		{
		//			Errors = new List<string> { "Error in Get Class Info by Policy Number" },
		//			Data = null,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}

		//	public bool StartCCHIUploadStandardClasses()
		//	{
		//		string Response = null;
		//		int intStatusCode = 0;
		//		string oResponseJson = null;
		//		string CCHIPolicyNo = null;
		//		string CCHIClassId = null;
		//		int CompanyNo = SharedSettings.GovernmentIntegrationSection.UserCompanyID;
		//		CCHIUploadBenefitResponse oCCHIUploadBenefitResponse = new CCHIUploadBenefitResponse();
		//		CCHIBenefitResponseInvalid oCCHIGBenefitResponseInvalid = new CCHIBenefitResponseInvalid();
		//		List<CCHIUploadStandardBenefitsRequest> ListOfStandardBenefitsRequest = new List<CCHIUploadStandardBenefitsRequest>();
		//		try
		//		{
		//			_Logger.LogInformation("*******API::StartCCHIUploadStandardClasses*******");
		//			string BenefitURL = SharedSettings.CCHIBenefitConfig.BenefitApiUrl + SharedSettings.CCHIBenefitConfig.UploadCCHITableOfBenefitsUrl;
		//			string fullPath = BenefitURL + "?user_key=" + SharedSettings.CCHIBenefitConfig.UserKey;
		//			string auth = SharedSettings.CCHIBenefitConfig.Authorization;
		//			bool UseSSL = SharedSettings.CCHIBenefitConfig.UseSSL;
		//			ListOfStandardBenefitsRequest = repositoryUnitOfWork.MpdClassesCchi.Value.CollectStandardClasses();
		//			if (ListOfStandardBenefitsRequest.Count > 0)
		//			{
		//				for (int i = 0; i < ListOfStandardBenefitsRequest.Count; i++)
		//				{
		//					CCHIPolicyNo = ListOfStandardBenefitsRequest[i].POLICYNUMBER;
		//					CCHIClassId = ListOfStandardBenefitsRequest[i].COMPANYCLASSID;
		//					ListOfStandardBenefitsRequest[i].COMPANYNUMBER = CompanyNo;
		//					_Logger.LogInformation("*******API::StartCCHIUploadStandardClasses*******  Start SendWebRequest PolicyNo:" + CCHIPolicyNo + " URL:" + fullPath);
		//					oResponseJson = Utilities.SendWebRequest(ref intStatusCode, fullPath, HttpMethodType.POST, _Logger, ListOfStandardBenefitsRequest[i], null, auth, null, encodeAuth: false, "application/json", UseSSL);
		//					_Logger.LogInformation("*******API::StartCCHIUploadStandardClasses*******  End SendWebRequest:: intStatusCode::" + intStatusCode + " ,oResponseJson::" + oResponseJson);
		//					if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode == 200)
		//					{
		//						_Logger.LogInformation("*******API:StartCCHIUploadStandardClasses******* Before Deserialize oResponse :" + oResponseJson);
		//						oCCHIUploadBenefitResponse = JsonConvert.DeserializeObject<CCHIUploadBenefitResponse>(oResponseJson);
		//						_Logger.LogInformation("*******API:StartCCHIUploadStandardClasses******* After Deserialize oResponse :" + oCCHIUploadBenefitResponse.REFRENCENUMBER);
		//						if (oCCHIUploadBenefitResponse != null)
		//						{
		//							_Logger.LogInformation("*******API::StartCCHIUploadStandardClasses******* After Deserialize _oCCHIUploadStandardBenefitResponse  Reference No : " + oCCHIUploadBenefitResponse.REFRENCENUMBER);
		//							IResponseResult<string> x2 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateStandardClasses(ListOfStandardBenefitsRequest[i].POLICYNUMBER, ListOfStandardBenefitsRequest[i].COMPANYCLASSID, oCCHIUploadBenefitResponse.REFRENCENUMBER, oCCHIUploadBenefitResponse.STATUS.ToUpper(), null, null);
		//							if (x2.Status == ResultStatus.Failed)
		//							{
		//								_Logger.LogInformation("after UpdateStandardClassesDB: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//							}
		//						}
		//						else
		//						{
		//							_Logger.LogInformation("*******API::StartCCHIUploadStandardClasses*******  _oCCHIUploadStandardBenefitResponse is null");
		//						}
		//					}
		//					else if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode != 200)
		//					{
		//						_Logger.LogInformation("*******API::CCHIUploadStandardClasses*******Response: " + oResponseJson);
		//						oCCHIGBenefitResponseInvalid = JsonConvert.DeserializeObject<CCHIBenefitResponseInvalid>(oResponseJson);
		//						if (oCCHIGBenefitResponseInvalid == null || oCCHIGBenefitResponseInvalid.Errors.Count <= 0)
		//						{
		//							continue;
		//						}
		//						foreach (BENEFITErrorResponse ErrorResponse in oCCHIGBenefitResponseInvalid.Errors)
		//						{
		//							IResponseResult<string> x3 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateStandardClasses(ListOfStandardBenefitsRequest[i].POLICYNUMBER, ListOfStandardBenefitsRequest[i].COMPANYCLASSID, null, oCCHIGBenefitResponseInvalid.STATUS.ToUpper(), "Error Code: " + ErrorResponse.ErrorCode + "  Error Message " + ErrorResponse.Message, null);
		//							if (x3.Status == ResultStatus.Failed)
		//							{
		//								_Logger.LogInformation("after UpdateStandardClassesDB: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//							}
		//							_Logger.LogInformation("*******API::CCHIUploadStandardClasses******* CCHIPolicyNo= " + ListOfStandardBenefitsRequest[i].POLICYNUMBER + " After Deserialize oCCHIGetClassInfoResponse.Errors ErrorResponseCode:" + ErrorResponse.ErrorCode + " ErrorResponseMessage " + ErrorResponse.Message);
		//						}
		//					}
		//					else
		//					{
		//						_Logger.LogInformation("*******API:StartCCHIUploadStandardClasses******* HTTP FAIL intStatusCode:" + intStatusCode + " ,RESPONSE:" + oResponseJson);
		//					}
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			IResponseResult<string> x = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateStandardClasses(CCHIPolicyNo, CCHIClassId, null, "FAIL", ex.Message, null);
		//			if (x.Status == ResultStatus.Failed)
		//			{
		//				_Logger.LogInformation("after UpdateStandardClassesDB: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//			}
		//			_Logger.LogInformation("*******API::CCHIUploadStandardClasses******* Catch ERROR ::: Message::" + ex.Message + "STACK TRACE::" + ex.StackTrace);
		//		}
		//		return true;
		//	}

		//	public bool StartCCHIUploadNonStandardBenefits()
		//	{
		//		int intStatusCode = 0;
		//		string oResponseJson = string.Empty;
		//		string PolicyId = string.Empty;
		//		string CCHIPolicyNo = null;
		//		string CCHIClassId = null;
		//		int CompanyNo = SharedSettings.GovernmentIntegrationSection.UserCompanyID;
		//		CCHIUploadBenefitResponse oCCHIUploadBenefitResponse = new CCHIUploadBenefitResponse();
		//		CCHIBenefitResponseInvalid oCCHIBenefitResponseInvalid = new CCHIBenefitResponseInvalid();
		//		try
		//		{
		//			string BenefitURL = SharedSettings.CCHIBenefitConfig.BenefitApiUrl + SharedSettings.CCHIBenefitConfig.UploadCustoomTableOfBenefitsUrl;
		//			string fullPath = BenefitURL + "?user_key=" + SharedSettings.CCHIBenefitConfig.UserKey;
		//			string auth = SharedSettings.CCHIBenefitConfig.Authorization;
		//			bool UseSSL = SharedSettings.CCHIBenefitConfig.UseSSL;
		//			List<PrepareNonStandardClassesRequest> lstPrepareNonStandardClassesRequest = repositoryUnitOfWork.MpdClassesCchi.Value.PrepareNonStandardClasses();
		//			if (lstPrepareNonStandardClassesRequest.Count > 0)
		//			{
		//				_Logger.LogInformation("*******API::StartCCHIUploadNonStandardBenefits******* After Prepare Non-Standard Benefits for policies count: " + lstPrepareNonStandardClassesRequest.Count);
		//				for (int i = 0; i < lstPrepareNonStandardClassesRequest.Count; i++)
		//				{
		//					_Logger.LogInformation("*******API::StartCCHIUploadNonStandardBenefits******* before collect Non-Standard Benefits for specific class: PolicyNo= " + lstPrepareNonStandardClassesRequest[i].CchiPolicyNo + " and CchiClassId= " + lstPrepareNonStandardClassesRequest[i].CchiClassId);
		//					CCHIUploadNonStandardBenefitsRequest oCCHIUploadNonStandardBenefitsRequest = repositoryUnitOfWork.MpdClassesCchi.Value.CollectNonStandardClasses(lstPrepareNonStandardClassesRequest[i].CchiPolicyNo, lstPrepareNonStandardClassesRequest[i].CchiClassId);
		//					if (oCCHIUploadNonStandardBenefitsRequest != null)
		//					{
		//						_Logger.LogInformation("*******API::StartCCHIUploadNonStandardBenefits******* After collect Non-Standard Benefits for specific class: PolicyNo= " + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " and CchiClassId= " + oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID + " and Benefits count= " + oCCHIUploadNonStandardBenefitsRequest.BENEFITS.Count);
		//						CCHIPolicyNo = oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER;
		//						CCHIClassId = oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID;
		//						oCCHIUploadNonStandardBenefitsRequest.COMPANYNUMBER = CompanyNo;
		//						_Logger.LogInformation("*******API::StartCCHIUploadNonStandardBenefits*******  Start SendWebRequest CCHIPolicyNo:" + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " URL:" + fullPath);
		//						oResponseJson = Utilities.SendWebRequest(ref intStatusCode, fullPath, HttpMethodType.POST, _Logger, oCCHIUploadNonStandardBenefitsRequest, null, auth, null, encodeAuth: false, "application/json", UseSSL);
		//						_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits*******  End SendWebRequest CCHIPolicyNo:" + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " intStatusCode:" + intStatusCode + " ,oResponseJson:" + oResponseJson);
		//						if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode == 200)
		//						{
		//							_Logger.LogInformation("*******API:CCHIUploadNonStandardBenefits******* Before Deserialize oResponse :" + oResponseJson);
		//							oCCHIUploadBenefitResponse = JsonConvert.DeserializeObject<CCHIUploadBenefitResponse>(oResponseJson);
		//							if (oCCHIUploadBenefitResponse != null)
		//							{
		//								_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* After Deserialize oCCHIUploadBenefitResponse CCHIPolicyNo= " + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " oCCHIUploadBenefitResponse.REFRENCENUMBER: " + oCCHIUploadBenefitResponse.REFRENCENUMBER + "oCCHIUploadBenefitResponse.Status: " + oCCHIUploadBenefitResponse.STATUS);
		//								IResponseResult<string> x2 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateNonStandardClasses(oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER, oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID, null, oCCHIUploadBenefitResponse.REFRENCENUMBER, "UPLOAD", oCCHIUploadBenefitResponse.STATUS.ToUpper(), null, null);
		//								if (x2.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("after UpdateNonstandardClassesInfoDB: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//								}
		//							}
		//							else
		//							{
		//								_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* After Deserialize oResponse Empty JSON data");
		//							}
		//						}
		//						else if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode != 200)
		//						{
		//							_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits*******Response: " + oResponseJson);
		//							oCCHIBenefitResponseInvalid = JsonConvert.DeserializeObject<CCHIBenefitResponseInvalid>(oResponseJson);
		//							if (oCCHIBenefitResponseInvalid == null || oCCHIBenefitResponseInvalid.Errors.Count <= 0)
		//							{
		//								continue;
		//							}
		//							foreach (BENEFITErrorResponse ErrorResponse in oCCHIBenefitResponseInvalid.Errors)
		//							{
		//								IResponseResult<string> x3 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateNonStandardClasses(oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER, oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID, ErrorResponse.BenefitID, null, "UPLOAD", oCCHIBenefitResponseInvalid.STATUS.ToUpper(), ErrorResponse.Message, null);
		//								if (x3.Status == ResultStatus.Failed)
		//								{
		//									_Logger.LogInformation("Error in Benefit response:after UpdateNonstandardClassesInfoDB: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//								}
		//								_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* CCHIPolicyNo= " + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " After Deserialize oCCHIUploadBenefitResponse.Errors ErrorResponseCode:" + ErrorResponse.ErrorCode + " ErrorResponseMessage " + ErrorResponse.Message);
		//							}
		//						}
		//						else
		//						{
		//							_Logger.LogInformation("*******API:CCHIUploadNonStandardBenefits******* HTTP FAIL intStatusCode:" + intStatusCode + " ,RESPONSE:" + oResponseJson);
		//						}
		//					}
		//					else
		//					{
		//						_Logger.LogInformation("*******API:CCHIUploadNonStandardBenefits******* Empty list of Benefits for Policy No: " + lstPrepareNonStandardClassesRequest[i].CchiPolicyNo + " and CchiClassId: " + lstPrepareNonStandardClassesRequest[i].CchiClassId);
		//					}
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			if (CCHIPolicyNo != null && CCHIClassId != null)
		//			{
		//				IResponseResult<string> x = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateNonStandardClasses(CCHIPolicyNo, CCHIClassId, null, null, "UPLOAD", "FAIL", ex.Message, null);
		//				if (x.Status == ResultStatus.Failed)
		//				{
		//					_Logger.LogInformation("after UpdateNonstandardClassesInfoDB: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//				}
		//			}
		//			_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* Catch ERROR ::: Message::" + ex.Message + "STACK TRACE::" + ex.StackTrace);
		//		}
		//		finally
		//		{
		//			_Logger.LogInformation("*******API::FinallyCCHIUploadNonStandardBenefits******* END CCHIPolicyNo :" + CCHIPolicyNo);
		//		}
		//		_Logger.LogInformation("*******API::ENDCCHIUploadNonStandardBenefits******* oCCHIGetClassInfoResponse :" + oCCHIUploadBenefitResponse);
		//		_Logger.LogInformation("*******API::ENDCCHIUploadNonStandardBenefits******* oCCHIGetClassInfoResponseInvalid :" + oCCHIBenefitResponseInvalid);
		//		return true;
		//	}

		//	public IResponseResult<bool> CCHIReuploadNonStandardBenefitsPerClass(CCHIUploadNonStandardBenefitsRequest oCCHIUploadNonStandardBenefitsRequest)
		//	{
		//		int intStatusCode = 0;
		//		string oResponseJson = string.Empty;
		//		string PolicyId = string.Empty;
		//		string CCHIPolicyNo = oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER;
		//		string CCHIClassId = oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID;
		//		int UpdateReason = oCCHIUploadNonStandardBenefitsRequest.UPDATEREASON;
		//		int CompanyNo = SharedSettings.GovernmentIntegrationSection.UserCompanyID;
		//		CCHIUploadBenefitResponse oCCHIUploadBenefitResponse = new CCHIUploadBenefitResponse();
		//		CCHIBenefitResponseInvalid oCCHIBenefitResponseInvalid = new CCHIBenefitResponseInvalid();
		//		try
		//		{
		//			string BenefitURL = SharedSettings.CCHIBenefitConfig.BenefitApiUrl + SharedSettings.CCHIBenefitConfig.UploadCustoomTableOfBenefitsUrl;
		//			string fullPath = BenefitURL + "?user_key=" + SharedSettings.CCHIBenefitConfig.UserKey;
		//			string auth = SharedSettings.CCHIBenefitConfig.Authorization;
		//			bool UseSSL = SharedSettings.CCHIBenefitConfig.UseSSL;
		//			oCCHIUploadNonStandardBenefitsRequest = repositoryUnitOfWork.MpdClassesCchi.Value.CollectNonStandardClasses(oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER, oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID);
		//			if (oCCHIUploadNonStandardBenefitsRequest == null)
		//			{
		//				_Logger.LogInformation("*******API:CCHIUploadNonStandardBenefits******* Empty list of Benefits for Policy No: " + CCHIPolicyNo + " and CchiClassId: " + CCHIClassId);
		//				return new ResponseResult<bool>
		//				{
		//					Errors = new List<string> { "Error in reupload benefits: Empty list of Benefits" },
		//					Data = false,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			_Logger.LogInformation("*******API::StartCCHIUploadNonStandardBenefits******* After collect Non-Standard Benefits for specific class: PolicyNo= " + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " and CchiClassId= " + oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID + " and Benefits count= " + oCCHIUploadNonStandardBenefitsRequest.BENEFITS.Count);
		//			CCHIPolicyNo = oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER;
		//			CCHIClassId = oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID;
		//			oCCHIUploadNonStandardBenefitsRequest.COMPANYNUMBER = CompanyNo;
		//			oCCHIUploadNonStandardBenefitsRequest.UPDATEREASON = UpdateReason;
		//			_Logger.LogInformation("*******API::StartCCHIUploadNonStandardBenefits*******  Start SendWebRequest CCHIPolicyNo:" + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " URL:" + fullPath);
		//			oResponseJson = Utilities.SendWebRequest(ref intStatusCode, fullPath, HttpMethodType.POST, _Logger, oCCHIUploadNonStandardBenefitsRequest, null, auth, null, encodeAuth: false, "application/json", UseSSL);
		//			_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits*******  End SendWebRequest CCHIPolicyNo:" + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " intStatusCode:" + intStatusCode + " ,oResponseJson:" + oResponseJson);
		//			if (!string.IsNullOrEmpty(oResponseJson) && intStatusCode == 200)
		//			{
		//				_Logger.LogInformation("*******API:CCHIUploadNonStandardBenefits******* Before Deserialize oResponse :" + oResponseJson);
		//				oCCHIUploadBenefitResponse = JsonConvert.DeserializeObject<CCHIUploadBenefitResponse>(oResponseJson);
		//				if (oCCHIUploadBenefitResponse != null)
		//				{
		//					_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* After Deserialize oCCHIUploadBenefitResponse CCHIPolicyNo= " + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " oCCHIUploadBenefitResponse.REFRENCENUMBER: " + oCCHIUploadBenefitResponse.REFRENCENUMBER + "oCCHIUploadBenefitResponse.Status: " + oCCHIUploadBenefitResponse.STATUS);
		//					IResponseResult<string> x2 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateNonStandardClasses(oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER, oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID, null, oCCHIUploadBenefitResponse.REFRENCENUMBER, "UPLOAD", oCCHIUploadBenefitResponse.STATUS.ToUpper(), null, null);
		//					if (x2.Status == ResultStatus.Failed)
		//					{
		//						_Logger.LogInformation("after UpdateNonstandardClassesInfoDB: STATUS: " + x2.Status.ToString() + " ERRORS: " + x2.Errors[0]);
		//						return new ResponseResult<bool>
		//						{
		//							Errors = new List<string> { "Error in reupload benefits: " + x2.Errors[0] },
		//							Data = false,
		//							Status = ResultStatus.Failed,
		//							TotalRecords = 0L
		//						};
		//					}
		//					return new ResponseResult<bool>
		//					{
		//						Errors = new List<string>(),
		//						Data = true,
		//						Status = ResultStatus.Success,
		//						TotalRecords = 1L
		//					};
		//				}
		//				_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* After Deserialize oResponse Empty JSON data");
		//				return new ResponseResult<bool>
		//				{
		//					Errors = new List<string> { "Error in reupload benefits: Empty response" },
		//					Data = false,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			if (string.IsNullOrEmpty(oResponseJson) || intStatusCode == 200)
		//			{
		//				_Logger.LogInformation("*******API:CCHIUploadNonStandardBenefits******* HTTP FAIL intStatusCode:" + intStatusCode + " ,RESPONSE:" + oResponseJson);
		//				return new ResponseResult<bool>
		//				{
		//					Errors = new List<string> { "Error in reupload benefits: HTTP Fail" },
		//					Data = false,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits*******Response: " + oResponseJson);
		//			oCCHIBenefitResponseInvalid = JsonConvert.DeserializeObject<CCHIBenefitResponseInvalid>(oResponseJson);
		//			if (oCCHIBenefitResponseInvalid != null && oCCHIBenefitResponseInvalid.Errors.Count > 0)
		//			{
		//				foreach (BENEFITErrorResponse ErrorResponse in oCCHIBenefitResponseInvalid.Errors)
		//				{
		//					IResponseResult<string> x3 = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateNonStandardClasses(oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER, oCCHIUploadNonStandardBenefitsRequest.COMPANYCLASSID, ErrorResponse.BenefitID, null, "UPLOAD", oCCHIBenefitResponseInvalid.STATUS.ToUpper(), ErrorResponse.Message, null);
		//					if (x3.Status == ResultStatus.Failed)
		//					{
		//						_Logger.LogInformation("Error in Benefit response:after UpdateNonstandardClassesInfoDB: STATUS: " + x3.Status.ToString() + " ERRORS: " + x3.Errors[0]);
		//						return new ResponseResult<bool>
		//						{
		//							Errors = new List<string> { "Error in reupload benefits: " + x3.Errors[0] },
		//							Data = false,
		//							Status = ResultStatus.Failed,
		//							TotalRecords = 0L
		//						};
		//					}
		//					_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* CCHIPolicyNo= " + oCCHIUploadNonStandardBenefitsRequest.POLICYNUMBER + " After Deserialize oCCHIUploadBenefitResponse.Errors ErrorResponseCode:" + ErrorResponse.ErrorCode + " ErrorResponseMessage " + ErrorResponse.Message);
		//				}
		//				return new ResponseResult<bool>
		//				{
		//					Errors = new List<string> { "Error in reupload benefits" },
		//					Data = false,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			if (CCHIPolicyNo != null && CCHIClassId != null)
		//			{
		//				IResponseResult<string> x = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateNonStandardClasses(CCHIPolicyNo, CCHIClassId, null, null, "UPLOAD", "FAIL", ex.Message, null);
		//				if (x.Status == ResultStatus.Failed)
		//				{
		//					_Logger.LogInformation("after UpdateNonstandardClassesInfoDB: STATUS: " + x.Status.ToString() + " ERRORS: " + x.Errors[0]);
		//					return new ResponseResult<bool>
		//					{
		//						Errors = new List<string> { "Error in reupload benefits: " + x.Errors[0] },
		//						Data = false,
		//						Status = ResultStatus.Failed,
		//						TotalRecords = 0L
		//					};
		//				}
		//				return new ResponseResult<bool>
		//				{
		//					Errors = new List<string> { "Error in reupload benefits: " + ex.Message },
		//					Data = false,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			_Logger.LogInformation("*******API::CCHIUploadNonStandardBenefits******* Catch ERROR ::: Message::" + ex.Message + "STACK TRACE::" + ex.StackTrace);
		//		}
		//		finally
		//		{
		//			_Logger.LogInformation("*******API::FinallyCCHIUploadNonStandardBenefits******* END CCHIPolicyNo :" + CCHIPolicyNo);
		//		}
		//		_Logger.LogInformation("*******API::ENDCCHIUploadNonStandardBenefits******* oCCHIGetClassInfoResponse :" + oCCHIUploadBenefitResponse);
		//		_Logger.LogInformation("*******API::ENDCCHIUploadNonStandardBenefits******* oCCHIGetClassInfoResponseInvalid :" + oCCHIBenefitResponseInvalid);
		//		return new ResponseResult<bool>
		//		{
		//			Errors = new List<string> { "Error in reupload benefits: " },
		//			Data = false,
		//			Status = ResultStatus.Failed,
		//			TotalRecords = 0L
		//		};
		//	}

		//	public int ManageMemberNationalityID(string CRG_CNT_CODE)
		//	{
		//		return _tPServiceUnitOfWork.TPIntegrationService.Value.GetCountriesDTO().Result.data.Where((CountriesDTO x) => x.cODE == CRG_CNT_CODE).FirstOrDefault()?.iD.Value ?? 0;
		//	}

		//	public static string GetIdentityType(string NationalID, int? NationalityID)
		//	{
		//		if (NationalityID == 101 || NationalityID == 103 || NationalityID == 106 || NationalityID == 108 || NationalityID == 109)
		//		{
		//			return "3";
		//		}
		//		if (NationalID.StartsWith("1"))
		//		{
		//			return "1";
		//		}
		//		if (NationalID.StartsWith("2"))
		//		{
		//			return "2";
		//		}
		//		if (NationalID.StartsWith("3") || NationalID.StartsWith("4"))
		//		{
		//			return "4";
		//		}
		//		return "3";
		//	}

		//	public string HandleMobileNumber(string MobileNo)
		//	{
		//		if (!string.IsNullOrEmpty(MobileNo))
		//		{
		//			if (MobileNo.StartsWith("05"))
		//			{
		//				MobileNo.Remove(0, 1);
		//				MobileNo = "+966" + MobileNo;
		//			}
		//			else if (!MobileNo.StartsWith("00966"))
		//			{
		//				MobileNo = (MobileNo.StartsWith("5") ? ("+9665" + MobileNo) : ((!MobileNo.StartsWith("96")) ? "+966500000000" : ("+" + MobileNo)));
		//			}
		//			else
		//			{
		//				MobileNo.Remove(0, 2);
		//				MobileNo = "+" + MobileNo;
		//			}
		//			return MobileNo;
		//		}
		//		return "+966500000000";
		//	}

		//	public int? GetRelationType(int Gender, int Relation)
		//	{
		//		if (Gender == gender.Male.GetHashCode())
		//		{
		//			if (Relation == Relations.Self.GetHashCode())
		//			{
		//				return 1;
		//			}
		//			if (Relation == Relations.Spouse.GetHashCode())
		//			{
		//				return 3;
		//			}
		//			if (Relation == Relations.Child.GetHashCode())
		//			{
		//				return 5;
		//			}
		//			if (Relation == Relations.Parents.GetHashCode())
		//			{
		//				return 6;
		//			}
		//			if (Relation == Relations.Others.GetHashCode())
		//			{
		//				return 8;
		//			}
		//			return 10;
		//		}
		//		if (Relation == Relations.Self.GetHashCode())
		//		{
		//			return 1;
		//		}
		//		if (Relation == Relations.Spouse.GetHashCode())
		//		{
		//			return 2;
		//		}
		//		if (Relation == Relations.Child.GetHashCode())
		//		{
		//			return 4;
		//		}
		//		if (Relation == Relations.Parents.GetHashCode())
		//		{
		//			return 7;
		//		}
		//		if (Relation == Relations.Others.GetHashCode())
		//		{
		//			return 9;
		//		}
		//		return 10;
		//	}

		//	public string ManageOccupationValue(long Occupation, int Relation)
		//	{
		//		string _code = string.Empty;
		//		switch (Relation)
		//		{
		//		case 2:
		//			return "99401";
		//		case 3:
		//			return "99402";
		//		default:
		//		{
		//			long MinerCode = repositoryUnitOfWork.MpdMembersCchi.Value.LoadCodeById(Occupation);
		//			bool flag = true;
		//			return MinerCode.ToString();
		//		}
		//		}
		//	}

		//	public string HandleEndorsementActionType(long EndorsementType, long MPD_PLM_ID)
		//	{
		//		if (EndorsementType == EndorsementTypes.PolicyCorrection.GetHashCode())
		//		{
		//			return "10";
		//		}
		//		if (EndorsementType == EndorsementTypes.MemberCancellation.GetHashCode() || EndorsementType == EndorsementTypes.PolicyCancellation.GetHashCode())
		//		{
		//			return "2";
		//		}
		//		if (EndorsementType == EndorsementTypes.MemberAddition.GetHashCode())
		//		{
		//			return "1";
		//		}
		//		if (EndorsementType == EndorsementTypes.MemberCorrection.GetHashCode())
		//		{
		//			return repositoryUnitOfWork.MpdMembersCchi.Value.CheckMemberActionType(MPD_PLM_ID).ToString();
		//		}
		//		return "";
		//	}

		//	public async Task<string> HandleClassActionType(string AccessKey, string PolicyNo, string CCHIClassNo)
		//	{
		//		string actionTypeValue = "1";
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		try
		//		{
		//			_Logger.LogInformation("HandleClassActionType method enter, AccessKey:" + AccessKey + " PolicyNo:" + PolicyNo + " CCHIClassNo:" + CCHIClassNo);
		//			using MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address);
		//			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//			CustomCompanyClassWithResult oCustomCompanyClassWithResult = await oMOCServiceClient.GetClassesByPolicyNumberAsync(AccessKey, PolicyNo);
		//			_Logger.LogInformation("HandleClassActionType Method after GetClassesByPolicyNumberAsync oCustomCompanyClassWithResult= " + oCustomCompanyClassWithResult.CompanyClassListk__BackingField.Length);
		//			if (oCustomCompanyClassWithResult != null && oCustomCompanyClassWithResult.CompanyClassListk__BackingField != null && oCustomCompanyClassWithResult.CompanyClassListk__BackingField.Length != 0)
		//			{
		//				CustomCompanyClass[] arrCustomCompanyClass = oCustomCompanyClassWithResult.CompanyClassListk__BackingField;
		//				for (int i = 0; i < arrCustomCompanyClass.Length; i++)
		//				{
		//					if (arrCustomCompanyClass[i]._cchi_class_number == CCHIClassNo || arrCustomCompanyClass[i]._class_number == CCHIClassNo)
		//					{
		//						return "10";
		//					}
		//				}
		//			}
		//		}
		//		catch (Exception ex2)
		//		{
		//			Exception ex = ex2;
		//			_Logger.LogInformation("HandleClassActionType Method after GetClassesByPolicyNumberAsync catch ex= " + ex.Message);
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", ex.Message);
		//			message.AddMessageLine("Method Name ", "UpdateMemberStatusCCHI");
		//			_MailService.SendEmail(message.CreateMessageBody());
		//		}
		//		return actionTypeValue;
		//	}

		//	public async Task<string> HandleSponsorType(string AccessKey, string PolicyNo, string SponsorNumber)
		//	{
		//		string _strActionType = "1";
		//		BasicHttpBinding binding = new BasicHttpBinding
		//		{
		//			MaxBufferSize = int.MaxValue,
		//			ReaderQuotas = XmlDictionaryReaderQuotas.Max,
		//			MaxReceivedMessageSize = 2147483647L,
		//			Security = 
		//			{
		//				Mode = BasicHttpSecurityMode.Transport
		//			},
		//			TransferMode = TransferMode.Buffered
		//		};
		//		EndpointAddress address = new EndpointAddress(SharedSettings.GovernmentIntegrationSection.ServiceURL);
		//		_Logger.LogInformation("HandleSponsorType method enter, AccessKey:" + AccessKey + " PolicyNo:" + PolicyNo + " SponsorNumber:" + SponsorNumber);
		//		try
		//		{
		//			using MOCServiceClient oMOCServiceClient = new MOCServiceClient(binding, address);
		//			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		//			CustomSponsorWithResult oCustomSponsorWithResult = await oMOCServiceClient.GetSponsorsByPolicyNumberAsync(PolicyNo, AccessKey);
		//			_Logger.LogInformation("HandleSponsorType Method after GetSponsorsByPolicyNumberAsync oCustomSponsorWithResult= " + oCustomSponsorWithResult.SponsorListk__BackingField.Length);
		//			if (oCustomSponsorWithResult != null && oCustomSponsorWithResult.SponsorListk__BackingField != null && oCustomSponsorWithResult.SponsorListk__BackingField.Length != 0)
		//			{
		//				CustomSponsor[] arrCustomSponsor = oCustomSponsorWithResult.SponsorListk__BackingField;
		//				for (int I = 0; I < arrCustomSponsor.Length; I++)
		//				{
		//					if (arrCustomSponsor[I]._sponsor_number == SponsorNumber)
		//					{
		//						return "10";
		//					}
		//				}
		//			}
		//		}
		//		catch (Exception ex2)
		//		{
		//			Exception ex = ex2;
		//			_Logger.LogInformation("HandleSponsorType Method after GetSponsorsByPolicyNumberAsync catch ex= " + ex.Message);
		//			MessageBody message = new MessageBody();
		//			message.AddMessageLine("Error Message ", ex.Message);
		//			message.AddMessageLine("Method Name ", "UpdateMemberStatusCCHI");
		//			_MailService.SendEmail(message.CreateMessageBody());
		//		}
		//		return _strActionType;
		//	}

		//	public string GregToHijri(string Greg)
		//	{
		//		string[] allFormats = new string[18]
		//		{
		//			"yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy",
		//			"dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy"
		//		};
		//		CultureInfo arCul = new CultureInfo("ar-SA");
		//		CultureInfo enCul = new CultureInfo("en-US");
		//		return DateTime.ParseExact(Greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces).ToString("yyyy-MM-dd", arCul.DateTimeFormat);
		//	}

		//	public string TempPath(string HostName, bool IsWrite = true)
		//	{
		//		if (IsWrite)
		//		{
		//			CreateFolder(_strBasicPath_Write);
		//			if (!string.IsNullOrEmpty(_strBasicPath_Write))
		//			{
		//				string strTempPath = _strBasicPath_Write + "\\TempFolder";
		//				CreateFolder(strTempPath);
		//				return strTempPath + "\\";
		//			}
		//			return string.Empty;
		//		}
		//		string strRelativePath = "http://" + HostName + "/" + _strBasicPath_Read;
		//		string strTempPath2 = strRelativePath + "/TempFolder";
		//		return strTempPath2 + "/";
		//	}

		//	private void CreateFolder(string sPath)
		//	{
		//		if (!Directory.Exists(sPath))
		//		{
		//			try
		//			{
		//				Directory.CreateDirectory(sPath);
		//			}
		//			catch
		//			{
		//				sPath = string.Empty;
		//			}
		//		}
		//	}

		//	public string PolicyDocumentsPath(long Policy_ID, string HostName, bool IsWrite = true)
		//	{
		//		if (IsWrite)
		//		{
		//			CreateFolder(_strBasicPath_Write);
		//			if (!string.IsNullOrEmpty(_strBasicPath_Write))
		//			{
		//				string PolicyDocumentsPath = _strBasicPath_Write + "\\Policies\\";
		//				CreateFolder(PolicyDocumentsPath);
		//				PolicyDocumentsPath += "Documents\\";
		//				CreateFolder(PolicyDocumentsPath);
		//				PolicyDocumentsPath = PolicyDocumentsPath + "\\" + Policy_ID;
		//				CreateFolder(PolicyDocumentsPath);
		//				return PolicyDocumentsPath + "\\";
		//			}
		//			return string.Empty;
		//		}
		//		string strRelativePath = "http://" + HostName + "/" + _strBasicPath_Read;
		//		return strRelativePath + "/Policies/Documents/" + Policy_ID + "/";
		//	}

		//	private bool AddUpdateMntPrvNetCchi(MntPrvNetCchi mntPrvNetCchi)
		//	{
		//		MntPrvNetCchi Update = repositoryUnitOfWork.MntPrvNetCchi.Value.Find((MntPrvNetCchi x) => x.MntPrvNetId == mntPrvNetCchi.MntPrvNetId).FirstOrDefault();
		//		if (Update == null)
		//		{
		//			MntPrvNetCchi result = repositoryUnitOfWork.MntPrvNetCchi.Value.Add(mntPrvNetCchi);
		//			return (result != null) ? true : false;
		//		}
		//		mntPrvNetCchi.Id = Update.Id;
		//		mntPrvNetCchi.MntNetCchiId = Update.MntNetCchiId;
		//		mntPrvNetCchi.MntPrvNetId = Update.MntPrvNetId;
		//		mntPrvNetCchi.ReferenceNo = ((Update.ReferenceNo != null) ? Update.ReferenceNo : mntPrvNetCchi.ReferenceNo);
		//		mntPrvNetCchi.Hoid = Update.Hoid;
		//		mntPrvNetCchi.CreationUser = Update.CreationUser;
		//		mntPrvNetCchi.CreationDate = Update.CreationDate;
		//		mntPrvNetCchi.EndDate = (Update.EndDate.HasValue ? Update.EndDate : mntPrvNetCchi.EndDate);
		//		mntPrvNetCchi.ModificationDate = DateTime.Now;
		//		mntPrvNetCchi.ModificationUser = mntPrvNetCchi.CreationUser.ToUpper();
		//		MntPrvNetCchi result2 = repositoryUnitOfWork.MntPrvNetCchi.Value.Update(mntPrvNetCchi);
		//		return (result2 != null) ? true : false;
		//	}

		//	private bool AddMntPrvNetCchiHist(MntPrvNetCchiHist mntprvNetCchiHist)
		//	{
		//		MntPrvNetCchiHist result = repositoryUnitOfWork.MntPrevNetCchiHist.Value.Add(mntprvNetCchiHist);
		//		return (result != null) ? true : false;
		//	}

		//	private bool AddUpdateMntNetCchi(MntNetCchi mntNetCchi)
		//	{
		//		MntNetCchi Update = repositoryUnitOfWork.MntNetCchi.Value.Find((MntNetCchi x) => x.MntNetId == mntNetCchi.MntNetId).FirstOrDefault();
		//		if (Update == null)
		//		{
		//			MntNetCchi result = repositoryUnitOfWork.MntNetCchi.Value.Add(mntNetCchi);
		//			return (result != null) ? true : false;
		//		}
		//		mntNetCchi.Id = Update.Id;
		//		mntNetCchi.MntNetId = Update.MntNetId;
		//		mntNetCchi.Name = Update.Name;
		//		mntNetCchi.CreationDate = Update.CreationDate;
		//		mntNetCchi.CreationUser = Update.CreationUser;
		//		mntNetCchi.ReferenceNo = ((Update.ReferenceNo != null) ? Update.ReferenceNo : mntNetCchi.ReferenceNo);
		//		mntNetCchi.ModificationDate = DateTime.Now;
		//		mntNetCchi.ModificationUser = mntNetCchi.CreationUser.ToUpper();
		//		MntNetCchi result2 = repositoryUnitOfWork.MntNetCchi.Value.Update(mntNetCchi);
		//		return (result2 != null) ? true : false;
		//	}

		//	private bool AddMntNetCchiHist(MntNetCchiHist mntNetCchiHist)
		//	{
		//		MntNetCchiHist result = repositoryUnitOfWork.MntNetCchiHist.Value.Add(mntNetCchiHist);
		//		return (result != null) ? true : false;
		//	}

		//	private bool UpdateMpdPoliciesCchi(MpdPoliciesCchi mpdPoliciesCchi)
		//	{
		//		MpdPoliciesCchi result = repositoryUnitOfWork.MpdPoliciesCchi.Value.Update(mpdPoliciesCchi);
		//		return (result != null) ? true : false;
		//	}

		//	private bool AddMpdPoliciesCchiHist(MpdPoliciesCchiHist mpdPoliciesCchiHist)
		//	{
		//		MpdPoliciesCchiHist result = repositoryUnitOfWork.MpdPoliciesCchiHist.Value.Add(mpdPoliciesCchiHist);
		//		return (result != null) ? true : false;
		//	}

		//	public IResponseResult<ClassBenefitClassDeductibleResponse> GetClassBenefitts(int classID, int benefitID)
		//	{
		//		try
		//		{
		//			IResponseResult<ClassBenefitClassDeductibleResponse> result = repositoryUnitOfWork.MpdClassesCchi.Value.GetClassBenefits(classID, benefitID);
		//			if (result.Status == ResultStatus.Failed)
		//			{
		//				return new ResponseResult<ClassBenefitClassDeductibleResponse>
		//				{
		//					Errors = new List<string> { result.Errors[0] },
		//					Data = null,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 0L
		//				};
		//			}
		//			return new ResponseResult<ClassBenefitClassDeductibleResponse>
		//			{
		//				Errors = new List<string>(),
		//				Data = result.Data,
		//				Status = ResultStatus.Success,
		//				TotalRecords = 1L
		//			};
		//		}
		//		catch (Exception e)
		//		{
		//			return new ResponseResult<ClassBenefitClassDeductibleResponse>
		//			{
		//				Errors = new List<string> { e.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}

		//	public IResponseResult<string> UpdateClassBenefit(ClassBenefitClassDeductibleResponse oClassBenefitClassDeductibleResponse)
		//	{
		//		try
		//		{
		//			IResponseResult<string> result = repositoryUnitOfWork.MpdClassesCchi.Value.UpdateClassBenefit(oClassBenefitClassDeductibleResponse);
		//			if (result.Status == ResultStatus.Failed)
		//			{
		//				return new ResponseResult<string>
		//				{
		//					Errors = new List<string> { result.Errors[0] },
		//					Data = null,
		//					Status = ResultStatus.Failed,
		//					TotalRecords = 1L
		//				};
		//			}
		//			return new ResponseResult<string>
		//			{
		//				Status = ResultStatus.Success
		//			};
		//		}
		//		catch (Exception e)
		//		{
		//			return new ResponseResult<string>
		//			{
		//				Errors = new List<string> { e.Message },
		//				Data = null,
		//				Status = ResultStatus.Failed,
		//				TotalRecords = 0L
		//			};
		//		}
		//	}
		//}
	}
}
