<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="WebApplication2.pages.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script >
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({});
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">
                    
                          <div class="row">
                           <div class="col">
                            <center><h4>Author Details</h4>                     
                           </center>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col">
                            <center>
                                <img width="100px" src="../imgs/writer.png" />
                            </center>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                            <hr />
                           </div>
                        </div>
                       <div class="row">
                           <div class="col-md-4">
                               <label>Author ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Author ID"></asp:TextBox>
                             <asp:Button  class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" /> 
                                    </div>
                            </div>
                           </div>
                         <div class="col-md-8">
                               <label>Author Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Author Name"  ></asp:TextBox>
                             </div>
                           </div>
                        </div>
                     <div class="row">
                           <div class="col-md-4">
                                <asp:Button  class="btn btn-success btn-block" ID="Button2" runat="server" Text="ADD" OnClick="Button2_Click" /> 
                            </div>
                             <div class="col-md-4">
                                <asp:Button  class="btn btn-primary btn-block" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click"  /> 
                            </div>
                      <div class="col-md-4">
                                <asp:Button  class="btn btn-danger btn-block" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click"  /> 
                            </div>
                         
                           </div>
                        
                    </div>
                </div>
            <a href="Homepage.aspx"><< Back to Home Page</a>
            </div>
            <div class="col-md-7 mx-auto">
                <div class ="card">
                    <div class="class-body">
                        <div class="row">
                            <div class ="col">
                                <center>
                                <h3>Author List</h3></center>
                            </div>
                        </div>
                      
                         <div class="row">
                            <div class ="col">
                                <hr />
                                 </div> 
                        </div>
                         <div class="row">
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
