using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_CRUD.Entities
{
    [Table("Dropdown")]
    public class Dropdown
    {

        [Key()]
        public virtual int genreID { get; set; }
        public virtual string genre { get; set; }
    }


    public class Listados
    {
        public virtual int genreID { get; set; }
        public virtual string genre { get; set; }
    }
}