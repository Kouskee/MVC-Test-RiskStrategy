using Domain.Enums;

namespace Domain.Response
{
    public class BaseResponse<T>
    {
        public string? Description { set; get; }
        public CodeStatus CodeStatus { set; get; }
        public T Data { set; get; } = default!;
    }
}
