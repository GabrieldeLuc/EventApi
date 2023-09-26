using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void RegistrarPresenca(PresencaEvento presencaEvento); 

        List<PresencaEvento> ListarPresencas();

        PresencaEvento BuscarPresencaPorId(Guid id); 

        void AtualizarPresenca(Guid id, PresencaEvento presencaEvento);

        void DeletarPresenca(Guid id); 
    }
}
