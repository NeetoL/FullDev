namespace Models.Usuarios
{
    public class UsuarioResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UsuariosModel? Usuario { get; set; }
        public IEnumerable<UsuariosModel>? Usuarios { get; set; }
    }
}
