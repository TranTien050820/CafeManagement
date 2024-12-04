using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IMenuDetailRepository
    {
        Task<IEnumerable<MenuDetail>> GetMenuDetail(int Menu_ID);
       // Task AddMenuDetail(MenuDetail menuDetail);
      //  Task UpdateMenuDetail(MenuDetail menuDetail);
    }
}
