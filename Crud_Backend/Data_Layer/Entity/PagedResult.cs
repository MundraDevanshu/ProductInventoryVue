using System.Collections.Generic;

namespace Data_Layer.Entity
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Products { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PagedResult(IEnumerable<T> products ,int totalCount , int pageNumber , int pageSize)
        {
            Products = products;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
