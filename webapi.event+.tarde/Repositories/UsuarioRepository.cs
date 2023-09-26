using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void AtualizarPorId(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioExistente = _eventContext.Usuario.Find(id);

                if (usuarioExistente != null) 
                {
                usuarioExistente.Nome = usuario.Nome;
                    usuarioExistente.Email= usuario.Email;
                    usuarioExistente.Senha=  Criptografia.GerarHash(usuario.Senha);

                    _eventContext.SaveChanges();

                }
                

                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Usuario.", ex); 
            }
            
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario

                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario, 
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }

            catch (Exception)
            {

                throw;
            }
        }

       

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuario = _eventContext.Usuario.Find(id); 

                if (usuario != null) 
                {
                _eventContext.Usuario.Remove(usuario);
                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar Usuario", ex); 
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                return _eventContext.Usuario.ToList(); 
            }
            catch (Exception ex) 
            {

                throw new Exception("Erro ao listar Usuario", ex); 
            }
        }
    }
}