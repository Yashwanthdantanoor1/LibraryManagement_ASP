<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Userprofile.aspx.cs" Inherits="WebApplication2.pages.Userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                           <div class="col">
                            <center><img width="150px" src="../imgs/generaluser.png" /></center>
                           </div>
                        </div>
                          <div class="row">
                           <div class="col">
                            <center><h4>Your Profile</h4>
                                <span>Account Status : </span>
                                <asp:Label class="badge badge-pill badge-success" ID="Label1" runat="server" Text="Active"></asp:Label>
                            </center>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                            <hr />
                           </div>
                        </div>
                       <div class="row">
                           <div class="col-md-6">
                               <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-6">
                               <label>Date of Birth</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>
                             </div>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col-md-6">
                               <label>Contact Number</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-6">
                               <label>Email ID</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                             </div>
                           </div>
                        </div>
                         <div class="row">
                           <div class="col-md-4">
                               <label>State</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="State"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-4">
                               <label>City</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="State" ></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-4">
                               <label>Pin Code</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                             </div>
                           </div>
                        </div>
                        <div class="row">
                           <div class="col-md-12">
                               <label>Full-Address</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Full Address" TextMode="MultiLine"></asp:TextBox>
                             </div>
                           </div>
                            </div>
                        <div class="row">
                            <div class="col">
                                <center>
                        <span class="badge badge-pill badge-info">Login Credentials</span></center>
                                <br />
                            </div>
                        </div>
                         <div class="row">
                           <div class="col-md-4">
                               <label>User ID</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="User Id" ReadOnly="True"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-4">
                               <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Password" ReadOnly="True"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-4">
                               <label>Change Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="New Password" ></asp:TextBox>
                             </div>
                           </div>
                        </div>
                     <div class="row">
                           <div class="col-md-6">
                               <center>
                              <div class="form-group">   
                          <asp:Button  class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Update" />
                                    </div>
                           </div>
                        </div>
                    </div>
                </div>
            
            </div>
            <div class="col-md-7 mx-auto">
                <div class ="card">
                    <div class="class-body">
                        <div class="row">
                            <div class ="col">
                                <center>
                                <img width="90px"src="../imgs/books.png" /></center>
                            </div>
                        </div>
                       <div class="row">
                            <div class ="col">
                                <center>
                                <h3> Your Issued Books</h3></center>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <center>
                                  <span class="badge badge-pill badge-info">Info about book due date</span></center>
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

        </div>
    </div>
</asp:Content>
