namespace CrossCuttingConcerns.Core.Features.Paging
{
    public class Page
    {
        public Page(int size, int index)
        {
            Size = size;
            Index = index;
        }

        public int Size { get; private set; }
        public int Index { get; private set; }

        public int Skip()
        {
            return GetCurrentIndex() * Size;
        }

        private int GetCurrentIndex()
        {
            var currentIndex = Index - 1;
            return currentIndex < 0 ? 0 : currentIndex;
        }
    }
}