<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="CNSA216_EBC_project.WebForm8" %>
<%@ Import Namespace="CNSA216_EBC_project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Search - Louis' Pharmacy</title>
    <script>
        // require one of the active/inactive textboxes to be selected
        function ActiveInactiveChanged(caller) {
            var chkActive = document.getElementById("ASPContent_chkActive");
            var chkInactive = document.getElementById("ASPContent_chkInactive");

            //alert(caller)

            if (!chkActive.checked && !chkInactive.checked) {
                caller.checked = !caller.checked
            }
        }

        function ClearTextBox(textboxName) {
            var textbox = document.getElementById(textboxName);
            textbox.value = "";
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">

    <form id="formSearchFor" runat="server">
        <div class="container-fluid px-4">
            <h1>Search</h1>
            <hr />
            <asp:Label runat="server" Text="Label" ForeColor="Red" ID="lblError" Visible="False"></asp:Label>

            <!--
                    Dropdown box to select what type of data to search for
                    The dropdown box auto posts back to the server so other dropdowns are updated automatically   
                -->

            <%--<asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>--%>

            <div class="row">
                <div class="col-xl mb-4">
                    <div class="card h-100">
                        <%--<div class="card-header">

                        </div>--%>
                        <div class="card-body">
                            <p>
                                Search for:&nbsp;
                                <asp:DropDownList
                                    ID="ddlSearchFor"
                                    runat="server"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlSearchFor_SelectedIndexChanged"
                                >
                                    <asp:ListItem>Patients</asp:ListItem>
                                    <asp:ListItem>Physicians</asp:ListItem>
                                    <asp:ListItem>Prescriptions</asp:ListItem>
                                    <asp:ListItem>Refills</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <p>
                                <asp:CheckBox runat="server" ID="chkActive" Text="&nbsp;Show active" Checked="true" ></asp:CheckBox><br />
                                <asp:CheckBox runat="server" ID="chkInactive" Text="&nbsp;Show inactive"></asp:CheckBox>
                            </p>

                            <p>
                                <asp:DropDownList
                                    ID="ddlParameter1"
                                    runat="server" 
                                    OnSelectedIndexChanged="ddlParameter1_SelectedIndexChanged" 
                                    onchange="javascript:ClearTextBox('ASPContent_txtParameter1');"
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
                                    AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlParameter2_SelectedIndexChanged" 
                                    onchange="javascript:ClearTextBox('ASPContent_txtParameter2');"
                                    CausesValidation="True">
                                </asp:DropDownList>
                                &nbsp;
                                <asp:TextBox ID="txtParameter2" runat="server" CausesValidation="true"></asp:TextBox>
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

                            <%--<input id="btnSearch1" type="submit" value="Search" class="btn btn-primary" />--%>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                            
                        </div>
                    </div>
                </div>

                <div class="col-xl mb-4">
                    <div class="card h-100">
                        <div class="card-body d-flex align-items-center justify-content-center">
                            Use the navigation bar on the left to add new records. <br />
                            Search for a prescription to add a refill for it.
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    Results
                </div>

                <div class="card-body">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
                        <asp:GridView ID="dgvPatient" runat="server" CssClass="table datatable-table nowrap" AutoGenerateColumns="False">
                            <EmptyDataTemplate>
                                <h2>No data</h2>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <i class="fa-solid fa-gear"></i>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            runat="server" 
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Prescription:ADD"
                                            CommandArgument='<%# Eval("PatientID") %>'
                                        >
                                            <i class="fa-solid fa-prescription-bottle"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Patient:VIEW"
                                            CommandArgument='<%# Eval("PatientID") %>'
                                        >
                                            <i class="fa-solid fa-eye"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Patient:EDIT"
                                            CommandArgument='<%# Eval("PatientID") %>'
                                        >
                                            <i class="fa-solid fa-pencil"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Patient:DELETE"
                                            CommandArgument='<%# Eval("PatientID") %>'
                                        >
                                            <i class="fa-solid fa-trash"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="Active" HeaderText="Active" ItemStyle-CssClass="text-center"></asp:CheckBoxField>
                                <asp:BoundField DataField="PatientID" HeaderText="Patient ID"></asp:BoundField>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name"></asp:BoundField>
                                <asp:BoundField DataField="Middle" HeaderText="Middle"></asp:BoundField>
                                <asp:BoundField DataField="LastName" HeaderText="Last Name"></asp:BoundField>
                                <asp:BoundField DataField="Gender" HeaderText="Gender"></asp:BoundField>
                                <asp:BoundField DataField="InsuranceName" HeaderText="Insurance"></asp:BoundField>
                                <asp:BoundField DataField="Street" HeaderText="Street"></asp:BoundField>
                                <asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
                                <asp:BoundField DataField="State" HeaderText="State"></asp:BoundField>
                                <asp:BoundField DataField="Zip" HeaderText="ZIP"></asp:BoundField>
                                <asp:BoundField DataField="Phone1" HeaderText="Phone 1"></asp:BoundField>
                                <asp:BoundField DataField="Phone2" HeaderText="Phone 2"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                <asp:BoundField DataField="Height" HeaderText="Height (in)"></asp:BoundField>
                                <asp:BoundField DataField="Weight" HeaderText="Weight (lb)"></asp:BoundField>
                                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date"></asp:BoundField>
                                <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="End Date"></asp:BoundField>
                    
                            </Columns>
                        </asp:GridView>

                        <asp:GridView ID="dgvPhysician" runat="server" CssClass="table datatable-table nowrap " AutoGenerateColumns="False" Visible="false">
                            <EmptyDataTemplate>
                                <h2>No data</h2>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <i class="fa-solid fa-gear"></i>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Physician:VIEW"
                                            CommandArgument='<%# Eval("PhysicianID") %>'
                                        >
                                            <i class="fa-solid fa-eye"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Physician:EDIT"
                                            CommandArgument='<%# Eval("PhysicianID") %>'
                                        >
                                            <i class="fa-solid fa-pencil"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Physician:DELETE"
                                            CommandArgument='<%# Eval("PhysicianID") %>'
                                        >
                                            <i class="fa-solid fa-trash"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="Active" HeaderText="Active" ItemStyle-CssClass="text-center"></asp:CheckBoxField>
                                <asp:BoundField DataField="PhysicianID" HeaderText="Physician ID"></asp:BoundField>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name"></asp:BoundField>
                                <asp:BoundField DataField="Middle" HeaderText="Middle"></asp:BoundField>
                                <asp:BoundField DataField="LastName" HeaderText="Last Name"></asp:BoundField>
                                <asp:BoundField DataField="Gender" HeaderText="Gender"></asp:BoundField>
                                <asp:BoundField DataField="Street" HeaderText="Street"></asp:BoundField>
                                <asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
                                <asp:BoundField DataField="State" HeaderText="State"></asp:BoundField>
                                <asp:BoundField DataField="Zip" HeaderText="ZIP"></asp:BoundField>
                                <asp:BoundField DataField="Phone1" HeaderText="Phone 1"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date"></asp:BoundField>
                                <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="End Date"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
            
                        <asp:GridView ID="dgvPrescription" runat="server" CssClass="table datatable-table nowrap" AutoGenerateColumns="False" Visible="false">
                            <EmptyDataTemplate>
                                <h2>No data</h2>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <i class="fa-solid fa-gear"></i>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            runat="server" 
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Refill:ADD"
                                            CommandArgument='<%# Eval("PrescriptionID") %>'
                                        >
                                            <i class="fa-solid fa-prescription-bottle"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Prescription:VIEW"
                                            CommandArgument='<%# Eval("PrescriptionID") %>'
                                        >
                                            <i class="fa-solid fa-eye"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Prescription:EDIT"
                                            CommandArgument='<%# Eval("PrescriptionID") %>'
                                        >
                                            <i class="fa-solid fa-pencil"></i>
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton
                                            runat="server"
                                            CssClass="no-underline"
                                            OnCommand="TableActions"
                                            CommandName="Prescription:DELETE"
                                            CommandArgument='<%# Eval("PrescriptionID") %>'
                                        >
                                            <i class="fa-solid fa-trash"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="Active" HeaderText="Active" ItemStyle-CssClass="text-center"></asp:CheckBoxField>
                                <asp:BoundField DataField="PrescriptionID" HeaderText="Prescription ID"></asp:BoundField>
                                <asp:BoundField DataField="PatientFirstName" HeaderText="Patient First Name"></asp:BoundField>
                                <asp:BoundField DataField="PatientLastName" HeaderText="Patient Last Name"></asp:BoundField>
                                <asp:BoundField DataField="PhysFirstName" HeaderText="Phys. First Name"></asp:BoundField>
                                <asp:BoundField DataField="PhysLastName" HeaderText="Phys. Last Name"></asp:BoundField>
                                <asp:BoundField DataField="MedicineName" HeaderText="Medicine"></asp:BoundField>
                                <asp:BoundField DataField="Dosage" HeaderText="Dosage"></asp:BoundField>
                                <asp:BoundField DataField="IntakeMethod" HeaderText="Intake Method"></asp:BoundField>
                                <asp:BoundField DataField="Instructions" HeaderText="Instructions"></asp:BoundField>
                                <asp:BoundField DataField="ExtraInstructions" HeaderText="Extra Instructions" ></asp:BoundField>
                                <asp:BoundField DataField="RefillsAllowed" HeaderText="Refills Allowed"></asp:BoundField>
                                <asp:BoundField DataField="RefillsLeft" HeaderText="Refills Left"></asp:BoundField>
                                <asp:BoundField DataField="RefillQuantity" HeaderText="Refill Quantity"></asp:BoundField>
                                <asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date"></asp:BoundField>
                                <asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HeaderText="End Date"></asp:BoundField>
                                <asp:BoundField DataField="EnteredDateTime" DataFormatString="{0:G}" HeaderText="Date &amp; Time Entered"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
            
                        <asp:GridView ID="dgvRefill" runat="server" CssClass="table datatable-table nowrap" AutoGenerateColumns="False" Visible="false">
                            <EmptyDataTemplate>
                                <h2>No data</h2>
                            </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <i class="fa-solid fa-gear"></i>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton
                                                runat="server"
                                                CssClass="no-underline"
                                                OnCommand="TableActions"
                                                CommandName="Refill:VIEW"
                                                CommandArgument='<%# Eval("RefillID") %>'
                                            >
                                                <i class="fa-solid fa-eye"></i>
                                            </asp:LinkButton>
                                            &nbsp;
                                             <asp:LinkButton
                                                 runat="server"
                                                 CssClass="no-underline"
                                                 OnCommand="TableActions"
                                                 CommandName="Refill:EDIT"
                                                 CommandArgument='<%# Eval("RefillID") %>'
                                             >
                                                 <i class="fa-solid fa-pencil"></i>
                                             </asp:LinkButton>
                                             &nbsp;
                                             <asp:LinkButton
                                                 runat="server"
                                                 CssClass="no-underline"
                                                 OnCommand="TableActions"
                                                 CommandName="Refill:DELETE"
                                                 CommandArgument='<%# Eval("RefillID") %>'
                                             >
                                                 <i class="fa-solid fa-trash"></i>
                                             </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField DataField="Active" HeaderText="Active" ItemStyle-CssClass="text-center"></asp:CheckBoxField>
                                    <asp:BoundField DataField="FillDateTime" DataFormatString="{0:G}" HeaderText="Time of Refill"></asp:BoundField>
                                    <asp:BoundField DataField="PrescriptionID" HeaderText="Prescription ID"></asp:BoundField>
                                    <asp:BoundField DataField="PatientFirstName" HeaderText="Patient First Name"></asp:BoundField>
                                    <asp:BoundField DataField="PatientLastName" HeaderText="Patient Last Name"></asp:BoundField>
                                    <asp:BoundField DataField="ClerkFirstName" HeaderText="Clerk First Name"></asp:BoundField>
                                    <asp:BoundField DataField="ClerkLastName" HeaderText="Clerk Last Name"></asp:BoundField>
                                    <asp:BoundField DataField="MedicineName" HeaderText="Medicine"></asp:BoundField>
                                    <asp:BoundField DataField="Dosage" HeaderText="Dosage"></asp:BoundField>
                                    <asp:BoundField DataField="RefillsAllowed" HeaderText="Refills Allowed"></asp:BoundField>
                                    <asp:BoundField DataField="RefillsLeft" HeaderText="Refills Left"></asp:BoundField>
                                    <asp:BoundField DataField="RefillQuantity" HeaderText="Refill Quantity"></asp:BoundField>
                                </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkSearch").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
