namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagingQuery
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string SearchTerm { get; set; }
        public string OrderBy { get; set; }

        private string _orderKey()
        {
            if (OrderBy != null && OrderBy.Split(" ").Length > 0)
                return OrderBy.Split(" ")[0];

            return null;
        }

        private string _direction()
        {
            if (OrderBy != null && OrderBy.Split(" ").Length > 1)
                return OrderBy.Split(" ")[1];

            return null;
        }

        public string OrderKey => _orderKey()?.ToLower();
        public bool IsDescending => _direction()?.ToLower() == "desc";
    }
}