using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext; 

        public EventoRepository(EventContext Context)
        {
            _eventContext = Context;
        }

        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoExistente = _eventContext.Evento.Find(id); 

                if (eventoExistente != null)
                {
                    eventoExistente.NomeEvento = evento.NomeEvento;
                    eventoExistente.DataEvento= evento.DataEvento;
                    eventoExistente.Descricao= evento.Descricao;

                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex) 
            {

                throw new Exception("Erro ao Atualizar o Evento", ex); 
            }
        }

        public Evento BuscarEventoPorId(Guid id)
        {
            try
            {
                return _eventContext.Evento.Find(id); 

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Buscar o Evento pelo Id!", ex); 
            }
        }

        public Evento BuscarEventoPorNome(string nome)
        {
            try
            {
                return _eventContext.Evento.FirstOrDefault(e => e.NomeEvento == nome); 


            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar o Evento pelo Nome!", ex); 

            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento); 
                _eventContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Cadastrar Evento!", ex); 
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento evento = _eventContext.Evento.Find(id); 

                if (evento != null)
                {
                    _eventContext.Evento.Remove(evento);
                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar o Evento", ex); 
            }
        }

        public List<Evento> ListarEventos()
        {
            try
            {
                return _eventContext.Evento.ToList(); 
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar os Eventos!", ex); 
            }
        }
    }
}
