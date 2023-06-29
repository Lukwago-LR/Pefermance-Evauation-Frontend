<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="ExecutiveDirectorAccount.aspx.cs" Inherits="SATRI_CLIENT.ExecutiveDirectorAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>

        <div class="container text-danger pt-md-5 pb-md-5">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div id="C1" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C2" runat="server" class="col-md-6 choosing">
                                </div>

                            </div>

                            <div class="row">
                                <div id="C8" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C7" runat="server" class="col-md-6 choosing">
                                </div>


                            </div>

                            <div class="row">
                                <div id="C6" runat="server" class="col-12 choosing">
                                </div>
                            </div>

                            <div class="text-danger">
                               <center><h3>DASHBOARD</h3></center>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-md-6 mx-auto">

                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <div class="col-12">
                                    <h4>
                                        <center>TOTAL PERFORMANCE [WORK AND COMMENTS EVALUATED]</center>
                                    </h4>

                                    <center><div id="TT" runat="server" class="border border-success rounded-circle"> </div></center>


                                </div>

                            </div>

                            <div class="row">
                                <div>
                                    <h4>
                                        <center>OVERALL PERFORMANCE PERCENTAGE</center>
                                    </h4>
                                </div>


                                <div id="ev" runat="server" class="col-12 border border-success rounded text-danger text-center">
                                </div>

                            </div>


                        </div>

                    </div>

                </div>

            </div>

            <div class="row">
                <div class="col-12 text-danger">
                    <center><h3>EXECUTIVE DIRECTOR</h3></center>
                </div>

            </div>

        </div>

    </section>
</asp:Content>
