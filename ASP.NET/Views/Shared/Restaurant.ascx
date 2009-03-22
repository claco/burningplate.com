<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<BurningPlate.Models.Restaurant>" %>
<% if (Model != null) { %>
<div class="restaurant">
    <%=Html.RouteLink(Model.Name, "Restaurant", new {id=Model.Id}) %>
</div>
<% } %>