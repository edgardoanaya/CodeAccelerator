namespace SoftwareOne.BaseLine.Core
{
    public class SwoPaginatedList<T>
        where T : new()
    {
        public SwoPaginatedList(IQueryable<T> IQuery) { this.List = IQuery.ToList(); }

        public SwoPaginatedList(List<T> IQuery, dynamic Page)
        {
            this.List = IQuery;
            Paged = Page;
        }

        public List<T> List { get; }

        public dynamic Paged { set; get; } = null!;

        public SwoPaginatedList<T> ToList()
        {
            return this;
        }
    }
}