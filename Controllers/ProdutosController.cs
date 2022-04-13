using APICatalogo.Context;
using APICatalogo.Filter;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

 
        //OBTER PRIMEIRO PRODUTOS
        [HttpGet("/primeiro")]
        public async Task<ActionResult<Produto>> GetPrimeiro()
        {
            var produtos = await _context.Produtos.FirstOrDefaultAsync();
            if (produtos is null)
                return NotFound("Produtos não encontrados."); ;

            return produtos;
        }
        //OBTER LISTA DE PRODUTOS
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();
            if (produtos is null)
                return NotFound("Produtos não encontrados."); ;

            return produtos;
        }
        //OBTER PRODUTO POR ID
        [HttpGet("{id:int:min(1)}", Name="ObterProduto")]  
        public ActionResult<Produto> GetId(int id)
        {
   
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
                return NotFound("Produto não encontrado.");

            return produto;
        }

        ////OBTEM UM PRODUTO UTILIZANDO UM VALOR ALFANUMÉRICO
        //[HttpGet("{valor:alpha:length(4)}")]
        //public ActionResult<Produto> Get2(string valor)
        //{
        //    string? nome = valor;
        //    return _context.Produtos.Find(nome);

        //}




        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();


            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId } , produto );
        }
    

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Verifique o Id do produto informado!");
            }


            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
   
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
                return NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        
        }




    }
}
