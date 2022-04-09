namespace Pc.Core.DTO
{
    public class IciciRequestModel
    {
        public string CustomerCode { get; set; }
        public string VirtualACCode { get; set; }
        public string MODE { get; set; }
        public string UTR { get; set; }
        public string SENDER_REMARK { get; set; }
        public string CustomerAccountNo { get; set; }
        public string AMT { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAccountNumber { get; set; }
        public string PayeeBankIFSC { get; set; }
        public string PayeePaymentDate { get; set; }
        public string BankInternalTransactionNumber { get; set; }

    }
}