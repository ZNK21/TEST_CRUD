using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TEST_CRUD.Models
{
    public class DropdownModels
    {
        public virtual int genreID { get; set; }
        public virtual string genre { get; set; }
        public List<SelectListItem> ListGenre { get; set; }
    }

    public class Dropdown2Models
    {
        public virtual int platformID { get; set; }
        public virtual string platform { get; set; }
    }
}
