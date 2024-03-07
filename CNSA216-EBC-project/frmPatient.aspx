<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPatient.aspx.cs" Inherits="CNSA216_EBC_project.WebForm3" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style>
body {background-color: green;
text-align:center;}
form{
    font:bold;
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}
        </style>
    <title>Patients - Louis' Pharmacy</title>
    </head>
    <body>
        <form id="form1" runat="server">
    <div>
    </div>
<asp:Label ID="lblPatientID" Text="PatientID" runat="server"></asp:Label>
<asp:TextBox ID="txtPatientID" ReadOnly="True" runat="server"></asp:TextBox>
          <br />
<asp:Label ID="lblfname" Text="First name:" runat="server"></asp:Label>
<asp:Textbox ID="txtfname" runat="server"></asp:Textbox>
<asp:Label ID="lblLname" Text="Last name:" runat="server"></asp:Label>
<asp:Textbox ID="txtLname" runat="server"></asp:Textbox>
<asp:Label ID="lblMidinit" Text="Middle Initial" runat="server"></asp:Label>
<asp:Textbox ID="txtMidinit" runat="server"></asp:Textbox>
            <asp:Label ID="lblInsurance" Text="Insurance ID:" runat="server"></asp:Label>
            <asp:DropDownList ID="DDLInsurance" runat="server"></asp:DropDownList>
<br/>
            <asp:Label ID="lblGender" Text="Gender:" runat="server"></asp:Label>
<asp:DropDownList ID="DDLGender" runat="server" OnSelectedIndexChanged="lblGender_SelectedIndexChanged">
    <asp:ListItem Text="Male" Value="0" /><asp:ListItem Text="Female" Value="0" /><asp:ListItem Text="Other" Value="0" />
</asp:DropDownList>
<br/>
<asp:Label ID="lblDOB" Text="DOB" runat="server"></asp:Label>
<asp:Textbox ID="txtDOB" runat="server"></asp:Textbox>
<br/>
<br/>
<asp:Label ID="lblAddress" Text="Address:" runat="server"></asp:Label>
<asp:Textbox ID="txtAddress" runat="server"></asp:Textbox>
<asp:Label ID="lblPhone" Text="Phone:" runat="server"></asp:Label>
<asp:Textbox ID="txtPhone" runat="server"></asp:Textbox>
<br/>
<br/>
<asp:Label ID="lblprescription" Text="Prescription:" runat="server"></asp:Label>
<asp:Textbox ID="txtprescription" runat="server"></asp:Textbox>
<br/>
<br/>
<asp:Label ID="lblHeight" Text="Height:" runat="server"></asp:Label>
<asp:Textbox ID="txtHeight" runat="server"></asp:Textbox>
<br/>
<asp:Label ID="lblWeight" Text="Weight:" runat="server"></asp:Label>
<asp:Textbox ID="txtWeight" runat="server"></asp:Textbox>
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
