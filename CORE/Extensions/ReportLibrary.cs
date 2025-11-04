namespace CORE.Extensions
{
	public class ReportLibrary
	{
		public string Value { get; private set; }

		public static ReportLibrary Quotation => new ReportLibrary("SSTCMPD019");

		public static ReportLibrary Policy => new ReportLibrary("SSTCMPD024");

		public static ReportLibrary Invoice => new ReportLibrary("MPD0039");

		public static ReportLibrary MemberListReport => new ReportLibrary("MPD0021");

		private ReportLibrary(string value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
