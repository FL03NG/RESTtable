namespace RESTtable.Models
{
    public interface ITableRepo
    {
        IEnumerable<Table> Get(int? minWeight, int? maxWeight);
        public Table? GetTableById(int id);
        public Table? AddTable(Table table);
        public Table? UpdateTable(Table table);
        public Table? DeleteTable(int id);
    }
}
