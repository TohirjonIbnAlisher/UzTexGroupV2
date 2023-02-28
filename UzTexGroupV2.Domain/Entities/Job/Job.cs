namespace UzTexGroupV2.Domain.Entities;

public class Job : LocalizedObject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Desription { get; set; }
    public string WorkTime { get; set; }
    public decimal Salary { get; set; }
    public Guid FactoryId { get; set; }
    public Factory Factory { get; set; }
    public ICollection<Applications>? Applications { get; set; }
}
