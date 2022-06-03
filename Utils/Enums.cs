using System;
using System.ComponentModel;

namespace Utils.Enums
{
    public enum TipoCirculoEnum
    {
        [Description("Endereco")]
        Endereco,
        [Description("Aleatório")]
        Aleatorio,
        [Description("Idade")]
        Idade,
    }

    public enum TipoPessoaEnum
    {
        [Description("Equipante")]
        Equipante,
        [Description("Participante")]
        Participante
    }
    public enum CamposEnum
    {
        [Description("Email")]
        Email,
        [Description("Nome Completo")]
        Nome,
        [Description("Apelido")]
        Apelido,
        [Description("Gênero")]
        Genero,
        [Description("Data Nascimento")]
        DataNascimento,
        [Description("Fone")]
        Fone,
        [Description("Instagram")]
        Instagram,
        [Description("Camisa")]
        Camisa,
        [Description("Profissão")]
        Profissao,
        [Description("Endereço")]
        Endereco,
        [Description("Dados da Mãe")]
        Mae,
        [Description("Dados do Pai")]
        Pai,
        [Description("Dados do Contato")]
        Contato,
        [Description("Dados do Convite")]
        Convite,
        [Description("Ônibus")]
        Onibus,
        [Description("Parente")]
        Parente,
        [Description("Congregação")]
        Congregacao,
        [Description("Alergia")]
        Alergia,
        [Description("Medicação")]
        Medicacao,
        [Description("Restrição Alimentar")]
        Restricao,


    }
    public enum StatusEnum
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Inativo")]
        Inativo = 2,
        [Description("Deletado")]
        Deletado = 3,
        [Description("Aberto")]
        Aberto = 4,
        [Description("Quitado")]
        Quitado = 5,
        [Description("Cancelado")]
        Cancelado = 6,
        [Description("Encerrado")]
        Encerrado = 7,
        [Description("Inscrito")]
        Inscrito = 8,
        [Description("Confirmado")]
        Confirmado = 9,
        [Description("Em Espera")]
        Espera = 10
    }

    public enum SexoEnum
    {
        [Description("Masculino")]
        Masculino = 1,
        [Description("Feminino")]
        Feminino = 2
    }

    public enum EquipesEnum
    {
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Reitor(a)")]
        Reitor = 1,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Base")]
        Base = 2,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Auxiliar Sala")]
        AuxiliarSala = 3,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Ligação Interna Sala")]
        LigInternaSala = 4,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Bem Estar")]
        BemEstar = 5,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Liturgia")]
        Liturgia = 6,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Sala")]
        Sala = 7,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Decúrias")]
        Decuria = 8,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Sineteria")]
        Sineteria = 9,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Louvor")]
        Louvor = 10,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Loja Conveniência")]
        Loja = 11,
        [TipoEquipe(TipoEquipeEnum.Sala)]
        [Description("Vigília")]
        Vigilia = 12,       

        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Coordenador(a)")]
        Coordenador = 13,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Auxiliar Serviço")]
        AuxiliarServico = 14,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Ligação Interna Serviço")]
        LigInternaServico = 15,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Cozinha")]
        Cozinha = 16,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Refeitório")]
        Refeitorio = 17,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Lanche")]
        Lanche = 18,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Almoxerifado")]
        Almoxerifado = 19,
        [TipoEquipe(TipoEquipeEnum.Servico)]
        [Description("Ordem")]
        Ordem = 20,

        [TipoEquipe(TipoEquipeEnum.Inscricoes)]
        [Description("Secretaria")]
        Secretaria = 21,

        [TipoEquipe(TipoEquipeEnum.Secretariado)]
        [Description("Secretariado")]
        Secretariado = 22,

        [TipoEquipe(TipoEquipeEnum.Clero)]
        [Description("Arcebispo")]
        Arcebispo = 23,
        [TipoEquipe(TipoEquipeEnum.Clero)]
        [Description("Bispo")]
        Bispo = 24,
        [TipoEquipe(TipoEquipeEnum.Clero)]
        [Description("Clérigos")]
        Clerigos = 25,
        [TipoEquipe(TipoEquipeEnum.Clero)]
        [Description("Ministros Comissionados")]
        Ministros = 26,

        [TipoEquipe(TipoEquipeEnum.Rollistas)]
        [Description("Rollistas")]
        Rollistas = 27,
    }

    public enum TiposEventoEnum
    {
        [Nickname("Cursilho Masculino")]
        [Description("Cursilho Masculino")]
        [Genero(SexoEnum.Masculino)]
        Masculino = 1,
        [Nickname("Cursilho Feminino")]
        [Description("Cursilho Feminino")]
        [Genero(SexoEnum.Feminino)]
        Feminino = 2,
    }

    public enum BancosEnum
    {
        [Description("Bradesco")]
        Bradesco = 1,
        [Description("Santander")]
        Santander = 2,
        [Description("Itaú")]
        Itau = 3,
        [Description("Caixa")]
        Caixa = 4,
        [Description("Banco do Brasil")]
        BancoBrasil = 5,
        [Description("NuBank")]
        Nubank = 6,
        [Description("Banco Inter")]
        Inter = 7,
        [Description("HSBC")]
        HSBC = 8
    }

    public enum TiposEquipeEnum
    {
        [Description("Coordenador")]
        Coordenador = 1,
        [Description("Membro")]
        Membro = 2
    }

    public enum PerfisUsuarioEnum
    {
        [Description("Master")]
        Master,
        [Description("Admin")]
        Admin,
        [Description("Coordenador")]
        Coordenador,
        [Description("Secretaria")]
        Secretaria,
    }

    public enum TiposLancamentoEnum
    {
        [Description("Receber")]
        Receber = 1,
        [Description("Pagar")]
        Pagar = 2
    }

    public enum TiposCentroCustoEnum
    {
        [Description("Receita")]
        Receita = 1,
        [Description("Despesa")]
        Despesa = 2
    }

    public enum CentroCustoPadraoEnum
    {
        [Description("Inscrições")]
        Inscricoes = 1,
        [Description("Taxa de Equipante")]
        TaxaEquipante = 2
    }

    public enum ValoresPadraoEnum
    {
        [Description("Inscrições")]
        Inscricoes = 300,
        [Description("Taxa de Equipante")]
        TaxaEquipante = 150
    }

    public enum MeioPagamentoPadraoEnum
    {
        [Description("Pix")]
        Transferencia,
        [Description("Dinheiro")]
        Dinheiro,
        [Description("Isenção")]
        Isencao
    }

    public enum CoresEnum
    {
        [Description("Vermelho")]
        Vermelho,
        [Description("Laranja")]
        Laranja,
        [Description("Rosa")]
        Rosa,
        [Description("Azul Claro")]
        AzulClaro,
        [Description("Azul Escuro")]
        AzulEscuro,
        [Description("Verde Claro")]
        VerdeClaro,
        [Description("Verde Escuro")]
        VerdeEscuro,
        [Description("Amarelo")]
        Amarelo,
        [Description("Cinza")]
        Cinza,
        [Description("Lilás")]
        Lilas
    }

    public enum TipoEquipeEnum
    {
        [Description("Sala")]
        Sala,
        [Description("Serviço")]
        Servico,
        [Description("Clero")]
        Clero,
        [Description("Secretariado")]
        Secretariado,
        [Description("Rollistas")]
        Rollistas,
        [Description("Inscrições")]
        Inscricoes,
    }

    internal class NicknameAttribute : Attribute
    {
        public virtual string Nickname { get; }

        public NicknameAttribute(string Nickname)
        {
            this.Nickname = Nickname;
        }
    }

    internal class TipoEquipeAttribute : Attribute
    {
        public virtual TipoEquipeEnum TipoEquipe { get; }

        public TipoEquipeAttribute(TipoEquipeEnum TipoEquipe)
        {
            this.TipoEquipe = TipoEquipe;
        }
    }

    internal class GeneroAttribute : Attribute
    {
        public virtual SexoEnum Genero { get; }

        public GeneroAttribute(SexoEnum Genero)
        {
            this.Genero = Genero;
        }
    }

    internal class EmailPagSeguroAttribute : Attribute
    {
        public virtual string EmailPagSeguro { get; }

        public EmailPagSeguroAttribute(string EmailPagSeguro)
        {
            this.EmailPagSeguro = EmailPagSeguro;
        }
    }

    internal class TokenPagSeguroAttribute : Attribute
    {
        public virtual string TokenPagSeguro { get; }

        public TokenPagSeguroAttribute(string TokenPagSeguro)
        {
            this.TokenPagSeguro = TokenPagSeguro;
        }
    }
}