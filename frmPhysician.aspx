<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPhysician.aspx.cs" Inherits="CNSA216_EBC_project.WebForm4" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Physicians - Louis' Pharmacy</title>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <form id="FormPhysician" runat="server">
       <div class="formdiv">
           <div>
               <small>Physician ID</small> <br />
               <asp:TextBox ID="txtPhysicianID" runat="server" Width="7em" Enabled="false"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString" ControlToValidate="txtPhysicianID" Display="Dynamic"></asp:RegularExpressionValidator>
           </div>
           <div>
               <small>First Name</small> <br />
               <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString1" ControlToValidate="txtFname" Display="Dynamic"></asp:RegularExpressionValidator>
           </div><br />
           <div>
               <small>Last Name</small> <br />
               <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString2" ControlToValidate="txtLname" Display="Dynamic"></asp:RegularExpressionValidator>
           </div> <br />
           <div>
                 <small>Middle Initial</small><br />
                 <asp:TextBox ID="txtMiddle" runat="server" Width="5em"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString3" ControlToValidate="txtMiddle" Display="Dynamic"></asp:RegularExpressionValidator>
            </div><br />
           <div>
               <small>Gender</small> <br />
               <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString4" ControlToValidate="ddlGender" Display="Dynamic"></asp:RegularExpressionValidator>
           </div><br />

           <div>
               <small>Phone</small> <br />
               <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox> <br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString5" ControlToValidate="txtPhone" Display="Dynamic"></asp:RegularExpressionValidator>
               <small>Email</small> <br />
               <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString6" ControlToValidate="txtEmail" Display="Dynamic"></asp:RegularExpressionValidator>
           </div><br />

           <div>
               <small>Street</small> <br />
               <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox> <br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString7" ControlToValidate="txtStreet" Display="Dynamic"></asp:RegularExpressionValidator>
               <small>City</small><br />
               <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString8" ControlToValidate="txtCity" Display="Dynamic"></asp:RegularExpressionValidator>
               <small>State</small> <br />
               <asp:DropDownList ID="ddlState" runat="server" readonly="true" Enabled="true"></asp:DropDownList> <br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString9" ControlToValidate="ddlState" Display="Dynamic"></asp:RegularExpressionValidator>
               <small>Zip Code</small> <br />
               <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxString10" ControlToValidate="txtZip" Display="Dynamic"></asp:RegularExpressionValidator>
           </div> <br />

           <div>
               <small>Speciality</small>
               <asp:DropDownList ID="ddlSpecial" ReadOnly="true" Enabled="true" runat="server"></asp:DropDownList>
           </div> <br />
           <div>
               <small>Start Date</small><br />
               <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox><br />
               <asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngDate2" ControlToValidate="txtStartDate" Display="Dynamic"></asp:RangeValidator>
               <small>End Date</small> <br />
               <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
               <asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngDate1" ControlToValidate="txtEndDate" Display="Dynamic"></asp:RangeValidator>
           </div><br />

           <div style="padding-top: 1em">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" />&nbsp;&nbsp;

                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" />&nbsp;&nbsp;
               </div>
           <div style="padding-top: 1em">
               <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" />&nbsp;&nbsp;
           </div>


       </div>
    </form>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkPhysician").style.color = "rgba(255,255,255,1.0)";

        document.getElementById("ASPContent_txtInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtInstructions").style.width = "15em";

        document.getElementById("ASPContent_txtExtraInstructions").style.height = "6em";
        document.getElementById("ASPContent_txtExtraInstructions").style.width = "15em";
    </script>
</asp:Content>
