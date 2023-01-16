using API_Tutorial.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        List<Friend> friends = new List<Friend>(){
            new Friend(1,"Kindson", "Munonye", "Budapest", DateTime.Today),
            new Friend(2,"Oleander", "Yuba", "Nigeria", DateTime.Today),
            new Friend(3,"Saffron", "Lawrence", "Lagos", DateTime.Today),
            new Friend(4,"Jadon", "Munonye", "Asaba", DateTime.Today),
            new Friend(5,"Solace", "Okeke", "Oko", DateTime.Today)
        };

        // GET: api/<FriendController>
        [HttpGet]
        public List<Friend> Get()
        {
            return friends;
        }

        // GET api/<FriendController>/5
        [HttpGet("{id}")]
        public Friend Get(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            return friend;
        }

        // POST api/<FriendController>
        [HttpPost]
        public List<Friend> Post([FromBody] Friend friend)
        {
            friends.Add(friend);
            return friends;
        }

        // PUT api/<FriendController>/5
        [HttpPut("{id}")]
        public List<Friend> Put(int id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = friends.Find(f => f.id == id);
            int index = friends.IndexOf(friendToUpdate);

            friends[index].firstname = friend.firstname;
            friends[index].lastname = friend.lastname;
            friends[index].location = friend.location;
            friends[index].dateOfHire = friend.dateOfHire;

            return friends;
        }

        // DELETE api/<FriendController>/5
        [HttpDelete("{id}")]
        public List<Friend> Delete(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            friends.Remove(friend);
            return friends;
        }
    }
}
