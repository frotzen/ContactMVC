using ContactMVC.Models;
namespace ContactMVC.Services.Interfaces
{
    public interface IAddressBookService
    {
        public Task AddContactToCategoryAsync(int categoryId, int contactId);
        public Task AddContactToCategoriesAsync(IEnumerable<int> categoryIds, int contactId);
        public Task<bool> IsContactInCategory(int categoryId, int contactId);
        public Task<IEnumerable<Category>> GetAppUserCategoriesAsync(string appUserId);
        public Task RemoveAllContactCategoriesAsync(int contactId);
    }
}
