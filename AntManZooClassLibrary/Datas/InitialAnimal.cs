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
            new Animal{ Id = 1, Name = "Balto", Age = 6, Description = "Balto le héros !", ImageLink = "https://www.sciencesetavenir.fr/assets/img/2023/04/25/cover-r4x3w1200-6447e451a984d-balto-kasson.jpg", Species = Species.Loup },

            new Animal{ Id = 2, Name = "Ponyta", Age = 12, Description = "Très beau cheval de feu", ImageLink = "https://i.ytimg.com/vi/vbb0oUNE65o/sddefault.jpg", Species = Species.Cheval },

            new Animal{ Id = 3, Name = "Winnie", Age = 3, Description = "Un ours originaire de Springfield", ImageLink = "https://media.gq.com/photos/596cf8527bf9083f8bf881b8/16:9/w_1280,c_limit/winnie-the-pooh-ban-china.jpg", Species = Species.Ours },

            new Animal{ Id = 4, Name = "Jamie", Age = 41, Description = "Un très beau lion à qui il manque une patte", ImageLink = "https://cdn.images.express.co.uk/img/dynamic/20/590x/secondary/Game-of-Thrones-Jaime-was-trapped-with-his-cousin-1864452.jpg?r=1558125976497", Species = Species.Lion},

            new Animal{ Id = 5, Name = "Bouftou", Age = 110, Description = "Il bouffe tout", ImageLink = "https://static.cnews.fr/sites/default/files/000_8vq76v_5fbcea50c8137.jpg", Species = Species.Requin },

            new Animal{ Id = 6, Name = "Parrot", Age = 2, Description = "Une belle perruche dedju !", ImageLink = "https://www.fermeexotique.fr/public/img/medium/nos-animaux-afrique53eb4cd7bb705.jpg", Species = Species.Perruche },
        };
    }
}
