using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class SomeEntity
    {
        public int Id { get; set; }
        public string SomeProp1 { get; set; }
        public int SomeProp2 { get; set; }
        public int SomeProp3 { get; set; }
        public virtual List<SamuraiSomeEntity> SamuraiSomeEntities { get; set; }


    }
}