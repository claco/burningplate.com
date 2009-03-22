<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<BurningPlate.Models.Restaurant>>" %>
<% if (Model.Count() > 0) { %>
<div class="restaurants">
    <% foreach (var restaurant in Model) { %>
        <% Html.RenderPartial("Restaurant", restaurant); %>
    <% } %>
</div>
<% } %>
