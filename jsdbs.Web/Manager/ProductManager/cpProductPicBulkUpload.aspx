<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpProductPicBulkUpload.aspx.cs" Inherits="jsbestop.Web.Manager.ProductManager.cpProductPicBulkUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <script type="text/javascript" src="../ImgUpload/swfobject.js" language="javascript"></script>
     <script type="text/javascript" src="../js/jquery-1.3.2.min.js"> </script>
    <script type="text/javascript" language="javascript">

        window.onload = function () {
            var id = $('#hidmenu').val();
            var params = {
                uploadServerUrl: "../ImgUpload/upload.aspx?id=" + id,     //上传响应页面(必须设置)
                jsFunction: "CallBack", 		//上传成功后回调JS
                filter: "*.jpg;*.gif;*.png"	//上传文件类型限制
            }
            swfobject.embedSWF("../ImgUpload/uploadImage.swf", "myContent", "715", "500", "10.0.0", "../ImgUpload/expressInstall.swf", params);
        }

        //回调函数，文件成功上传后，将会执行此JS脚本
        function CallBack() {
            //alert('上传成功！');
        }
    </script>
    <link href="../css/core.css" type="text/css" rel="stylesheet"/>
    <script src="../js/jquery-1.3.2.min.js" type="text/javascript" language="javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <input type="hidden"  id="hidmenu" value="" runat="server" />
                <div id="myContent">
                 </div>
            
    </div>
    </form>
</body>
</html>
