using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using personelMVC0806.Models.EntityFramework; //tabloları çektik
namespace personelMVC0806.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman>Departmanlar { get; set; } //Depertman ilişkisi kuruyor.
        public Personel Personel { get; set; }

    }
}