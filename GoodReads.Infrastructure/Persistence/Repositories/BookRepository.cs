﻿using GoodReads.Core.Entities;
using GoodReads.Core.Enum;
using GoodReads.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly GoodReadsContext _context;

        public BookRepository(GoodReadsContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            return book.Id;
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync(string param)
        {
            return await _context.Books
                .Where(b => param.ToLower().Contains(b.Title.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByGenreAsync(Genre genre)
        {
            return await _context.Books
                .Where(b => b.Genre == genre)
                .ToListAsync();
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            return _context.Books
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
