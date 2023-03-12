<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="WebApplication2.pages.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">
                          <div class="row">
                           <div class="col">
                            <center><h4>Member Details</h4>                     
                           </center>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col">
                            <center>
                                <img width="100px" src="../imgs/generaluser.png" />
                            </center>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                            <hr />
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-md-3">
                               <label>Member ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                             <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">GO</asp:LinkButton>
                                    </div>
                            </div>
                           </div>
                         <div class="col-md-4">
                               <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" ReadOnly="True" placeholder="Member Name"></asp:TextBox>
                             </div>
                           </div>
                        <div class="col-md-5">
                               <label>Account Status</label>
                            <div class="form-group">
                                 <div class="input-group">
                                     
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server"  ReadOnly="True" placeholder="Account Status"></asp:TextBox>
                                <asp:LinkButton class="btn btn-success mr-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                   <asp:LinkButton class="btn btn-warning mr-1" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="far fa-pause-circle"></i></asp:LinkButton> 
                                   <asp:LinkButton class="btn btn-danger mr-1" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                 </div>
                                 </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-md-3">
                               <label>DOB</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"  ReadOnly="True" TextMode="Date"></asp:TextBox>
                             </div>
                           </div>
                          <div class="col-md-4">
                               <label>Contact</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server"  ReadOnly="True" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-5">
                               <label>Email Id</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Email ID" ReadOnly="True" TextMode="Email"></asp:TextBox>
                             </div>
                           </div>
                        </div>
                         <div class="row">
                           <div class="col-md-4">
                               <label>State</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" ReadOnly="True" placeholder="State"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-4">
                               <label>City</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" ReadOnly="True"  placeholder="City" ></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-4">
                               <label>Pin Code</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" ReadOnly="True"  placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                             </div>
                           </div>
                        </div>
                      <div class="row">
                           <div class="col-md-12">
                               <label>Full-Address</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" ReadOnly="True" placeholder="Full Address" TextMode="MultiLine"></asp:TextBox>
                             </div>
                           </div>
                            </div>
                     <div class="row">
                             <div class="col">
                                 <center>
                                <asp:Button  class="btn btn-danger btn-block" ID="Button3" runat="server" Text="Delete User Permanently" OnClick="Button3_Click" /> </center>
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
                                <h3>Member List</h3></center>
                            </div>
                        </div>
                      
                         <div class="row">
                            <div class ="col">
                                <hr />
                                 </div> 
                        </div>
                         <div class="row">
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
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
