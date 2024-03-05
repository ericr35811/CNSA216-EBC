<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="MasterTest.aspx.cs" Inherits="CNSA216_EBC_project.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ASPContent" runat="server">
    <div class="container-fluid px-4">
        <form id="form1" runat="server">
            <h1>super awesome button</h1>
            <%-- **** use classes to style ASP elements --%>
            <asp:Button CssClass="btn btn-primary" runat="server" Text="Button"></asp:Button>
        
            <br /><br />

             <div class="card mb-4">
                 <div class="card-header">
                     DataGridView
                 </div>
     
                 <div class="card-body">
                     <asp:GridView ID="GridView1" CssClass="table" runat="server"  AutoGenerateColumns="True" BorderStyle="Solid" BorderWidth="1px">
                     
                     </asp:GridView>
                 </div>
             </div>
    
        </form>
    </div>
</asp:Content>
