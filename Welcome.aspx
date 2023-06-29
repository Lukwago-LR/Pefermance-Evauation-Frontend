<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="SATRI_CLIENT.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="sec1">
        <div class="container p-1 p-sm-3">
            <div class="row">
                <div class="col-12 text-danger text-center">

                    <b>YOU ARE WELCOME, YOUR ACCOUNT WILL BE VALIDATED AS SOON AS POSSIBLE</b>
                    <hr />
                </div>
            </div>
        </div>
    </section>

    <section class="sec2">
        <div class="container p-1 p-sm-3">
            <div class="row ">
                <div class="col md-5">
                    <img class="img-fluid" src="images/icon2.jpg" width="400" alt="" />
                </div>

                <div class="col- col-md-7                ">
                    <p>
                        The Sam Tambani Research Institute is a Public Benefit Non-profit Company registered in 2012.
                        The idea of establishing the institute was perceived jointly by the National Union of Mine Workers (NUM) and Mineworkers Investment Trust (MIT).
                        It arose from the need to consolidate NUM efforts to ensure that workers get a fair share of what they produce which enables them in turn to improve their livelihoods. 
                        It was recognised that interventions aimed at improving workers and their families’ welfare had become complex and required a great deal of factual information. 
                        SATRI would be responsible for gathering and analysing such information through its targeted research agenda
                    </p>

                    <p> <b>For more information visit the official SATRI website</b> </p>

                </div>

            </div>
        </div>

    </section>

    <section class=" sec3 pt-2 pb-3">
        <div class="container">
            <div class="row">
                <div class="col md-12 text-danger text-center">
                    <h3><b>DIFFERENT PERSONEL AND THEIR ROLES ON THIS SYSTEM</b></h3>
                    
                <hr />

                </div>


                <div class="row">                    

                    <div class="col md-3 text-center">

                         <i class="fas fa-4x fa-user-tie"></i>
                        <h5>
                            EXECUTIVE DIRECTOR
                        </h5>
                        <p>
                            Oversees Administrators and Verifies Senior Researcher Research Work 
                        </p>
                        <p>
                            Verifies Administrator comments
                        </p>

                    </div>

                    <div class="col md-3 text-center">

                       <i class="fas fa-4x fa-graduation-cap"></i>
                        <h5>
                            SENIOR RESEARCHER
                        </h5>
                        <p>
                            Oversees Researchers and Verifies their research work
                        </p>

                         <p>
                            Verifies Administrator comments
                        </p>
                    </div>

                    <div class="col md-3 text-center">

                        <i class="fas fa-4x fa-user-graduate"></i>
                        <h5>
                            RESEARCHER
                        </h5>
                        <p>
                            Does research and comments on support received from administrator and the Senior Researcher
                        </p>

                    </div>

                     <div class="col md-3 text-center">

                       <i class="fas fa-4x fa-hands-helping"></i>
                        <h5>
                            ADMINISTRATOR
                        </h5>
                        <p>
                            Supports Researchers in their work and comments on their co-operation
                        </p>

                    </div>

                </div>            
                   
               
            </div>

        </div>
    </section>
</asp:Content>
