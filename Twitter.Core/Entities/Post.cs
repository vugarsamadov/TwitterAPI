using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Post : BaseEntity
    {
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string Body { get; set; }

        public ICollection<Media> Medias { get; set; }

    }
}
