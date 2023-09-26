using System;
using System.Collections.Generic;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void AdicionarComentario(ComentarioEvento comentarioEvento);
        List<ComentarioEvento> ListarComentariosPorEvento(Guid idEvento);
        ComentarioEvento BuscarComentarioPorId(Guid id);
        void AtualizarComentario(Guid id, ComentarioEvento comentarioEvento);
        void DeletarComentario(Guid id);
    }
}
