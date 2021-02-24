namespace HRSystem.Application.Common
{
    public class QueryParameters
    {
        public string SortBy { get; set; }

        public string Direction { get; set; } = "asc";

        public string FilterBy { get; set; }

        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; } = 50;
    }
}
