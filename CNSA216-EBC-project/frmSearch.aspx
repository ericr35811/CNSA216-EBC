<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="CNSA216_EBC_project.WebForm8" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // needed for table styling to apply
        const GridView1 = document.getElementById('GridView1');
        if (GridView1) {
            new simpleDatatables.DataTable(GridView1);
        }
    </script>

    <script>
        // Change the color of the selected link
        document.getElementById("lnkSearch").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
