$(document).ready(function () {
    $('#sub-DangKy').click(function () {
        if ($('#HoTen').val() == "" || $('#Email').val() == "" || $('#SDT').val() == "" || $('#NgaySinh').val() == "" ||
            $('#DiaChi').val() == "" || $('#TenDN').val() == "" || $('#MatKhau').val() == "" || $('#LaiMK').val() == "") {
            $('#HoTen').css('border-color', '#ddd');
            $('#Email').css('border-color', '#ddd');
            $('#SDT').css('border-color', '#ddd');
            $('#NgaySinh').css('border-color', '#ddd');
            $('#DiaChi').css('border-color', '#ddd');
            $('#TenDN').css('border-color', '#ddd');
            $('#MatKhau').css('border-color', '#ddd');
            $('#LaiMK').css('border-color', '#ddd');
            if ($('#HoTen').val() == "") {
                $('#HoTen').css('border-color', '#ff0000');
            }
            if ($('#Email').val() == "") {
                $('#Email').css('border-color', '#ff0000');
            }
            if ($('#SDT').val() == "") {
                $('#SDT').css('border-color', '#ff0000');
            }
            if ($('#NgaySinh').val() == "") {
                $('#NgaySinh').css('border-color', '#ff0000');
            }
            if ($('#DiaChi').val() == "") {
                $('#DiaChi').css('border-color', '#ff0000');
            }
            if ($('#TenDN').val() == "") {
                $('#TenDN').css('border-color', '#ff0000');
            }
            if ($('#MatKhau').val() == "") {
                $('#MatKhau').css('border-color', '#ff0000');
            }
            if ($('#LaiMK').val() == "") {
                $('#LaiMK').css('border-color', '#ff0000');
            }
            $('#ThongBao').html("Vui Lòng Nhập Đầy Đủ Thông Tin!")
            return false;
        }
    });
    $('#sub-DN').click(function () {
        if ($('#TaiKhoan').val() == "" || $('#MK').val() == "") {
            $('#TaiKhoan').css('border-color', '#ddd');
            $('#MK').css('border-color', '#ddd');
            if ($('#TaiKhoan').val() == "") {
                $('#TaiKhoan').css('border-color', "red");
            }
            if ($('#MK').val() == "") {
                $('#MK').css('border-color', "red");
            }
            return false;
        }
        else {
            $('#DN-ThongBao').css('display', 'block');
        }
    });
    /*js Sửa Thông Tin*/
    $('#btn-SuaTT').click(function () {
        $('#TT-Right').css('display', 'none');
        $('#TT-Right2').css('display', 'block');
        $('#TT-Right3').css('display', 'none');
    });
    $('#btn-LuuTT').click(function () {
        var MaKH = $('#LayMKH').val();
        var HoTen = $('#HoTen').val();
        var GioiTinh = $('#GioiTinh').val();
        var Email = $('#Email').val();
        var DiaChi = $('#DiaChi').val();
        var SDT = $('#SDT').val();
        var NgaySinh = $('#NgaySinh').val();
        $.ajax({
            url: "/DKDN/CapNhatThongTin",
            data: { HoTen: HoTen, GioiTinh: GioiTinh, Email: Email, DiaChi: DiaChi, SDT: SDT, NgaySinh: NgaySinh, MaKH: MaKH },
            type: "POST",
            success: function (result) {
                alert(result)
                $('#TT-Right').css('display', 'block');
                $('#TT-Right2').css('display', 'none');
                $('#TT-Right3').css('display', 'none');
                $('#TT-HT').html(HoTen)
                $('#TT-GT').html(GioiTinh)
                $('#TT-E').html(Email)
                $('#TT-DC').html(DiaChi)
                $('#TT-DT').html(SDT)
                $('#TT-NS').html(NgaySinh)
            }
        });
    });
    /*js Đổi MK*/
    $('#btn-DoiMK').click(function () {
        $('#TT-Right').css('display', 'none');
        $('#TT-Right2').css('display', 'none');
        $('#TT-Right3').css('display', 'block');
    });
    $('#btn-LuuTT2').click(function () {
        var MaKH = $('#LayMKH').val();
        var MKCu = $('#MKCu').val();
        var MKMoi = $('#MKMoi').val();
        var LaiMKMoi = $('#LaiMKMoi').val();
        if (MKMoi == LaiMKMoi)
        {
            $.ajax({
                url: '/DKDN/CapNhatMatKhau',
                type: 'POST',
                data: { MaKH: MaKH, MatKhauCu: MKCu,MatKhauMoi:MKMoi },
                success:function (result){
                    if(result == 'false')
                    {
                        alert('Mật Khẩu Củ Không Chính Xác');
                    }
                    else {
                        alert("Thay Đổi Mật Khẩu Thành Công")
                        $('#TT-Right').css('display', 'block');
                        $('#TT-Right2').css('display', 'none');
                        $('#TT-Right3').css('display', 'none');
                    }
                }
            });
        }
        else
        {
            alert("Mật Khẩu Mới Không Trùng Vui Lòng Nhập Lại!")
        }
        
    });
});