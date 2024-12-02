using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> GetMenus(Nullable<int> Menu_ID, Nullable<bool> IsActive)
        {
            return await _menuRepository.GetMenus(Menu_ID, IsActive);
        }

        public async Task AddMenu(Menu menu)
        {
            await _menuRepository.AddMenu(menu);
        }



        public async Task UpdateMenu(Menu menu)
        {
            await _menuRepository.UpdateMenu(menu);
        }
    }
}
