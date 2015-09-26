using MyStore.Infra.Persistence.Contexts;

namespace MyStore.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStoreDataContext _context;

        public UnitOfWork(MyStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Não faz nada :)
        }
    }
}
