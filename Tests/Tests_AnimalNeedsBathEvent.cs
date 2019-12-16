using AnimalShelter.Code;
using AnimalShelter.Code.Classes;
using AnimalShelter.Code.Enums;
using AnimalShelter.Code.Events;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Tests
{
    [TestClass]
    public class Tests_AnimalActions_EventsTests
    {
        [TestMethod]
        public void AddAnimal_TriggersEvent_Test()
        {
            // Arrange
            var animal = new Animal(AnimalType.Cat);
            var shelter = new AnimalsShelter();
            var actionShelter = new ShelterActions(shelter);
            
            // Act
            shelter.AddAnimal(animal);
            var animalInBathList = actionShelter.GetAnimalFromBathList();

            // Assert
            // by animal type
            animalInBathList.AnimalType.Should().Be(AnimalType.Cat);

            // by animal Id
            animalInBathList.UniqueAnimalId.Should().Be(animal.UniqueAnimalId);

            // by comparing animal objects
            Assert.AreEqual(animal, animalInBathList);
        }

        [TestMethod]
        public void RemoveAnimal_Triggers_HandleAnimalRemovedFromShelterEvent_()
        {
            // Arrange
            var animal = new Animal(AnimalType.Cat);
            var shelter = new AnimalsShelter();
            var actionShelter = new ShelterActions(shelter);

            // Act
            shelter.AddAnimal(animal);
            var animalInBathList = actionShelter.GetAnimalFromBathList();
            animalInBathList.UniqueAnimalId.Should().Be(animal.UniqueAnimalId);

            shelter.RemoveAnimal(animal);
            animalInBathList = actionShelter.GetAnimalFromBathList();

            // Assert
            animalInBathList.Should().BeNull();
        }
    }
}
