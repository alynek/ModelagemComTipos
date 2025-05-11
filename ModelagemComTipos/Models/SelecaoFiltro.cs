using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelagemComTipos.Models
{
    [Table("Filtro")]
    public class Filtro
    {
        [Key]
        public Guid ServicoId { get; set; }
        public string Nome {  get; set; }
        public TipoFiltroRelatorio TipoFiltroRelatorio {  get; set; }  
        public int Departamento { get; set; }
        public DateTime DataInicial {  get; set; }
        public DateTime DataFinal {  get; set; }
        public bool Ativo {  get; set; }
    }

    //relatorio com rentecao e origem
    //seria responsabilidade da service, instanciar 2 FiltroCustomizado, com Filtro comum as duas
    //aí teria uma origem FiltroCustomizado
    //e teria uma retencao FiltroCustomizado

    //relatorio com retencao
    //seria responsabilidade da service, instanciar 1 FiltroCustomizado, com Filtro

    [Table("FiltroCustomizado")] 
    public class FiltroCustomizado
    {
        [Key]
        public Guid Id { get; set; }
        public string Chave {  get; set; }
        public List<string> Valor {  get; set; }

        [ForeignKey("Filtro")]
        public int FiltroId { get; set; }
        public Filtro Filtro { get; set; }
    }

    public enum TipoFiltroRelatorio
    {
        RetencaoOrigem = 1,
        Retencao = 2,
        Categorias = 3,
        Variaveis = 4
    }


    [Table("FiltrosCategorias")]
    public class FiltroCategorias : Filtro
    {
        public ICollection<FiltroCategorias> Categorias { get; set; } = new List<FiltroCategorias>();
    }


    [Table("FiltroCategoria")]
    public class FiltroCategoria
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [ForeignKey("FiltrosCategorias")]
        public int FiltrosCategoriasId { get; set; }

        public FiltroCategorias FiltroCategorias { get; set; }
    }

    [Table("FiltrosVariaveis")]
    public class FiltrosVariaveis : Filtro
    {
        public ICollection<FiltroVariavel> Variaveis { get; set; } = new List<FiltroVariavel>();
    }


    [Table("FiltroVariavel")]
    public class FiltroVariavel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [ForeignKey("FiltrosVariaveis")]
        public int FiltrosVariaveisId { get; set; }

        public FiltrosVariaveis FiltrosVariaveis { get; set; }
    }

}
