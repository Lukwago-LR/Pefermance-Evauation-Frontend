<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="SATRI_CLIENT.Comment" %>

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
                                <div class="col-12 text-danger">
                                    <center>
                                    <h3>
                                        COMMENT
                                    </h3>
                                </center>
                                    <hr />
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-12">

                                    <label>Comment Type</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <label>Comment Recepient</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <div id="about" runat="server">
                                        <label>Comment About</label>
                                        <div class="form-group">
                                            <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>



                                    <label>Comment Description</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="descrip" placeholder="Description" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="btn_comment" class="btn btn-block btn-danger" runat="server" OnClick="Comment_Click" Text="Send Comment" />

                                    </div>

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


    </section>
</asp:Content>
