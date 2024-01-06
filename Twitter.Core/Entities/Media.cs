using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Media : BaseEntity
    {

        public string MediaType { get; set; }
        public string Path { get; set; }
        
        public string Alt { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
