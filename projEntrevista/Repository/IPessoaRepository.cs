using projEntrevista.Models;


namespace projEntrevista.Repository
{
    public interface IPessoaRepository
    {
        public PessoaModels[] GetAll();
        public PessoaModels GetById(int id);
        public void Insert(PessoaModels pessoa);
        public void Update(int id, PessoaModels pessoa);
        public void Delete(int id);
    }
}
