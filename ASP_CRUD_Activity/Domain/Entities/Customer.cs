namespace ASP_CRUD_Activity.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        
    }
}
