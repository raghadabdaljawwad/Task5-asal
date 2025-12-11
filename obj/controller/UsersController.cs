using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new List<User>();

    [HttpGet] // GET /api/users
    public IActionResult GetAll() => Ok(users);

    [HttpGet("{id}")] // GET /api/users/1
    public IActionResult GetById(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost] // POST /api/users
    public IActionResult Create(User user)
    {
        users.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")] // PUT /api/users/1
    public IActionResult Update(int id, User updatedUser)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        user.Age = updatedUser.Age;
        return NoContent();
    }

    [HttpDelete("{id}")] // DELETE /api/users/1
    public IActionResult Delete(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        users.Remove(user);
        return NoContent();
    }
}
