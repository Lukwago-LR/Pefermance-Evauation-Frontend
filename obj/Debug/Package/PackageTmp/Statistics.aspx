<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="SATRI_CLIENT.Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>

        <div class="container text-danger pt-md-5 pb-md-5">
            <div class="row">
                <div class="col-md-4 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div id="a" runat="server" class="text-danger">
                            </div>
                            <div runat="server" id="perMonth">
                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-md-4 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div id="underAdmin" runat="server" class="text-danger">
                                <h5><b>
                                    <center>POSSIBLE OUTCOMES</center>
                                </b></h5>
                            </div>
                            <div runat="server" id="outcom">
                               
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-4 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div id="b" runat="server" class="text-danger">
                            </div>
                            <div runat="server" id="compGraph">
                            </div>
                        </div>

                    </div>
                </div>

            </div>
            <div class="row">

                <div id="underP" runat="server" class="col-md-4 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="text-danger">
                                <h5><b>
                                    <center>UNDER PERFORMING RESEARCHERS</center>
                                </b></h5>
                                <div runat="server" id="under">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-md-4 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="text-danger">
                                <h5><b>
                                    <center>OVERALL SATRI PERFORMANCE PER MONTH</center>
                                </b></h5>
                            </div>
                            <div runat="server" id="monthPerformance">
                            </div>
                        </div>

                    </div>
                </div>

                <div id="overP" runat="server" class="col-md-4 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="text-danger">
                                <h5><b>
                                    <center>EXCELLING RESEARCHERS</center>
                                </b></h5>
                                 <div runat="server" id="over">
                                </div>

                            </div>
                        </div>

                    </div>
                </div>


            </div>

        </div>
    </section>
</asp:Content>
