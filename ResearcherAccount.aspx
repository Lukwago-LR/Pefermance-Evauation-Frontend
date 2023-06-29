<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="ResearcherAccount.aspx.cs" Inherits="SATRI_CLIENT.ResearcherAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container-fluid text-danger pt-md-5 pb-md-5">
             <div class="row">
                <div class="col-12">
                    <h4>
                        <center><b>DASHBOARD</b></center>
                    </h4>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <p>
                        <center> <b>PUBLICATIONS</b> </center>

                    </p>

                    <center><div id="pub" runat="server" class="border border-success rounded"> </div></center>

                </div>

                <div class="col-md-3">
                    <p>
                        <center> <b>DISSEMINATIONS</b></center>

                    </p>

                    <center><div id="dis" runat="server" class="border border-success rounded"> </div></center>

                </div>

                <div class="col-md-3 white_bg">
                    <p>
                        <center> <b>PROJECTS</b></center>

                    </p>

                    <center><div id="RP" runat="server" class="border border-success rounded"> </div></center></div>


                <div class="col-md-3">
                    <p>
                        <center> <div class="font-weight-bold">TOTAL</div></center>
                    </p>

                    <center><div id="TM" runat="server" class="col-12 border border-success rounded text-danger text-center"></div></center>

                </div>

            </div>
            <hr />

            <div class="row text-center">
                <div class="col-md-6 mx-auto">
                    <div class="card card border-success" style="border-width:thick">
                        <div class="card-body">
                            <div class="row">

                                <div id="C3" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C4" runat="server" class="col-md-6 choosing">
                                </div>

                            </div>

                            <div class="row">
                                

                                <div id="C5" runat="server" class="col-md-6 choosing">
                                </div>

                                 <div id="C7" runat="server" class="col-md-6 choosing">
                                </div>

                            </div>

                            <div class="row">

                                <div id="C8" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C9" runat="server" class="col-md-6 choosing">
                                </div>

                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-md-6 mx-auto">

                    <div class="card card border-success" style="border-width:thick"">
                        <div class="card-body">

                            <div class="row">
                                <div class="col-md-6">
                                    <b>
                                        <center>CURRENT WORK</center>


                                    </b>
                                    <div runat="server" id="graph1">
                                    </div>

                                </div>

                                <div class="col-md-6">
                                    <b>
                                        <center>PERFORMANCE</center>
                                    </b>

                                    <div id="myperformChart" runat="server">
                                    </div>

                                </div>

                            </div>
                        </div>

                    </div>

                </div>

            </div>

            <div class="row">
                <div id="name" runat="server" class="col-12 text-danger">
                   

                </div>

            </div>

        </div>

    </section>

</asp:Content>
