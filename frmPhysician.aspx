<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPhysician.aspx.cs" Inherits="CNSA216_EBC_project.WebForm4" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Physicians - Louis' Pharmacy</title>
 <style>
    body {
        background-color: green;
        text-align: center;
    }

    form {
        font: bold;
        font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <form>
        <ASP:Label ID="Label1" Text="Physiscian ID" runat="server"></ASP:Label>
<asp:Textbox ID="Textbox1" runat="server"></asp:Textbox>
         <div>
        </div>
        <asp:Label ID="lblfname" Text="First name:" runat="server"></asp:Label>
        <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
        <asp:Label ID="lblLname" Text="Last name:" runat="server"></asp:Label>
        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
        <asp:Label ID="lblMidinit" Text="Middle Initial" runat="server"></asp:Label>
        <asp:TextBox ID="txtMidinit" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGender" Text="Gender:" runat="server"></asp:Label>
        <asp:DropDownList ID="DDLGender" runat="server">
            <asp:ListItem Text="Male" Value="0" />
            <asp:ListItem Text="Female" Value="0" />
            <asp:ListItem Text="Other" Value="0" />
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblDOB" Text="DOB" runat="server"></asp:Label>
        <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblStreet" Text="Street:" runat="server"></asp:Label>
        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
        <asp:Label ID="lblCity" Text="City" runat="server"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <asp:Label ID="lblState" Text="State" runat="server"></asp:Label>
        <asp:DropDownList ID="DDLState" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="lblPhone" Text="Phone" runat="server"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblnumberpatient" Text="Number of Patients:" runat="server"></asp:Label>
        <asp:textbox ID="txtnumberPatient" runat="server"></asp:textbox>
    </form>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkPhysician").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
