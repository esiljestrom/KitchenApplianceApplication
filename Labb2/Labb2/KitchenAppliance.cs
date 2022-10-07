using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class KitchenAppliance : IKitchenAppliance
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        public void Use()
        {
            if(IsFunctioning == true)
            {
                Console.WriteLine($"{Brand} {Type} används!");
            }
            else
            {
                Console.WriteLine($"{Type} är tyävrr trasig...");
            }
        }

        public KitchenAppliance(string type, string brand, char isFunctioning)
        {
            Type = type;
            Brand = brand;
            if(isFunctioning == 'j')
            {
                IsFunctioning = true;
            }
            else
            {
                IsFunctioning = false;
            }
        }
    }
}
