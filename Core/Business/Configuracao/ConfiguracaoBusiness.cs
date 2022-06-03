using Core.Models.Configuracao;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utils.Enums;
using Utils.Extensions;

namespace Core.Business.Configuracao
{
    public class ConfiguracaoBusiness : IConfiguracaoBusiness
    {
        private readonly IGenericRepository<Data.Entities.Configuracao> repo;
        private readonly IGenericRepository<ConfiguracaoCampos> camposRepo;

        public ConfiguracaoBusiness(IGenericRepository<Data.Entities.Configuracao> repo, IGenericRepository<ConfiguracaoCampos> camposRepo)
        {
            this.repo = repo;
            this.camposRepo = camposRepo;
        }

        public PostConfiguracaoModel GetConfiguracao(int? id)
        {
            TiposEventoEnum tipoEvento = (TiposEventoEnum)(System.Enum.GetValues(typeof(TiposEventoEnum))).GetValue(0);
            return repo.GetAll(x => id.HasValue ? x.Id == id : x.TipoEvento == tipoEvento).Include(x => x.LogoRelatorio).Include(x => x.BackgroundCelular).Include(x => x.Logo).Include(x => x.Background).ToList().Select(x => new PostConfiguracaoModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                BackgroundId = x.BackgroundId,
                BackgroundCelularId = x.BackgroundCelularId,
                CorBotao = x.CorBotao,
                CorHoverBotao = x.CorHoverBotao,
                CorHoverScroll = x.CorHoverScroll,
                TipoCirculoId= x.TipoCirculo,
                TipoCirculo = x.TipoCirculo.GetDescription(),
                TipoEvento = x.TipoEvento.GetDescription(),
                CorLoginBox = x.CorLoginBox,
                CorScroll = x.CorScroll,
                LogoId = x.LogoId,
                LogoRelatorioId = x.LogoRelatorioId,
                Logo = x.Logo != null ? Convert.ToBase64String(x.Logo.Conteudo) : "",
                Background = x.Background != null ? Convert.ToBase64String(x.Background.Conteudo) : "",
                LogoRelatorio = x.LogoRelatorio != null ? Convert.ToBase64String(x.LogoRelatorio.Conteudo) : "",
                BackgroundCelular = x.BackgroundCelular != null ? Convert.ToBase64String(x.BackgroundCelular.Conteudo) : ""

            }).FirstOrDefault();
        }

        public IEnumerable<CamposModel> GetCampos(int? id)
        {
            TiposEventoEnum tipoEvento = (TiposEventoEnum)(System.Enum.GetValues(typeof(TiposEventoEnum))).GetValue(0);
            return camposRepo.GetAll().Include(x => x.Configuracao).Where(x => id.HasValue ? x.ConfiguracaoId == id : x.Configuracao.TipoEvento == tipoEvento).ToList().Select(x => new CamposModel
            {
                Campo = x.Campo.GetDescription(),
                CampoId = x.Campo,
                Id = x.Id
            });
        }

        public void PostCampos(IEnumerable<CamposModel> campos, int? id)
        {
            TiposEventoEnum tipoEvento = (TiposEventoEnum)(System.Enum.GetValues(typeof(TiposEventoEnum))).GetValue(0);
            var config = repo.GetAll(x => x.TipoEvento == tipoEvento).FirstOrDefault();
            var camposBanco = camposRepo.GetAll().Include(x => x.Configuracao).Where(x => id.HasValue ? x.Configuracao.Id == id : x.Configuracao.TipoEvento == tipoEvento).ToList();

            camposBanco.ForEach(campoBanco =>
            {
                if (!campos.Select(x => x.CampoId).ToList().Any(y => y == campoBanco.Campo))
                {
                    camposRepo.Delete(campoBanco.Id);
                }
            });

            campos.ToList().ForEach(campo =>
            {
                if (!camposBanco.Select(x => x.Campo).ToList().Any(y => y == campo.CampoId))
                {
                    camposRepo.Insert(new Data.Entities.ConfiguracaoCampos
                    {
                        Campo = campo.CampoId,
                        ConfiguracaoId = id.HasValue ? id.Value : config.Id
                    });
                }
            });

            camposRepo.Save();
        }

        public void PostBackground(int backgroundId, int Id)
        {
            Data.Entities.Configuracao configuracao = repo.GetAll(x => x.Id == Id).FirstOrDefault();
            configuracao.BackgroundId = backgroundId;
            repo.Save();
        }

        public void PostConfiguracao(PostConfiguracaoModel model)
        {
            Data.Entities.Configuracao configuracao = repo.GetAll(x => x.Id == model.Id).FirstOrDefault();

            configuracao.CorBotao = model.CorBotao;
            configuracao.TipoCirculo = model.TipoCirculoId;
            configuracao.CorHoverBotao = model.CorHoverBotao;
            configuracao.CorHoverScroll = model.CorHoverScroll;
            configuracao.CorScroll = model.CorScroll;
            configuracao.Titulo = model.Titulo;
            configuracao.CorLoginBox = model.CorLoginBox;
            repo.Update(configuracao);

            repo.Save();
        }

        public void PostLogo(int logoId, int Id)
        {
            Data.Entities.Configuracao configuracao = repo.GetAll(x => x.Id == Id).FirstOrDefault();
            configuracao.LogoId = logoId;
            repo.Save();
        }

        public void PostLogoRelatorio(int logoId, int Id)
        {
            Data.Entities.Configuracao configuracao = repo.GetAll(x => x.Id == Id).FirstOrDefault();
            configuracao.LogoRelatorioId = logoId;
            repo.Save();
        }

        public void PostBackgroundCelular(int backgroundId, int Id)
        {
            Data.Entities.Configuracao configuracao = repo.GetAll(x => x.Id == Id).FirstOrDefault();
            configuracao.BackgroundCelularId = backgroundId;
            repo.Save();
        }

        public IQueryable<Data.Entities.Configuracao> GetConfiguracoes()
        {
            return repo.GetAll().Include(x => x.LogoRelatorio).Include(x => x.BackgroundCelular).Include(x => x.Logo).Include(x => x.Background);
        }

        public PostConfiguracaoModel GetConfiguracaoByTipoEvento(TiposEventoEnum tipoevento)
        {
            return repo.GetAll(x => x.TipoEvento == tipoevento).Include(x => x.LogoRelatorio).Include(x => x.BackgroundCelular).Include(x => x.Logo).Include(x => x.Background).ToList().Select(x => new PostConfiguracaoModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                BackgroundId = x.BackgroundId,
                BackgroundCelularId = x.BackgroundCelularId,
                CorBotao = x.CorBotao,
                CorHoverBotao = x.CorHoverBotao,
                CorHoverScroll = x.CorHoverScroll,
                TipoCirculoId= x.TipoCirculo,
                TipoCirculo = x.TipoCirculo.GetDescription(),
                TipoEvento = x.TipoEvento.GetDescription(),
                CorLoginBox = x.CorLoginBox,
                CorScroll = x.CorScroll,
                LogoId = x.LogoId,
                LogoRelatorioId = x.LogoRelatorioId,
                Logo = x.Logo != null ? Convert.ToBase64String(x.Logo.Conteudo) : "",
                Background = x.Background != null ? Convert.ToBase64String(x.Background.Conteudo) : "",
                LogoRelatorio = x.LogoRelatorio != null ? Convert.ToBase64String(x.LogoRelatorio.Conteudo) : "",
                BackgroundCelular = x.BackgroundCelular != null ? Convert.ToBase64String(x.BackgroundCelular.Conteudo) : ""

            }).FirstOrDefault();
        }
    }
}
