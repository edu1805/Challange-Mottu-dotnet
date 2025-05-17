namespace Cp2WebApplication.Infrastructure.DTOs
{
    public class MotoDto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Status { get; set; } = "desconhecido";
        public DateTime? UltimaAtualizacao { get; set; }
    }

}
