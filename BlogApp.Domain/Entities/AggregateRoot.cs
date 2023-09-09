using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
      public string EXId 
    }
}
