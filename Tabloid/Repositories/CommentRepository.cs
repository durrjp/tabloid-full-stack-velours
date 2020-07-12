﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabloid.Data;
using Tabloid.Models;

namespace Tabloid.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Comment> GetAllComments()
        {
            return _context.Comment
                       .Include(c => c.Post)
                       .Include(c => c.UserProfile)
                       .OrderByDescending(c => c.CreateDateTime)
                       .ToList();

        }
        public List<Comment> GetCommentByPostId(int postId)
        {
            return _context.Comment
                       .Include(c => c.Post)
                       .Include(c=>c.UserProfile)
                       .Where(p => p.Id == postId)
                       .OrderByDescending(c=> c.CreateDateTime)
                       .ToList();

        }

        public void Add(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }

      
        public void Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

    }
}