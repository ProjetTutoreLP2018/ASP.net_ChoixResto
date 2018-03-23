using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal : IDisposable
    {
        List<Resto> ObtientTousLesRestaurants ();
        void CreerRestaurant (string nom, string telephone);
        void ModifierRestaurant (int id, string nom, string telephone);
    }  
}