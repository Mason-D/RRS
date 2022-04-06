namespace RRS.Data
{
    public class Employee : Person
    {
        public string TaxFileNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
    }
}
