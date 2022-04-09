using System.IO;

namespace Pc.Core.DTO
{
    public class ImagePath
    {
        //public ImagePath(string Folderpath, string fileName)
        //{
        //    this.folderPath = Folderpath;
        //    string folderToCreate = HttpContext.Current.Server.MapPath("~/" + this.folderPath);
        //    if (!Directory.Exists(folderToCreate))
        //    {
        //        Directory.CreateDirectory(folderToCreate);
        //    }
        //    this.physicalFolderPath = folderToCreate;
        //    this.physicalPath = folderToCreate + "\\" + fileName;
        //    this.absoluteUrl = Folderpath + "/" + fileName;
        //    this.filename = fileName;

        //    string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        //    this.fullUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/") + this.absoluteUrl;
        //}

        //public ImagePath(string absoluteUrl)
        //{
        //    string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        //    this.absoluteUrl = absoluteUrl;
        //    this.fullUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/") + this.absoluteUrl;
        //}

        public string AbsoluteUrl { get; set; }
        public string PhysicalPath { get; set; }
        public string FolderPath { get; set; }
        public string PhysicalFolderPath { get; set; }
        public string Filename { get; set; }
        public string FullUrl { get; set; }
    }
}