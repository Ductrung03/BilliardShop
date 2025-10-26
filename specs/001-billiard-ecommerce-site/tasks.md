# Kế hoạch công việc: Website Thương mại điện tử Bida

**Nhánh**: `001-billiard-ecommerce-site`

## Giai đoạn 1: Cài đặt & Thiết lập

- [X] T001 Tạo thư mục `tests` ở thư mục gốc của dự án.
- [X] T002 [P] Dùng `dotnet new xunit` để tạo dự án `BilliardShop.Application.Tests` trong thư mục `tests/`.
- [X] T003 [P] Dùng `dotnet new xunit` để tạo dự án `BilliardShop.Domain.Tests` trong thư mục `tests/`.
- [X] T004 [P] Thêm tham chiếu từ `BilliardShop.Application.Tests` đến `BilliardShop.Application`.
- [X] T005 [P] Thêm tham chiếu từ `BilliardShop.Domain.Tests` đến `BilliardShop.Domain`.

## Giai đoạn 2: Nền tảng & Cấu trúc

- [X] T006 Cấu hình Dependency Injection trong `src/BilliardShop.Web/Program.cs` để đăng ký các services và repositories.
- [X] T007 [P] Implement `GenericRepository` trong `src/BilliardShop.Infrastructure/Repositories/GenericRepository.cs`.
- [X] T008 [P] Implement `UnitOfWork` trong `src/BilliardShop.Infrastructure/Repositories/UnitOfWork.cs`.
- [X] T009 Thiết lập `DbContext` (`BilliardShopDbContext.cs`) để sử dụng chuỗi kết nối từ `appsettings.json`.

## Giai đoạn 3: [US1] Duyệt và Xem Sản phẩm

- **Mục tiêu**: Người dùng có thể duyệt danh mục và xem chi tiết sản phẩm.
- **Kiểm thử độc lập**: Có thể điều hướng đến trang danh mục, nhấp vào một sản phẩm và thấy trang chi tiết của nó.

- [X] T010 [US1] Tạo `ProductService` trong `src/BilliardShop.Application/Services/` để lấy dữ liệu sản phẩm và danh mục.
- [X] T011 [US1] Tạo `HomeController.cs` trong `src/BilliardShop.Web/Controllers/` với action `Index`.
- [X] T012 [US1] Tạo `ProductController.cs` trong `src/BilliardShop.Web/Controllers/` với các actions `Index` và `Details`.
- [X] T013 [US1] [P] Tạo `HomeViewModel.cs` và `ProductListViewModel.cs` trong `src/BilliardShop.Web/Models/`.
- [X] T014 [US1] [P] Tạo `ProductDetailViewModel.cs` trong `src/BilliardShop.Web/Models/`.
- [X] T015 [US1] Tạo View `Views/Home/Index.cshtml` và tích hợp giao diện từ thư mục `Template/`.
- [X] T016 [US1] Tạo View `Views/Product/Index.cshtml` cho danh sách sản phẩm.
- [X] T017 [US1] Tạo View `Views/Product/Details.cshtml` cho chi tiết sản phẩm.
- [X] T018 [US1] Viết Unit Test cho `ProductService` trong `tests/BilliardShop.Application.Tests/`.

## Giai đoạn 4: [US2] Quản lý Giỏ hàng

- **Mục tiêu**: Người dùng có thể thêm, xem và quản lý các sản phẩm trong giỏ hàng.
- **Kiểm thử độc lập**: Có thể thêm một sản phẩm vào giỏ, vào trang giỏ hàng và thấy sản phẩm đó.

- [X] T019 [US2] Tạo `CartService` trong `src/BilliardShop.Application/Services/`.
- [X] T020 [US2] Tạo `CartController.cs` trong `src/BilliardShop.Web/Controllers/`.
- [X] T021 [US2] Implement các actions `Index`, `AddToCart`, `UpdateQuantity`, `RemoveFromCart` trong `CartController`.
- [X] T022 [US2] [P] Tạo `CartViewModel.cs` trong `src/BilliardShop.Web/Models/`.
- [X] T023 [US2] Tạo View `Views/Cart/Index.cshtml`.
- [X] T024 [US2] Implement logic hiển thị "Hết hàng" trên trang chi tiết sản phẩm.
- [X] T025 [US2] Viết Unit Test cho `CartService` trong `tests/BilliardShop.Application.Tests/`.

## Giai đoạn 5: [US3] Mua hàng

- **Mục tiêu**: Người dùng có thể đặt hàng và hoàn tất quy trình thanh toán đơn giản.
- **Kiểm thử độc lập**: Có thể đi từ giỏ hàng đến trang thanh toán, điền thông tin và nhận được xác nhận đơn hàng.

- [X] T026 [US3] Tạo `OrderService` trong `src/BilliardShop.Application/Services/`.
- [X] T027 [US3] Tạo `CheckoutController.cs` trong `src/BilliardShop.Web/Controllers/`.
- [X] T028 [US3] Implement actions `Index` (GET) và `PlaceOrder` (POST) trong `CheckoutController`.
- [X] T029 [US3] [P] Tạo `CheckoutViewModel.cs` và `OrderConfirmationViewModel.cs` trong `src/BilliardShop.Web/Models/`.
- [X] T030 [US3] Tạo View `Views/Checkout/Index.cshtml` cho form thanh toán.
- [X] T031 [US3] Tạo View `Views/Checkout/Confirmation.cshtml` cho trang xác nhận đơn hàng.
- [X] T032 [US3] Viết Unit Test cho `OrderService` trong `tests/BilliardShop.Application.Tests/`.

## Giai đoạn 6: [US4] Tìm kiếm Sản phẩm

- **Mục tiêu**: Người dùng có thể tìm kiếm và lọc sản phẩm.
- **Kiểm thử độc lập**: Có thể dùng thanh tìm kiếm, nhận kết quả, và áp dụng bộ lọc trên trang danh mục.

- [X] T033 [US4] Mở rộng `ProductService` để hỗ trợ tìm kiếm và lọc.
- [X] T034 [US4] Thêm action `Search` vào `ProductController`.
- [X] T035 [US4] Implement giao diện người dùng cho bộ lọc trên `Views/Product/Index.cshtml`.
- [X] T036 [US4] Viết Unit Test cho logic tìm kiếm và lọc trong `ProductService`.

## Giai đoạn 7: Hoàn thiện & Các tính năng bổ sung

- [X] T037 [P] Implement chức năng đánh giá sản phẩm.
- [X] T038 [P] Implement chức năng danh sách yêu thích (wishlist).
- [X] T039 [P] Implement chức năng hiển thị sản phẩm đã xem gần đây.
- [X] T040 Hoàn thiện giao diện người dùng trên toàn bộ trang web.
- [X] T041 Tạo và điền nội dung cho tệp `README.md` ở thư mục gốc.

## Thứ tự phụ thuộc

- **MVP (Sản phẩm khả dụng tối thiểu)**: Giai đoạn 3 (US1).
- **Phụ thuộc**: Giai đoạn 3 (US1) → Giai đoạn 4 (US2) → Giai đoạn 5 (US3). Giai đoạn 6 (US4) có thể thực hiện song song sau Giai đoạn 3.

## Cơ hội thực hiện song song

- Các nhiệm vụ được đánh dấu `[P]` có thể được thực hiện song song trong cùng một giai đoạn.
- Giai đoạn 3, 4, 5 nên được thực hiện tuần tự để đảm bảo luồng người dùng chính hoạt động.
- Giai đoạn 6 và 7 có thể được thực hiện song song với các giai đoạn khác sau khi Giai đoạn 3 hoàn thành.
