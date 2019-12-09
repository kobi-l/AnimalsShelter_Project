using AnimalShelter.Code;
using FluentAssertions;
using AnimalShelter.Code.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter.Code.Classes;
using System;

namespace AnimalShelter.Tests
{
	[TestClass]
	public class AnimalTypesAndCriteria_Tests
	{
		[TestMethod]
		public void AnymalTypes_KnownTypes_Expected_SixTypes()
		{
			// Arrange
			var animalTypesCount = Enum.GetNames(typeof(AnimalType)).Length;

			// Assert
			animalTypesCount.Should().Be(6);
		}

		[TestMethod]
		public void AnimalCriteria_AvailableCriterias_Expected_FourTypes()
		{
			// Arrange
			var animalCriteriaCount = Enum.GetNames(typeof(AnimalCriteria)).Length;

			// Assert
			animalCriteriaCount.Should().Be(4);
		}
	}
}