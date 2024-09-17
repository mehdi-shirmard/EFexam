using System.Collections.Specialized;
using ZooManagement.Dtos.Sections;
using ZooManagement.Entities;
using ZooManagement.Migrations;

namespace ZooManagement.EFPerisistance.Sections;

public class EfSectionRepository(EfDataContext context)
{
    public void Add(Section section)
    {
        context.Set<Section>().Add(section);
    }

    public List<GetAllSectionsDto> GetAll()
    {
        return (
            from Section in context.Set<Section>()
            join zoo in context.Set<Zoo>()
                on Section.ZooId equals zoo.Id
            join ticket in context.Set<Ticket>()
                on Section.TicketId equals ticket.Id
                into sectionTickets
            from sectionTicket in sectionTickets.DefaultIfEmpty()
            select new GetAllSectionsDto
            {
                Area = Section.Area,
                ZooName = zoo.Name,
                Captions = Section.Captions,
                NameOfAnimal = Section.NameOfAnimal,
                NumberOfAnimal = Section.NumberOfAnimal,
                SectionId = Section.Id
                
            }
        ).ToList();
    }
    public Section? GetById(int id)
    {
        return context.Set<Section>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Section employee)
    {
        context.Set<Section>().Remove(employee);
    }
}