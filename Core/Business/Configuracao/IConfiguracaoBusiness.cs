using Core.Models.Configuracao;
using System.Collections.Generic;
using System.Linq;
using Utils.Enums;

namespace Core.Business.Configuracao
{
    public interface IConfiguracaoBusiness
    {
        IQueryable<Data.Entities.Configuracao> GetConfiguracoes();
        PostConfiguracaoModel GetConfiguracao(int? id = null);

        PostConfiguracaoModel GetConfiguracaoByTipoEvento(TiposEventoEnum tipoevento);
        IEnumerable<CamposModel> GetCampos(int? id = null);
        void PostCampos(IEnumerable<CamposModel> campos, int? id = null);
        void PostConfiguracao(PostConfiguracaoModel model);
        void PostLogo(int logoId, int Id);
        void PostBackground(int backgroundId, int Id);
        void PostLogoRelatorio(int logoId, int Id);
        void PostBackgroundCelular(int backgroundId, int Id);
    }
}
