﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookListRazor.Pages.BookList
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public Book Book { get; set; }
        public void OnGet()
        {

        }
        [TempData]
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
             _db.Book.Add(Book);
            await _db.SaveChangesAsync();
            Message = "Book created successfully.";
            return RedirectToPage("Index");
        }
    }
}