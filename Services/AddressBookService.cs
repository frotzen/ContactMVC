using ContactMVC.Data;
using ContactMVC.Models;
using ContactMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactMVC.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly ApplicationDbContext _context;

        public AddressBookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddContactToCategoriesAsync(IEnumerable<int> categoryIds, int contactId)
        {
            try
            {
                Contact? contact = await _context.Contacts.FindAsync(contactId);

                foreach (int categoryId in categoryIds)
                {
                    Category? category = await _context.Categories.FindAsync(categoryId);

                    if(category != null && contact != null)
                    {
                        contact.Categories.Add(category);
                    }
                }

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddContactToCategoryAsync(int categoryId, int contactId)
        {
            try
            {
                // Check to see if contact is already in the category
                if (!await IsContactInCategory(categoryId, contactId))
                {
                    // if not, Add the category to the contact's collection
                    Contact? contact = await _context.Contacts.FindAsync(contactId);
                    Category? category = await _context.Categories.FindAsync(categoryId);

                    if (contact != null && category != null)
                    {
                        category.Contacts.Add(contact);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetAppUserCategoriesAsync(string appUserId)
        {
            List<Category> categories = new List<Category>();
            try
            {
                categories = await _context.Categories.Where(c => c.AppUserId == appUserId)
                                                      .OrderBy(c => c.Name)
                                                      .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return categories;
        }

        public async Task<bool> IsContactInCategory(int categoryId, int contactId)
        {
            Contact? contact = await _context.Contacts.FindAsync(contactId);

            bool isInCategory = await _context.Categories
                                 .Include(c => c.Contacts)
                                 .Where(c => c.Id == categoryId && c.Contacts.Contains(contact!))
                                 .AnyAsync();
            
            return isInCategory;
        }

        public async Task RemoveAllContactCategoriesAsync(int contactId)
        {
            try
            {
                Contact? contact = await _context.Contacts
                                         .Include(c => c.Categories)
                                         .FirstOrDefaultAsync(c => c.Id == contactId);

                contact!.Categories.Clear();
                _context.Update(contact);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
