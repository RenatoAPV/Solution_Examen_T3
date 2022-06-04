namespace Prieto_T3.WEB.Models
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public string? NombreMascota { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaNacimientoMascota { get; set; }
        public string Sexo { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Tamanio { get; set; }
        public string Datospart { get; set; }
        public string? NombreDueño { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string email { get; set; }

        public int Usuarioid { get; set; }
    }
}
