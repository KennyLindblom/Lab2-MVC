using Microsoft.EntityFrameworkCore;
using NewLab1_MinimalAPI.Data;
using NewLab1_MinimalAPI.Models;

namespace NewLab1_MinimalAPI.Services
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly LibDbContext _context;

        public BookRepository(LibDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddBook(Book newBook)
        {
            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }



        public async Task<Book> DeleteBook(int id)
        {
            var bookToDelete = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                await _context.SaveChangesAsync();
            }
            return bookToDelete;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> SearchForBook(string keyWord)
        {
            List<Book> tempList = await _context.Books
                .Where(b => b.Author.ToLower()
                .Contains(keyWord) ||
                b.Title.ToLower()
                .Contains(keyWord)).ToListAsync();

            if (tempList.Count == 0)
            {
                return null;
            }
            return tempList;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var bookToUpdate = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Author = book.Author;
                bookToUpdate.ReleaseYear = book.ReleaseYear;
                bookToUpdate.IsAvaliabel = book.IsAvaliabel;

                await _context.SaveChangesAsync();
                return bookToUpdate;


            }
            return null;
        }
    }
}
