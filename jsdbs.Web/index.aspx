<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs"
    Inherits="jsbestop.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>零点起步</title>
    <script type="text/javascript" src="js/jquery-1.7.2.js"></script>
    <script src="js/jquery.kinMaxShow-1.0.min.js" type="text/javascript"></script>
    <script src="js/jquery.carouFredSel-5.2.3.js" type="text/javascript"></script>
    <script src="js/index.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/common.js"></script>
    <link href="css/common.css" rel="stylesheet" />
    <link href="css/my.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("#kinMaxShow").kinMaxShow({
                height: 406,
                button: {
                    switchEvent: 'mouseover',
                    showIndex: false,
                    normal: { display: "none", background: 'url(images/quan1.png) no-repeat 0px 0', marginRight: '5px', border: '0', right: '48%', bottom: '20px', width: '19px', height: '17px' },
                    focus: { background: 'url(images/quan2.png) no-repeat 0 0px', border: '0', width: '19px', height: '20px' }
                }
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <div class="top">
            <img src="images/logo.jpg" class="logo" />
            <div class="topC1">
                <div class="join">
                    <a href="javascript:window.external.addFavorite('<%=website %>','<%=name %>');" class="homeico">
                    </a><a href="#" class="syico" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('<%=website %>');">
                    </a>
                </div>
                
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="navwai">
            <div class="nav">
                <ul class="">
                    <li><a href="index.aspx">网站首页</a></li>
                    <li><a href="about.aspx?type=5">公司介绍</a></li>
                    <li><a href="ProductList.aspx">产品展示</a></li>
                    <li><a href="news.aspx">新闻中心 </a></li>
                    <li><a href="case.aspx?type=14">成功案例 </a></li>
                    <li><a href="case.aspx?type=15">生产设备 </a></li>
                    <li><a href="message.aspx">在线留言 </a></li>
                    <li><a href="about.aspx?type=44">联系我们 </a></li>
                </ul>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="content">
        <div class="mainQH">
            <div id="kinMaxShow">
                <asp:Repeater ID="rptBanner" runat="server">
                    <ItemTemplate>
                        <div>
                            <img src="<%#Eval("BannerPic")%>" /></div>
                    </ItemTemplate>
                </asp:Repeater>
     
            </div>
        </div>
        <div class="mainall">
            <div class="left">
                <div class="leftDIVALL">
                    <div class="leftDIV">
                        <div class="leftDIVTop">
                            产品列表<span>/ LIST<span></div>
                        <ul>
                            <asp:Repeater ID="rptProType" runat="server">
                                <ItemTemplate>
                                    <li><a href="ProductList.aspx?type=<%#Eval("id")%>"><span>
                                        <%#GetStrByByteLength(Eval("ProductTypeName").ToString(), 30, true)%></span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                </div>
                <img src="images/leftbottom.jpg" style="display: block;" />
                <div class="chaTop">
                    成功案例 <a href="case.aspx?type=14" class="more"></a>
                </div>
                <ul class="alul">
                    <asp:Repeater ID="chenggong" runat="server">
                        <ItemTemplate>
                            <li><a href="caseDetail.aspx?id=<%#Eval("id")%>&type=<%#Eval("SSType") %>">
                                <img src="<%# Convert.ToString(Eval("SSPic"))%>"><p>
                                    <%#GetStrByByteLength(Eval("SSName").ToString(), 30, true)%></p>
                            </a>&nbsp;</li>
                        </ItemTemplate>
                    </asp:Repeater>
  
                </ul>
                <div class="qywhTop">
                    企业文化 <a href="about.aspx?type=62" class="more"></a>
                </div>
                <div class="qywhTopDiv">
                    <ul>
        
                        <li>
                            <img src="images/tx.jpg" />
                            毕业季愿景：<br />
                            再见
                            <div class="clear">
                            </div>
                        </li>
                        <li>
                            <img src="images/tx2.jpg" />
                            毕业季愿景：<br />
                            回忆
                            <div class="clear">
                            </div>
                        </li>
                        <li>
                            <img src="images/01.png" />
                            毕业季愿景：<br />
                            想念
                            <div class="clear">
                            </div>
                        </li>
                        <li>
                            <img src="images/02.png" />
                            毕业季愿景：<br />
                            再见
                            <div class="clear">
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="right">
                <div class="rightL">
                    <div class="rightLTop">
                        &nbsp;<span class="rl1">公司</span><span class="rl2">介绍</span>&nbsp;/ ABOUT US <a href="about.aspx?type=5">
                        </a>
                    </div>
                    <img src="images/ds.jpg" class="ds" />
                    <asp:Literal ID="companyintroduce" runat="server"></asp:Literal>
                    <div class="clear">
                    </div>
                    <div class="rightLTop">
                        &nbsp;<span class="rl1">产品</span><span class="rl2">展示</span>&nbsp;/ PRODUCT <a href="ProductList.aspx">
                        </a>
                    </div>
                    <ul class="in_pro">
                        <asp:Repeater ID="rptProduct" runat="server">
                            <ItemTemplate>
                                <li><a href="ProductListDetail.aspx?id=<%#Eval("id")%>">
                                    <img src="<%#Eval("ProductPic")%>" />
                                    <p>
                                        <%#GetStrByByteLength(Eval("ProductName").ToString(), 10, true)%></p>
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="rightLTop">
                        &nbsp;<span class="rl1">公司</span><span class="rl2">新闻</span>&nbsp;/ NEWS <a href="news.aspx">
                        </a>
                    </div>
                    <ul class="in_news">
                        <asp:Repeater ID="rptNews" runat="server">
                            <ItemTemplate>
                                <li><a href="news_detail.aspx?id=<%#Eval("Id")%>">
                                    <div class="in_newsTop">
                                        <img src="images/book.png" />
                                        <%#GetStrByByteLength(Eval("NewsTitle").ToString(), 20, true)%><p>
                                            <%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy/MM/dd")%></p>
                                    </div>
                                </a>
                                    <%#GetStrByByteLength(Eval("NewsContent").ToString(), 60, true)%>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                      
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <div class="rightR">
                    <div class="chaTop">
                        生产设备 <a href="case.aspx?type=15" class="more"></a>
                    </div>
                    <div class="workListWrap">
                        <div class="ctrlArea">
                            <a id="case_progress_prev" class="left" href="javascript:(void)" alt="向左"></a><a
                                id="case_progress_next" class="right" href="javascript:(void)" alt="向右"></a>
                        </div>
                        <div class="workList">
                            <asp:Repeater ID="shengchan" runat="server">
                                <ItemTemplate>
                                    <span href="caseDetail.aspx?id=<%#Eval("id")%>&type=<%#Eval("SSType") %>" class="workItem">
                                        <img src="<%# Convert.ToString(Eval("SSPic"))%>">
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                          
                        </div>
                    </div>
                    <div class="qywhTop">
                        联系我们 <a href="about.aspx?type=44" class="more"></a>
                    </div>
                    <div class="lxwm">
                        <div class="lxwmDiv">
                            <h1>
                                <%=name %></h1>
                            联系人：<%=people %><br />
                            手机：<%=tel %><br />
                            电话：<%=phone %><br />
                            传真：<%=fax %><br />
                            地址：<%=address %>
                        </div>
                    </div>
                    <a href="about.aspx?type=58">
                        <img src="images/recr.jpg" /></a>
                    <div class="empty">
                    </div>
                    <a href="xiazai.aspx">
                        <img src="images/dow.jpg" /></a>
                    <div class="empty">
                    </div>
                    <a href="message.aspx">
                        <img src="images/mes.jpg" /></a>
                    <div class="empty2">
                    </div>
                    <div class="chaTop">
                        生产设备 <a href="#" class="more"></a>
                    </div>
                    <ul class="alul">
                        <asp:Repeater ID="shengchan1" runat="server">
                            <ItemTemplate>
                                <li><a href="caseDetail.aspx?id=<%#Eval("id")%>&type=<%#Eval("SSType") %>">
                                    <img src="<%# Convert.ToString(Eval("SSPic"))%>" />
                                    <p>
                                        <%# Convert.ToString(Eval("SSName"))%></p>
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
             
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="footer">
        <div class="footerall">
            <ul class="">
                <li><a href="index.aspx">网站首页</a></li>
                <li><a href="about.aspx?type=5">公司介绍</a></li>
                <li><a href="ProductList.aspx">产品展示</a></li>
                <li><a href="news.aspx">新闻中心 </a></li>
                <li><a href="case.aspx?type=14">成功案例 </a></li>
                <li><a href="case.aspx?type=15">生产设备 </a></li>
                <li><a href="message.aspx">在线留言 </a></li>
                <li><a href="about.aspx?type=44">联系我们 </a></li>
            </ul>
            <div class="clear">
            </div>
            <div class="footerBQ">
                Copyright © 2015 零点起步毕设 版权所有<br />
                <a href="#">技术支持：零点起步</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
