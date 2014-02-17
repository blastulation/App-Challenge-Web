﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinkedIn.OAuth;
using System.Web.Security;
using YAF.Core;
using YAF.Types.EventProxies;


public partial class ReturnClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            var token = OAuthManager.Current.GetTokenInCallback();
            var session = OAuthManager.Current.CompleteAuth(token);
            if (session.IsAuthorized())
            {
                session.StoreInUserSession();
                var p = session.GetProfile();

                var user = Membership.GetUser(p.Firstname + " " + p.Lastname+" ("+p.UserId+")");
                if (user == null)
                {
                    var pass = Guid.NewGuid().ToString();
                    user = Membership.CreateUser(p.Firstname + " " + p.Lastname + " (" + p.UserId + ")", pass);

                    

                   
                }



                FormsAuthentication.SetAuthCookie(p.Firstname + " " + p.Lastname, false);
                Response.Redirect("~");
            }
        
    }
}
