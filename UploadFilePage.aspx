<%@ Page Title="" Language="C#" MasterPageFile="~/SATRI.Master" AutoEventWireup="true" CodeBehind="UploadFilePage.aspx.cs" Inherits="SATRI_CLIENT.UploadFilePage" %>

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
                                        UPLOAD A FILE
                                    </h3>
                                </center>
                                    <hr />
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-12">

                                    <label>File Type</label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="Ti" runat="server">
                                           
                                        </asp:DropDownList>
                                    </div>


                                    <label>File Selection</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="submit" class="btn btn-block btn-danger" runat="server" OnClick="Submit_Click" Text="Upload File" />
                                    </div>

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

    </section>
</asp:Content>
