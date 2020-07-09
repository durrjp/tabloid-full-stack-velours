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

        public List<Comment> GetCommentByPostId(int postId)
        {
            return _context.Comment
                       .Include(c=>c.Post)
                       .ThenInclude(c=>c.UserProfile)
                       .Where(p => p.Id == postId)
                       .OrderByDescending(c=> c.CreateDateTime)
                       .ToList();

        }

        public void Add(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
        }
    
}
}
