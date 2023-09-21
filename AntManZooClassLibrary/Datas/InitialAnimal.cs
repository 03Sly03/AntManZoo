using AntManZooClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntManZooClassLibrary.Datas
{
    public class InitialAnimal
    {
        public static readonly List<Animal> animals = new List<Animal>()
        {
            new Animal{ Id = 1, Name = "Balto", Age = 6, Description = "Balto le héros !", ImageLink = null, Species = Species.Loup },

            new Animal{ Id = 2, Name = "Ponyta", Age = 12, Description = "Très beau cheval de feu", ImageLink = null, Species = Species.Cheval },

            new Animal{ Id = 3, Name = "Winnie", Age = 3, Description = "Un ours originaire de Springfield", ImageLink = null, Species = Species.Ours },

            new Animal{ Id = 4, Name = "Jamie", Age = 41, Description = "Un très beau lion à qui il manque une patte", ImageLink = null, Species = Species.Lion},

            new Animal{ Id = 5, Name = "Bouftou", Age = 110, Description = "Il bouffe tout", ImageLink = null, Species = Species.Requin },

            new Animal{ Id = 6, Name = "Parrot", Age = 2, Description = "Une belle perruche dedju !", ImageLink = null, Species = Species.Perruche },
        };
    }
}
