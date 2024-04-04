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
           </div>
           <div>
               <small>First Name</small> <br />
               <asp:TextBox ID="txtFName" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxFName" ControltoValidate="txtFName" Display="Dynamic"> </asp:RegularExpressionValidator>
           </div><br />
           <div>
               <small>Last Name</small> <br />
               <asp:TextBox ID="txtLName" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxLName" ControltoValidate="txtLName" Display="Dynamic"> </asp:RegularExpressionValidator>
           </div> <br />
           <div>
                 <small>Middle Initial</small><br />
                 <asp:TextBox ID="txtMiddle" runat="server" Width="5em" CausesValidation="true" Enabled="false"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxMiddle" ControltoValidate="txtMiddle" Display="Dynamic"> </asp:RegularExpressionValidator>
            </div><br />
           <div>
               <small>Gender</small> <br />
               <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxGender" ControltoValidate="ddlGender" Display="Dynamic"> </asp:RegularExpressionValidator>
           </div><br />

           <div>
               <small>Phone</small> <br />
               <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" CausesValidation="true" Enabled="false"></asp:TextBox> <br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxPhone" ControltoValidate="txtPhone" Display="Dynamic"> </asp:RegularExpressionValidator>
               <small>Email</small> <br />
               <asp:TextBox ID="txtEmail" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxEmail" ControltoValidate="txtEmail" Display="Dynamic"> </asp:RegularExpressionValidator>
           </div><br />

           <div>
               <small>Street</small> <br />
               <asp:TextBox ID="txtStreet" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox> <br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxStreet" ControltoValidate="txtStreet" Display="Dynamic"> </asp:RegularExpressionValidator>
               <small>City</small><br />
               <asp:TextBox ID="txtCity" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox><br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxCity" ControltoValidate="txtCity" Display="Dynamic"> </asp:RegularExpressionValidator>
               <small>State</small> <br />
               <asp:DropDownList ID="ddlState" runat="server" readonly="true" Enabled="true"></asp:DropDownList> <br />
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxState" ControltoValidate="ddlState" Display="Dynamic"> </asp:RegularExpressionValidator>
               <small>Zip Code</small> <br />
               <asp:TextBox ID="txtZip" runat="server" CausesValidation="true" Enabled="false"></asp:TextBox>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxZip" ControltoValidate="txtZip" Display="Dynamic"> </asp:RegularExpressionValidator>
           </div> <br />

           <div>
               <small>Speciality</small>
               <asp:DropDownList ID="ddlSpecial" ReadOnly="true" Enabled="true" runat="server" CausesValidation="true"></asp:DropDownList>
               <asp:RegularExpressionValidator runat="server" ErrorMessage="RegularExpressionValidator" ID="rgxSpecial" ControltoValidate="ddlSpecial" Display="Dynamic"> </asp:RegularExpressionValidator>
           </div> <br />
           <div>
               <small>Start Date</small><br />
               <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" CausesValidation="true" Enabled="false"></asp:TextBox><br />
               <asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngStart" ControlToValidate="txtStartDate" Display="Dynamic"></asp:RangeValidator>
               <small>End Date</small> <br />
               <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" CausesValidation="true" Enabled="false"></asp:TextBox>
               <asp:RangeValidator runat="server" ErrorMessage="RangeValidator" ID="rngEnd" ControlToValidate="txtEndDate" Display="Dynamic"></asp:RangeValidator>
           </div><br />

           <div style="padding-top: 1em">
               <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" CommandName="btnAdd_Click"/>&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" CommandName="btnUpdate_Click"/>&nbsp;&nbsp;
               <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" />
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
