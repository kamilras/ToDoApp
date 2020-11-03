using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa.ViewModel
{
    public class NewTaskViewModel
    {
        [Required(ErrorMessage = "zadanie musi mieć tytuł!")]
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
