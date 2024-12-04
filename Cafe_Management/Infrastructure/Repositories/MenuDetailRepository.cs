using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class MenuDetailRepository : IMenuDetailRepository
    {
        private readonly AppDbContext _context;

        public MenuDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MenuDetail>> GetMenuDetail(int menuId)
        {
            return await _context.MenuDetail
                .Where(pi => pi.Menu_ID == menuId).ToListAsync();
        }

    }
}
