namespace Models.Login
{
    public class SignInModel
    {
        public int cd_usuario { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? telefone { get; set; }
        public string? endereco { get; set; }
        public string? nome { get; set; }
        public string? sobrenome { get; set; }
    }
}
