﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Repositories;

namespace Tabloid.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagRepository _tagRepository;
        private readonly UserProfileRepository _userProfileRepository;

        public TagController(ApplicationDbContext context)
        {
            _tagRepository = new TagRepository(context);
            _userProfileRepository = new UserProfileRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tagRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag  = _tagRepository.GetById(id);
            if (tag != null)
            {
                NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public IActionResult Post(Tag tag)
        {
         
            _tagRepository.Add(tag);
            return CreatedAtAction(nameof(Get), new { id = tag.Id }, tag);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _tagRepository.Update(tag);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tagRepository.Delete(id);
            return NoContent();
        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }

    }
}