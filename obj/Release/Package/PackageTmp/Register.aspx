<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SATRI_CLIENT.Register" %>

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
                                    <img src="images/adminIcon.png" height="100" alt="" />
                                </center>

                                </div>

                            </div>

                            <div class="row">
                                <div class="col-12 text-danger text-center font-weight-bolder">
                                    MEMBER REGISTRATION
                                
                                    <hr />
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-4 md">

                                    <label>Title</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">

                                            <asp:ListItem Text="DR" Value="DR"> </asp:ListItem>
                                            <asp:ListItem Text="MR" Value="MR"> </asp:ListItem>
                                            <asp:ListItem Text="MRS" Value="MRS" />
                                            <asp:ListItem Text="MS" Value="MS" />

                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-4 md">
                                    <label>User Type</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                            <asp:ListItem Text="RESEARCHER" Value="RESEARCHER" />
                                            <asp:ListItem Text="ADMINISTRATOR" Value="ADMINISTRATOR" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-4 md">

                                    <label>Firstname</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="firstname" placeholder="Firstname" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">


                            <div class="col-4 md">
                                <label>Surname</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="surname" placeholder="Surname" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-4 md">

                                <label>Contact</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="contact" placeholder="Contact" Type="Cellular" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-4 md">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="email" placeholder="Email" runat="server"></asp:TextBox>
                                </div>

                            </div>

                        </div>


                        <div class="row">

                            <div class="col-6 md">

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="Password" runat="server" placeholder="Password" type="password"></asp:TextBox>
                                </div>
                            </div>



                            <div class="col-6 md">


                                <label>Confirm Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="ConfirmPass" runat="server" placeholder="Password" type="password"></asp:TextBox>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 md">

                            <div class="form-group">
                                <asp:Button ID="register" class="btn-block btn-danger" runat="server" OnClick="Register_Click" Text="COMPLETE REGISTRATION" />

                                <div class="text-danger" style="text-align: center">
                                    <asp:Label ID="error" runat="server" Text="" Visible="false"></asp:Label>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-6 mx-auto">
                    <div class="card card border-success" style="border-width:thick">
                        <div class="card-body">
                             <div class="col-12">
                                    <div class="text-danger text-center font-weight-bolder">
                                        <p>WELCOME , SIGN UP AND  TRACK YOUR PERFORMANCE</p>
                                    </div>
                                    <center>
                                    <img src="images/register.png" height="400" width="480" alt="" />
                                </center>

                                </div>
                            

                        </div>

                    </div>

                </div>
                </div>
            </div>
    </section>

</asp:Content>
