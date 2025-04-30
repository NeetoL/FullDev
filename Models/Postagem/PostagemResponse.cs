namespace Models.Postagem
{
    public class PostagemResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public IEnumerable<PostagemModel>? Postagens { get; set; }
    }
}
