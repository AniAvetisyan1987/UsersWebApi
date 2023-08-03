using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersWebApi.Models.Users;

namespace UsersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("AllUsers")]
        public ActionResult AllUsers()
        {
            var allUsers = new List<User>();
            try
            {
                using (var context = new MyUsersContext())
                {
                    allUsers = context.Users.ToList();
                    
                }
                return Ok(allUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User")]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var context = new MyUsersContext();
                var user = context.Users.Find(id);
                return Ok(user);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost("Add")]
        public ActionResult AddUser(Dictionary<string,string> data)
        {
            try
            { 
                var context = new MyUsersContext();
                int a = context.Users.Count();
                var user = new User
                {
                    Id = a+1,
                    Firstname = data["Firstname"],
                    Lastname = data["Lastname"],
                    Age = Int16.Parse(data["Age"]),
                    Gender = Convert.ToBoolean(data["Gender"])
                };
                context.Add(user);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Data);
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var context = new MyUsersContext();
                var user = context.Users.Find(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                        context.SaveChanges();
                }
                return Ok(id);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateUser(int id, Dictionary<string,string> data)
        {
            try
            {
                var context = new MyUsersContext();
                var user = context.Users.First(a => a.Id == id);
                    user.Firstname = data["firstname"];
                    context.SaveChanges();
               
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
