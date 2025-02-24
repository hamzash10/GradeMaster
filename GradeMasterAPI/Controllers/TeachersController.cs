﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradeMasterAPI.Controllers.DB;
using GradeMasterAPI.Controllers.DB.DBModels;
using GradeMasterAPI.Services;
using GradeMasterAPI.DTOs;

namespace GradeMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly GradeMasterDbContext _context;
        ICsvLoader _csvLoader;
        public TeachersController(GradeMasterDbContext context ,ICsvLoader loader)
        {
            _context = context;
            _csvLoader = loader;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            if(_csvLoader!=null)
                _csvLoader.Test();
            return await _context.Teachers.ToListAsync(); //SELECT SQL
        }

        // GET: api/Teachers
        [HttpGet("sorted")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachersSorted()
        {
            return await _context.Teachers.OrderBy(t=>t.LastName).ToListAsync(); //SELECT SQL
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id); //SELECT WHERE

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(TeacherDTO teacherdto)
        {
            Teacher teacher = new Teacher { 
                FirstName = teacherdto.FirstName,
                LastName = teacherdto.LastName,
                Email = teacherdto.Email,
                PhoneNumber = teacherdto.PhoneNumber,
                Password = teacherdto.Password
            };

            //ADD to DB
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            //201
            return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
