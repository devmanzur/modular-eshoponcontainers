namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagingQuery
    {
        const int maxPageSize = 30;
        private int _pageSize = 6;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public int Offset()
        {
            return GetCurrentIndex() * PageSize;
        }

        private int GetCurrentIndex()
        {
            var currentIndex = PageNumber - 1;
            return currentIndex < 0 ? 0 : currentIndex;
        }
    }
}