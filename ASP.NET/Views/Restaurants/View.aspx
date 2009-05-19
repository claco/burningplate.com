<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BurningPlate.Controllers.RestaurantsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Model.Restaurant != null) { %>
        <%=Html.Encode(Model.Restaurant.Name) %>
    <% } %>
</asp:Content>
