﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPatient.aspx.cs" Inherits="CNSA216_EBC_project.WebForm3" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Patients - Louis' Pharmacy</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">

    <form id="formPatient" runat="server">
        <div class-="formdiv">
            <div>
                   <small>Patient ID</small> <br />
    <asp:TextBox ID="txtPatientID" runat="server" Width="7em"></asp:TextBox>
 </div>

<div>
    <small>First name</small> <br />
    <asp:Textbox ID="txtFname" runat="server"></asp:Textbox>
</div>

 <div>
    <small>Last name</small> <br />
    <asp:Textbox ID="txtLname" runat="server"></asp:Textbox>
</div>
            <div>
                <small>Middle Initial</small> <br />
                <asp:TextBox ID="txtMidinitial" width="3em" runat="server"></asp:TextBox>
            </div>
            <div>
                <small>Gender</small> <br />
                <asp:DropDownList ID="ddlGender" runat="server" ReadOnly="True" Width="6em" disabled="false"></asp:DropDownList>
            </div><br />
            <div>
                <small>Date of Birth</small>
                <asp:TextBox ID="txtDob" runat="server" TextMode="Date"></asp:TextBox>
            </div><br />
            <div>
                <small>Height</small><br />
                <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox><br />
                <small>Weight</small><br />
                <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
            </div>
            <div>
                <small>Street</small> <br />
                <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
            </div>
            <div>
            <small>City</small> <br />
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </div>
            <div>
                <small>Zip Code</small> <br />
                <asp:TextBox ID="txtZip" runat="server" Width="7em"></asp:TextBox>
            </div>
            <div>
                <small>State</small> <br />
                <asp:DropDownList ID="ddlState" runat="server" ReadOnly="True" Width="6em" disabled="false"></asp:DropDownList>
            </div>
             <div>
                <small>Phone 1</small> <br />
                <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox><br />
                 <small>Phone 2</small> <br />
                 <asp:TextBox ID="txtPhone2" runat="server"></asp:TextBox>
            </div>
             <div>
                <small>Email</small> <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
             </div>
            <div>
                <small>Insurance Name</small> <br />
                <asp:DropDownList ID="txtInsurance" runat="server" Enabled="true"></asp:DropDownList>
            </div>
            <div>
                <small>Reason for Visit</small> <br />
                <asp:TextBox ID="txtVisit" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div>
                <small>Start Date</small><br />
                <asp:TextBox ID="txtStart" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <small>End Date</small><br />
                <asp:TextBox ID="txtEnd" runat="server" TextMode="Date"></asp:TextBox>
            </div>
</div>
        <div style="padding-top: 1em">
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" />&nbsp;&nbsp;

    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" />&nbsp;&nbsp;
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
