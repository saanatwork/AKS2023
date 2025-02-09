using AKS.BLL.IRepository;
using AKS.BOL;
using AKS.BOL.Inventory;
using AKS.BOL.User;
using AKS.ViewModel.UserVM;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class UserController : Controller
    {
        string pMsg = "";
        LogInUserInfo LUser;
        IUserRepository _iUser;
        IInventoryRepository _iInventory;
        public UserController(IUserRepository iuser, IInventoryRepository iInventory)
        {
            _iUser = iuser;
            _iInventory = iInventory;
            LUser = iuser.getLoggedInUser();                     
        }
        public ActionResult LogOut() 
        {
            _iUser.LogOut();
            return RedirectToAction("Index", "Home");
        }
        // GET: User
        public async Task<ActionResult> Index()
        {
            UserDashBoardVM model = new UserDashBoardVM();
            string goldrateurl = "https://www.google.com/search?q=gold+rate+in+kolkata+today&gl=in";
            string city = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().GLocation;
            model.CurrentGoldrate = await GetCurrentGoldRate(goldrateurl, city);
            model.CategoryList = _iInventory.GetCategoryWithStock(LUser.LogInProfitCentreID, ref pMsg);
            return View(model);
        }


        #region - Private function
        private async Task<DBGoldRate> GetCurrentGoldRate(string searchurl, string city)
        {
            DBGoldRate dbg=new DBGoldRate();
            GoldRate goldrate = new GoldRate();
            try
            {
                double gr10g24k = 0;
                double gr1g24k = 0;
                DateTime curDate = MyHelper.GetCurrentIndianTime();
                dbg = _iInventory.GetGoldRate(city, DateTime.Today.ToString("dd.MM.yyyy"), ref pMsg).FirstOrDefault();
                goldrate = await GetDatafromWebPage(searchurl, city);
                goldrate.rate = goldrate.rate > 0 ? goldrate.rate : dbg.GoldRate;
                if (goldrate != null)
                {
                    gr10g24k = goldrate.rate;
                    if (dbg != null)
                    {
                        if (dbg.CDate == curDate.ToString("dd.MM.yyyy"))
                        {
                            if (dbg.GoldRate != goldrate.rate)
                            {
                                _iInventory.LogGoldRate(city, goldrate.rate, ref pMsg);
                            }
                        }
                        else
                        {
                            _iInventory.LogGoldRate(city, goldrate.rate, ref pMsg);
                            //dbg.LogGoldRate(city, goldrate.rate);
                        }
                    }
                    else
                    {
                        _iInventory.LogGoldRate(city, goldrate.rate, ref pMsg);
                        //dbg.LogGoldRate(city, goldrate.rate);
                    }
                }
                else
                {
                    if (dbg != null)
                    {
                        gr10g24k = dbg.GoldRate;
                    }
                }
                if (gr10g24k > 0)
                {
                    gr1g24k = Math.Round(gr10g24k / 10, 0);
                }
                if (dbg == null) { dbg = new DBGoldRate(); }
                dbg.GoldRate = gr10g24k;
                dbg.GoldRate24K1GM = gr1g24k;
                dbg.GoldRate22K1GM = Math.Round(gr1g24k * 22 / 24, 0);
                dbg.GoldRate20K1GM = Math.Round(gr1g24k * 20 / 24, 0);
                dbg.GoldRate18K1GM = Math.Round(gr1g24k * 18 / 24, 0);
                dbg.GoldRate16K1GM = Math.Round(gr1g24k * 16 / 24, 0);
                dbg.GoldRate14K1GM = Math.Round(gr1g24k * 14 / 24, 0);
                dbg.GoldRate12K1GM = Math.Round(gr1g24k * 12 / 24, 0);
            }
            catch { }
            return dbg;
        }
        private async Task<GoldRate> GetDatafromWebPage(string fullurl, string city)
        {
            GoldRate gr = new GoldRate();
            try
            {
                List<GoldRate> goldrates = new List<GoldRate>();
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(fullurl);
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(response);
                HtmlNode[] node = htmlDocument.DocumentNode.SelectNodes("//div[@class='am3QBf']").ToArray();
                foreach (HtmlNode item in node)
                {
                    HtmlNode aNode = item.SelectNodes(".//div[@class='BNeawe deIvCb AP7Wnd']").FirstOrDefault();
                    HtmlNode bNode = item.SelectNodes(".//div[@class='BNeawe tAd8D AP7Wnd']").FirstOrDefault();

                    GoldRate goldrate = new GoldRate();
                    if (bNode.InnerHtml.IndexOf(" ") > 1)
                    {
                        goldrate.city = bNode.InnerHtml.Substring(0, bNode.InnerHtml.IndexOf(" ") - 1);
                    }

                    string r = "0";
                    int r1 = aNode.InnerHtml.IndexOf("(");
                    int r2 = aNode.InnerHtml.IndexOf("%");

                    if (r1 > 0 && r2 > 0 && r1 + 1 < r2)
                    {
                        r = aNode.InnerHtml.ToString().Substring(r1 + 1, r2 - r1 - 1).Trim();
                        goldrate.accuracy = double.Parse(r);
                    }
                    r1 = aNode.InnerHtml.IndexOf(":");
                    r2 = aNode.InnerHtml.IndexOf("INR");
                    if (r1 > 0 && r2 > 0 && r1 + 1 < r2)
                    {
                        r = aNode.InnerHtml.ToString().Substring(r1 + 1, r2 - r1 - 1).Trim();
                        r = r.Replace(",", "");
                        goldrate.rate = double.Parse(r);
                    }
                    if (goldrate.rate > 0)
                        goldrates.Add(goldrate);
                }

                if (goldrates != null)
                {
                    goldrates = goldrates.Where(o => o.city.ToUpper() == city.ToUpper()).ToList();
                    gr = goldrates.Where(o => o.accuracy == goldrates.Max(x => x.accuracy)).FirstOrDefault();
                }
                //GoldRate Excluding GST
                if (gr != null)
                {
                    double ExGST = gr.rate * 0.970874;
                    gr.rate = Math.Round(ExGST, 0);
                }
                //GoldRate Excluding GST  -end
            }
            catch { }
            return gr;
        }
        [HttpPost]
        public JsonResult UpdateGoldRate(int goldrate)
        {
            bool success = _iInventory.LogGoldRate("Kolkata", goldrate, ref pMsg);

            return Json(new { success, message = pMsg });
        }


        #endregion
    }
}