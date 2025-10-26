# Đặc tả tính năng: Website Thương mại điện tử Bida

**Nhánh tính năng**: `001-billiard-ecommerce-site`  
**Ngày tạo**: 2025-10-26  
**Trạng thái**: Bản nháp  
**Đầu vào**: Mô tả người dùng: "..."

## Làm rõ

### Phiên 2025-10-26

- Q: Cần xử lý các khác biệt giữa lược đồ cơ sở dữ liệu hiện có và các thực thể được định nghĩa trong đặc tả như thế nào? → A: Tuân thủ nghiêm ngặt `database.sql`. Cập nhật các thực thể trong đặc tả để khớp với lược đồ hiện có.
- Q: Các mẫu giao diện trong thư mục `Template/` nên được sử dụng như thế nào? → A: Dùng mẫu làm nền tảng cho Views, điều chỉnh các thành phần MVC để phù hợp.
- Q: Nếu có thời gian, tính năng nâng cao trải nghiệm người dùng nào sau đây nên được ưu tiên phát triển trước? → A: Cả ba: Đánh giá sản phẩm, Danh sách yêu thích, và Sản phẩm đã xem gần đây.

## Kịch bản người dùng & Kiểm thử *(bắt buộc)*

### Câu chuyện người dùng 1 - Duyệt và Xem Sản phẩm (Ưu tiên: P1)

Là một khách hàng, tôi muốn duyệt các danh mục sản phẩm và xem chi tiết của một sản phẩm cụ thể để tôi có thể quyết định mình muốn mua gì.

**Lý do ưu tiên**: Đây là chức năng cơ bản nhất của một trang web thương mại điện tử. Nếu không có nó, người dùng không thể xem những gì đang được bán.

**Kiểm thử độc lập**: Có thể được kiểm thử bằng cách điều hướng trang web, nhấp vào các danh mục và xem các trang sản phẩm. Mang lại giá trị bằng cách cho phép người dùng khám phá danh mục sản phẩm.

**Kịch bản nghiệm thu**:

1.  **Cho trước** tôi đang ở Trang chủ, **Khi** tôi nhấp vào một danh mục sản phẩm, **Thì** tôi sẽ thấy một danh sách các sản phẩm trong danh mục đó.
2.  **Cho trước** tôi đang xem danh sách sản phẩm, **Khi** tôi nhấp vào một sản phẩm, **Thì** tôi sẽ thấy thông tin chi tiết của nó, bao gồm tên, mô tả, giá và hình ảnh.

---

### Câu chuyện người dùng 2 - Quản lý Giỏ hàng (Ưu tiên: P1)

Là một khách hàng, tôi muốn thêm sản phẩm vào giỏ hàng và xem các mặt hàng tôi đã chọn để tôi có thể chuẩn bị mua hàng.

**Lý do ưu tiên**: Đây là cơ chế cốt lõi để mua hàng. Nó cho phép người dùng thu thập các mặt hàng họ dự định mua.

**Kiểm thử độc lập**: Có thể được kiểm thử bằng cách thêm các mặt hàng vào giỏ hàng từ một trang sản phẩm và sau đó xem giỏ hàng. Mang lại giá trị bằng cách kích hoạt quy trình thanh toán.

**Kịch bản nghiệm thu**:

1.  **Cho trước** tôi đang ở trang chi tiết sản phẩm còn hàng, **Khi** tôi nhấp vào "Thêm vào giỏ hàng", **Thì** sản phẩm được thêm vào giỏ hàng của tôi.
2.  **Cho trước** một sản phẩm có số lượng tồn kho là 0, **Khi** tôi xem trang sản phẩm của nó, **Thì** tôi sẽ thấy thông báo "Hết hàng" và nút "Thêm vào giỏ hàng" sẽ bị vô hiệu hóa.
3.  **Cho trước** tôi có các mặt hàng trong giỏ hàng của mình, **Khi** tôi điều hướng đến trang giỏ hàng, **Thì** tôi sẽ thấy danh sách tất cả các mặt hàng, số lượng và tổng giá tiền.

---

### Câu chuyện người dùng 3 - Mua hàng (Ưu tiên: P2)

Là một khách hàng, tôi muốn hoàn tất việc mua các mặt hàng trong giỏ hàng của mình bằng một phương thức thanh toán cục bộ đơn giản.

**Lý do ưu tiên**: Điều này hoàn thành hành trình chính của người dùng là mua một sản phẩm.

**Kiểm thử độc lập**: Có thể được kiểm thử bằng cách tiến hành từ giỏ hàng đến trang thanh toán và hoàn thành biểu mẫu đặt hàng. Mang lại giá trị bằng cách cho phép doanh nghiệp nhận đơn đặt hàng.

**Kịch bản nghiệm thu**:

1.  **Cho trước** tôi có các mặt hàng trong giỏ hàng của mình, **Khi** tôi tiến hành thanh toán, **Thì** tôi được cung cấp một biểu mẫu để nhập thông tin giao hàng của mình.
2.  **Cho trước** tôi đã điền thông tin giao hàng của mình, **Khi** tôi xác nhận đơn đặt hàng, **Thì** đơn hàng được đặt và tôi thấy một thông báo xác nhận.

---

### Câu chuyện người dùng 4 - Tìm kiếm Sản phẩm (Ưu tiên: P3)

Là một khách hàng, tôi muốn tìm kiếm sản phẩm theo tên và lọc chúng theo nhiều tiêu chí khác nhau để tôi có thể tìm thấy những gì mình đang tìm kiếm dễ dàng hơn.

**Lý do ưu tiên**: Cải thiện trải nghiệm người dùng bằng cách giúp tìm kiếm các sản phẩm cụ thể trong một danh mục lớn dễ dàng hơn.

**Kiểm thử độc lập**: Có thể được kiểm thử bằng cách sử dụng thanh tìm kiếm và các tùy chọn bộ lọc trên trang danh mục và xác minh kết quả.

**Kịch bản nghiệm thu**:

1.  **Cho trước** tôi đang ở trên trang web, **Khi** tôi nhập một từ khóa vào thanh tìm kiếm, **Thì** tôi thấy một danh sách các sản phẩm phù hợp với từ khóa.
2.  **Cho trước** tôi đang ở trên trang danh mục sản phẩm, **Khi** tôi áp dụng một bộ lọc (ví dụ: theo thương hiệu hoặc giá), **Thì** danh sách sản phẩm được cập nhật để phù hợp với bộ lọc.

### Các trường hợp biên

-   Điều gì xảy ra nếu người dùng cố gắng thêm một mặt hàng "Hết hàng" vào giỏ hàng? (Nút sẽ bị vô hiệu hóa).
-   Hệ thống xử lý thông tin không hợp lệ trong biểu mẫu thanh toán như thế nào? (Lỗi xác thực sẽ được hiển thị).
-   Điều gì được hiển thị nếu một tìm kiếm không trả về kết quả? (Một thông báo "Không tìm thấy kết quả" sẽ được hiển thị).

## Yêu cầu *(bắt buộc)*

### Yêu cầu chức năng

-   **FR-001**: Hệ thống PHẢI hiển thị một Trang chủ.
-   **FR-002**: Hệ thống PHẢI cho phép người dùng duyệt các sản phẩm được sắp xếp theo danh mục.
-   **FR-003**: Hệ thống PHẢI hiển thị các trang chi tiết sản phẩm với tên, mô tả, giá, hình ảnh và số lượng tồn kho.
-   **FR-004**: Hệ thống PHẢI hiển thị thông báo "Hết hàng" cho các sản phẩm có hàng tồn kho bằng 0.
-   **FR-005**: Người dùng PHẢI có thể thêm và xóa các mặt hàng khỏi giỏ hàng.
-   **FR-006**: Hệ thống PHẢI tính toán và hiển thị tổng giá của các mặt hàng trong giỏ hàng.
-   **FR-007**: Hệ thống PHẢI cung cấp một quy trình thanh toán để người dùng đặt hàng.
-   **FR-008**: Quy trình thanh toán PHẢI được tối ưu hóa cho thanh toán cục bộ (ví dụ: Tiền mặt khi giao hàng).
-   **FR-009**: Hệ thống PHẢI cung cấp chức năng tìm kiếm để tìm sản phẩm theo tên.
-   **FR-010**: Hệ thống PHẢI cung cấp tính năng lọc đa tiêu chí trên các trang danh sách sản phẩm.
-   **FR-011**: Giao diện trang web PHẢI được xây dựng dựa trên nền tảng (HTML/CSS) từ các mẫu trong thư mục `Template/`, và các Views của MVC PHẢI được điều chỉnh để phù hợp với cấu trúc của mẫu.
-   **FR-012**: Một tệp README ghi lại các chức năng phía người dùng PHẢI được tạo.
-   **FR-013**: (Nếu thời gian cho phép) Hệ thống NÊN cho phép người dùng gửi đánh giá và xếp hạng cho sản phẩm.
-   **FR-014**: (Nếu thời gian cho phép) Hệ thống NÊN cung cấp chức năng "Danh sách yêu thích" (wishlist) cho người dùng.
-   **FR-015**: (Nếu thời gian cho phép) Hệ thống NÊN hiển thị một mục cho các sản phẩm người dùng đã xem gần đây.

### Các thực thể chính *(bao gồm nếu tính năng liên quan đến dữ liệu)*

*(Lưu ý: Cấu trúc của các thực thể này phải tuân thủ nghiêm ngặt theo lược đồ trong tệp `docs/database/database.sql`.)*

-   **Sản phẩm**: Đại diện cho một mặt hàng để bán. Các thuộc tính bao gồm Tên, Mô tả, Giá, Số lượng tồn kho, Danh mục, Thương hiệu, Hình ảnh.
-   **Danh mục**: Đại diện cho một danh mục sản phẩm.
-   **Giỏ hàng**: Một bộ sưu tập tạm thời các sản phẩm mà người dùng dự định mua.
-   **Đơn hàng**: Đại diện cho một yêu cầu mua hàng đã hoàn tất của khách hàng. Các thuộc tính bao gồm Địa chỉ giao hàng, Tổng giá và danh sách các Mặt hàng trong đơn hàng.
-   **Người dùng**: Đại diện cho một khách hàng. Các thuộc tính bao gồm Tên, Địa chỉ và thông tin Liên hệ.

## Tiêu chí thành công *(bắt buộc)*

### Kết quả có thể đo lường

-   **SC-001**: Một người dùng mới có thể tìm thấy thành công một sản phẩm, thêm nó vào giỏ hàng và hoàn tất quy trình thanh toán trong vòng chưa đầy 5 phút.
-   **SC-002**: Các trang danh mục sản phẩm và chi tiết phải tải trong vòng chưa đầy 3 giây trên một kết nối cục bộ tiêu chuẩn.
-   **SC-003**: Trạng thái "Hết hàng" phải được hiển thị chính xác trong thời gian thực cho tất cả các sản phẩm có hàng tồn kho bằng không.
-   **SC-004**: 100% các mô-đun chính (Trang chủ, Danh mục, Chi tiết, Giỏ hàng, Thanh toán, Tìm kiếm, Lọc) được triển khai và hoạt động theo các kịch bản nghiệm thu.
-   **SC-005**: Giao diện người dùng cuối cùng được xác nhận là một triển khai trung thực và bóng bẩy của các mẫu thiết kế được cung cấp.
