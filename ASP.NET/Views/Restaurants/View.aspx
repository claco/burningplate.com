<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BurningPlate.Models.Restaurant>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <%=Html.Encode(Model.Name)%>
</asp:Content>
