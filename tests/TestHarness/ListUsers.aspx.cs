using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MockableWebSecurity.Tests.TestHarness
{
    public partial class ListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var users = Membership.GetAllUsers();
            UsersRepeater.DataSource = users;
            UsersRepeater.DataBind();
        }
    }
}