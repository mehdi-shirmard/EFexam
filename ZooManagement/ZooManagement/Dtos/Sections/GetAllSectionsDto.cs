using ZooManagement.EFPerisistance;

namespace ZooManagement.Dtos.Sections;

public class GetAllSectionsDto
{
    public int SectionId { get; set; }
    public string ZooName { get; set; }
    public string Area { get; set; }
    public string NameOfAnimal { get; set; }
    public string NumberOfAnimal { get; set; }
    public string Captions { get; set; }
    
}