<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="CNSA216_EBC_project.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Search - Louis' Pharmacy</title>

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


        <asp:GridView ID="dgvResult" runat="server" CssClass="table datatable-table "></asp:GridView>

        <p>
            <asp:DropDownList ID="ddlParameter1" runat="server"></asp:DropDownList>&nbsp;
                    <asp:TextBox ID="txtParameter1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:DropDownList ID="ddlParameter2" runat="server"></asp:DropDownList>&nbsp;
                    <asp:TextBox ID="txtParameter2" runat="server"></asp:TextBox>
        </p>
        <p>
            <input id="btnSearch" type="submit" value="Search" class="btn btn-primary" />
        </p>
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkSearch").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
