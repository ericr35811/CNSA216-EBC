<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="CNSA216_EBC_project.WebForm8" %>
<%@ Import Namespace="CNSA216_EBC_project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Search - Louis' Pharmacy</title>
    <style>
        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">

    <form id="formSearchFor" runat="server">
        <h1>Search</h1>
        <hr />

        <!--
                Dropdown box to select what type of data to search for
                The dropdown box auto posts back to the server so other dropdowns are updated automatically   
            -->

        <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>

        <p>
            Search for:&nbsp;
            <asp:DropDownList CssClass="dropdown" ID="ddlSearchFor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchFor_SelectedIndexChanged">
                <asp:ListItem>Patients</asp:ListItem>
                <asp:ListItem>Physicians</asp:ListItem>
                <asp:ListItem>Prescriptions</asp:ListItem>
                <asp:ListItem>Refills</asp:ListItem>
            </asp:DropDownList>
        </p>

        <p>
            <asp:DropDownList
                ID="ddlParameter1"
                runat="server" 
                onchange="javascript:clearTextBox('txtParameter1')" 
                OnSelectedIndexChanged="ddlParameter1_SelectedIndexChanged" 
                CausesValidation="True" 
                AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="txtParameter1" runat="server" CausesValidation="True"></asp:TextBox>&nbsp;

            <asp:CompareValidator 
                ID="cmpParameter01" 
                runat="server" 
                ErrorMessage="CompareValidator" 
                ControlToValidate="txtParameter1" 
                Operator="DataTypeCheck" 
                Enabled="False"
                Display="Dynamic">
            </asp:CompareValidator>

            <asp:RangeValidator 
                ID="rngParameter01" 
                runat="server" 
                ErrorMessage="RangeValidator" 
                ControlToValidate="txtParameter1" 
                Enabled="False" 
                Display="Dynamic">
            </asp:RangeValidator>

            <asp:RegularExpressionValidator
                runat="server"
                ErrorMessage="RegularExpressionValidator" 
                ID="rgxParameter01" 
                ControlToValidate="txtParameter1" 
                Display="Dynamic">
            </asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:RadioButtonList ID="rdoAndOr" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="A" Selected="True">&nbsp;AND&nbsp;&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="O">&nbsp;OR&nbsp;</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:DropDownList 
                ID="ddlParameter2" 
                runat="server"
                onchange="javascript:clearTextBox('txtParameter2')" 
                AutoPostBack="True" 
                OnSelectedIndexChanged="ddlParameter2_SelectedIndexChanged" 
                CausesValidation="True">
            </asp:DropDownList>
            &nbsp;
            <asp:TextBox ID="txtParameter2" runat="server"></asp:TextBox>
            &nbsp;
            <asp:CompareValidator 
                ID="cmpParameter02" 
                runat="server" 
                ErrorMessage="CompareValidator"
                ControlToValidate="txtParameter2" 
                Operator="DataTypeCheck" 
                Enabled="False" 
                Display="Dynamic">
            </asp:CompareValidator>

            <asp:RangeValidator
                ID="rngParameter02" 
                runat="server" 
                ErrorMessage="RangeValidator" 
                ControlToValidate="txtParameter2" 
                Enabled="False" 
                Display="Dynamic">
            </asp:RangeValidator>

            <asp:RegularExpressionValidator 
                runat="server" 
                ErrorMessage="RegularExpressionValidator"
                ID="rgxParameter02" 
                ControlToValidate="txtParameter2"
                Display="Dynamic">
            </asp:RegularExpressionValidator>
        </p>
        <p>
            <%--<input id="btnSearch1" type="submit" value="Search" class="btn btn-primary" />--%>
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        </p>
        <p>
           <asp:GridView ID="dgvResult" runat="server" CssClass="table datatable-table "></asp:GridView>
        </p>
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkSearch").style.color = "rgba(255,255,255,1.0)";
    </script>

    <script>
        //clear the text box when parameter changed
        function clearTextBox(textBoxName) {
            textBox = document.getElementById("ASPContent_" + textBoxName);
            textBox.value = "";
        }
    </script>
</asp:Content>
