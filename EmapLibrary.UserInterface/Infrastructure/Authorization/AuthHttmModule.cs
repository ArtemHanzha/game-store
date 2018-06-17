using EmapLibrary.Auth.Interfaces;
using System;
using System.Web;
using System.Web.Mvc;

namespace EmapLibrary.UserInterface.Infrastructure.Authorization
{
    public class AuthHttmModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += Auth;
        }

        private void Auth(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            var context = app.Context;

            var auth = DependencyResolver.Current.GetService<IAuthentication>();

            auth.Context = context;
            context.User = auth.CurrentUser;
        }

        public void Dispose()
        {
        }
    }
}