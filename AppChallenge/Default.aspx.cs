﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinkedIn.OAuth;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var session = LinkedInSession.RetrieveFromUserSession();
        if (session != null) {
            if (session.IsAuthorized())
            {
                session.StoreInUserSession();
                var p = session.GetProfile();
                string firstname = p.Firstname;
            }
        }
    }
}
