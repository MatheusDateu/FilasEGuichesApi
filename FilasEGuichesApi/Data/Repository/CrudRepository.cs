using Microsoft.EntityFrameworkCore;

namespace FilasEGuichesApi.Data.Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        #region Propriedades

        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region Construtores

        public CrudRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #endregion

        #region Metodos de Crud

        public async Task<IEnumerable<T>> ObterTodosAsync() => await _dbSet.ToListAsync();

        public async Task<T> ObterPorIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Atualizar(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Deletar(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SalvarAsync() => await _context.SaveChangesAsync();

        #endregion
    }
}
