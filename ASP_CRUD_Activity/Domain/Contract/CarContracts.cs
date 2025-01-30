namespace ASP_CRUD_Activity.Domain.Contract
{
    public record CreateCar
    {
        public string Model { get; set; }
        public long EngineNumber { get; set; }
        public int PlateNo { get; set; }
        public int Year { get; set; }
    }

    public record UpdateCar
    {
        public string Model { get; set; }
        public long EngineNumber { get; set; }
        public int PlateNo { get; set; }
        public int Year { get; set; }
    }

    public record DeleteCar
    {
        public Guid Id { get; set; }

    }

    public record GetCar
    {
        public Guid Id { set; get; }
    }


    public class GetCarDto
    {
        public Guid Id { get; set; }    
        public string Model { get; set; }
        public long EngineNumber { get; set; }
        public int PlateNo { get; set; }
        public int Year { get; set; }
    }
   
    
}
