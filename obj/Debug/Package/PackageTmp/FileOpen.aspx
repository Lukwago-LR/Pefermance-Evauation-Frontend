<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="FileOpen.aspx.cs" Inherits="SATRI_CLIENT.FileOpen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group">
        <asp:LinkButton class="btn-block btn-success" ID="getFile" runat="server" OnClick="downL_Click"><center>OPEN FILE IN WORD</center></asp:LinkButton>
    </div>

    <div class="container-fluid text-center p-3">
        <div id="dFile" runat="server">
        </div>

        <div class="text-danger" style="text-align: center">
            <asp:Label ID="errorD" runat="server" Text="" Visible="false"></asp:Label>
        </div>

        <img src="images/satri-favi.png" class="img-fluid" alt="Responsive image">
    </div>


</asp:Content>

