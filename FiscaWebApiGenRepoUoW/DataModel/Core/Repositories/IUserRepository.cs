namespace DataModel.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUSer(int id);
        User GetAllUsers();
    }
}