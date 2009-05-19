<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BurningPlate.Controllers.RestaurantsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Model.Restaurants.Count > 0) { %>
        <div class="restaurants">
            <% foreach (var restaurant in Model.Restaurants) { %>
                <div class="restaurant"><%=Html.RouteLink(restaurant.Name, "Restaurant", new {id = restaurant.Id}) %></div>            
            <% } %>
        </div>
    <% } %>
</asp:Content>
