using AnimalShelter.Code.Classes;
using AnimalShelter.Code.Enums;
using AnimalShelter.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.Code
{
    public class AnimalsShelter
    {
        public Dictionary<Guid, IAnimal> Animals { get; set; }
        public AnimalsShelter()
        {
            Animals = new Dictionary<Guid, IAnimal>();
        }

        // AddAnimal method that takes an animal object parameter and returns a result object
        public AnimalResult AddAnimal(IAnimal animal)
        {
            var result = false;
            var message = string.Empty;

            if (!IsAnimalSupported(animal))
                message = "Animal is not a supported animal.";
            else
            {
                Animals.Add(animal.UniqueAnimalId, animal);
                result = true;
            }

            return new AnimalResult(result, animal, message);
        }

        // Check if animal is supported (Cat, Dog, Bird, Snake)
        public bool IsAnimalSupported(IAnimal animal)
        {
            if (animal.AnimalType != AnimalType.Cat && animal.AnimalType != AnimalType.Dog &&
                animal.AnimalType != AnimalType.Bird && animal.AnimalType != AnimalType.Snake)
                return false;
            else
                return true;
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

        // RemoveAnimal method that takes animal object parameter removes it and returns a result object
        public AnimalResult RemoveAnimal(IAnimal animal)
        {
            var result = false;
            var message = string.Empty;

            if (!Animals.ContainsKey(animal.UniqueAnimalId))
                message = "Animal does not exist in the system.";
            else
            {
                Animals.Remove(animal.UniqueAnimalId);
                result = true;
            }

            return new AnimalResult(result, animal, message);
        }

        // GetAnimaById that takes animal ID for its parameter and returns a result object
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
