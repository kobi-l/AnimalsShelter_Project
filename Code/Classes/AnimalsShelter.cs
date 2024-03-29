﻿using AnimalShelter.Code.Classes;
using AnimalShelter.Code.Enums;
using AnimalShelter.Code.Events;
using AnimalShelter.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.Code
{
    public class AnimalsShelter
    {
        // declare a delegare
        public delegate void AnimalBeenAddedToShelter(IAnimal animal); // AnimalBeenAddedToShelter
        public delegate void AnimalRemovedFromShelter(IAnimal animal);

        // declare event of type delegate
        public event AnimalBeenAddedToShelter AnimalBeenAddedToShelterEvent;
        public event AnimalRemovedFromShelter AnimalRemovedFromShelterEvent;

        public Dictionary<Guid, IAnimal> Animals { get; set; }
        public AnimalsShelter() : this(new Dictionary<Guid, IAnimal>())
        {
        }

        public AnimalsShelter(Dictionary<Guid, IAnimal> animals)
        {
            Animals = animals ?? throw new ArgumentNullException();
        }

        // AddAnimal method that takes an animal object parameter and returns a result object
        public AnimalResult AddAnimal(IAnimal animal)
        {
            var result = false;
            var message = string.Empty;

            //var worker = new ShelterAction();
            //var animalList = new List<IAnimal>();

            if (!IsAnimalSupported(animal))
                message = "Animal is not a supported animal.";
            else
            {
                // call delegate method <-- RAISING AN EVENT!
                //if (AnimalBeenAddedToShelterEvent != null)
                    //AnimalBeenAddedToShelterEvent();

                // OR like this: (null-conditional or 'elvis-operator')
                AnimalBeenAddedToShelterEvent?.Invoke(animal);
                // ??
                //AnimalBeenAddedToShelterEvent?.Invoke(animal);

                // Add animal by Id
                Animals.Add(animal.UniqueAnimalId, animal);



                // And Raise an Event!!!
                //var args = new ShelterActionEventArgs(animal);
                //EventHandler<ShelterActionEventArgs> eventHandler = AnimalNeedsBath;
                //eventHandler(this, args);

                // Are these for listen to an Event?
                //worker.AnimalNeedsBath += (object sender, ShelterActionEventArgs e) => animalList.Add(animal);
                //worker.AnimalBeenBathed += (object sender, EventArgs e) => animalList.Remove(animal);
                //worker.DoBathWork(animal);

                result = true;
            }

            return new AnimalResult(result, animal, message);
        }

        // Check if animal is supported (Cat, Dog, Bird, Snake)
        public bool IsAnimalSupported(IAnimal animal)
        {
            switch (animal.AnimalType)
            {
                case AnimalType.Cat:
                case AnimalType.Dog:
                case AnimalType.Bird:
                case AnimalType.Snake:
                    return true;

                default:
                    return false;
            }
        }

        // A list of filtered animals from the animals stored in the shelter
        public List<IAnimal> GetAnimalsByCriteria(AnimalCriteria animalCriteria)
        {
            switch (animalCriteria)
            {
                case AnimalCriteria.AnimalsThatAreCats:
                    return Animals.Values.Where(a => a.AnimalType == AnimalType.Cat).ToList(); 

                case AnimalCriteria.AnimalsThatAreDogs:
                    return Animals.Values.Where(a => a.AnimalType == AnimalType.Dog).ToList();

                case AnimalCriteria.AnimalsThatCanFly:
                    return Animals.Values.Where(a => a.AnimalCanFly).ToList();

                default:
                    return Animals.Values.ToList();
            };
        }

        // RemoveAnimal method that takes animal object parameter, removes it and returns a result object
        public AnimalResult RemoveAnimal(IAnimal animal)
        {
            var result = false;
            var message = string.Empty;

            if (!Animals.ContainsKey(animal?.UniqueAnimalId ?? Guid.Empty)) // <-- sets Guid to empty if Animal is NULL
                message = "Animal does not exist in the system.";
            else
            {
                Animals.Remove(animal.UniqueAnimalId);
                result = true;

                AnimalRemovedFromShelterEvent?.Invoke(animal);
            }

            return new AnimalResult(result, animal, message);
        }

        // GetAnimalById method that takes animal ID for its parameter and returns a result object
        public AnimalResult GetAnimalById(Guid animalId)
        {
            var result = false;
            IAnimal animal = null;
            var message = string.Empty;

            if (!Animals.ContainsKey(animalId))
                message = "Animal does not exist in the system.";
            else
            {
                animal = Animals[animalId];
                result = true;
            }

            return new AnimalResult(result, animal, message);
        }
    }
}
