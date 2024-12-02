using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;
        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Menu>> GetMenus(Nullable<int> Menu_ID, Nullable<bool> IsActive)
        {
            List<Menu> menuList = null;
            Expression<Func<Menu, bool>> _Filter = r => true;

            if (Menu_ID != null)
            {
                _Filter = Function.AndAlso(_Filter, x => x.Menu_ID == Menu_ID);
            }

            if (IsActive != null)
            {
                _Filter = Function.AndAlso(_Filter, x => x.IsActive == IsActive);
            }

            menuList = await _context.Menu.Where(_Filter).ToListAsync();

            return menuList;
        }


        public async Task AddMenu(Menu menu)
        {
            menu.CreatedDate = DateTime.Now;
            menu.ModifiedDate = DateTime.Now;

            var maxId = await _context.Menu.MaxAsync(p => (int?)p.Menu_ID) ?? 0;

            menu.Menu_ID = maxId + 1;
            await _context.Menu.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMenu(Menu menu)
        {
            var existingMenu = await _context.Menu.FindAsync(menu.Menu_ID);
            if(existingMenu != null)
            {
                if (menu.Menu_Name != null)
                {
                    existingMenu.Menu_Name = menu.Menu_Name;
                }
                if (menu.IsActive != null)
                {
                    existingMenu.IsActive = menu.IsActive;
                }

                existingMenu.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }
    }
}
