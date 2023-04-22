using AKS.BLL.IRepository;
using AKS.BOL.User;
using AKS.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _iUser;
        string pMsg = "";
        LogInUserInfo LUser;
        public HomeController(IUserRepository iuser)
        {
            _iUser = iuser;
            LUser = iuser.getLoggedInUser();
        }
        public ActionResult Index()
        {
            LogInVM LoginModel = new LogInVM();
            if (LUser.user != null)
            {
                if (LUser.user.IsActive)
                {
                    return RedirectToAction("UnlockSystem");
                }
            }
            return View(LoginModel);
        }
        [HttpPost]
        public ActionResult Index(LogInVM LoginModel, string Submit) 
        {
            if (Submit == "Login") 
            {
                bool result = false;
                LUser = _iUser.LogIn(LoginModel.UserEmailContact, LoginModel.UserCredentials, ref pMsg, ref result);
                if (result)
                {
                    if (LUser.user != null)
                    {
                        if (LUser.user.IsActive)
                        {
                            if (LUser.user.NoOfProfitCentres > 1)
                            {
                                return RedirectToAction("SelectPC");
                            }
                            else if (LUser.user.NoOfProfitCentres == 1)
                            {
                                if (LUser.userpcs != null && LUser.userpcs.Count > 0)
                                {
                                    int defaultpcid = LUser.userpcs.FirstOrDefault().PCID;
                                    LUser.LogInProfitCentreID = defaultpcid;
                                    _iUser.SetLogInUser(LUser);
                                    return RedirectToAction("Index", "User");
                                }
                                else { ViewBag.ErrMsg = "You Are Not Assigned Any Role Yet. Please Contact To System Admin."; }
                            }
                            else { ViewBag.ErrMsg = "You Are Not Assigned To Any Profit Centre. Please Contact To System Admin."; }
                        }
                        else { ViewBag.ErrMsg = "User Is Not Active. Please Contact To System Admin."; }
                    }
                    else { ViewBag.ErrMsg = "No User Found With The Provided Credential."; }  
                }
                else 
                {
                    ViewBag.ErrMsg = "Invalid Credentials. Please Try Again.";
                }
            }
            return View(LoginModel);
        }
        public ActionResult RegisterUser() 
        {
            RegisterUserVM model = new RegisterUserVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult RegisterUser(RegisterUserVM model)
        {
            if (model.Password == model.CnfPassword)
            {
                UserInfoWithPwd obj = new UserInfoWithPwd();
                obj.UserName = model.UserName;
                obj.EmailID = model.EmailID;
                obj.ContactNo = model.ContactNo;
                obj.HashedPassword = model.Password;
                if (_iUser.SetUser(obj, ref pMsg)) 
                {
                    ViewBag.Msg = "User Registered Successfully. Contact To System Admin For Required Permission.";
                } 
                else 
                {
                    ViewBag.ErrMsg = pMsg;
                }
            }
            else { ViewBag.ErrMsg = "Password Confirmation Failed."; }            
            return View(model);
        }
        public ActionResult ChangePassword() 
        {
            RegisterUserVM model = new RegisterUserVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangePassword(RegisterUserVM model)
        {
            if (model.Password == model.CnfPassword)
            {                
                if (_iUser.ChangePassword(LUser.user.ContactNo, model.OldPassword,LUser.user.UserID, model.Password, ref pMsg))
                {
                    ViewBag.Msg = "Password Changed Successfully.";
                }
                else
                {
                    ViewBag.ErrMsg = pMsg;
                }
            }
            else { ViewBag.ErrMsg = "Password Confirmation Failed."; }
            return View(model);
        }
        public ActionResult SelectPC() 
        {
            SelectPCVM model = new SelectPCVM();
            model.UserID = LUser.user.UserID;
            model.UserName = LUser.user.UserName;
            model.ProfitCentreList = LUser.userpcs;
            return View(model);
        }
        [HttpPost]
        public ActionResult SelectPC(SelectPCVM model) 
        {
            if (model.PCID > 0) 
            {
                LUser.LogInProfitCentreID = model.PCID;
                _iUser.SetLogInUser(LUser);
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }
        public ActionResult UnlockSystem() 
        {
            LogInVM model = new LogInVM();
            model.UserName =LUser.user.UserName;
            model.UserEmailContact = LUser.user.ContactNo;
            return View(model);
        }
        [HttpPost]
        public ActionResult UnlockSystem(LogInVM LoginModel, string Submit) 
        {
            if (Submit == "UnLock")
            {
                bool result = false;
                LUser = _iUser.LogIn(LoginModel.UserEmailContact, LoginModel.UserCredentials, ref pMsg, ref result);
                if (result)
                {
                    if (LUser.user != null)
                    {
                        if (LUser.user.IsActive)
                        {
                            if (LUser.user.NoOfProfitCentres > 1)
                            {
                                return RedirectToAction("SelectPC");
                            }
                            else if (LUser.user.NoOfProfitCentres == 1)
                            {
                                if (LUser.userpcs != null && LUser.userpcs.Count > 0)
                                {
                                    int defaultpcid = LUser.userpcs.FirstOrDefault().PCID;
                                    LUser.LogInProfitCentreID = defaultpcid;
                                    _iUser.SetLogInUser(LUser);
                                    return RedirectToAction("Index", "User");
                                }
                                else { ViewBag.ErrMsg = "You Are Not Assigned Any Role Yet. Please Contact To System Admin."; }
                            }
                            else { ViewBag.ErrMsg = "You Are Not Assigned To Any Profit Centre. Please Contact To System Admin."; }
                        }
                        else { ViewBag.ErrMsg = "User Is Not Active. Please Contact To System Admin."; }
                    }
                    else { ViewBag.ErrMsg = "No User Found With The Provided Credential."; }
                }
                else
                {
                    ViewBag.ErrMsg = "Invalid Credentials. Please Try Again.";
                }
            }
            else if (Submit == "OtherUser") 
            {
                _iUser.LogOut();
                LUser.user = null;
                return RedirectToAction("Index");
            }
            return View(LoginModel);
        }
        
    }
}