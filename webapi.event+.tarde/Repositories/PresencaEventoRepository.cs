using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {

        private readonly EventContext _eventContext; 

        public PresencaEventoRepository (EventContext eventContext)
        {
            _eventContext= eventContext;
        }
        public void AtualizarPresenca(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                PresencaEvento presencaExistente= _eventContext.PresencaEvento.Find(id);

                if (presencaExistente != null) 
                {
                    presencaExistente.IdEvento = presencaEvento.IdEvento;
                    presencaExistente.IdUsuario = presencaEvento.IdUsuario; 

                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex) 
            {

                throw new Exception("Erro ao Atualizar Presença", ex); 
            }
        }

        public PresencaEvento BuscarPresencaPorId(Guid id) 
        {
            try
            {
                return _eventContext.PresencaEvento.Find(id); 
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar presença no evento por ID", ex); 
            }
        }

        

        public void DeletarPresenca(Guid id)
        {
            try
            {
                PresencaEvento presencaEvento = _eventContext.PresencaEvento.Find(id);

                if (presencaEvento!= null)
                {
                    _eventContext.PresencaEvento.Remove(presencaEvento); 
                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex) 
            {

                throw new Exception ("Erro ao deletar Presença." , ex); 
            }
        }

        public List<PresencaEvento> ListarPresencas()
        {
            try
            {
                return _eventContext.PresencaEvento.ToList();
            }
            catch (Exception ex) 
            {

                throw new Exception("Erro ao listar as presenças de evento", ex); 

            }
        }

        public void RegistrarPresenca(PresencaEvento presencaEvento)
        {
            try
            {
                _eventContext.PresencaEvento.Add(presencaEvento); 
                _eventContext.SaveChanges();
            }
            catch (Exception ex) 
            {

                throw new Exception("Erro ao registrar Presença", ex); 
            }
        }
    }
}
