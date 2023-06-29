<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="AdministratorAccount.aspx.cs" Inherits="SATRI_CLIENT.AdministratorAccount" %>

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
                                 <div id="C3" runat="server" class="col-md-4 choosing">
                                </div>
                                <div id="C5" runat="server" class="col-md-4 choosing">
                                </div>
                                <div id="C7" runat="server" class="col-md-4 choosing">
                                </div>
                            </div>

                            <div class="row">
                                <div id="C8" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C9" runat="server" class="col-md-6 choosing">
                                </div>
                            </div>

                            <div class="col-12">
                                    <h4>
                                        <center><b>DASHBOARD</b></center>
                                    </h4>
                                </div>

                        </div>

                    </div>
                </div>

                <div class="col-md-6 mx-auto">

                    <div class="card">
                        <div class="card-body">
                            <div class="row">

                                <div class="col-md-12">
                                    <h4>
                                        <center>COMMENT MARK</center>
                                    </h4>

                                    <center><div id="Com" runat="server" class="border border-success rounded-circle"></div></center>
                                    <hr />

                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <h3>
                                        <center>Current Work</center>


                                    </h3>
                                    <div runat="server" id="graph1">
                                    </div>

                                </div>

                                <div class="col-md-8">
                                    <h3>
                                        <center>Performance</center>
                                    </h3>

                                    <div id="myperformChart" runat="server">
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

            <div class="row">
                <div class="col-12 text-danger">
                    <center><h4>ADMINISTRATOR</h4></center>
                </div>

            </div>

        </div>

    </section>

</asp:Content>
