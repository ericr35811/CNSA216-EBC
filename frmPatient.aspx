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
    <asp:Textbox ID="txtFname" runat="server" CausesValidation="true" Enabled="false"></asp:Textbox>
    

</div>

 <div>
    <small>Last name</small> <br />
    <asp:Textbox ID="txtLname" runat="server" CausesValidation="true" Enabled="false"></asp:Textbox>
     
</div>
            <div>
                <small>Middle Initial</small> <br />
                <asp:TextBox ID="txtMiddle" width="3em" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
                
            </div>
            <div>
                <small>Gender</small> <br />
                <asp:DropDownList ID="ddlGender" runat="server"  Width="6em" Enabled="false"></asp:DropDownList>
            </div><br />
            <div>
                <small></small>
                
                
            </div><br />
            <div>
                <small>Height</small><br />
                <asp:TextBox ID="txtHeight" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox><asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngHeight" ControlToValidate="txtHeight"></asp:RangeValidator><br />
                
                <small>Weight</small><br />
                <asp:TextBox ID="txtWeight" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox><asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngWeight" ControlToValidate="txtWeight"></asp:RangeValidator>
                
            </div>
            <div>
                <small>Street</small> <br />
                <asp:TextBox ID="txtStreet" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
                
            </div>
            <div>
            <small>City</small> <br />
            <asp:TextBox ID="txtCity" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
                
            </div>
            <div>
                <small>Zip Code</small> <br />
                <asp:TextBox ID="txtZip" runat="server" Width="7em" CausesValidation="true" Enabled="false"></asp:TextBox>
                
            </div>
            <div>
                <small>State</small> <br />
                <asp:DropDownList ID="ddlState" runat="server" Enabled="false" Width="6em" CausesValidation="true"></asp:DropDownList>
                
            </div>
             <div>
                <small>Phone 1</small> <br />
                <asp:TextBox ID="txtPhone1" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox><br />
                 
                 <small>Phone 2</small> <br />
                 <asp:TextBox ID="txtPhone2" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
                 
            </div>
             <div>
                <small>Email</small> <br />
                <asp:TextBox ID="txtEmail" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
                 
             </div>
            <div>
                <small>Insurance Name</small> <br />
                <asp:DropDownList ID="ddlInsurance" runat="server" Enabled="true" CausesValidation="true"></asp:DropDownList>
                
            </div>
            <div>
                <small></small> <br />
                
                
            </div>
            <div>
                <small>Start Date</small><br />
                <asp:TextBox ID="txtStart" runat="server" TextMode="Date" CausesValidation="true" Enabled="false"></asp:TextBox>
                <asp:RangeValidator runat="server" ID="rngStartDate" ErrorMessage="RangeValidator" Controltovalidate="txtStart" Display="Dynamic"></asp:RangeValidator>
            </div>
            <div>
                <small>End Date</small><br />
                <asp:TextBox ID="txtEnd" runat="server" TextMode="Date" CausesValidation="true" Enabled="false"></asp:TextBox>
                <asp:RangeValidator runat="server" ID="rngEndDate" ErrorMessage="RangeValidator" Controltovalidate="txtEnd" Display="Dynamic"></asp:RangeValidator>
            </div>
</div>
        <div style="padding-top: 1em">
            <asp:Button ID="btnSave" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnSave_Click" />&nbsp;&nbsp;
            &nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" />&nbsp;&nbsp;
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
