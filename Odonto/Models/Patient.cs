
namespace Odonto.Models;


public class Patient : Person
{
   public int idPac { get; set; }
    public string MedicalHistory { get; set; }
     public ICollection<Date> Dates { get; set; }
}