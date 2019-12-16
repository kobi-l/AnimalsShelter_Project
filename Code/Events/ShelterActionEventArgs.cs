using AnimalShelter.Code.Classes;
using AnimalShelter.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Code.Events
{
    public class ShelterActionEventArgs : System.EventArgs
    {
        public ShelterActionEventArgs(IAnimal animal)
        {
            Animal = animal;
        }
        public IAnimal Animal { get; set; }
    }

    /*
        AventArgs class is used when delegate and the event handler takes a ton of parameters!

        It must inherits from System.EventArgs.
     
        It encapsulates data, keeps code cleaner, easier to write, better for maintenance.
     
     */
}
