namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagingQuery
    {
        const int maxPageSize = 50;
        const int minPageSize = 10;
        const int minPageNumber = 1;
        private int _pageSize = 6;
        private int _pageNumber = 1;

        public int PageNumber {
            get => _pageNumber;
            set => _pageNumber =(value < minPageNumber) ? minPageNumber : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : (value < minPageSize) ? minPageSize : value;
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