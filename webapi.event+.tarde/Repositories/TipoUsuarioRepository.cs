using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext(); 
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                var TipoUsuarioExistente = _eventContext.TipoUsuario.Find(id);
                if (TipoUsuarioExistente!= null) 
                {
                    TipoUsuarioExistente.Titulo = tipoUsuario.Titulo; 
                    _eventContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o tipo do Usuario!", ex); 
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.TipoUsuario.Find(id); 
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar o tipo do Usuario por Id", ex); 
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar o Tipo de Usuario!", ex); 
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var tipoUsuario = _eventContext.TipoUsuario.Find(id); 
                if ( tipoUsuario != null) 
                {
                    _eventContext.TipoUsuario.Remove(tipoUsuario);
                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar o Tipo de Usuario!", ex); 
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _eventContext.TipoUsuario.ToList(); 

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os tipos de Usuario!", ex); 
            }
        }
    }
}
