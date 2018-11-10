# PHẦN MỀM QUẢN LÝ KHÁCH SẠN

🏨🚪🛌🛎️ Ứng dụng quản lý khách sạn sử dụng C#, SQL SERVER

![Hình ảnh demo sản phẩm](/images/mainscreen.png)

## Nội dung

* [Tính năng](#Tính-năng)
* [Cài đặt](#Cài-đặt)
* [Môi trường](#Môi-trường)
* [Tài liệu tham khảo](#Tài-liệu-tham-khảo)
* [Bugs và các vấn đề](#Bugs-và-các-vấn-đề)
* [Ảnh chụp màn hình](#Ảnh-chụp-màn-hình)
* [Tác giả](#Tác-giả)
* [Giấy phép](#Giấy-phép)

## Tính năng

* Đặt phòng
* Nhận phòng
* Đặt dịch vụ
* Thanh toán và in hóa đơn
* Quản lý phòng và loại phòng
* Quản lý dịch vụ và loại dịch vụ
* Quản lý tài khoản
* Báo cáo 

## Cài đặt

**1. Tải các thành phần liên quan**

* Git clone https://github.com/ThuctapnhomK51/QLKS
* Khôi phục file backup database /Database/HotelManagement.bak

**2. Chỉnh sửa connection string**

* Mở file DAO/DataProvider.cs 
* Sửa đổi  private string connectionStr = @"Data Source=**.\TUNGUYENSV**;Initial Catalog=HotelManagement;Integrated Security=True";
với tên server tương ứng

**3. Tài khoản đăng nhập hệ thống**
username: admin
password: admin

## Môi trường

* [Visual Studio 2017](https://visualstudio.microsoft.com/fr/downloads/?rr=https%3A%2F%2Fwww.google.com.vn%2F)
* [SQL Server 2017](https://www.microsoft.com/en-us/sql-server/sql-server-2017)

## Tài liệu tham khảo

Tai liệu hỗ trợ việc sử dụng C# [documentation](https://docs.microsoft.com/en-us/dotnet/csharp/).

## Bugs và các vấn đề

Bạn có câu hỏi hoặc vấn đề với dự án? [Đặt câu hỏi](https://github.com/ThuctapnhomK51/QLKS/issues) tại đây trên Github.

## Ảnh chụp màn hình

* `Đăng nhập`

![Đăng nhập](/images/login.png)

* `Đặt phòng`

![Đặt phòng](/images/datphong.png)

* `Nhận phòng`

![Nhận phòng](/images/nhanphong.png)

* `Đặt dịch vụ và thanh toán`

![Đặt dịch vụ và thanh toán](/images/dichvu-thanhtoan.png)

* `Quản lý nhân viên`

![Quản lý nhân viên](/images/nhanvien.png)

## Tính năng đang phát triển
*Thống kê doanh thu*


## Tác giả

* **Nguyễn Phúc Tú** - [phuctu1901](https://github.com/phuctu1901)
* **Nguyễn Phú Lập** - [NguyenPhuLap3112](https://github.com/NguyenPhuLap3112)
* **Bùi Đức Tuấn** - [BuiDucTuan2802](https://github.com/BuiDucTuan2802)
* **Trần Minh Phát** - [tranminhphat1122](https://github.com/tranminhphat1122)
* **Vũ Tiến Đức** - [VuTienDuc1707](https://github.com/VuTienDuc1707)
* **Cao Đình Dũng** - [caodinhdung](https://github.com/caodinhdung)
* **Sinna Sone** - [sinnasonemta](https://github.com/sinnasonemta)

## Giấy phép

[MIT](https://opensource.org/licenses/MIT)
