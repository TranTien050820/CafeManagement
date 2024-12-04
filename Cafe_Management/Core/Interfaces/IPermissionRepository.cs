using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> Get(Nullable<int> Permission_ID, Nullable<bool> IsActive);
        Task Create(Permission permission);
        Task Update(Permission permission);
    }
}
