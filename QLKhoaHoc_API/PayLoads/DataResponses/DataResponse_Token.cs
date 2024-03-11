using QLKhoaHoc_API.Entities;

namespace QLKhoaHoc_API.PayLoads.DataResponses
{
    public class DataResponse_Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
