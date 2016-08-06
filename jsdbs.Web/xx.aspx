<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xx.aspx.cs" Inherits="jsbestop.Web.xx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>豫味一品</title>
<script type="text/javascript" src="js/jquery-1.7.2.js" ></script>
<script src="js/jquery.kinMaxShow-1.0.min.js" type="text/javascript"></script>
<script type="text/javascript" src="js/common.js" ></script>
<link href="css/my.css" rel="stylesheet" />
<script type="text/javascript">
    $(function () {
        $("#kinMaxShow").kinMaxShow({
            height: 764,
            button: {
                switchEvent: 'mouseover',
                showIndex: false,
                normal: { display: 'none', background: '#bd2911 no-repeat 0px 0', marginRight: '10px', border: '0px solid #e1dbda', right: '45%', bottom: '10px', width: '40px', height: '10px' },
                focus: { background: '#f39789 no-repeat 0 -15px', border: '0px solid #e1dbda' }
            }
        });
    });
</script>
<script type="text/javascript">
    $(function () {
        $('.rightTop2 a').hover(function () {
            //以下代码由hover驱动/触发
            var nums = $(this).index();
            $(this).addClass('selected');
            $(this).siblings('a').removeClass('selected');
            $(".xk:eq(" + nums + ")").show().siblings('.xk').hide();

        })
    })
</script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="header">
    <div class="top">
        <div class="nav">
            <ul>
                <li style="margin: 36px 0 0 0;" class="cur"><a href="index.html"><span>首页</span></a></li>
                <li style="margin:24px 0 0 0;" ><a href="关于我们.html" ><span>公司简介</span></a></li>
                <li style="margin:12px 0 0 0;"><a href="我的作品.html" ><span>加盟中心</span></a></li>
                <li><a href="陶艺文萃.html" ><span>荣誉资质</span></a></li>
                <li></li>
                <li><a href="艺术会馆.html" ><span>新闻中心</span></a></li>
                <li style="margin:12px 0 0 0;"><a href="艺术生活.html" ><span>美食展示</span></a></li>
                <li style="margin:24px 0 0 0;"><a href="壶友留言.html" ><span>店面展示</span></a></li>
                <li style="margin: 36px 0 0 0;"><a href="联系我们.html" ><span>联系我们</span></a></li>
            </ul>
        
        </div>
    </div>
</div>
<div class="content">
    <!--banner需要做成能替换的--> 
    <div class="mainQH">
		<div id="kinMaxShow">    
				<div><img src="images/banner.jpg"/></div>    
        </div>
    </div>
    <div class="qioge">
        <div class="qiogeDiv">
            <div class="in_com">无锡豫味一品餐饮管理有限公司，创建于2010年，位于无锡市中山路与人民路交叉口。该公司以快餐的形式推出的"砂锅土豆粉"、
            "黄焖鸡米饭"品 牌，一经上市就受到广大顾客的好评，慕名而至堪称一绝，在短期时间内以诚信创新的经营理念及独特的管理制度而迅速成长，如今旗
            下加盟店遍布河南，江苏，上 海，广东，山东等省，开创了“以风味形成品牌”名吃为特色的加盟连锁之路。</div>
            <div class="scrollleft2">
                    <ul class="">
                       <li> 
                               <a href="">
                               <img src="images/pc.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc.jpg" />
                               </a>
                       </li>
                    </ul>
            </div>
            <div class="sp">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="770" height="443">
                  <param name="movie" value="http://player.youku.com/player.php/sid/XMTM3NjMxOTA4/v.swf" />
                  <param name="quality" value="high" />
                  <param name="allowFullScreen" value="true" />
                  <embed src="http://player.youku.com/player.php/sid/XMTM3NjMxOTA4/v.swf" allowfullscreen="true"  quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="770" height="443"></embed>
                </object>
            </div>
            <div class="scrollleft">
                    <ul class="">
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                    </ul>
            </div>
        </div>
        
    </div>
    <div class="tc">
        <div class="in_tc">
            <img src="images/tcy.png" />
            <ul>
                <li class="l1"><p>A套餐5800元</p>可以学习目前火爆的重庆特色系列(麻辣小面．凉面．红烧牛肉面．红烧肥肠面．红烧排骨面．清汤猪手面．炸酱面等)可以不加盟自由开店，公司提供调料。</li>
                <li class="l2" style="width: 200px;"><p>B套餐8800元</p>可以学习(凉皮．米线．粉丝．热干面．茄汁面．肉夹馍．黄焖鸡米饭．土豆粉系列．火爆龙虾等)可以不加盟，自由开店，公司提供调料。</li>
                <li class="l3"><p>C套餐30000元</p>30000元含5000保证金，每年有5000元品牌使用费，加盟豫味一品，店面统一装修，统一管理。公司所研发新品合同期内全部免费学习。</li>
            </ul>
        </div>
    
    </div>
    <div class="bz">
        <div class="bzaLL">
            <div class="rightTop2">
                    <a href="#" class="x1 selected"><img src="images/a.png" />县 级</a>
                    <a href="#" class="x2" style="margin: 0 30px;"><img src="images/b.png" />市 级</a>
                    <a href="#" class="x3"><img src="images/c.png" />省会及直辖市</a>
            </div>
            <div class="x_table">
                <div class="xk bg1" style="display: block;">
                       <ul>
                            <li>县级</li>
                            <li>2000/年</li>
                            <li style="height: 65px;">新加盟2.5万，老加盟1.5万</li>
                            <li>3000/年</li>
                            <li style="height: 70px;">0.5万</li>
                            <li style="height: 65px;">100元/平米</li>
                            <li>约1000元/平米（参考价）</li>
                            <li style="height: 71px;">1万</li>
                            <li style="height: 65px;">500-2000元（视距离远近而定）</li>
                            <li>2万左右</li>
                            <li style="height: 67px;">3万左右(后厨、收银、监控）</li>
                            <li style="height: 65px;">0.5-1万左右</li>
                            <li>50平米15万、80平米20万<a href="">+更多详情</a></li>
                       
                       </ul>
                       <img src="images/mk.jpg" class="mk" />
                </div>
                <div class="xk bg2" style="display: none;">
                        <ul>
                            <li>市 级</li>
                            <li>2000/年</li>
                            <li style="height: 65px;">新加盟2.5万，老加盟1.5万</li>
                            <li>3000/年</li>
                            <li style="height: 70px;">0.5万</li>
                            <li style="height: 65px;">100元/平米</li>
                            <li>约1000元/平米（参考价）</li>
                            <li style="height: 71px;">1万</li>
                            <li style="height: 65px;">500-2000元（视距离远近而定）</li>
                            <li>2万左右</li>
                            <li style="height: 67px;">3万左右(后厨、收银、监控）</li>
                            <li style="height: 65px;">0.5-1万左右</li>
                            <li>50平米15万、80平米20万<a href="">+更多详情</a></li>
                       
                       </ul>
                       <img src="images/mk.jpg" class="mk" />
                </div>
                <div class="xk bg3"  style="display: none;">
                        <ul>
                            <li>省会及直辖市</li>
                            <li>2000/年</li>
                            <li style="height: 65px;">新加盟2.5万，老加盟1.5万</li>
                            <li>3000/年</li>
                            <li style="height: 70px;">0.5万</li>
                            <li style="height: 65px;">100元/平米</li>
                            <li>约1000元/平米（参考价）</li>
                            <li style="height: 71px;">1万</li>
                            <li style="height: 65px;">500-2000元（视距离远近而定）</li>
                            <li>2万左右</li>
                            <li style="height: 67px;">3万左右(后厨、收银、监控）</li>
                            <li style="height: 65px;">0.5-1万左右</li>
                            <li>50平米15万、80平米20万<a href="">+更多详情</a></li>
                       
                       </ul>
                       <img src="images/mk.jpg" class="mk" />
                </div>
            </div>
        </div>
    </div>
    <div class="sc">
        <div class="scAll">
            <div class="in_lan">员工风采</div>
            <div class="scrollleft3">
                    <ul class="">
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc2.jpg" />
                               </a>
                       </li>
                    </ul>
            </div>
            <div class="in_lan" style="margin: 35px 0 0 0;">合作伙伴</div>
            <div class="scrollleft4">
                    <ul class="">
                       <li> 
                               <a href="">
                               <img src="images/pc4.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc4.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc4.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc4.jpg" />
                               </a>
                       </li>
                       <li> 
                               <a href="">
                               <img src="images/pc4.jpg" />
                               </a>
                       </li>
                    </ul>
            </div>
        </div>
    
    </div>
    <div class="in_b_Top">
        <img src="images/lyzi.jpg" class="lyzi"/>
    </div>
    <div class="mesBGAll">
        <div class="mesBG">
            <div class="nyMainCC">
					&#12288;&#12288;<table width="90%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                    <tr>
                        <td align="right" width="150">
                            姓名：
                        </td>
                        <td height="30">
                            <input type="text" style="border-width:1px;border-style:solid;height:22px;" id="ContentPlaceHolder1_txtMesName" name="ctl00$ContentPlaceHolder1$txtMesName"><span style="color: #cf0000;">&nbsp;&nbsp;*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            手机：
                        </td>
                        <td height="30">
                            <input type="text" style="border-width:1px;border-style:solid;height:22px;" id="ContentPlaceHolder1_txtMesPhone" name="ctl00$ContentPlaceHolder1$txtMesPhone"><span style="color: #cf0000;">&nbsp;&nbsp;*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            地址：
                        </td>
                        <td height="30">
                            <input type="text" style="border-width:1px;border-style:solid;height:22px;" id="ContentPlaceHolder1_txtEmail" name="ctl00$ContentPlaceHolder1$txtEmail"><span style="color: #cf0000;">&nbsp;&nbsp;*</span>
                        </td>
                    </tr>
                    <tr >
                        <td align="right">
                            留言：
                        </td>
                        <td>
                            <textarea style="border-width:1px;border-style:solid;height:130px;width:260px;" id="ContentPlaceHolder1_txtMesContent" cols="20" rows="2" name="ctl00$ContentPlaceHolder1$txtMesContent"></textarea><span style="color: #cf0000;display: none;">&nbsp;&nbsp;*</span>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td height="30" align="left">
                            <input type="image" src="images/CCbutton.jpg" id="ContentPlaceHolder1_ImageButton1" name="ctl00$ContentPlaceHolder1$ImageButton1">
                        </td>
                    </tr>
                </tbody></table>
            </div>
            <div class="scrollleft5all">
                <div class="scrollleft5">
                        <ul class="">
                           <li> 
                                   <img src="images/man.jpg" />
                                   <p>陈女士</p>
                                    <div>有意加盟！汪汪汪！！</div>
                           </li>
                           <li> 
                                   <img src="images/woman.jpg" />
                                   <p>陈先生</p>
                                    <div>有意加盟！汪汪汪！！</div>
                           </li>
                           <li> 
                                   <img src="images/man.jpg" />
                                   <p>陈女士</p>
                                    <div>有意加盟！汪汪汪！！</div>
                           </li>
                           <li> 
                                   <img src="images/woman.jpg" />
                                   <p>陈先生</p>
                                    <div>有意加盟！汪汪汪！！</div>
                           </li>
                           <li> 
                                   <img src="images/man.jpg" />
                                   <p>陈女士</p>
                                    <div>有意加盟！汪汪汪！！</div>
                           </li>
                           <li> 
                                   <img src="images/woman.jpg" />
                                   <p>陈先生</p>
                                    <div>有意加盟！汪汪汪！！</div>
                           </li>
                        </ul>
                </div>
            </div>
        </div>
    </div>
</div>
    
<div class="footer">
  <div class="footerAll">
        <span class="fl">
        版权所有 ：无锡豫味一品餐饮管理有限公司
        </span>
        <span class="fr"><a href="http://jsbestop.com/">技术支持：江苏百拓</a></span>
  </div>
</div>
<script type="text/javascript">
    //图片滚动 调用方法 imgscroll({speed: 30,amount: 1,dir: "up"});
    $.fn.imgscroll = function (o) {
        var defaults = {
            speed: 40,
            amount: 0,
            width: 1,
            dir: "left"
        };
        o = $.extend(defaults, o);

        return this.each(function () {
            var _li = $("li", this);
            _li.parent().parent().css({ overflow: "hidden", position: "relative" }); //div
            _li.parent().css({ margin: "0", padding: "0", overflow: "hidden", position: "relative", "list-style": "none" }); //ul
            _li.css({ position: "relative", overflow: "hidden" }); //li
            if (o.dir == "left") _li.css({ float: "left" });

            //初始大小
            var _li_size = 0;
            for (var i = 0; i < _li.size(); i++)
                _li_size += o.dir == "left" ? _li.eq(i).outerWidth(true) : _li.eq(i).outerHeight(true);

            //循环所需要的元素
            if (o.dir == "left") _li.parent().css({ width: (_li_size * 3) + "px" });
            _li.parent().empty().append(_li.clone()).append(_li.clone()).append(_li.clone());
            _li = $("li", this);

            //滚动
            var _li_scroll = 0;
            function goto() {
                _li_scroll += o.width;
                if (_li_scroll > _li_size) {
                    _li_scroll = 0;
                    _li.parent().css(o.dir == "left" ? { left: -_li_scroll} : { top: -_li_scroll });
                    _li_scroll += o.width;
                }
                _li.parent().animate(o.dir == "left" ? { left: -_li_scroll} : { top: -_li_scroll }, o.amount);
            }

            //开始
            var move = setInterval(function () { goto(); }, o.speed);
            _li.parent().hover(function () {
                clearInterval(move);
            }, function () {
                clearInterval(move);
                move = setInterval(function () { goto(); }, o.speed);
            });
        });
    };
    $(document).ready(function () {

        $(".scrollleft").imgscroll({
            speed: 2000,    //图片滚动速度
            amount: 500,    //图片滚动过渡时间
            width: 249,     //图片滚动步数
            dir: "left"   // "left" 或 "up" 向左或向上滚动
        });
        $(".scrollleft2").imgscroll({
            speed: 2000,    //图片滚动速度
            amount: 500,    //图片滚动过渡时间
            width: 331,     //图片滚动步数
            dir: "left"   // "left" 或 "up" 向左或向上滚动
        });
        $(".scrollleft3").imgscroll({
            speed: 2000,    //图片滚动速度
            amount: 500,    //图片滚动过渡时间
            width: 251,     //图片滚动步数
            dir: "left"   // "left" 或 "up" 向左或向上滚动
        });
        $(".scrollleft4").imgscroll({
            speed: 10,    //图片滚动速度
            amount: 1,    //图片滚动过渡时间
            width: 1,     //图片滚动步数
            dir: "left"   // "left" 或 "up" 向左或向上滚动
        });
        $(".scrollleft5").imgscroll({
            speed: 20,    //图片滚动速度
            amount: 1,    //图片滚动过渡时间
            width: 1,     //图片滚动步数
            dir: "up"   // "left" 或 "up" 向左或向上滚动
        });
    });
</script>
    </form>
</body>
</html>
