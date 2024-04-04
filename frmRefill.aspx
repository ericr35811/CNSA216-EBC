<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmRefill.aspx.cs" Inherits="CNSA216_EBC_project.WebForm6" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Refills - Louis' Pharmacy</title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
   <form id="form1" runat="server">
     <div>
     <asp:Label ID="lblPatientID" Text="PatientID:" runat="server"></asp:Label> 
     <asp:TextBox ID="txtPatientID" ReadOnly="True" runat="server"></asp:TextBox> &nbsp &nbsp
     <asp:Label ID="lblRillId" runat="server" Text="RefillID:" AssociatedControlID="txtRefillID"></asp:Label>
    <asp:TextBox ID="txtRefillID" runat="server" ReadOnly="true" Enabled="false" ></asp:TextBox>
         <br />
         <br />
     <asp:Label ID="lblPatientFName" Text="Patient Full Name:" runat="server" ></asp:Label> <br />
     <asp:TextBox ID="txtPatientFName" ReadOnly="false" runat="server" Enabled="false" ></asp:TextBox>
     <br />
    <br />
     <asp:Label ID="lblPrescID" runat="server" Text="PrescriptionID:"></asp:Label><br />
     <asp:TextBox ID="txtPrescID" ReadOnly="true" runat="server"></asp:TextBox> <br />
         <br />
     <asp:Label ID="lblPrescNameDose" runat="server" Text="Prescription Name & dose:"></asp:Label> <br />
     <asp:TextBox ID="txtPresNameDose" ReadOnly="false" runat="server" Enabled="false" Width="35%" ></asp:TextBox> <br />
        <br />
         <br />
     <asp:Label ID="lblDate" runat="server" Text="Today's Date:"></asp:Label>
         <asp:TextBox ID="txtDateTime" ReadOnly="false" runat="server" TextMode="DateTime" OnTextChanged="txtDateTime_TextChanged"></asp:TextBox>&nbsp&nbsp
         <asp:RangeValidator ID="rngDateTime" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtDateTime">*</asp:RangeValidator> &nbsp &nbsp
     <asp:Label ID="lblClerkName"  runat="server" Text="Clerck's Name:"></asp:Label>
         <asp:DropDownList ID="ddlClerckName" runat="server"></asp:DropDownList>

         <br />
         <br />
         <asp:Button ID="btnSave" runat="server" Text="Confirm Refill" OnClick="btnSave_Click1" /> &nbsp&nbsp
         <%--<asp:Button ID="btnGoBack" runat="server" Text="Back" OnClick="btnGoBack_Click1" />--%>
         <a class="btn btn-primary" href="frmSearch.aspx"></a>

     </div>
 </form>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        document.getElementById("lnkRefill").style.color = "rgba(255,255,255,1.0)";
    </script>    
</asp:Content> 


 
