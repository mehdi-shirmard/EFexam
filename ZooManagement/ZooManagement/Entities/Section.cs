namespace ZooManagement.Entities;

public class Section
{
    public int Id { get; set; }
    public int ZooId { get; set; }
    
    public int TicketId { get; set; }
    public string Area { get; set; }
    public string NameOfAnimal { get; set; }
    public string NumberOfAnimal { get; set; }
    public string Captions { get; set; }
    
}

