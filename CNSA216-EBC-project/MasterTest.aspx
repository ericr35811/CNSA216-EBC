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
                     <asp:GridView ID="GridView1" CssClass="table " runat="server"  AutoGenerateColumns="True" BorderStyle="Solid" BorderWidth="1px">
                     
                     </asp:GridView>
                 </div>
             </div>
    
        </form>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        

        function RefreshDataTable() {
            //// Change the <table> created by ASP so that it gets styled correctly
            // Get the table element
            var table = document.getElementById("ASPContent_GridView1");
            // Get the position where the <tbody> tag begins
            var index = table.innerHTML.indexOf("<tbody>");
            // Get the <th> elements for the table header
            var header = table.querySelector("tbody tr").outerHTML;

            var newHTML = table.innerHTML;
            // Erase the old table header
            newHTML = newHTML.replace(header, "");
            // Insert the new table header in a <thead> tag
            // I tried breaking this by making header names with HTML in them, it seems to be fine 
            newHTML = newHTML.slice(0, index) + '<thead>' + header + '</thead>' + newHTML.slice(index);

            table.innerHTML = newHTML;

            //// needed for table styling to apply
            const GridView1 = document.getElementById('ASPContent_GridView1');
            if (GridView1) {
                new simpleDatatables.DataTable(GridView1);
            }
        }

        //// Change the color of the selected link
        document.getElementById("lnkWelcome").style.color = "rgba(255,255,255,1.0)";

        RefreshDataTable();
    </script>


</asp:Content>
