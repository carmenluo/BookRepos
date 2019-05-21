using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books;
        public void OnGet()
        {
            Books= _db.Book.ToList();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var deleteItem =await _db.Book.FindAsync(id);
            if (deleteItem == null)
            {
                return null;
            }
            _db.Book.Remove(deleteItem);
            await _db.SaveChangesAsync();
            Message = "Delete successfully";
            return RedirectToPage("Index");
        }
        [TempData]
        public string Message { get; set; }
    }
}