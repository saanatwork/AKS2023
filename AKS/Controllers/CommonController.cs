using AKS.BLL.IRepository;
using AKS.BOL;
using AKS.BOL.Common;
using AKS.BOL.User;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class CommonController : Controller
    {
        //IUserRepository _iUser;
        LogInUserInfo LUser;
        // GET: Common
        public CommonController(IUserRepository iuser)
        {
            LUser = iuser.getLoggedInUser(); 
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UploadFile()
        {
            FileUploadResponse result = new FileUploadResponse();
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    string extName = _ext.ToString().ToUpper();
                    if (extName == ".PDF" || extName == ".PNG" || extName == ".JPG" || extName == ".JPEG")
                    {
                        _imgname = Guid.NewGuid().ToString();
                        var _comPath = Server.MapPath("/Upload/Forms/") + _imgname + _ext;
                        _imgname = _imgname + _ext;
                        ViewBag.Msg = _comPath;
                        var path = _comPath;
                        pic.SaveAs(path);
                        result.ResponseStat = 1;
                        result.ResponseMsg = "File Successfully Uploaded.";
                    }
                    else
                    {
                        result.ResponseMsg = "Only PDF,PNG,JPEG & JPG Files Can Be Uploaded.";
                    }
                    // Saving Image in Original Mode

                    //_imagePath=
                    //// resizing image
                    //MemoryStream ms = new MemoryStream();
                    //WebImage img = new WebImage(_comPath);

                    //if (img.Width > 200)
                    //    img.Resize(200, 200);
                    //img.Save(_comPath);
                    //// end resize
                }
            }
            result.FileName = _imgname;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GeneratePdf(string ViewUrl, string PdfFileName)
        {
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + ViewUrl);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForGLSummary(string ACD,string ACDDesc,string AsOnDate, string PdfFileName)
        {
            var pcdesc= LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Accounts/PrintGLSummary?ACD="+ ACD+ "&ACDDesc="+ ACDDesc+ "&AsOnDate="+ AsOnDate+ "&PCDesc="+ pcdesc+ "&PCID="+LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForGLDetails(string ACD, string ACDDesc,string FromDate, string AsOnDate, string PdfFileName)
        {
            var pcdesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Accounts/PrintGLDetails?ACD=" + ACD + "&ACDDesc=" + ACDDesc + "&FromDate="+ FromDate + "&AsOnDate=" + AsOnDate + "&PCDesc=" + pcdesc + "&PCID=" + LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForTrialBalance(string FromDate, string AsOnDate, string PdfFileName)
        {
            var pcdesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Accounts/PrintTrialBalance?FromDate=" + FromDate + "&AsOnDate=" + AsOnDate + "&PCDesc=" + pcdesc + "&PCID=" + LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForPartyDetails(string SCD, string SCDDesc, string FromDate, string AsOnDate, string PdfFileName)
        {
            var pcdesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Accounts/PrintPartyDetails?SCD=" + SCD + "&SCDDesc=" + SCDDesc + "&FromDate=" + FromDate + "&AsOnDate=" + AsOnDate + "&PCDesc=" + pcdesc + "&PCID=" + LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForStockSummary(string PdfFileName)
        {
            var pcdesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Inventory/PrintStockSummary?PCDesc=" + pcdesc + "&PCID=" + LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForStockItems(string PdfFileName)
        {
            var pcdesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Inventory/PrintStockItem?PCDesc=" + pcdesc + "&PCID=" + LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public ActionResult GeneratePdfForStockItemTrans(string CatCode,string PdfFileName)
        {
            var pcdesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            var converter = new HtmlToPdf();
            var doc = converter.ConvertUrl(MyHelper.BaseUrl + "/Inventory/PrintStockItemTran?CatCode="+CatCode+"&PCDesc=" + pcdesc + "&PCID=" + LUser.LogInProfitCentreID);

            var pdfPath = Server.MapPath("~/Upload/PDF/" + PdfFileName + ".pdf");
            doc.Save(pdfPath);

            return File(pdfPath, "application/pdf", PdfFileName + ".pdf");
        }
        public JsonResult SendEmail()
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            string to = "saanatwork@gmail.com";
            string from = "helpdeskrinnovationlab@gmail.com";
            string subject = "Test Email with Attachment";
            string body = "<h1>This is a test email with HTML body.</h1>";

            MailMessage message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;

            // Create PDF attachment
            var pdfPath = Server.MapPath("~/Upload/PDF/AS2300003.pdf");
            Attachment attachment = new Attachment(pdfPath, MediaTypeNames.Application.Pdf);
            message.Attachments.Add(attachment);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("helpdeskrinnovationlab@gmail.com", "saan@1234#");

            try
            {
                client.Send(message);
                result.bResponseBool = true;
            }
            catch (Exception ex)
            {
                result.bResponseBool = false;
                result.sResponseString = "Error sending email: " + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }




    }
}