namespace NobelApi.Controllers
{
    public class FiliacaoDTO
    {
        public int FiliacaoId { get; set; }
        public string Nome { get; set; }
        public virtual CidadeDTO Cidade { get; set; }
    }
}