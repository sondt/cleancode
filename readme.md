# Clean code & clean architecture
    []: # Language: markdown
    []: # Path: readme.md

1. Clean Code
   1. [Lý do cần viết mã sạch và tầm quan trọng](#Lý-do-cần-viết-mã-sạch-và-tầm-quan-trọng)
   2. Developer as writer
   3. Nguyên tắc viết mã sạch
   4. Naming convention
   5. Write clean methods
   6. Write clean classes
   7. Write clean comments
2. Clean architecture


<img src="https://media.doisongphapluat.com/thumb_x1280x857/2020/05/28/Maria_Ozawa.jpg" alt="Clean code like beautiful girl" width="100%" />
Clean code like beautiful girl 

<img src="http://idtco.com.vn/images/IDTCO-DESIGNS/BIETTHU/biet-thu-dep-21/biet-thu-dep-21.jpg" alt="Clean architecture like villa" width="100%" />
Clean architecture like villa

## Clean Code

### Lý do cần viết mã sạch và tầm quan trọng
Có nhiều lý do tại sao viết mã sạch lại quan trọng, tuy nghiên điều quan trọng cần nhớ là **viết mã thì dễ nhưng đọc thì khó**   

    - Làm việc nhóm
    - Có thể tái sử dụng
    - Bạn sẽ cảm thấy thích code của mình hơn, thích làm việc hơn, thích đọc code hơn
    - Bạn sẽ thấy sự phát triển
    
#### Developer as writer
Các bạn đang truyền tải cho các developer khác về TÁC PHẨM của mình,  vì thế các bạn cần phải có một cách để viết mã sạch và một kiến trúc sạch.
### Nguyên tắc viết mã sạch
#### Ba nguyên tắc viết mã sạch
1. Stay native 

Tránh sử dụng một ngôn ngữ này để viết một ngôn ngữ khác thông qua chuỗi ký tự
<img src="https://mariagraziamerlo.files.wordpress.com/2015/12/dirty_code.png?w=636">
3. Signal to Noise Ratio

Tín hiệu code tuân thủ theo nguyên tắc TED (**T**erse - Ngắn gọn; **E**xpressive - Hàm ý; **D**oes one thing - Làm một việc cụ thể)

Nhận dạng **Noise**:

 - Có tính lặp lại
 - Class lớn
 - Method dài
 - Độ phức tạp cao
 - Thụt lề quá mức
 - Comments không cần thiết
 - Đặt tên tệ

3. Self-Documenting Code
   - Trình bày ý định một cách rõ ràng để người đọc có thể hiểu chính xác những gì mà đang làm
   - Sử dụng các lớp trừu tượng (abstract)  để đi qua ở các mức độ chi tiết khác nhau 
   - Định dạng dễ đọc để tối ưu hóa trải nghiệm người đọc
   - Ưu tiên mã tự diễn đạt hơn comments

#### Don't repeat yourself (DRY)
Bill Gates said: "Measuring programming progress by lines of code is like measuring aircraft building progress by weight."
<img src="https://pbs.twimg.com/media/EufwYG_U4AUUEr1.jpg" alt="Bill Gates">
### Naming convention
#### Tại sao đặt tên lại quan trọng
Đặt tên có tác động rất lớn tới khả năng đọc mã của bạn, vì thế các bạn cần phải có một cách để đặt có ý nghĩa, tuân thủ theo các nguyên tắc đặt tên của mỗi ngôn ngữ lập trình (C#, Js ...)

[C# naming convention](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md)
<img src="docs/images/cSharpNamingClassesConvention.JPG" alt="c# naming convention">
[Javascript naming convention](https://github.com/ktaranov/naming-convention/blob/master/JavaScript%20Name%20and%20Coding%20Conventions.md)
<img src="docs/images/javascriptNamingClassesConvention.JPG" alt="javascript naming convention">
[SQL naming convention](https://github.com/ktaranov/naming-convention/blob/master/SQL%20Server%20Name%20Convention%20and%20T-SQL%20Programming%20Style.md)
<img src="docs/images/sqlNamingClassesConvention.JPG" alt="SQL naming convention">
[Java naming convention](https://www.javatpoint.com/java-naming-conventions)
<img src="docs/images/javaNamingClassesConvention.JPG" alt="Java naming convention">

### Writing clean methods
**4 lý do để tạo ra 1 method mới**
- Tránh lặp lại code
- Loại bỏ thụt lề quá mức
- Giảm thời gian tồn tại của biến
- Thực hiện một hành động cụ thể
### Writing clean classes
Các class như là headings của một cuốn sách
<img src="docs/images/classAsHeadingsABook.png" alt="Class like book headings">
**Lý do để tạo 1 class mới:**
- Mô hình hóa 1 đối tượng (New Concept): những đối tượng này có thể mô hình hóa các khái niệm cụ thệ hoặc trừu trượng
- Chia tách các lớp riêng biệt (Low Cohesion): Nếu các lớp ít liên quan đến nhau thì đó là dấu hiệu cho thấy có sự gắn kết thấp, vì thế cần được chia thành các lớp riêng biệt để hướng tới nhiều mục tiêu hơn
- Thúc đẩy tái sử dụng (Promote Reuse: Small, targeted): , ngay cả 1 một đoạn mã là 1 phần của lớp lớn hơn hãy tách ra thành 1 method và đặt nó vào một lớp riêng nếu nó hữu ích cho chương trình
- Giảm độ phức tạp của lớp (Reduce complexity):
- Xác định một nhóm dữ liệu
### Writing clean comments
Các comments là cần thiết và hữu ích cho dự án của bạn. 
- Các comment nên tránh

- Sử dụng các comments hữu ích
## Clean Architecture
Clean Architecture là một tập hợp các pattern, practices và Principles để tạo ra một kiến trúc phần mềm hiện đại đơn giản, dễ hiểu, linh hoạt, kiểm thử và dễ bảo trì
<img src="docs/images/dc2.png" alt="Class like book headings">

<img src="docs/images/levelsOfAA.png" alt="Level of A A">
<img src="docs/images/messyVsCleanArchitecture.png" alt="messyVsCleanArchitecture">

What's bad architecture?
- Phức tạp (Complex)
- Rời rạc, không có sự gắn kết (Incoherent)
- Cứng nhắc, không thể tùy biến (Rigid)
- Dễ đứt gãy (Brittle): Sửa một đoạn mã ở một lớp có thể
- Không thể hay rất khó để maintain (Lấy ví dụ 1 lớp của VAS)
