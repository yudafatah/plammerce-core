namespace Pc.Core.Constants
{

    public class Constant
    {
        public const string contactUsHtml = "<b>Email:</b>{0}<br/><b>IP:</b>{1}<br/><b>Name:</b>{2}<br><b>Contact:</b>{3}<br><b>Subject:</b>{4}<br><b>Message:</b>{5}";//<br><b>Country:</b>{6}<br><b>State:</b>{7}<br><b>City:</b>{8}
        public const string newsletterHtml = "<b>Email:</b>{0}<br/><b>IP:</b>{1}<br><b>Country:</b>{2}<br><b>State:</b>{3}<br><b>City:</b>{4}";
        public const string affiliateSlugHelper = "VEND00";
        public const string reviewHtml = "<b>Product:</b>{0}<br/><b>Review:</b>{1}<br/><b>Link:</b>{2}";
        public const string orderReceivedEmail = "<b>New order received, check details </b>";

        public const string RegularNotVerified = "Regular Not- Verified";
        public const string RegularVerified = "Regular Verified";
        public const string PrimiumNotVerified = "Premium Not-Verified";
        public const string PrimiumVerified = "Premium Verified";


        //public static string baseUrl
        //{
        //    get
        //    {
        //        string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        //        return HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
        //    }
        //}
    }
}
