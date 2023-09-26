using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IInstituicaoRepository
    {

        void Cadastrar(Instituicao instituicao);

        List<Instituicao> ListarInstituicoes();

        Instituicao BuscarInstituicaoPorId(Guid id);

        void Atualizar(Guid id, Instituicao instituicao); 

        void Deletar(Guid id); 

    }
}
