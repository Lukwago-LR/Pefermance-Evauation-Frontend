<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Decline.aspx.cs" Inherits="SATRI_CLIENT.Decline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container p-sm-2 p-md-5">

            <div class="row">
                <div class="col-12 text-danger">
                    <center>
                     <h5>
                     UPLOAD DECLINED FILE
                    </h5>
                   </center>
                    <hr />
                </div>

            </div>

            <div class="row">
                <div class="col-12">
                    <label>File Selection</label>
                    <div class="form-group">
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-12 text-danger">

                    <center>
                        <h5>FEEDBACK</h5>
                    </center>

                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="descrip" placeholder="Description" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button CssClass="btn-block btn-danger" ID="btnDES" runat="server" Text="FORWARD FILE WITH FEEDBACK" OnClick="DESC_Click" />
                    </div>

                    <div class="text-danger" style="text-align: center">
                        <asp:Label ID="error" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                </div>

            </div>

        </div>
    </section>

</asp:Content>
