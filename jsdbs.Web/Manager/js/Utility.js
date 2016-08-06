    function $(o) { return document.getElementById(o); }

    //keydown事件
    function entryToTab()
    {
       var sTagName = event.srcElement.tagName.toLowerCase(); 
       if   (window.event.keyCode==13 && sTagName != 'textarea')   window.event.keyCode=9 ;  //Tab键
    }
    
    function checkDate(val)
    {
        if(val.trim()=="")
          return false;
          //年月日正则表达式
         var r=val.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/); 
         if(r==null)
         {
            return false;
         }
          var d=new Date(r[1],r[3]-1,r[4]);   
          var num = (d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]);
          return (num!=0);
    } 
    
     function checkNumber()
    {
        if((event.keyCode>=48)&&(event.keyCode <=57))
         {
            event.returnValue=true;
         }
         else
         {
            event.returnValue=false;
         }
    }
    
    //keypress
    function checkDouble(obj)
    {
        if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) 
        {
            if(event.keyCode==46)
            {
                if(obj.value.indexOf('.')>=0||obj.value=="")
                event.returnValue=false;
            }
            else
                event.returnValue=true;
        }
        else
        {
            event.returnValue=false;
        }
    }
    //keyup
    function checkCN(obj)
    {
		obj.value.replace(/[^\d\.]+?/g,'');
    }
 
    //前后空格
    String.prototype.trim = function() 
    { 
    return this.replace(/(^\s*)|(\s*$)/g, ""); 
    } 
    //前空格
    String.prototype.ltrim = function() 
    { 
    return this.replace(/(^\s*)/g, ""); 
    } 
    //后空格
    String.prototype.rtrim = function() 
    { 
    return this.replace(/(\s*$)/g, ""); 
    } 
    
     var reg=/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
     
     function chkEmail(email)
     {
        return reg.test(email);
     }
     
     var regmobile=/^(13[0-9]|15[^4]|18[6|8|9])\d{8}$/;
     var regphone=/^((0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;

     
     function chkPhone(phone)//电话
     {
		return regphone.test(phone);
     }
     function chkMobile(mobile)//手机
     {
		return regmobile.test(mobile);
     }
     
      function showmodal(url,width,height)
　    {
            var szFeatures = 'dialogWidth:'+width+';dialogHeight:'+height+';center:yes;help:no;resizable:yes;status:no;scroll:yes;';
　          var str=window.showModalDialog(url,'',szFeatures);
　          return str;
      }



      function createxmlhttp()//创建xmlhttp对象;
      {
          var xmlhttp = false;
          try {
              xmlhttp = new ActiveXObject("Msxml12.XMLHTTP");
          }
          catch (e) {
              try {
                  xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
              }
              catch (e) {
                  //xmlhttp=new XMLHttpRequest();
                  xmlhttp = false;
              }
          }
          if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
              xmlhttp = new XMLHttpRequest();
              if (xmlhttp.overrideMimeType) {
                  xmlhttp.overrideMimeType('text/xml'); //是指MIME类别;
              }
          }
          return xmlhttp;
      }
   
