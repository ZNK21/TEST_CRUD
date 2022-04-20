using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_CRUD.Entities
{
    [Table("Dropdown2")]
    public class Dropdown2
    {

        [Key()]
        public virtual int platformID { get; set; }
        public virtual string platform { get; set; }
    }


    public class Listados2
    {
        public virtual int platformID { get; set; }
        public virtual string platform { get; set; }
    }
}