namespace CORE.DTOs.APIs.Business
{
    public class CalculationRequest
    {
        public Members Member { get; set; }

        public int DiscountType { get; set; }
        public int P_NOOFNONSAUDIPRINCMEM { get; set; } = 0;
        public int P_NOOFSAUDIPRINCMEM { get; set; } = 0;
        public int P_NOOFSAUDIDEPMEM { get; set; } = 0;
        public int P_NOOFNONSAUDIDEPMEM { get; set; } = 0;
        //public int ClassCode { get; set; }

        public CalculationRequest()
        {
            Member = new Members();
        }
    }
}
