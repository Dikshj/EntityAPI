using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {

         private readonly DatabaseService _databaseService;

        public EntityController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // Mock data source
        private readonly List<Entity> _entities = MockData.Entities;

        // GET /entity
        [HttpGet]
        public ActionResult<IEnumerable<Entity>> GetEntities(
            [FromQuery] string search,
            [FromQuery] string gender,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] List<string> countries,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Id",
            [FromQuery] bool descending = false)
        {
            IQueryable<Entity> query = _entities.AsQueryable();

            // Search entities
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.Addresses.Any(a => a.AddressLine?.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                                          a.Country?.Contains(search, StringComparison.OrdinalIgnoreCase) == true) ||
                    e.Names.Any(n => n.FirstName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                                     n.MiddleName?.Contains(search, StringComparison.OrdinalIgnoreCase) == true ||
                                     n.Surname?.Contains(search, StringComparison.OrdinalIgnoreCase) == true));
            }

            // Filter entities
            if (!string.IsNullOrWhiteSpace(gender))
            {
                query = query.Where(e => e.Gender == gender);
            }

            if (startDate.HasValue)
            {
                query = query.Where(e => e.Dates.Any(d => d.DateValue >= startDate));
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.Dates.Any(d => d.DateValue <= endDate));
            }

            if (countries?.Any() == true)
            {
                query = query.Where(e => e.Addresses.Any(a => countries.Contains(a.Country)));
            }

            // Sorting
            query = descending ? query.OrderByDescending(sortBy) : query.OrderBy(sortBy);

            // Pagination
            var entities = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(entities);
        }

        // GET /entity/{id}
        [HttpGet("{id}")]
        public ActionResult<Entity> GetEntityById(string id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
    }
}
