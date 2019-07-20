using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class SamuraiSomeEntity
    {
        public int SamuraiId { get; set; }
        public virtual Samurai Samurai { get; set; }
        public int SomeEntityId { get; set; }
        public virtual SomeEntity SomeEntity { get; set; }
    }
}
