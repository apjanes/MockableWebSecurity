<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <ul>
            <li><asp:HyperLink runat="server" NavigateUrl="~/ListUsers.aspx">List Users</asp:HyperLink></li>
            <li><asp:HyperLink runat="server" NavigateUrl="~/CreateUser.aspx">Create User</asp:HyperLink></li>
            <li><asp:HyperLink runat="server" NavigateUrl="~/DeleteUser.aspx">Delete User</asp:HyperLink></li>
        </ul>
    </div>
</body>
</html>
