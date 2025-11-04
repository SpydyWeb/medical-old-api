public class AccountInfo
{
	public long ID { get; set; }

	public long CUSTOMER_ID { get; set; }

	public object PAYMENT_METHOD { get; set; }

	public string CURRENCY_CODE { get; set; }

	public double CREDIT_LIMIT { get; set; }

	public object RISK_LEVEL { get; set; }

	public object PARENT_CUSTOMER { get; set; }

	public object ACQUIRED_BY { get; set; }

	public string E_WALLET_NO { get; set; }

	public object START_DATE { get; set; }

	public object CHEQUES_LIMIT { get; set; }

	public int STATUS { get; set; }

	public string BENEFICIARY_NAME { get; set; }

	public int IS_BLACK_LIST { get; set; }

	public object BLACK_LIST_REASON { get; set; }

	public int IS_ON_HOLD { get; set; }

	public object ON_HOLD_REASON { get; set; }

	public int HAS_LEGAL_ISSUES { get; set; }

	public object REASON_LEGAL_ISSUES { get; set; }
}
