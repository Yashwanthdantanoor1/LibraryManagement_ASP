<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usersignup.aspx.cs" Inherits="WebApplication2.pages.Usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                           <div class="col">
                            <center><img width="150px" src="../imgs/generaluser.png" /></center>
                           </div>
                        </div>
                          <div class="row">
                           <div class="col">
                            <center><h4>User Registration</h4></center>
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
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
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
                           <div class="col-md-6">
                               <label>User ID</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="User Id"></asp:TextBox>
                             </div>
                           </div>
                         <div class="col-md-6">
                               <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Password" ></asp:TextBox>
                             </div>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                              <div class="form-group">
                                 <a style="text-decoration:none" href="Usersignup.aspx">
                                     <asp:Button ID="Button1" class="btn btn-success btn-block" runat="server" Text="Signup" OnClick="Button1_Click" />
                              </a>
                                     </div>
                           </div>
                        </div>
                    </div>
                </div>
                      <a href="Homepage.aspx"><< Back to Home Page</a>
            </div>

        </div>
    </div>
</asp:Content>
