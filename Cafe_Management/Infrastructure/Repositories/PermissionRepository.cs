using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;
        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permission>> Get(Nullable<int> Permission_ID, Nullable<bool> IsActive)
        {
            List<Permission> Data = null;
            Expression<Func<Permission, bool>> _Filter = r => true;

            if (Permission_ID != null)
            {
                _Filter = Function.AndAlso(_Filter, x => x.Permission_ID == Permission_ID);
            }

            if (IsActive != null)
            {
                _Filter = Function.AndAlso(_Filter, x => x.IsActive == IsActive);
            }

            Data = await _context.Permission.Where(_Filter).ToListAsync();

            return Data;
        }


        public async Task Create(Permission permission)
        {
            permission.CreatedDate = DateTime.Now;
            permission.ModifiedDate = DateTime.Now;

            var maxId = await _context.Permission.MaxAsync(p => (int?)p.Permission_ID) ?? 0;

            permission.Permission_ID = maxId + 1;
            await _context.Permission.AddAsync(permission);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Permission permission)
        {
            var existingMenu = await _context.Permission.FindAsync(permission.Permission_ID);
            if (existingMenu != null)
            {
                if (permission.Permission_Name != null)
                {
                    existingMenu.Permission_Name = permission.Permission_Name;
                }
                if (permission.IsActive != null)
                {
                    existingMenu.IsActive = permission.IsActive;
                }

                existingMenu.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }
    }
}
