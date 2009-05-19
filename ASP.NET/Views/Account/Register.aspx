<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BurningPlate.Controllers.AppViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.BeginRouteForm("Register"); %>
        <p>
            <label for="UserName">User Name</label>
            <%=Html.AntiForgeryToken("RegisterForm") %>
            <%=Html.TextBox("UserName") %>
            <%=Html.ValidationMessage("UserName") %>
        </p>
        <p>
            <label for="Password">Password</label>
            <%=Html.Password("Password") %>
            <%=Html.ValidationMessage("Password") %>
        </p>
         <p>
            <label for="EmailAddress">Email Address</label>
            <%=Html.TextBox("EmailAddress") %>
            <%=Html.ValidationMessage("EmailAddress")%>
        </p>
        <p>
            <input type="submit" value="Register" />
        </p>
    <% Html.EndForm(); %>
</asp:Content>
