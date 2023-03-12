<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Userlogin.aspx.cs" Inherits="WebApplication2.pages.Userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                           <div class="col">
                            <center><img width="150px" src="../imgs/generaluser.png" /></center>
                           </div>
                        </div>
                          <div class="row">
                           <div class="col">
                            <center><h3>Member Login</h3></center>
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                            <hr />
                           </div>
                        </div>
                       <div class="row">
                           <div class="col">
                            <div class="form-group">
                                <label>User ID</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                                <br />
                                <label>Password
                                </label>
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                               <div class="form-group">
                                   <asp:Button  class="btn btn-success btn-block" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                               </div>
                              <div class="form-group">
                                 <a style="text-decoration:none" href="Usersignup.aspx">
                                     <asp:Button  class="btn btn-danger btn-block" ID="Button3" runat="server" Text="Signup" OnClick="Button3_Click" />
                              </a>
                                     </div>
                           </div>
                        </div>
      <a href="Homepage.aspx"><< Back to Home Page</a>
                    </div>

                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
