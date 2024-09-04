using GoodReads.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            Status = Status.Active;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Status Status { get; private set; }
    }
}
