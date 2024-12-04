using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class PermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<Permission>> Get(Nullable<int> Permission_ID, Nullable<bool> IsActive)
        {
            return await _permissionRepository.Get(Permission_ID, IsActive);
        }

        public async Task Create(Permission permission)
        {
            await _permissionRepository.Create(permission);
        }

        public async Task Update(Permission permission)
        {
            await _permissionRepository.Update(permission);
        }
    }
}
