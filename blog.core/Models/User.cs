using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace blog.core.Models
{
    public class User
    {
        public User()
        {
            Posts = new Collection<Post>();
        }
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
