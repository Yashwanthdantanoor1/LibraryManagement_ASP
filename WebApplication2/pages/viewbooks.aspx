<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="WebApplication2.pages.viewbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class ="mb-auto mt-5 pt-3">
                <div class="col">
                <div class ="card">
                    <div class="class-body">
                        <div class="row">
                            <div class ="col">
                                <center>
                                <h3>Books List</h3></center>
                            </div>
                        </div>
                      
                         <div class="row">
                            <div class ="col">
                                <hr />
                                 </div> 
                        </div>
                         <div class="row">
                            <div class ="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </main>
</asp:Content>
