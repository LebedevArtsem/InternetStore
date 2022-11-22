using InternetStore.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InternetStore.Infrastructure
{
    public class Pagination<T> : List<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Models { get; set; }

        private Pagination(int currentPage, int itemPerPage, IEnumerable<T> values)
        {
            Models = values.Skip((currentPage - 1) * itemPerPage).Take(itemPerPage).ToList();
            CurrentPage = currentPage;
            TotalPages = values.Count() / itemPerPage;
            if (values.Count() % itemPerPage != 0)
            {
                TotalPages++;
            }

        }

        public static Pagination<T> GetModel(int currentPage, int itemPerPage, IEnumerable<T> values)
        {
            var pagination = new Pagination<T>(currentPage, itemPerPage, values);

            return pagination;
        }
    }
}
