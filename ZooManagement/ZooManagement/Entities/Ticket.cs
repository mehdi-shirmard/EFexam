namespace ZooManagement.Entities;

public class Ticket
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int SectionId { get; set; }
    public int TicketCount { get; set; }
}