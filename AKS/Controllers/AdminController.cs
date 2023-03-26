using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class AdminController : Controller
    {
        IUserRepository _iUser;
        string pMsg = "";
        LogInUserInfo LUser;
        public AdminController(IUserRepository iuser)
        {
            _iUser = iuser;
            LUser = iuser.getLoggedInUser();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users() 
        {
            return View();
        }
        

        #region - Ajax Call
        public JsonResult GetUser(string UserID) 
        {
            var result = _iUser.GetUser(int.Parse(UserID),ref pMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<UserForList> userslist = _iUser.GetUserList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SetUser(UserInfoAjaxRapper modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                if (_iUser.SetUserInfo(modelobj.UserList.FirstOrDefault(), ref pMsg))
                {
                    result.bResponseBool = true;
                }
                else {result.bResponseBool = false; result.sResponseString = pMsg; }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        #endregion
    }
}