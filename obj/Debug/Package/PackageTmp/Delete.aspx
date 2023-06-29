<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="SATRI_CLIENT.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container p-md-3">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">

                            <div class="text-danger" style="text-align: center">
                                <asp:Label ID="del" runat="server" Text="" Visible="false"></asp:Label>
                            </div>

                        </div>
                    </div>

                </div>

            </div>

        </div>


    </section>

</asp:Content>
