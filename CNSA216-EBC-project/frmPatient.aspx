<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPatient.aspx.cs" Inherits="CNSA216_EBC_project.WebForm3" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Patients - Louis' Pharmacy</title>
    <body>
<form>
<asp:Label ID="lblfname" Text="First name:" runat="server"></asp:Label>
<asp:Textbox ID="txtfname" runat="server"></asp:Textbox>
<asp:Label ID="lblLname" Text="Last name:" runat="server"></asp:Label>
<asp:Textbox ID="txtLname" runat="server"></asp:Textbox>
<asp:Label ID="lblMidinit" Text="Middle Initial" runat="server"></asp:Label>
<asp:Textbox ID="txtMidinit" runat="server"></asp:Textbox>
<br/>
<br/>
<asp:Label ID="lblDOB" Text="DOB" runat="server"></asp:Label>
<asp:Textbox ID="txtDOB" runat="server"></asp:Textbox>
<br/>
<br/>
<asp:Label ID="lblAddress" Text="Address:" runat="server"></asp:Label>
<asp:Textbox ID="txtAddress" runat="server"></asp:Textbox>
<br/>
<br/>
<asp:Label ID="lblprescription" Text="Prescription:" runat="server"></asp:Label>
<asp:Textbox ID="txtprescription" runat="server"></asp:Textbox>
<br/>
<br/>
</form>
</body>
</asp:Content>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkPatient").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
