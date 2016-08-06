$(function(){
	$(".workList").carouFredSel({
					direction: 'right',
					prev: '#case_progress_prev',
					next: '#case_progress_next',
					circular: true,
					infinite: true,
					items: {
						visible:1,
						minimum:1
					},
					align: false,
					auto: {
						play: true,
						timeoutDuration: 1500
					},
					scroll:{
						items:1,
						pauseOnHover: true
					}
	});


});