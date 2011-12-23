using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FluentReflection;
using MockableWebSecurity.Proxies;

namespace MockableWebSecurity.Tests.TestHarness
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var membership = new MembershipProxy();
            var user = membership.CreateUser("testing", "boomshaka");

            Response.Write("<table>");
            WL("Type", user.GetType().FullName);
            WP("Comment", user);
            WP("CreationDate", user);
            WP("Email", user);
            WP("IsApproved", user);
            WP("IsLockedOut", user);
            WP("IsOnline", user);
            WP("LastActivityDate", user);
            WP("LastLockoutDate", user);
            WP("LastLoginDate", user);
            WP("LastPasswordChangeDate", user);
            WP("PaswordQuestion", user);
            WP("ProviderName", user);
            WP("ProviderUserKey", user);
            WP("UserName", user);
            Response.Write("</table>");
        }

        private void WP<T>(string property, T instance)
        {
            if (instance == null) return;
            var val = instance.Property(property).GetValue();
            WL(property, val);
        }

        private void WL(string label, object value)
        {
            var text = value == null ? "[null]" : Convert.ToString(value);
            Response.Write("<tr>");
            Response.Write("<td>" + label + "</td>");
            Response.Write("<td>" + text + "</td>");
            Response.Write("</tr>");
        }
    }
}