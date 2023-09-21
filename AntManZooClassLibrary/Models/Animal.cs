using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntManZooClassLibrary.Models
{
    public class Animal
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Description { get; set; }

        public string? ImageLink { get; set; }

        public Species Species { get; set; }

    }

    public enum Species

    {
        None,
        Loup,
        Ours,
        Lion,
        Cheval,
        Requin,
        Perruche
    }

}
