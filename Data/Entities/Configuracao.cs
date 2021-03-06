using Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using Utils.Enums;

namespace Data.Entities
{
    public class Configuracao : UsuarioBase
    {
        public int Id { get; set; }
        public int? LogoId { get; set; }
        public Arquivo Logo { get; set; }
        public int? LogoRelatorioId { get; set; }
        public Arquivo LogoRelatorio { get; set; }
        public int? BackgroundId { get; set; }
        public Arquivo Background { get; set; }
        public int? BackgroundCelularId { get; set; }
        public Arquivo BackgroundCelular { get; set; }
        public string Titulo { get; set; }
        public string CorBotao { get; set; }
        public string InscricaoConcluida { get; set; }
        public string InscricaoCompleta { get; set; }
        public string CorHoverBotao { get; set; }
        public string CorLoginBox { get; set; }
        public string CorScroll { get; set; }
        public string CorHoverScroll { get; set; }
        public TipoCirculoEnum TipoCirculo { get; set; }
        public TiposEventoEnum TipoEvento { get; set; }
    }
}
