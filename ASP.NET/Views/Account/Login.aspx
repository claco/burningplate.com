<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BurningPlate.Controllers.AppViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.BeginRouteForm("Login"); %>
        <p>
            <label for="UserName">User Name</label>
            <%=Html.AntiForgeryToken("LoginForm") %>
            <%=Html.TextBox("UserName") %>
            <%=Html.ValidationMessage("UserName") %>
        </p>
        <p>
            <label for="Password">Password</label>
            <%=Html.Password("Password") %>
            <%=Html.ValidationMessage("Password") %>
        </p>
        <p>
            <label for="Remember">Remember Me</label>
            <%=Html.CheckBox("Remember", false) %>
        </p>
        <p>
            <input type="submit" value="Login" />
        </p>
    <% Html.EndForm(); %>
</asp:Content>
