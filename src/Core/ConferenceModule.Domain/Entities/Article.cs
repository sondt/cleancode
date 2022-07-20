using System.ComponentModel.DataAnnotations.Schema;
using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Domain;

[Table("News")]
public class Article {
    /// <summary>
    ///     ID của tin
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Tiêu đề tin
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     Tiêu đề dẫn
    /// </summary>
    public string? SubTitle { get; set; }

    /// <summary>
    ///     Mô tả tin
    /// </summary>
    public string? Sapo { get; set; }

    /// <summary>
    ///     Tiêu đề ngắn
    /// </summary>
    public string? ShortTitle { get; set; }

    /// <summary>
    ///     Mô tả ngắn
    /// </summary>
    public string? ShortSapo { get; set; }

    /// <summary>
    ///     ID chuyên mục
    /// </summary>
    public int? CatId { get; set; }

    /// <summary>
    ///     Danh sách các chuyên mục khác cách nhau bởi dấu &quot;,&quot;
    /// </summary>
    public string? OtherCats { get; set; }

    /// <summary>
    ///     Hiển thị ảnh đại diện trong bài chi tiết
    /// </summary>
    public byte? DisplayAvatar { get; set; }

    /// <summary>
    ///     Ảnh đại diện
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    ///     Mô tả ảnh đại diện
    /// </summary>
    public string? AvatarDescription { get; set; }

    /// <summary>
    ///     Nội dung tin
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    ///     Nội dung trên hiển thị trên bản mobile. Mặc định là rỗng, nếu rỗng thì lấy trường Content.
    /// </summary>
    public string? MobileContent { get; set; }

    /// <summary>
    ///     Trạng thái cho phép comment bài viết
    /// </summary>
    public byte? AllowComment { get; set; }

    /// <summary>
    ///     Cho phép quảng cáo trong bài chi tiết
    /// </summary>
    public byte? AllowAds { get; set; }

    /// <summary>
    ///     Danh sách các tin liên quan cách nhau bởi dấu &quot;,&quot;
    /// </summary>
    public string? Relation { get; set; }

    /// <summary>
    ///     Kiểu tin bài như: tin ảnh, tin video, tin slide, tin inforgraphic, magazine, video + ảnh, longform...
    /// </summary>
    public byte? DisplayType { get; set; }

    public byte? IsPr { get; set; }

    /// <summary>
    ///     Bài có ảnh: 1 ; Bài có video : 2 ; Bài có Audio: 4 ; Bài hot: 8 ; Bài trực tiếp: 16
    /// </summary>
    public int? MediaIcons { get; set; }

    /// <summary>
    ///     Kiểu tin dạng facebook article, google AMP...
    /// </summary>
    public byte? SocialType { get; set; }

    /// <summary>
    ///     Link redirect nếu có.
    /// </summary>
    public string? UrlRedirect { get; set; }

    /// <summary>
    ///     Nguồn vợt, ví dụ: Zing, TTVN, Tuổi trẻ....
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    ///     Link bài gốc
    /// </summary>
    public string? SourceUrl { get; set; }

    public int? ProvinceId { get; set; }

    /// <summary>
    ///     ID tác giả bài viết - Liên kết với bảng Author nếu có
    /// </summary>
    public int? AuthorId { get; set; }

    /// <summary>
    ///     Tên tác giả bài viết. Sử dụng trong trường hợp độc giả gửi bài viết hoặc không chọn tác giả ở trên
    /// </summary>
    public string? AuthorName { get; set; }

    public byte? ContentCategory { get; set; }
    public byte? ProductionType { get; set; }

    /// <summary>
    ///     Tiêu đề SEO, nếu không sửa mặc định lấy tiêu đề bài viết
    /// </summary>
    public string? SeoTitle { get; set; }

    /// <summary>
    ///     Mô tả SEO, nếu không sửa mặc định lấy sapo bài viết, nếu không có sapo lấy tiêu đề
    /// </summary>
    public string? SeoDescription { get; set; }

    /// <summary>
    ///     Từ khóa bài viết: mặc định lấy tag trong bài
    /// </summary>
    public string? SeoKeywords { get; set; }

    public string? Tags { get; set; }

    /// <summary>
    ///     ID người tạo
    /// </summary>
    public int? CreatorId { get; set; }

    /// <summary>
    ///     Ngày tạo
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    ///     Ngày xuất bản
    /// </summary>
    public DateTime? PublishedDate { get; set; }

    public NewsStatus? Status { get; set; }
    public int? EditingUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? PublisherId { get; set; }
    public int? EditorId { get; set; }

    /// <summary>
    ///     Kiểu hiển thị ảnh. 0 --&gt; bình thường, 1 --&gt; ảnh lớn, 2 --&gt; ảnh trung bình, 3 --&gt; ảnh nhỏ
    /// </summary>
    public byte? AvatarShowType { get; set; }

    public string? CoverImage { get; set; }
    public string? CoverImageMobile { get; set; }
    public int? WcTitle { get; set; }
    public int? WcSapo { get; set; }
    public int? WcContent { get; set; }
    public string? VideoUrl { get; set; }
    public string? VideoPoster { get; set; }
    public int? ShowVideoAsAvatar { get; set; }
    public int? DisplaySource { get; set; }

    public virtual Conference? Conference { get; set; }
}