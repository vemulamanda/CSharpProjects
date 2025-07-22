namespace CollectionsProject
{
    internal class LinqCustomer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public double? salary { get; set; }
        public bool? Status { get; set; }

        public override string ToString()
        {
            return $"ID = {ID}, Name = {Name}, Role = {Role}, Salary = {salary}, Status = {Status} ";
        }
    }
}
