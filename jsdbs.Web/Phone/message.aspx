<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="message.aspx.cs" Inherits="jsbestop.Web.Phone.message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
                    <div class="nyMainMessage">
                        <span>*您的真实姓名</span>联系人：</div>
                    <div>
                        <input name="" class="txtInput1" type="text" id="contactor" runat="server" /></div>
                    <div class="nyMainMessage">
                        联系地址：</div>
                    <div>
                        <input name="" class="txtInput1" type="text" id="lblAddress" runat="server" /></div>
                    <div class="nyMainMessage">
                        <span>*</span>联系电话：</div>
                    <div>
                        <input name="" class="txtInput1" type="text" id="phonenumber" runat="server" /></div>
                    <div class="nyMainMessage">
                        电子邮箱：</div>
                    <div>
                        <input name="" class="txtInput1" type="text" id="email" runat="server" /></div>
                    <div class="nyMainMessage">
                        <span>*</span>留言内容：</div>
                    <div>
                        <textarea name="" class="txtInput1" cols="50" rows="10" style="height: 130px;" id="messageContent"
                            runat="server"></textarea></div>
                    <div class="btnTJ">
                        <asp:Button ID="Button1" type="submit" Text="确定" runat="server" class="btnInput"
                            OnClick="Unnamed1_Click" /></div>
                
            
        <div class="clear">
        </div>
  </div>
</asp:Content>
