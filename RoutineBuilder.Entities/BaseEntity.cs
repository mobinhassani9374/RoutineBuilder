using System;
using System.Collections.Generic;
using System.Text;

namespace RoutineBuilder.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
