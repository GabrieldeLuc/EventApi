using webapi.event_.tarde.Domains;


namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);

        List<Evento> ListarEventos();

        Evento BuscarEventoPorId(Guid id); 

        Evento BuscarEventoPorNome (string nome);
        void Deletar(Guid id);
        void Atualizar(Guid id, Evento evento);
    }
}
