using System.Xml.Linq;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {

        private readonly EventContext _eventContext;

        public InstituicaoRepository(EventContext Context)
        {
            _eventContext = Context;
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                var instituicaoExistente = _eventContext.Instituicao.Find(id); 
                if (instituicaoExistente != null) 
                {
                    instituicaoExistente.NomeFantasia = instituicao.NomeFantasia;
                    instituicaoExistente.Endereco = instituicao.Endereco;
                    instituicaoExistente.CNPJ = instituicao.CNPJ;

                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar Instituição!", ex); 
            }
        }

        public Instituicao BuscarInstituicaoPorId(Guid id)
        {
            try
            {
                return _eventContext.Instituicao.Find(id); 
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar a Instituição!", ex); 
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao); 
                _eventContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Instituição!", ex); 
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var instituicao = _eventContext.Instituicao.Find(id);
                if (instituicao != null)
                {
                    _eventContext.Instituicao.Remove(instituicao); 
                    _eventContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao deletar instituição!", ex);
            }
        }

        public List<Instituicao> ListarInstituicoes()
        {
            try
            {
                return _eventContext.Instituicao.ToList(); 

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar instituições", ex); 
            }
        }
    }
}
