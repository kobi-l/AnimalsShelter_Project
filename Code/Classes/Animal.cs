using AnimalShelter.Code.Enums;
using AnimalShelter.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Code.Classes
{
    public class Animal : IAnimal
    {
        public Guid UniqueAnimalId { get; set; }
        public AnimalType AnimalType { get; }
        public AnimalCriteria AnimalCriteria { get; }

        public Animal(AnimalType animalType)
        {
            UniqueAnimalId = Guid.NewGuid();
            AnimalType = animalType;
            AnimalCriteria = ClassifyByCriteria(animalType);
        }

        private AnimalCriteria ClassifyByCriteria(AnimalType animalType)
        {
            switch (animalType)
            {
                case AnimalType.Cat:
                    return AnimalCriteria.AnimalsThatAreCats;

                case AnimalType.Dog:
                    return AnimalCriteria.AnimalsThatAreDogs;

                case AnimalType.Bird:
                    return AnimalCriteria.AnimalsThatCanFly;

                default:
                    return AnimalCriteria.AllAnimals;
            }
        }
    }
}
