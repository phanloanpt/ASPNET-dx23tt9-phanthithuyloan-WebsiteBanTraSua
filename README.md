# Website Bán Trà Sữa NGON

## Giới thiệu

Website **Trà Sữa NGON** là hệ thống bán trà sữa trực tuyến được xây dựng bằng **ASP.NET Web Forms**, áp dụng mô hình kiến trúc **3 tầng (Presentation – Business Logic – Data Access)** và sử dụng **SQL Server** để lưu trữ dữ liệu.

Hệ thống hỗ trợ:

- Khách hàng xem sản phẩm, đặt hàng trực tuyến.
- Quản trị viên quản lý sản phẩm, danh mục, topping, đơn hàng, kho vật tư, tin tức và người dùng.

---

# Công nghệ sử dụng

- ASP.NET Web Forms (.NET Framework 4.7.2)
- C#
- SQL Server 22
- Visual Studio Insiders
- Bootstrap 5
- Font Awesome

---

# Cách chạy dự án

## Bước 1. Clone hoặc tải source code

Clone repository:

```bash
git clone <repository_url>
```

Hoặc tải file ZIP và giải nén.

---

## Bước 2. Khôi phục cơ sở dữ liệu

Mở **SQL Server Management Studio (SSMS)**.

Tạo database mới:

```
TraSuaNgonDB
```

Sau đó chạy file SQL đi kèm:

```
TraSuaNgonDB.sql
```

để tạo bảng và dữ liệu mẫu.

---

## Bước 3. Cấu hình chuỗi kết nối

Mở file:

```
Web.config
```

Tìm phần:

```xml
<connectionStrings>
    <add name="TraSuaNgonConnection"
         connectionString="Data Source=.;Initial Catalog=TraSuaNgonDB;Integrated Security=True"
         providerName="System.Data.SqlClient"/>
</connectionStrings>
```

Thay đổi:

```
Data Source
```

thành tên SQL Server của máy bạn nếu cần.

Ví dụ:

```
DESKTOP-ABC123
```

hoặc

```
.\SQLEXPRESS
```

---

## Bước 4. Mở dự án

Mở Visual Studio.

Chọn

```
Open Project
```

và mở file

```
TraSuaNgon.sln
```

---

## Bước 5. Build project

Trong Visual Studio:

```
Build
→ Build Solution
```

hoặc nhấn:

```
Ctrl + Shift + B
```

## Đảm bảo không có lỗi Build.

## Bước 6. Chạy website

Nhấn

```
F5
```

hoặc

```
IIS Express
```

## Website sẽ mở trên trình duyệt.

# Tài khoản đăng nhập

## Quản trị viên

```
Username: admin
Password: admin123
```

> Nếu dữ liệu mẫu khác, hãy sử dụng tài khoản được lưu trong bảng **Users**.

---

# Chức năng chính

## Khách hàng

- Xem sản phẩm
- Xem chi tiết sản phẩm
- Chọn size M/L
- Chọn topping
- Thêm vào giỏ hàng
- Thanh toán
- Xem tin tức
- Gửi liên hệ

## Quản trị viên

- Quản lý danh mục
- Quản lý sản phẩm
- Quản lý topping
- Quản lý đơn hàng
- Quản lý người dùng
- Quản lý banner
- Quản lý tin tức
- Quản lý vật tư
- Nhập kho
- Thống kê Dashboard

---

# Cấu trúc thư mục

```
TraSuaNgon
│
├── Admin/
│   ├── Products/
│   ├── Orders/
│   ├── Inventory/
│   ├── Users/
│   └── ...
│
├── App_Code/
│   ├── DAL/
│   ├── BLL/
│   ├── Models/
│   └── Helpers/
│
├── Assets/
│   ├── images/
│   ├── banners/
│   └── ...
│
├── Content/
├── Scripts/
├── Web.config
└── Default.aspx
```

---

# Kiến trúc hệ thống

Website áp dụng mô hình 3 tầng:

```
Presentation Layer
        │
        ▼
Business Logic Layer (BLL)
        │
        ▼
Data Access Layer (DAL)
        │
        ▼
SQL Server Database
```

---

# Một số lưu ý

- Đảm bảo SQL Server đang hoạt động trước khi chạy website.
- Kiểm tra chuỗi kết nối trong `Web.config` nếu không thể kết nối cơ sở dữ liệu.
- Nếu thiếu dữ liệu, hãy chạy lại file `TraSuaNgonDB.sql`.
- Sau khi thay đổi source code, nên **Build Solution** trước khi chạy lại dự án.

---

# Tác giả

**Phan Thị Thùy Loan**
ĐT: 0939882207
Email: phanloan2358@fmail.com
Đồ án môn học ASP.NET
Website bán trà sữa **Trà Sữa NGON**
