using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEST_CRUD.Entities //Se especifica que este sector es la entidad Games
{
    [Table("Games")]  //Se indica que se usa la tabla "Games"
    public class Games
    {
        [Key()] //Se indica que el valor de abajo es la PrimaryKey
        public int gameId { get; set; } //Se declara el entero del gameId con propiedad de lectura y escritura
        public string gameName { get; set; }
        public DateTime? launchDate { get; set; }
        public string genre { get; set; }
        public decimal price { get; set; }
    }
}
