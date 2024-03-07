<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPrescription.aspx.cs" Inherits="CNSA216_EBC_project.WebForm5" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Prescriptions - Louis' Pharmacy</title>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <form id="formPrescription" runat="server">
        <div class="formdiv">
            <div>
                <small>Prescription ID</small> <br />
                <asp:TextBox ID="txtPrescriptionID" runat="server" ReadOnly="True" Width="6em"></asp:TextBox>
             </div>

            <div>
                <small>Patient</small> <br />
                <asp:DropDownList ID="ddlPatient" runat="server"></asp:DropDownList>
            </div>

             <div>
                <small>Prescribing Physician</small> <br />
                <asp:DropDownList ID="ddlPhysician" runat="server"></asp:DropDownList>
            </div>

            <br />

            <div>
                <small>Medication</small> <br />
                <asp:DropDownList ID="ddlMedication" runat="server"></asp:DropDownList>
             </div>

            <div>
                <small>Dosage</small> <br />
                <asp:DropDownList ID="ddlDosage" runat="server"></asp:DropDownList>
            </div>

             <div>
                <small>Intake Method</small> <br />
                <asp:TextBox ID="txtIntakeMethod" runat="server" ReadOnly="True"></asp:TextBox>
            </div>

            <br />

            <div>
                <small>Medication Instructions</small> <br />
                <asp:TextBox ID="txtInstructions" runat="server" TextMode="MultiLine" ReadOnly="True" Height="6em" Width="15em"></asp:TextBox>
             </div>

            <div>
                <small>Extra Instructions</small> <br />
                <asp:TextBox ID="txtExtraInstructions" runat="server" TextMode="MultiLine" Height="6em" Width="15em"></asp:TextBox>
            </div>
        
            <br />

            <div>
                <small>Start Date</small> <br />
                <asp:TextBox ID="txtStartDate" runat="server" Width="8em"></asp:TextBox>
             </div>

            <div>
                <small>End Date</small> <br />
                <asp:TextBox ID="txtEndDate" runat="server" Width="8em"></asp:TextBox>
            </div>

             <div>
                <small>Date & Time of Entry</small> <br />
                 <asp:TextBox ID="txtEnteredDateTime" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkPrescription").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
