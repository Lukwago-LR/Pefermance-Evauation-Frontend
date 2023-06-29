<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="ExecutiveDirectorAccount.aspx.cs" Inherits="SATRI_CLIENT.ExecutiveDirectorAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>

         <div class="container-fluid text-danger pt-md-5 pb-md-5 bootstrap snippets bootdeys">
            <div class="row">
                <div class="col-12">
                    <h4>
                        <center><b>DASHBOARD</b></center>
                    </h4>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <p>
                        <center> <b>TOTAL SATRI PERFORMANCE</b> </center>

                    </p>

                    <center><div id="TT" runat="server" class="border border-success rounded"> </div></center>

                </div>

                <div class="col-md-6">
                    <p>
                        <center> <b>SATRI PERFORMACE PERCENTAGE</b></center>

                    </p>

                    <center><div id="ev" runat="server" class="border border-success rounded"> </div></center>

                </div>

            </div>
            <hr />

            <div class="row text-center">
                <div class="col-md-4 mx-auto">
                    <div class="card card border-success" style="border-width:thick">
                        <div class="card-body">
                            <div class="row">
                                <div id="C1" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C2" runat="server" class="col-md-6 choosing">
                                </div>


                            </div>

                            <div class="row">
                                <div id="C7" runat="server" class="col-md-6 choosing">
                                </div>

                                <div id="C8" runat="server" class="col-md-6 choosing">
                                </div>                               

                            </div>

                            <div class="row">
                                <div id="C6" runat="server" class="col-md-12 choosing">
                                </div>

                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-md-8 mx-auto">

                    <div class="card card border-success" style="border-width:thick"">
                        <div class="card-body">
                            <div class="row">

                                <div class="col-md-12 text-center">
                                    <b>
                                       REVIEW 

                                    </b>

                                </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 content-card">
                                        <div class="card-big-shadow">
                                            <div class="card card-just-text" data-background="color" data-radius="none">
                                                <div class="content">
                                                    <p class="text-center">ADMIN-RELATED COMMENTS</p>
                                                    <div class="text-left" id="adminC" runat="server">
                                                        </div>
                                                   
                                                </div>
                                            </div>
                                        </div>


                                    </div>

                                <div class="col-md-3 content-card">
                                    
                                     <div class="card-big-shadow">
                                            <div class="card card-just-text" data-background="color" data-radius="none">
                                                <div class="content">
                                                    <p class="text-center">FILES</p>
                                                    <div class="text-left" id="files" runat="server">
                                                        </div>
                                                   
                                                </div>
                                            </div>
                                        </div>

                                </div>

                                <div class="col-md-5 content-card">
                                     <div class="card-big-shadow">
                                            <div class="card card-just-text" data-background="color" data-radius="none">
                                                <div class="content">
                                                    <p class="text-center">MONTHLY PERFORMANCE</p>

                                                    <div class="text-left" id="mP" runat="server">
                                                        </div>
                                                   
                                                </div>
                                            </div>
                                        </div>
                                   

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
