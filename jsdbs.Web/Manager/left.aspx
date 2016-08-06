<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="jsbestop.Web.Manager.left" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
            font-family: "宋体";
        }
        #navigation
        {
            margin: 0px;
            padding: 0px;
            width: 147px;
        }
        #navigation a.head
        {
            cursor: pointer;
            background: url(images/main_34.gif) no-repeat scroll;
            display: block;
            font-weight: bold;
            margin: 0px;
            padding: 5px 0 5px;
            text-align: center;
            font-size: 12px;
            text-decoration: none;
        }
        #navigation ul
        {
            border-width: 0px;
            margin: 0px;
            padding: 0px;
            text-indent: 0px;
        }
        #navigation li
        {
            list-style: none;
            display: inline;
        }
        #navigation li li a
        {
            display: block;
            font-size: 12px;
            text-decoration: none;
            text-align: center;
            padding: 3px;
            color: #666;
        }
        #navigation li li a:hover
        {
            background: url(images/tab_bg.gif) repeat-x;
            border: solid 1px #adb9c2;
            color: #0033ff;
        }
        
        #navigation li li a.selmenu
        {
            display: block;
            font-size: 12px;
            text-decoration: none;
            text-align: center;
            padding: 3px;
            color: #006600;
            background: url(images/tab_bg.gif) repeat-x;
        }
        #navigation li li a.selmenu:hover
        {
            background: url(images/tab_bg.gif) repeat-x;
            border: solid 1px #adb9c2;
            color: #006600;
        }
        .houtai_left_dibu
        {
            background-image: url(images/houtaibg.jpg);
            background-repeat: no-repeat;
            background-position: center bottom;
            float: left;
            width: 147px;
        }
        .houtai_left_contact
        {
            padding-right: 2px;
            padding-left: 2px;
        }
        .STYLE2
        {
            font-size: 12px;
            line-height: 20px;
            color: #666666;
        }
        
        .nava
        {
            color: #666;
            text-decoration: none;
        }
    </style>
    <script type="text/javascript">

        function ShowDiv(id) {
            var oDisplay = document.getElementById(id).style.display;
            if (oDisplay == 'none') document.getElementById(id).style.display = 'block';
            else document.getElementById(id).style.display = 'none';
        }
        function setLink(obj) {

            var objs = document.getElementsByTagName("A");
            for (var i = 0; i < objs.length; i++) {
                if (objs[i].className != "head" && objs[i].className != "nava")
                    objs[i].className = "a";
            }
            obj.className = "selmenu";
        }
    </script>
</head>
<body>
    <div style="height: 100%;">
        <ul id="navigation">
            <li><a class="head" onclick="JavaScript:ShowDiv('ul1');">公司信息</a>
                <ul id="ul1" style="display: none;">
                    <li><a href="CpInformationManager/CompanyInformationTypeList.aspx" target="rightFrame"
                        onclick="javascript:setLink(this);">公司信息类别列表</a></li>
                    <li><a href="CpInformationManager/CompanyInformationList.aspx" target="rightFrame"
                        onclick="javascript:setLink(this);">公司信息列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul2');">新闻信息</a>
                <ul id="ul2" style="display: none;">
                    <li><a href="NewsManager/cpNewsTypeList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        新闻类别列表</a></li>
                    <li><a href="NewsManager/cpNewsList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        新闻列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul8');">产品展示</a>
                <ul id="ul8" style="display: none;">
                    <li><a href="ProductManager/cpProductTypeList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        产品展示类别列表</a></li>
                    <li><a href="ProductManager/cpProductSecondTypeList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        产品展示二级类别列表</a></li>
                    <li><a href="ProductManager/cpProductList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        产品展示明细列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul5');">合作伙伴信息</a>
                <ul id="ul5" style="display: none;">
                    <li><a href="SuccessStoriesManager/cpSuccessStoriesTypeList.aspx" target="rightFrame"
                        onclick="javascript:setLink(this);">合作伙伴类别列表</a></li>
                    <li><a href="SuccessStoriesManager/cpSuccessStoriesList.aspx" target="rightFrame"
                        onclick="javascript:setLink(this);">合作伙伴列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul3');">招聘信息</a>
                <ul id="ul3" style="display: none;">
                    <li><a href="JobManager/cpJobTypeList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        岗位类别列表</a></li>
                    <li><a href="JobManager/cpJobList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        招聘信息列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul6');">下载文件管理</a>
                <ul id="ul6" style="display: none;">
                    <li><a href="DownLoadManager/cpDownLoadList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        下载文件列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul9');">Banner设置</a>
                <ul id="ul9" style="display: none;">
                    <li><a href="BannerManager/cpComBannerTypeList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        Banner类别列表</a></li>
                    <li><a href="BannerManager/cpBannerSet.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        Banner列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul4');">留言信息</a>
                <ul id="ul4" style="display: none;">
                    <li><a href="MessageManager/cpMessageList.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        留言列表</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('ul7');">联系方式</a>
                <ul id="ul7" style="display: none;">
                    <li><a href="AddressManager/cpAddress.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        联系方式详细</a></li>
                </ul>
            </li>
            <li><a class="head" onclick="JavaScript:ShowDiv('menu3');">系统管理</a>
                <ul id="menu3" style="display: none;">
                    <li><a href="SysManager/wfAdminUser.aspx" target="rightFrame" onclick="javascript:setLink(this);">
                        管理员</a></li>
                </ul>
            </li>
        </ul>
    </div>
</body>
</html>
