using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        List<Usuario> ListarUsuarios(); 
        Usuario BuscarPorId(Guid id); 

            Usuario BuscarPorEmailESenha(string email, string senha);

        void AtualizarPorId(Guid id, Usuario usuario);

        void Deletar(Guid id); 


    }
}
