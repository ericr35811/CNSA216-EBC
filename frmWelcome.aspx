<%@ Page Title="" Language="C#" MasterPageFile="~/CNSA216-EBC.Master" AutoEventWireup="true" CodeBehind="frmWelcome.aspx.cs" Inherits="CNSA216_EBC_project.WebForm7" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <title>Welcome - Louis' Pharmacy</title>
    <style>
        .carousel img {
            height: 300px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ASPContent" runat="server">
    <h1>Welcome to Louis' Pharmacy!</h1>
    <hr />

    <div class="row">
        <div class="col-xl">
            <div class="card px-3 py-2">
                <p>Use the navigation bar on the left to add new records.</p>
                <p>Search for a patient to add a prescription for them. </p>
                <p>Search for a prescription to add a refill for it.</p>
            </div>
        </div>
    </div>

    <div id="welcomeCarousel" class="carousel slide" data-bs-ride="carousel" >
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="images/carousel1.jfif" alt="" />
            </div>
            <div class="carousel-item">
                <img src="images/carousel2.jpeg" alt="" />
            </div>
            <div class="carousel-item">
                <img src="images/carousel3.jpg" alt="" />
            </div>
            <div class="carousel-item">
                <img src="images/carousel4.png" alt="" />
            </div>


        </div>
    </div>

    <img src="images/medicine.png" alt="" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Bottom" runat="server">
    <script>
        // Change the color of the selected link
        document.getElementById("lnkWelcome").style.color = "rgba(255,255,255,1.0)";
    </script>
</asp:Content>
