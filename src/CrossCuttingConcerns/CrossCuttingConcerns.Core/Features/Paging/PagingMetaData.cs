namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class PagingMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;


        public override bool Equals(object obj)
        {
            var item = obj as PagingMetaData;

            return this.CurrentPage == item?.CurrentPage && this.TotalPages == item?.TotalPages &&
                   this.PageSize == item?.PageSize;
        }

        public override int GetHashCode()
        {
            return this.CurrentPage + this.TotalPages + this.PageSize;
        }
    }
}