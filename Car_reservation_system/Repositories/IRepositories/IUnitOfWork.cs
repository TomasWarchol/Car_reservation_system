namespace Car_reservation_system.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ICarRepository Car { get; }
        Task SaveAsync();
    }
}
