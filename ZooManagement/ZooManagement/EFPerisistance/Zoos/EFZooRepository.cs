using ZooManagement.Dtos.Zoos;
using ZooManagement.Entities;

namespace ZooManagement.EFPerisistance.Zoos;

public class EfZooRepository(EfDataContext context)
{
    public void Add(Zoo zoo)
    {
        context.Set<Zoo>().Add(zoo);
    }
    public List<GetAllZoosDto> GetAll()
    {
        return context.Set<Zoo>().Select(
            _ => new GetAllZoosDto
            {
                Id = _.Id,
                Name = _.Name,
                Address = _.Address
            }).ToList();
    }
    public bool DoesZooExistById(int id)
    {
        return context.Set<Zoo>().Any(_=>_.Id == id);
    }

    public Section? GetById(int id)
    {
        return context.Set<Section>().FirstOrDefault(_ => _.Id == id);
    }
}