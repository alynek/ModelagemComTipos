using Microsoft.AspNetCore.Mvc;
using ModelagemComTipos.Models;

namespace ModelagemComTipos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpGet]
        public void SalvaRetencaoEOrigem()
        {
            var selecaoFiltro = new SelecaoFiltro()
            {
                ServicoId = Guid.NewGuid(),
                Nome = "5 dias",
                Ativo = true,
                DataInicial = DateTime.Now,
                DataFinal = DateTime.Now,
                Departamento= 123
            };

            var origem = new SelecaoFiltroQualquer()
            {
                SelecaoFiltro = selecaoFiltro,
                Chave = "origens",
                Valor = new List<string>() { "web", "whatsapp"}
            };
            
            var retencao = new SelecaoFiltroQualquer()
            {
                SelecaoFiltro = selecaoFiltro,
                Chave = "retencoes",
                Valor = new List<string>() { "sim", "todos"}
            };

            //simulando
            //contexto.origem.salva()
            //contexto.retencao.salva()
        }

        [HttpGet]
        public void SalvaRetencao()
        {
            var selecaoFiltro = new SelecaoFiltro()
            {
                ServicoId = Guid.NewGuid(),
                Nome = "5 dias",
                Ativo = true,
                DataInicial = DateTime.Now,
                DataFinal = DateTime.Now
            };

            var retencao = new SelecaoFiltroQualquer()
            {
                SelecaoFiltro = selecaoFiltro,
                Chave = "retencoes",
                Valor = new List<string>() { "sim", "todos" }
            };

            //contexto.retencao.salva()
        }
        
        [HttpGet]
        public void Salvacategoria(List<SelecaoFiltroCategoria> Categorias)
        {
            var selecaoFiltro = new FiltroCategorias()
            {
                ServicoId = Guid.NewGuid(),
                Nome = "5 dias",
                Ativo = true,
                DataInicial = DateTime.Now,
                DataFinal = DateTime.Now,
                Departamento= 123,
                TipoFiltroRelatorio = TipoFiltroRelatorio.Categorias,
                Categorias = Categorias
            };

            //contexto.retencao.salva()
        }
    }
}
