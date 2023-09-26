using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository(EventContext eventContext)
        {
            _eventContext = eventContext;
        }


        public void AdicionarComentario(ComentarioEvento comentarioEvento)
        {
            {
                try
                {
                    _eventContext.ComentarioEvento.Add(comentarioEvento);
                    _eventContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao adicionar comentário no evento.", ex);
                }
            }
        }

        public void AtualizarComentario(Guid id, ComentarioEvento comentarioEvento)
        {
            {
                if (comentarioEvento == null)
                {
                    throw new ArgumentNullException(nameof(comentarioEvento));
                }

                _eventContext.Entry(comentarioEvento).State = EntityState.Modified;
                _eventContext.SaveChanges();
            }

        }

        public ComentarioEvento BuscarComentarioPorId(Guid id)
        {
            {
                try
                {
                    return _eventContext.ComentarioEvento.Find(id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar comentário por ID.", ex);
                }
            }

        }

        public void DeletarComentario(Guid id)
        {
            {
                try
                {
                    ComentarioEvento comentarioEvento = _eventContext.ComentarioEvento.Find(id);

                    if (comentarioEvento != null)
                    {
                        _eventContext.ComentarioEvento.Remove(comentarioEvento);
                        _eventContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao deletar comentário no evento.", ex);
                }
            }
        } 

            public List<ComentarioEvento> ListarComentariosPorEvento(Guid idEvento)
            {
            try
            {
                return _eventContext.ComentarioEvento
                    .Where(c => c.IdEvento == idEvento)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar comentários por evento.", ex);
            }
        }
    }
    }
   
 

       

