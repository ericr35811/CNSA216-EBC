<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPrescription.aspx.cs" Inherits="CNSA216_EBC_project.WebForm5" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Prescriptions - Louis' Pharmacy</title>
<%--    <style>
        div {
            border: 1px solid black;
        }
    </style>--%>
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
                <asp:RegularExpressionValidator ID="rgxExtraInstructions" runat="server" ErrorMessage="RegularExpressionValidator" Display="Dynamic" ControlToValidate="txtExtraInstructions" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        
            <br />

            <div>
                <small>Refills Allowed</small><br />
                <asp:TextBox ID="txtRefillsAllowed" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="rngRefillsAllowed" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtRefillsAllowed" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
            </div>

            <div>
                <small>Refills Left</small><br />
                <div class="row mx-auto">
                    <div class="col-auto my-auto px-0">
                        <asp:TextBox ID="txtRefillsLeft" runat="server"> </asp:TextBox>
                    </div>
                    <div class="col-sm">
                        <div>
                            <asp:RangeValidator ID="rngRefillsLeft" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtRefillsLeft" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
                        </div>
                        <div>
                            <%-- cannot be greater than refills allowed --%>
                            <asp:CompareValidator
                                ID="cmpRefillsLeft"
                                runat="server"
                                ErrorMessage="Must not be greater than Refills Allowed"
                                ControlToValidate="txtRefillsLeft"
                                Operator="LessThan"
                                ControlToCompare="txtRefillsAllowed"
                                Display="Dynamic" ForeColor="Red">
                            </asp:CompareValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div>
                <small>Refill Quantity (# of capsules, mL, etc. per refill)</small><br />
                <asp:TextBox ID="txtRefillQuantity" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="rngRefillQuantity" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtRefillQuantity" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
            </div>

            <br />

            <div>
                <small>Start Date</small> <br />
                <asp:TextBox ID="txtStartDate" runat="server" Width="8em" CausesValidation="True" TextMode="Date"></asp:TextBox>
                <asp:RangeValidator ID="rngStartDate" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtStartDate" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
             </div>

            <div>
                <small>End Date</small> <br />
                <asp:TextBox ID="txtEndDate" runat="server" Width="8em" CausesValidation="True" TextMode="Date">
                </asp:TextBox><asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngEndDate" Display="Dynamic" ControlToValidate="txtEndDate" ForeColor="Red"></asp:RangeValidator>
            </div>

             <div>
                <small>Date & Time of Entry</small> <br />
                 <asp:TextBox ID="txtEnteredDateTime" runat="server" TextMode="DateTime" ></asp:TextBox>

             </div>
            
        </div>
        <div class="pt-1">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary me-1 " OnClick="btnSave_Click" />

            <asp:Button ID="btnGoBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnGoBack_Click" />
            <%--<a href="frmSearch.aspx" class="btn btn-primary">Go Back</a>--%>
            
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
        txt = document.getElementById("ASPContent_txtEnteredDateTime");

        // Change the color of the selected link
        document.getElementById("lnkPrescription").style.color = "rgba(255,255,255,1.0)";

        document.getElementById("ASPContent_txtInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtInstructions").style.width = "15em";

        document.getElementById("ASPContent_txtExtraInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtExtraInstructions").style.width = "15em";

        function Updatetime() {
            


        }
    </script>
</asp:Content>
