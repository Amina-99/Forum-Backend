using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTask.Models.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
