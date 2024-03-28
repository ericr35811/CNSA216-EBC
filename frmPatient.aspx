<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPatient.aspx.cs" Inherits="CNSA216_EBC_project.WebForm3" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Patients - Louis' Pharmacy</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">

    <form id="formPatient" runat="server">
        <div class-="formdiv">
            <div>
                   <small>Patient ID</small> <br />
    <asp:TextBox ID="txtPatientID" runat="server" Width="7em" Enabled="false"></asp:TextBox>
 </div>

<div>
    <small>First name</small> <br />
    <asp:Textbox ID="txtFname" runat="server" CausesValidation="true"></asp:Textbox>
    <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxFname" ControltoValidate="txtFname" Display="Dynamic"> </asp:RegularExpressionValidator>

</div>

 <div>
    <small>Last name</small> <br />
    <asp:Textbox ID="txtLname" runat="server" CausesValidation="true"></asp:Textbox>
     <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxLname" ControltoValidate="txtLname" Display="Dynamic"> </asp:RegularExpressionValidator>
</div>
            <div>
                <small>Middle Initial</small> <br />
                <asp:TextBox ID="txtMiddle" width="3em" runat="server" CausesValidation="true"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxMiddle" ControltoValidate="txtMiddle" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
            <div>
                <small>Gender</small> <br />
                <asp:DropDownList ID="ddlGender" runat="server" ReadOnly="True" Width="6em" disabled="false"></asp:DropDownList>
            </div><br />
            <div>
                <small>Date of Birth</small>
                <asp:TextBox ID="txtDob" runat="server" TextMode="Date" CausesValidation="true"></asp:TextBox>
                <asp:RangeValidator runat="server" ID="rngDob" ErrorMessage="RangeValidator" ControlToValidate="txtDob" Display="Dynamic"></asp:RangeValidator>
            </div><br />
            <div>
                <small>Height</small><br />
                <asp:TextBox ID="txtHeight" runat="server" CausesValidation="true"></asp:TextBox><br />
                <asp:RangeValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rngHeight" ControltoValidate="txtHeight" Display="Dynamic"> </asp:RangeValidator>
                <small>Weight</small><br />
                <asp:TextBox ID="txtWeight" runat="server" CausesValidation="true"></asp:TextBox>
                <asp:RangeValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rngWeight" ControltoValidate="txtWeight" Display="Dynamic"> </asp:RangeValidator>
            </div>
            <div>
                <small>Street</small> <br />
                <asp:TextBox ID="txtStreet" runat="server" CausesValidation="true"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxStreet" ControltoValidate="txtStreet" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
            <div>
            <small>City</small> <br />
            <asp:TextBox ID="txtCity" runat="server" CausesValidation="true"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxCity" ControltoValidate="txtCity" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
            <div>
                <small>Zip Code</small> <br />
                <asp:TextBox ID="txtZip" runat="server" Width="7em" CausesValidation="true"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxZip" ControltoValidate="txtZip" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
            <div>
                <small>State</small> <br />
                <asp:DropDownList ID="ddlState" runat="server" ReadOnly="True" Width="6em" disabled="false" CausesValidation="true"></asp:DropDownList>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxState" ControltoValidate="ddlState" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
             <div>
                <small>Phone 1</small> <br />
                <asp:TextBox ID="txtPhone1" runat="server" CausesValidation="true"></asp:TextBox><br />
                 <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxPhone1" ControltoValidate="txtPhone1" Display="Dynamic"> </asp:RegularExpressionValidator>
                 <small>Phone 2</small> <br />
                 <asp:TextBox ID="txtPhone2" runat="server" CausesValidation="true"></asp:TextBox>
                 <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxPhone2" ControltoValidate="txtPhone2" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
             <div>
                <small>Email</small> <br />
                <asp:TextBox ID="txtEmail" runat="server" CausesValidation="true"></asp:TextBox>
                 <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxEmail" ControltoValidate="txtEmail" Display="Dynamic"> </asp:RegularExpressionValidator>
             </div>
            <div>
                <small>Insurance Name</small> <br />
                <asp:DropDownList ID="ddlInsurance" runat="server" Enabled="true" CausesValidation="true"></asp:DropDownList>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxInsurance" ControltoValidate="ddlInsurance" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
            <div>
                <small>Reason for Visit</small> <br />
                <asp:TextBox ID="txtVisit" runat="server" TextMode="MultiLine" CausesValidation="true"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxVisit" ControltoValidate="txtVisit" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div>
            <div>
                <small>Start Date</small><br />
                <asp:TextBox ID="txtStart" runat="server" TextMode="Date" CausesValidation="true"></asp:TextBox>
                <asp:RangeValidator runat="server" ID="rngStartDate" ErrorMessage="RangeValidator" Controltovalidate="txtStart" Display="Dynamic"></asp:RangeValidator>
            </div>
            <div>
                <small>End Date</small><br />
                <asp:TextBox ID="txtEnd" runat="server" TextMode="Date" CausesValidation="true"></asp:TextBox>
                <asp:RangeValidator runat="server" ID="rngEndDate" ErrorMessage="RangeValidator" Controltovalidate="txtEnd" Display="Dynamic"></asp:RangeValidator>
            </div>
</div>
        <div style="padding-top: 1em">
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" />&nbsp;&nbsp;

    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" />&nbsp;&nbsp;
    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" />
        </div>

        
    </form>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkPatient").style.color = "rgba(255,255,255,1.0)";

        document.getElementById("ASPContent_txtInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtInstructions").style.width = "15em";

        document.getElementById("ASPContent_txtExtraInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtExtraInstructions").style.width = "15em";
    </script>
</asp:Content>
