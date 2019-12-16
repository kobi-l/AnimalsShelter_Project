using AnimalShelter.Code.Events;
using AnimalShelter.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Code.Classes
{
    //public delegate int AnimalNeedsBathHandler(object sender, ShelterActionEventArgs e);
    public delegate int AnimalNeedsBathHandler(IAnimal animal);

    public class Worker
    {
        // defining TWO custom events: 

        // using the GENERIC EventHandler<T> class instead of custom Delegate.

        // GENERIC EventHandler<T> provides a simple way to create a custom delegate for an event.

        // ARE THIS DELEGATES OR EVENTS? OR TWO IN ONE because we are using the EventHandler<T>!!!

        // using the EventArgsClass and EventHandler<T>

        //public event EventHandler<ShelterActionEventArgs> AnimalNeedsBath;
        //public event EventHandler AnimalBeenBathed;

        public event AnimalNeedsBathHandler AnimalNeedsBath;
        public event EventHandler AnimalBeenBathed;

        public void DoBathWork(IAnimal animal)
        {
            OnAnimalNeedsBath(animal);
            OnAnimalBeenBathed();
        }

        // could be protected virtual
        // this method RAISES an EVENT
        private void OnAnimalNeedsBath(IAnimal animal) // 'On' is usually used to indicate what are we raising it on.
        {
            // Raising an EVENT by calling an event like a METHOD:
            //if (AnimalNeedsBath != null)
            //{
            //    AnimalNeedsBath(animal);
            //}

            // OR Raising an EVENT by casting to a delegate:
            //var del = AnimalNeedsBath as AnimalNeedsBathHandler;
            //if (del != null)
            //{
            //    del(animal);
            //}

            // OR Raising an EVENT by casting to a delegate (block above can be replaced by):
            (AnimalNeedsBath as AnimalNeedsBathHandler)?.Invoke(animal);

            // casting an event to a delegate!
            //var del = AnimalNeedsBath as EventHandler<ShelterActionEventArgs>;
            //if (del != null) // Listeners are attached
            //{
            //    //AddAnimalToBathList(animal);
            //    del(this, new ShelterActionEventArgs(animal)); // <-- RAISE EVENT!
            //}
        }

        private void OnAnimalBeenBathed()
        {
            // Raisind an Event by calling it like a method
            //if (AnimalBeenBathed != null)
                //AnimalBeenBathed(this, EventArgs.Empty);

            // OR (same as block above)
            AnimalBeenBathed?.Invoke(this, EventArgs.Empty);


            // OR Raising an EVENT by casting to a delegate: 
            //var del = AnimalBeenBathed as EventHandler;
            //if (del != null) // Listeners are attached
            //{

            //    del(this, EventArgs.Empty); // <-- RAISE EVENT!
            //}
        }

        private void AddAnimalToBathList(IAnimal animal)
        {
            var list = new List<IAnimal>();
            list.Add(animal);
        }

        //private void RemoveAnimalFromBathList(IAnimal animal)
        //{
        //    var list = new List<IAnimal>();
        //    list.Remove(animal);
        //}
    }
}
