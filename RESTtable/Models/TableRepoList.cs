namespace RESTtable.Models
{
    public class TableRepoList : ITableRepo
    {
        public List<Table> Tables = new List<Table>();
        private int _nextId = 1;
        public TableRepoList(bool includedata = true)
        {
            if(includedata)
            {
                AddTable(new Table { Id = _nextId++, Name = "Table 1", Weight = 10 });
                AddTable(new Table { Id = _nextId++, Name = "Table 2", Weight = 20 });
                AddTable(new Table { Id = _nextId++, Name = "Table 3", Weight = 30 });
            }
        }
        
        public List<Table> GetAllTables()
        {
            return Tables;
        }
        public IEnumerable<Table> Get(int? minimumweight, int? maximumweight)
        {
            IEnumerable<Table> result = Tables.AsReadOnly();

            if (minimumweight != null)
            {
                result = result.Where(t => t.Weight >= minimumweight);
            }

            if (maximumweight != null)
            {
                result = result.Where(t => t.Weight <= maximumweight);
            }

            return result;
        }

        public Table? GetTableById(int id)
        {
            return Tables.FirstOrDefault(t => t.Id == id);
        }

        public Table? AddTable(Table table)
        {
            table.Id = _nextId++;
            Tables.Add(table);
            return table;

        }

        public Table? UpdateTable(Table table)
        {
            var Table = GetTableById(table.Id);
            if (Table != null)
            {
                Table.Name = table.Name;
                Table.Weight = table.Weight;
                return Table;
            }
            return null;
        }

        public Table? DeleteTable(int id)
        {
            var table = GetTableById(id);
            if (table != null)
            {
                Tables.Remove(table);
                return table;
            }
            return null;
        }
    }
}
