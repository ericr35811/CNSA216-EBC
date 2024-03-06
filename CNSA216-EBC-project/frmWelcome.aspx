<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmWelcome.aspx.cs" Inherits="CNSA216_EBC_project.WebForm7" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Welcome - Louis' Pharmacy</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <div class="container-fluid px-4 mt-4">
        <h1>Welcome to Louis' Pharmacy!</h1>
        <hr />
        <p>Use the sidebar to navigate the site.</p>
        <p>test</p>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkWelcome").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
