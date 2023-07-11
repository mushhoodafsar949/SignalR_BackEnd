namespace CRUDinCore.Models.DataModels
{
    public class StudentAdd
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long RollNumber { get; set; }
        public string? section { get; set; }
        public long TeacherId { get; set; }
    }
}
