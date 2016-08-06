$(function(){
	$(".new_food:eq(0)").show();
	$(".new_f img").click(function(){
		$(this).addClass("on").siblings("img").removeClass("on");
		var f_num = $(this).index();
		$(".new_food:eq("+f_num+")").show().siblings(".new_food").hide();
	})
})