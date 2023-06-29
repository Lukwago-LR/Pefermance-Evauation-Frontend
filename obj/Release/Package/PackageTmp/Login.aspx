<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SATRI_CLIENT.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container p-md-3">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card card border-success" style="border-width:thick">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <center>
                                    <img src="images/adminIcon.png" alt="" />
                                </center>

                                </div>

                            </div>
                            <%--  --%>
                            <div class="row">
                                <div class="col-12 text-danger text-center font-weight-bolder">                                   
                                   
                                        MEMBER LOGIN                                   
                              
                                    <hr />
                                </div>



                            </div>

                            <div class="row">
                                <div class="col-12">

                                    <label>Email</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="email" placeholder="Email" runat="server"></asp:TextBox>
                                    </div>

                                    <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="password" runat="server" placeholder="Password" type="password"></asp:TextBox>
                                    </div>


                                    <div class="form-group">
                                        <asp:Button ID="login" class="btn-block btn-danger" runat="server" OnClick="login_Click" Text="Login" />

                                    </div>

                                    <div class="form-group">
                                        <asp:LinkButton class="btn-block btn-danger" ID="LinkButton1" runat="server" OnClick="reg_Click"><center>Register</center></asp:LinkButton>
                                    </div>

                                    <div class="text-danger" style="text-align: center">
                                        <asp:Label ID="error" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>

                                </div>

                            </div>
                        </div>

                    </div>

                </div>
                <div class="col-md-6 mx-auto">
                    <div class="card card border-success" style="border-width:thick">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <div class="text-danger text-center font-weight-bolder">
                                        <p>SATRI PERFORMACE EVALUATION ANALYSIS SYSTEM</p>
                                    </div>
                                    <center>
                                    <img src="images/manCarry.png" height="400" width="500" alt="" />
                                </center>

                                </div>

                            </div>

                        </div>

                    </div>

                </div>



            </div>
        </div>

    </section>

</asp:Content>
