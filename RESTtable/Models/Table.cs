namespace RESTtable.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"Table: Id={Id}, Name={Name}, Weight={Weight}";
        }
    }
}
