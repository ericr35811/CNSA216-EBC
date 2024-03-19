<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmPhysician.aspx.cs" Inherits="CNSA216_EBC_project.WebForm4" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Physicians - Louis' Pharmacy</title>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <form id="FormPhysician" runat="server">
       <div class="formdiv">
           <div>
               <small>Physician ID</small> <br />
               <asp:TextBox ID="txtPhysicianID" runat="server" Width="7em"></asp:TextBox>
           </div>
           <div>
               <small>First Name</small> <br />
               <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
           </div>
           <div>
               <small>Last Name</small> <br />
               <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
           </div> <br />

           <div>
               <small>Phone</small> <br />
               <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox> <br />
               <small>Email</small> <br />
               <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
           </div><br />

           <div>
               <small>Address</small> <br />
               <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox> <br />
               <small>State</small> <br />
               <asp:DropDownList ID="ddlState" runat="server" readonly="true" Enabled="true"></asp:DropDownList> <br />
               <small>Zip Code</small> <br />
               <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
           </div> <br />

           <div>
               <small>Speciality</small>
               <asp:DropDownList ID="ddlSpecial" ReadOnly="true" Enabled="true" runat="server"></asp:DropDownList>
           </div> <br />

           <div style="padding-top: 1em">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" />&nbsp;&nbsp;

                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" />&nbsp;&nbsp;
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
