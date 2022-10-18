namespace WebApiProgII.Models
{
    public class Fecha
    {
        public int Dia { get; set; }    
        public string DiaSemana { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }

        public Fecha()
        {
            Dia = DateTime.Now.Day;
            DiaSemana = DateTime.Now.DayOfWeek.ToString();            
            Mes=DateTime.Now.Month;
            Año = DateTime.Now.Year;
        }
    }
}
