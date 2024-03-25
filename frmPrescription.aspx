<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPrescription.aspx.cs" Inherits="CNSA216_EBC_project.WebForm5" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Prescriptions - Louis' Pharmacy</title>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <form id="formPrescription" runat="server">
        <h1>Prescription</h1>
        <hr />
        <div class="formdiv">
            <div>
                <small>Prescription ID</small> <br />
                <asp:TextBox ID="txtPrescriptionID" runat="server" ReadOnly="True" Width="6em" disabled="true"></asp:TextBox>
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
                <asp:DropDownList ID="ddlMedication" runat="server" OnSelectedIndexChanged="ddlMedication_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
             </div>

            <div>
                <small>Dosage</small> <br />
                <asp:DropDownList ID="ddlDosage" runat="server"></asp:DropDownList>
            </div>

             <div>
                <small>Intake Method</small> <br />
                <asp:TextBox ID="txtIntakeMethod" runat="server" ReadOnly="True" disabled="true"></asp:TextBox>
            </div>

            <br />

            <div>
                <small>Medication Instructions</small> <br />
                <asp:TextBox ID="txtInstructions" runat="server" TextMode="MultiLine" ReadOnly="True" disabled="true" ></asp:TextBox>
             </div>

            <div>
                <small>Extra Instructions</small> <br />
                <asp:TextBox ID="txtExtraInstructions" runat="server" TextMode="MultiLine" CausesValidation="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rgxExtraInstructions" runat="server" ErrorMessage="RegularExpressionValidator" Display="Dynamic" ControlToValidate="txtExtraInstructions"></asp:RegularExpressionValidator>
            </div>
        
            <br />

            <div>
                <small>Start Date</small> <br />
                <asp:TextBox ID="txtStartDate" runat="server" Width="8em" CausesValidation="True" TextMode="Date"></asp:TextBox>
                <asp:RangeValidator ID="rngStartDate" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtStartDate" Display="Dynamic"></asp:RangeValidator>
             </div>

            <div>
                <small>End Date</small> <br />
                <asp:TextBox ID="txtEndDate" runat="server" Width="8em" CausesValidation="True" TextMode="Date">
                </asp:TextBox><asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngEndDate" Display="Dynamic" ControlToValidate="txtEndDate"></asp:RangeValidator>
            </div>

             <div>
                <small>Date & Time of Entry</small> <br />
                 <asp:TextBox ID="txtEnteredDateTime" runat="server" ReadOnly="True" disabled="true" TextMode="DateTime"></asp:TextBox>
            </div>
            
        </div>
        <div style="padding-top: 1em">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary me-1 " />

            <%--<asp:Button ID="btnGoBack" runat="server" CssClass="btn btn-primary" Text="Back" />--%>
            <a href="frmSearch.aspx" class="btn btn-primary">Go Back</a>
            
            <br /><br /><br />

            Patient First Name
            <asp:TextBox
                runat="server"
                ID="txtString"
                CausesValidation="True">
            </asp:TextBox>

            <asp:RegularExpressionValidator
                runat="server"
                ErrorMessage="RegularExpressionValidator"
                ID="rgxString"
                ControlToValidate="txtString"
                Display="Dynamic">
            </asp:RegularExpressionValidator> <br />

            Patient Start Date
            <asp:TextBox
                runat="server"
                ID="txtDate"
                CausesValidation="True"
                TextMode="Date">
            </asp:TextBox>

            <asp:RangeValidator
                ID="rngDate"
                runat="server"
                ErrorMessage="RangeValidator"
                ControlToValidate="txtDate"
                Display="Dynamic">
            </asp:RangeValidator>

            Patient Weight
            <asp:TextBox
                runat="server"
                ID="txtSmallInt"
                CausesValidation="True"
            >
            </asp:TextBox>

            <asp:RangeValidator
                ID="rngSmallInt"
                runat="server"
                ErrorMessage="RangeValidator"
                ControlToValidate="txtSmallInt"
                Display="Dynamic">
            </asp:RangeValidator>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkPrescription").style.color = "rgba(255,255,255,1.0)";

        document.getElementById("ASPContent_txtInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtInstructions").style.width = "15em";

        document.getElementById("ASPContent_txtExtraInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtExtraInstructions").style.width = "15em";
    </script>
</asp:Content>
