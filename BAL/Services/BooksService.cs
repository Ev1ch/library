﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using BAL.Models;

namespace BAL.Services
{
    public class BooksService : Service, IBooksService
    {
        public BooksService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(Book book)
        {
            unitOfWork.BooksRepository.Add(mapper.Map<DAL.Entities.Book>(book));
            unitOfWork.Save();
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity => entity.Authors.Any(currentAuthor => currentAuthor.FullName.Contains(author)),
                    IncludeNestedEntities
                    )
                .Select(entity => mapper.Map<Book>(entity));
        }

        public IEnumerable<Book> GetByName(string name)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity => entity.Name.Contains(name),
                    IncludeNestedEntities
                    )
                .Select(entity => mapper.Map<Book>(entity));
        }

        public Book? GetById(int id)
        {
            return mapper.Map<Book>(unitOfWork
                .BooksRepository
                .GetById(
                    id,
                    IncludeNestedEntities
                )
            );
        }

        public IEnumerable<Book> GetByGenre(string genre)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity => entity.Genres.Any(currentGenre => currentGenre.Name.Contains(genre)),
                    IncludeNestedEntities
                )
                .Select(entity => mapper.Map<Book>(entity));
        }

        public IEnumerable<Book> GetBy(GetByFilters filters)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity =>
                    {
                        if (filters.Genre != null && !entity.Genres.Any(genre => genre.Name.Contains(filters.Genre)))
                        {
                            return false;
                        }

                        if (filters.Author != null && !entity.Authors.Any(author => author.FullName.Contains(filters.Author)))
                        {
                            return false;
                        }

                        if (filters.Name != null && !entity.Name.Contains(filters.Name))
                        {
                            return false;
                        }

                        return true;
                    },
                    IncludeNestedEntities
                )
                .Select(entity => mapper.Map<Book>(entity));
        }

        private IQueryable<DAL.Entities.Book> IncludeNestedEntities(IQueryable<DAL.Entities.Book> entities)
        {
            return entities
                .Include(entity => entity.Authors)
                .Include(entity => entity.Genres);
        }
    }
}
