using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Auth2.Infrastructure;
using Auth2.Models;
using Microsoft.AspNet.Identity;

namespace Auth2.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {

        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }
        /// <summary>
        /// 1. Accepts the submitted JSON data and stores it into a binding model.
        /// A binding model is like a viewModel except it is for incoming data. It serves a similar purpose.
        /// 2. Ensures that the model's data is validated.
        /// 3. Creates a new ApplicationUser and then maps the incoming data to that new user.
        /// 4. Runs the UserManager's Create (Async) method to create a new user and store the result in addUserResult.
        /// 5. Checks to make sure addUserResult was successful, if not, return error result.
        /// 6. Returns the Created user object's VIEWMODEL to the client. The VM is inside the ModelFactory Class.
        /// </summary>
        /// <param name="createUserModel"></param>
        /// <returns></returns>
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            //This ModelState.IsValid checks the incoming data against our data annotations
            //that we placed on the properties in CreateUserBindingModel
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Level = 3,
                JoinDate = DateTime.Now.Date,
            };
            //The CreateAsync method automatically checks to make sure that the username is not already in use
            //And that the password is a valid password based upon our specs, etc...
            IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }
    }
}