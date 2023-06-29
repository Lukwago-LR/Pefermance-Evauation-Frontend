<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Decline.aspx.cs" Inherits="SATRI_CLIENT.Decline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container p-sm-2 p-md-5">
            <div class="row">
                <div class="col-12 text-danger">

                    <center>
                        <label>Feedback</label>
                    </center>
                   
                    <div class="form-group">
                        <asp:TextBox class="form-control" ID="descrip" placeholder="Description" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Button CssClass="btn-block btn-danger" ID="btnDES" runat="server" Text="Send Feedback" OnClick="DESC_Click" />
                    </div>

                </div>

            </div>

        </div>
    </section>

</asp:Content>
