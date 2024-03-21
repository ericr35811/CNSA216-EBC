<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmRefill.aspx.cs" Inherits="CNSA216_EBC_project.WebForm6" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Refills - Louis' Pharmacy</title>
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
   <form id="form1" runat="server">
     <div>
     <asp:Label ID="lblPatientID" Text="PatientID:" runat="server"></asp:Label>
     <asp:TextBox ID="txtPatientID" ReadOnly="True" runat="server"></asp:TextBox>
     <asp:Label ID="lblPatientFName" Text="Patient Full Name:" runat="server" ></asp:Label>
     <asp:TextBox ID="txtPatientFName" ReadOnly="false" runat="server"></asp:TextBox>
     <br />
    <br />
     <asp:Label ID="lblPrescID" runat="server" Text="PrescriptionID:"></asp:Label>
     <asp:TextBox ID="txtPrescID" ReadOnly="true" runat="server"></asp:TextBox>
     <asp:Label ID="lblPrescNameDose" runat="server" Text="Prescription Name & dose:"></asp:Label>
     <asp:TextBox ID="txtPresNameDose" ReadOnly="false" runat="server"></asp:TextBox>
        <br />
         <br />
     <asp:Label ID="lblDate" runat="server" Text="Today's Date:"></asp:Label>
     <asp:TextBox ID="txtDate" ReadOnly="true" runat="server"></asp:TextBox>
     <asp:Label ID="lblClerkName"  runat="server" Text="Clerck's Name:"></asp:Label>
         <asp:DropDownList ID="ddlClerkName" runat="server"></asp:DropDownList>

         <br />
         <br />
         <asp:Button ID="btnConfirmRefill" runat="server" Text="Confirm Refill" />
     </div>
 </form>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        document.getElementById("lnkRefill").style.color = "rgba(255,255,255,1.0)";
    </script>    
</asp:Content> 


 
