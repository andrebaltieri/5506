namespace MyStore.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
