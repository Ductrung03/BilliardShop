# Data Model

This document outlines the data model for the Billiard Shop application, based on the provided `docs/database/database.sql` schema. The schema is the single source of truth.

## Core Tables

### 1. User Management

- **VaiTroNguoiDung**: Stores user roles (e.g., Admin, Customer).
- **NguoiDung**: Stores user account information, including credentials and profile data.
- **DiaChiNguoiDung**: Stores shipping and billing addresses for users.

### 2. Product Catalog

- **DanhMucSanPham**: Defines product categories, supporting hierarchical structures (parent-child categories).
- **ThuongHieu**: Stores brand information.
- **SanPham**: The central product table, containing details like name, description, pricing, stock, and SEO information.
- **HinhAnhSanPham**: Manages multiple images for each product.
- **ThuocTinhSanPham**: Allows for dynamic, custom attributes for products.

### 3. Inventory Management

- **NhaCungCap**: Stores supplier information.
- **BienDongKhoHang**: Tracks inventory changes (in, out, adjustments) for auditing purposes.

### 4. Order Management

- **DonHang**: The main table for orders, containing customer information, totals, shipping/payment details, and status.
- **ChiTietDonHang**: Stores the individual line items for each order.
- **TrangThaiDonHang**: Defines the possible statuses of an order (e.g., Pending, Processing, Shipped).
- **PhuongThucThanhToan**: Defines available payment methods.
- **PhuongThucVanChuyen**: Defines available shipping methods.

### 5. Customer Interaction

- **GioHang**: Stores the contents of the shopping cart for both registered users and guests.
- **DanhGiaSanPham**: Contains product reviews and ratings submitted by users.
- **DanhSachYeuThich**: Manages users' wishlists.

## Relationships

- A `SanPham` belongs to one `DanhMucSanPham` and one `ThuongHieu`.
- A `DonHang` has many `ChiTietDonHang` items.
- A `NguoiDung` can have multiple `DiaChiNguoiDung`, `DonHang`, `DanhGiaSanPham`, and `DanhSachYeuThich` entries.

## Stored Procedures & Views

The database makes extensive use of Stored Procedures (`sp_...`) for business logic (e.g., `sp_TaoDonHang`) and Views (`vw_...`) for querying complex data sets (e.g., `vw_DanhSachSanPham`). The application logic should leverage these where possible to ensure consistency and performance.
