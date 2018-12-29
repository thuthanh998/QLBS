$(document).ready(function () {
    var SlideIndex = 0;
    autoSlide();
    function autoSlide() {
        var i;
        var x = $('.SlidesImg');
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "none";
        }
        SlideIndex++;
        if (SlideIndex > x.length) {
            SlideIndex = 1;
        }
        x[SlideIndex - 1].style.display = "block";
        setTimeout(autoSlide, 5000);
        
    }
    
    ShowSlide(SlideIndex)
    $('#btn-L').click(function pre() {
        ShowSlide( SlideIndex -= 1);
    });
    $('#btn-R').click(function next() {
        ShowSlide(SlideIndex += 1);
    });
    function ShowSlide( n){
        var i;
        var x = $('.SlidesImg');
        if (n > x.length) { SlideIndex = 1 }
        if (n < 1) { SlideIndex = x.length }
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "none";
        }
        x[SlideIndex - 1].style.display = "block";
        
    }
    
    
    function hv1() {
        $('#btn-L').css("display", "block")
        $('#btn-R').css("display", "block")}

    function hv2() {
    $('#btn-L').css("display", "none")
    $('#btn-R').css("display", "none")}

    $(".mySlide > div").hover(hv1,hv2);
});