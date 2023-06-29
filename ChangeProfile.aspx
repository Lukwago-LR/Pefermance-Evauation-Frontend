<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="ChangeProfile.aspx.cs" Inherits="SATRI_CLIENT.ChangeProfile" %>

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

                            <div class="row">
                                <div class="col-12 text-danger">
                                    <center>
                                    <h3>
                                        Edit Profile
                                    </h3>
                                </center>
                                    <hr />
                                </div>



                            </div>

                            <div class="row">
                                <div class="col-12">

                                    <label>New Contact</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="contact" placeholder="Contact" Type="Cellular" runat="server"></asp:TextBox>
                                    </div>

                                    <label>New Email</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="email" runat="server"></asp:TextBox>
                                    </div>

                                    <label>New Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="Password" runat="server" type="password"></asp:TextBox>
                                    </div>

                                    <label>Confirm New Password</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="ConfirmPass" runat="server" type="password"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="update" class="btn-block btn-danger" runat="server" OnClick="Edit_Click" Text="FINISH UPDATE" />

                                        <div class="text-danger" style="text-align: center">
                                            <asp:Label ID="error" runat="server" Text="" Visible="false"></asp:Label>
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
