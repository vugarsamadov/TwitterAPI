using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public override bool TwoFactorEnabled { get=>false; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool Deleted { get; set; }


        public ICollection<Post> Posts { get; set; }


        public void Delete()
        {
            Deleted = true;
        }

        public void RevokeDelete()
        {
            Deleted = false;
        }
    }
}
