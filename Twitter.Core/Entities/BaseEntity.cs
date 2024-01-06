using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        
        public bool Deleted { get; set; } = false;

        public void Delete()
        {
            Deleted = true;
        }

        public void RevokeDelete()
        {
            Deleted = false;
        }
    }

    public interface IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public bool Deleted { get; set; }

        public void Delete();
        public void RevokeDelete();

    }
}
