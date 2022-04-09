using System;
using System.Collections.Generic;

namespace Pc.Core.DTO
{
    public class RishtpushtRefferedPatientDTO
    {
        public int enq_code { get; set; }
        public string disease { get; set; }
        public string patient_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int amount { get; set; }
        public Dprdata dprdata { get; set; }
        public class Datum
        {
            public int id { get; set; }
            public int enqid { get; set; }
            public string uid { get; set; }
            public string msg { get; set; }
            public DateTime dated { get; set; }
            public DateTime alertdate { get; set; }
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
            public object rating { get; set; }
            public string comment { get; set; }
            public object paydetailgiven { get; set; }
            public object accountPayMode { get; set; }
        }

        public class Dprdata
        {
            public int enq_code { get; set; }
            public int amount { get; set; }
            public IList<Datum> data { get; set; }
        }
    }
}
