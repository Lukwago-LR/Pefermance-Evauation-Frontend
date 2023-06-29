<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SATRI_CLIENT.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="sec pt-4 pb-5">
        <div class="container">
            <div class="row align-content-center">
                <div class="col md-5">
                    <h5>Research - Verify - Evaluate
                    </h5>
                    <h5>Impartial Performance Evaluaton
                    </h5>
                    <h5>Gauge personal and organisational performance.
                    </h5>

                    <a href="Welcome.aspx" class="button btn btn-primary btn-lg">Get Started</a>

                </div>

                <div class="col md-7">
                    <img src="images/Capture.PNG" width="550" height="160" alt="" />
                </div>

            </div>

        </div>
    </section>

    <section class="pt-2 pb-3">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-danger text-center">
                    <h5><b>MAJOR PROCEDURES YOU SHOULD EXPECT</b></h5>

                    <hr />

                </div>


                <div class="row">

                    <div class="col-md-4 text-center">

                        <img height="30" src="images/dotheSearch.jpg" alt="" />
                        <h5 class="text-danger">DO RESEARCH
                        </h5>
                        <p>
                            Do, finish and present quality research work for evaluation 
                        </p>

                    </div>

                    <div class="col md-4 text-center">
                        <img height="30" src="images/uploadfile.jpg" alt="" />
                        <h5 class="text-danger">UPLOAD AND FORWARD FILE
                        </h5>
                        <p>
                            Submit your research file for verification and auto evaluation
                        </p>
                    </div>

                    <div class="col md-4 text-center">

                        <img height="30" src="images/viewFile.jpg" alt="" />
                        <h5 class="text-danger">VIEW FILES
                        </h5>
                        <p>
                           View your files, if they have been verified and evaluated or not
                        </p>

                    </div>

                </div>

                <div class="row">
                    <div class="col md-4 text-center">

                        <img height="30" src="images/verify.jpg" alt="" />
                        <h5 class="text-danger">VERIFY FILES
                        </h5>
                        <p>
                            Research work checked for quality prior to evaluation
                        </p>

                    </div>

                    <div class="col md-4 text-center">

                        <img height="30" src="images/evaluate.jpg" alt="" />
                        <h5 class="text-danger">AUTO EVALUATION
                        </h5>
                        <p>
                            Your verified research work will then be evaluated and you be assigned a grade.
                        </p>

                    </div>

                    <div class="col md-4 text-center">

                        <img height="30" src="images/reward.jpg" alt="" />
                        <h5 class="text-danger">REWARDS
                        </h5>
                        <p>
                            Exceptional work in quality will be rewarded
                        </p>

                    </div>

                </div>
            </div>

        </div>
    </section>
</asp:Content>
