using System;

namespace Pc.Core.DTO
{
    public class SupportDPRDTO
    {
        public int id { get; set; }
        public int enqid { get; set; }
        public string uid { get; set; }
        public string msg { get; set; }
        public DateTime? dated { get; set; }
        public DateTime? alertdate { get; set; }
        public string time { get; set; }
        public string timeend { get; set; }
        public string status { get; set; }
        public string remarks { get; set; }
        public string response { get; set; }
        public int role { get; set; }
        public int alerttime { get; set; }
        public int alertstatus { get; set; }
        public string senderuid { get; set; }
        public string records { get; set; }
        public int? rating { get; set; }
        public string comment { get; set; }
        public string response_doc { get; set; }
        public int? paydetailgiven { get; set; }
    }
}
