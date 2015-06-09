<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2007_lesson6.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student info</h1>

    <h5>All fields are required</h5>

    <div class="form-group">
        <label for="txtlast" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtlast" runat="server" required MaxLength="50"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtfirst" class="col-sm-3">First Name:</label>
        <asp:TextBox ID="txtfirst" runat="server" required MaxLength="50"></asp:TextBox>
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
