﻿using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Master;
using AKS.BOL.User;
using AKS.ViewModel.AdminVM;
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
        IMasterRepository _iMaster;
        string pMsg = "";
        LogInUserInfo LUser;
        public AdminController(IUserRepository iuser, IMasterRepository iMaster)
        {
            _iUser = iuser;
            _iMaster = iMaster;
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
        public ActionResult ProfitCentres() 
        {
            List<GLocation> model=_iMaster.GetGLocations(ref pMsg);
            return View(model);
        }
        public ActionResult Categories() 
        {
            return View();
        }
        public ActionResult Variants()
        {
            return View();
        }
        #region - Ajax Call
        public JsonResult GetUser(string UserID) 
        {
            var result = _iUser.GetUser(int.Parse(UserID),ref pMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProfitCentre(string PCID)
        {
            var result = _iMaster.GetProfitCentreInfo(int.Parse(PCID), ref pMsg).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategory(string CategoryCode)
        {
            var result = _iMaster.GetCategories(CategoryCode, ref pMsg).FirstOrDefault();
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
        public JsonResult GetProfitCentreList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<ProfitCentresForList> objlist = _iMaster.GetProfitCentreList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, ref pMsg);
            var result = new
            {
                iTotalRecords = objlist.Count == 0 ? 0 : objlist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = objlist.Count == 0 ? 0 : objlist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = objlist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoryList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<CategoryForList> objlist = _iMaster.GetListOfCategory(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, ref pMsg);
            var result = new
            {
                iTotalRecords = objlist.Count == 0 ? 0 : objlist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = objlist.Count == 0 ? 0 : objlist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = objlist
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
        [HttpPost]
        public ActionResult SetProfitCentre(PCInfoAjaxRapper modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                if (_iMaster.SetProfitCentreInfo(modelobj.PCList.FirstOrDefault(), ref pMsg))
                {
                    result.bResponseBool = true;
                }
                else { result.bResponseBool = false; result.sResponseString = pMsg; }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SetCategoty(CategoryInfoAjaxRapper modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                if (_iMaster.SetCategory(modelobj.DataList.FirstOrDefault(), ref pMsg))
                {
                    result.bResponseBool = true;
                }
                else { result.bResponseBool = false; result.sResponseString = pMsg; }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }






        #endregion
    }
}