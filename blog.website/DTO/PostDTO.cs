using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.website.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public UserDTO User { get; set; }
    }
}
