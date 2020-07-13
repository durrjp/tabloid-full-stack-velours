﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabloid.Data;
using Tabloid.Models;

namespace Tabloid.Repositories
{
    public class TagRepository
    {

        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Tag> GetAll()
        {
            return _context.Tag
                .OrderBy(t => t.Name)
                .ToList();
        }
        public Tag GetById(int id)
        {
            return _context.Tag
               .FirstOrDefault(t => t.Id == id);
        }

        public void Add(Tag tag)
        {
            _context.Add(tag);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tag = GetById(id);
            _context.Tag.Remove(tag);
            _context.SaveChanges();
        }
        public void Update(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
