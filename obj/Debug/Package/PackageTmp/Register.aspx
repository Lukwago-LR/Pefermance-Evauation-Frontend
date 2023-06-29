<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SATRI_CLIENT.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container p-md-3">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-12">
                                    <center>
                                    <img src="images/adminIcon.png" alt="" />
                                </center>

                                </div>

                            </div>

                            <div class="row">
                                <div class="col-12 text-danger">
                                    <center>
                                    <h3>
                                        User Registration
                                    </h3>
                                </center>
                                    <hr />
                                </div>



                            </div>

                            <div class="row">
                                <div class="col-12">

                                    <label>Title</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">

                                            <asp:ListItem Text="DR" Value="DR"> </asp:ListItem>
                                            <asp:ListItem Text="MR" Value="MR"> </asp:ListItem>
                                            <asp:ListItem Text="MRS" Value="MRS" />
                                            <asp:ListItem Text="MS" Value="MS" />

                                        </asp:DropDownList>
                                    </div>

                                    <label>Firstname</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="firstname" placeholder="Firstname" runat="server"></asp:TextBox>
                                    </div>

                                    <label>Surname</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="surname" placeholder="Surname" runat="server"></asp:TextBox>
                                    </div>

                                    <label>User Type</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                            <asp:ListItem Text="RESEARCHER" Value="RESEARCHER" />
                                            <asp:ListItem Text="ADMINISTRATOR" Value="ADMINISTRATOR" />
                                        </asp:DropDownList>
                                    </div>

                                    <label>Contact</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="contact" placeholder="Contact" Type="Cellular" runat="server"></asp:TextBox>
                                    </div>

                                    <label>Email</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="email" placeholder="Email" runat="server"></asp:TextBox>
                                    </div>

                                    <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="Password" runat="server" placeholder="Password" type="password"></asp:TextBox>
                                    </div>

                                    <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="ConfirmPass" runat="server" placeholder="Password" type="password"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="register" class="btn-block btn-danger" runat="server" OnClick="Register_Click" Text="Complete Registration" />

                                         <div class="text-danger" style="text-align:center">
                                    <asp:Label ID="error" runat="server" Text="" visible="false" ></asp:Label>
                                </div>

                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>

                </div>

            </div>
        </div>

    </section>

</asp:Content>
