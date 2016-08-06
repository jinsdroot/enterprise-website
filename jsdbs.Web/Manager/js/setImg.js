function setImg(o)
{
var width_img;
var height_img;

o.style.visibility = "visible";
width_img=o.offsetWidth;
height_img=o.offsetHeight;

var width=120;   //预定义宽
var height=80;  //预定义高


var ratW;        //宽的缩小比例
var ratH;        //高的缩小比例
var rat;         //实际使用的缩小比例
if(width_img<width && height_img<height)
{
    //如果比预定义的宽高小，原图显示。
    o.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").sizingMethod = "image";
    return;

    
}else{
    //如果大的化，要把 sizingMethod改成scale 如果属性是image,不管怎么改div的宽高，都不起作用
    o.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").sizingMethod = "scale";

}
ratH=height/height_img;
ratW=width/width_img;
if(ratH<ratW)       //选择最小的作为实际的缩小比例
    rat=ratH;
else
    rat=ratW;
    
width_img=width_img * rat;
height_img=height_img * rat;
o.style.width=width_img;
o.style.height=height_img;
}
