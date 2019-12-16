using AnimalShelter.Code.Classes;
using AnimalShelter.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.Code.Events
{
    public class ShelterActions
    {
        //private AnimalsShelter Animal { get; set; }
        private List<IAnimal> AnimalsToBath { get; set; }

        public ShelterActions(AnimalsShelter shelter)
        {
            //Animal = new AnimalsShelter();
            AnimalsToBath = new List<IAnimal>();

            // subscribe to AnimalBeenAddedToShelterEvent event
            shelter.AnimalBeenAddedToShelterEvent += HandleAnimalAddedToShelterEvent;
            shelter.AnimalRemovedFromShelterEvent += HandleAnimalRemovedFromShelterEvent;
            //Animal.animalBeenBathed += Animal_animalBeenBathed;
        }

        private void HandleAnimalRemovedFromShelterEvent(IAnimal animal) => RemoveAnimalFromBathList(animal);

        // animalNeedsBath handler
        private void HandleAnimalAddedToShelterEvent(IAnimal animal)
        {
            AddAnimalToBathList(animal);
            // can add more actions inside of this event Handler 
            // OR you can do the same inside the ctor by subscribing to the same event and add 
            // a new Event Handler method!
        }

        public void AddAnimalToBathList(IAnimal animal) => AnimalsToBath.Add(animal);

        public IAnimal GetAnimalFromBathList() => AnimalsToBath.FirstOrDefault();

        // animalBeenBathed handler
        public void RemoveAnimalFromBathList(IAnimal animal) => AnimalsToBath.Remove(animal);


        // ATTACH DELEGATE TO AN EVENT! we use '+=' operator to attach 
        // One way of doing this: 
        // var worker = new Worker();
        // worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
    }
}
