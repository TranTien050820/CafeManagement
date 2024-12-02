using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetMenus(Nullable<int> Menu_ID, Nullable<bool> IsActive);
        Task AddMenu(Menu menu);
        Task UpdateMenu(Menu menu);
    }
}
