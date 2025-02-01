namespace FilasEGuichesApi.Data.Repository
{
    public interface ICrudRepository<T> where T : class

    {
    Task<IEnumerable<T>> ObterTodosAsync();
    Task<T> ObterPorIdAsync(int id);
    Task AdicionarAsync(T entity);
    void Atualizar(T entity);
    void Deletar(T entity);
    Task SalvarAsync();
    }
}
