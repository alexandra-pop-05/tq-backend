
using TQ_Project.Domain.Entities;

namespace TQ_Project.Domain.Interfaces
{
    public interface IUser : IGeneric<User>
    {
        Task<User>? GetByEmail(string email);
    }
}
