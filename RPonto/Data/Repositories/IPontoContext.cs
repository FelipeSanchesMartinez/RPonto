
namespace RPonto.Data.Repositories
{
    public interface IPontoContext
    {
        Task Atualizar(Ponto model);
        Task Cadastrar(Ponto model);
        Task Init();
        Task<List<Ponto>> ObterPorDia(DateTime data);
        Task<List<Ponto>> ObterPorPeriodo(DateTime dataI, DateTime dataF);
    }
}