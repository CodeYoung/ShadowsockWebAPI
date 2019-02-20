using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
//using WebGrease;

namespace ShadowsocksWebAPI.Controllers
{
    public class SessionValidateAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public const string SessionKeyName = "SessionKey";
        public const string LogonUserName = "LogonUser";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var qs = HttpUtility.ParseQueryString(filterContext.Request.RequestUri.Query);
            string sessionKey = qs[SessionKeyName];

            if (string.IsNullOrEmpty(sessionKey))
            {
                throw new ApiException("Invalid Session.", "InvalidSession");
            }

            IAuthenticationService authenticationService = IocManager.Instance.Resolve<IAuthenticationService>();

            //validate user session
            var userSession = authenticationService.GetUserDevice(sessionKey);

            if (userSession == null)
            {
                throw new ApiException("sessionKey not found", "RequireParameter_sessionKey");
            }
            else
            {
                //todo: 加Session是否过期的判断
                if (userSession.ExpiredTime < DateTime.UtcNow)
                    throw new ApiException("session expired", "SessionTimeOut");

                var logonUser = authenticationService.GetUser(userSession.UserId);
                if (logonUser == null)
                {
                    throw new ApiException("User not found", "Invalid_User");
                }
                else
                {
                    filterContext.ControllerContext.RouteData.Values[LogonUserName] = logonUser;
                    SetPrincipal(new UserPrincipal<int>(logonUser));
                }

                userSession.ActiveTime = DateTime.UtcNow;
                userSession.ExpiredTime = DateTime.UtcNow.AddMinutes(60);
                authenticationService.UpdateUserDevice(userSession);
            }
        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }

    public class UserIdentity<TKey> : IIdentity
    {
        public UserIdentity(IUser<TKey> user)
        {
            if (user != null)
            {
                IsAuthenticated = true;
                UserId = user.UserId;
                Name = user.LoginName.ToString();
                DisplayName = user.DisplayName;
            }
        }

        public string AuthenticationType
        {
            get { return "CustomAuthentication"; }
        }

        public TKey UserId { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }
    }

    public class UserPrincipal<TKey> : IPrincipal
    {
        public UserPrincipal(UserIdentity<TKey> identity)
        {
            Identity = identity;
        }

        public UserPrincipal(IUser<TKey> user)
            : this(new UserIdentity<TKey>(user))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public UserIdentity<TKey> Identity { get; private set; }

        IIdentity IPrincipal.Identity
        {
            get { return Identity; }
        }


        bool IPrincipal.IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUser<T>
    {
        T UserId { get; set; }
        string LoginName { get; set; }
        string DisplayName { get; set; }
    }
}