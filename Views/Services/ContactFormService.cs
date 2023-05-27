using Views.Contexts;
using Views.Models.Entities;
using Views.ViewModels;

namespace Views.Services
{
    public class ContactFormService
    {
        private readonly IdentityContext _context;

        public ContactFormService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ContactFormModel viewModel)
        {
            try 
            {
                ContactFormEntity contactFormEntity = viewModel;
                await _context.AddAsync(contactFormEntity);
                await _context.SaveChangesAsync();
                return true;
            } 
            catch
            {
                return false;
            }
            

        } 
    }
}
