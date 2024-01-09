using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.Media;

namespace Twitter.Business.Dtos.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Body { get; set; }
        public ICollection<MediaDto> Medias { get; set; }
    }
}
