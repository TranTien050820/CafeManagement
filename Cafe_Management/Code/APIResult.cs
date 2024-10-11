namespace Cafe_Management.Code
{
    public class APIResult
    {
        public int Status { set; get; }
        public string? Message { set; get; }
        public string? Exception { set; get; }
        public object? Data { set; get; }
    }
}
