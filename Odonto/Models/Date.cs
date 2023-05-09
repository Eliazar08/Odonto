

namespace Odonto.Models;

public class Date 
{

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public string Observation { get; set; }
    DateTime Fecha { get; set; }
    public int Id { get; set; }

}