using System.Collections.Generic;
using System.Linq;

namespace FutbolApi.ViewModels
{
    public class PageHeader<TModel>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasNextPage => this.Items == null || this.Items.Any();

        public int NextPage => this.HasNextPage ? this.PageNumber + 1 : this.PageNumber;

        public IEnumerable<TModel> Items { get; set; }
    }
}
