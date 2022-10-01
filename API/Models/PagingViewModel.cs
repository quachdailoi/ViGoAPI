namespace API.Models.Responses
{
    public class PagingViewModel<T>
    {
        public T? Items { get; set; }
        public int TotalItemsCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPagesCount { get; set; }    
    }
}
