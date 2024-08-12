using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MagicCubeRegistrationSystem
{
    public class Global : System.Web.HttpApplication
    {
        private ProjectClass _objThisProject;

        public ProjectClass ThisProject
        {
            get
            {
                _objThisProject = (ProjectClass)HttpContext.Current.Application["ThisProject"];

                if (_objThisProject == null)
                    _objThisProject = new ProjectClass();
                return _objThisProject;
            }
            set
            {
                _objThisProject = value;
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}