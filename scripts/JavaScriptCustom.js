$(document).ready(function () {
    //kiểm tra độ rộng responsive menu
    $(window).resize(function () {
        if ($(window).width() > 992) {
            $('#menu-responsive').css("display", "none");
            $('#TT > a').css("display", "block")
        }
    });
    $(window).resize(function () {
        if ($(window).width() > 769) {
            $('#TT > a').css("display", "block")
            $('#TG > a').css("display", "block")
            $('#HT > a').css("display", "block")

        }
        else {
            $('#TT > a').css("display", "none")
            $('#TG > a').css("display", "none")
            $('#HT > a').css("display", "none")
        }
    });
    //tắt mở thanh menu
    $("#btn-Menu").click(function () {
        if ($('#menu-responsive').is(":hidden") == true) {
            $('#menu-responsive').css("display", "block");
        }
        else {
            $('#menu-responsive').css("display", "none");
        }

    });
    $('#menu-plus').click(function () {
        if ($('#menu-plus > div').is(':hidden') == true) {
            $('#menu-plus > div').css("display", "block");
        }
        else {
            $('#menu-plus > div').css("display", "none");
        }
    });
    $('#menu-plus2').click(function () {
        if ($('#menu-plus2 > div').is(':hidden') == true) {
            $('#menu-plus2 > div').css("display", "block");
        }
        else {
            $('#menu-plus2 > div').css("display", "none");
        }
    });
    //tăt mở menu footer
    $('#TT').click(function () {

        if ($('#TT > a').is(':hidden') == true && $(window).width() < 769) {
            $('#TT > a').css("display", "block")
        }
        else if ($(window).width() < 769) {
            $('#TT > a').css("display", "none")
        }
    });
    $('#TG').click(function () {
        if ($('#TG > a').is(':hidden') == true && $(document).width() < 769) {
            $('#TG > a').css("display", "block")
        }
        else if ($(window).width() < 769) {
            $('#TG > a').css("display", "none")
        }
    });
    $('#HT').click(function () {
        if ($('#HT > a').is(':hidden') == true && $(window).width() < 769) {
            $('#HT > a').css("display", "block")
        }
        else if ($(window).width() < 769) {
            $('#HT > a').css("display", "none")
        }
    });
    $('#Tab-R').click(function () {
        if ($('.Tab-Review').is(":hidden") == true) {
            $('.Tab-Review').css("display", "block")
            $('#Tab-R').css({ "background-color": "#fff", "padding-bottom": "13px" })
            $('.Tab-Description').css("display", "none");
            $('#Tab-L').css({ "background-color": "#eee", "padding-bottom": "11px" })
        }
    });
    $('#Tab-L').click(function () {
        if ($('.Tab-Description').is(":hidden") == true) {
            $('.Tab-Description').css("display", "block")
            $('#Tab-L').css({ "background-color": "#fff", "padding-bottom": "13px" })
            $('.Tab-Review').css("display", "none");
            $('#Tab-R').css({ "background-color": "#eee", "padding-bottom": "11px" })
        }
    });
    var Rating;
    Star = function (s) {
        Rating = s
    }
    $('#subRating').click(function () {

        var MS = $('#MaSach').val();
        var Ngay = $('#Ngay').val();
        var name = $('#txt-frmRating').val();
        var BL = $('#erea-frmRating').val();
        var Rating1 = Rating;
        $.ajax({

            url: "/ViewSach/ChiTietSach",
            data: { iMaSach: MS, iName: name, iComment: BL, Ngay: Ngay, iRating: Rating },
            type: "POST",
            success: function (data) {
                $('.new-Cmt .author > b').append(name);
                $('.new-Cmt .author > span').append(Ngay);
                if (Rating == 1) {
                    $('.new-Cmt .rating-review').append("<i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star' aria-hidden='true'></i><i class='fa fa-star' aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i>")
                }
                else if (Rating == 2) {
                    $('.new-Cmt .rating-review').append("<i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star 'aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i>")
                }
                else if (Rating == 3) {
                    $('.new-Cmt .rating-review').append("<i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star'aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i>")
                }
                else if (Rating == 4) {
                    $('.new-Cmt .rating-review').append("<i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star'aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star ' aria-hidden='true'></i>")
                }
                else if (Rating == 5) {
                    $('.new-Cmt .rating-review').append("<i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star'aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i><i class='fa fa-star star' aria-hidden='true'></i>")
                }
                $(".new-Cmt .text-review").append(BL)
                $(".new-Cmt").css("display", "block");
            }
        });
        return false;
    });

});
// cong trừ số lượng giỏ hàng
var SL = 1;
function Tru() {
    SL = document.getElementById("txtSL").value;
    if (isNaN(SL) == true) {
        SL = 1;
    }
    SL--;
    if (SL < 1) {
        SL = 1;
    }
    document.getElementById("txtSL").value = SL;
};
function Cong() {
    SL = document.getElementById("txtSL").value;
    if (isNaN(SL) == true) {
        SL = 0;
    }
    SL++;
    document.getElementById("txtSL").value = SL;
};