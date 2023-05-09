

namespace Odonto.Models;

public class Doctor: Person
{

    public int idDoc { get; set; }
    public string Specialty { get; set; }
     public ICollection<Date> Dates { get; set; }

}