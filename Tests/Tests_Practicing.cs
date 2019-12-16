using AnimalShelter.Code;
using AnimalShelter.Code.Classes;
using AnimalShelter.Code.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AnimalShelter.Tests
{
    [TestClass]
    public class Tests_Practicing
    {
        [TestMethod]
        [Owner("KobiL")]
        [Priority(0)]
        public void NameYourTest()
        {
            // this would be incomplete test
            Assert.Inconclusive();
        }

        [TestMethod]
        [Owner("KobiL")]
        public void NameYourTest1()
        {
            // this would be incomplete test
            Assert.Inconclusive();
        }

        [TestMethod]
        [Owner("KobiL")]
        public void NameYourTest2()
        {
            // this would be incomplete test
            Assert.Inconclusive();
        }

        [TestMethod]
        [Owner("KobiL")]
        //[Ignore()]
        [Priority(0)]
        [Description("Testing if exception was thrown using the ExpectedException way")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionWasThrownUsingThe_ExpectedException()
        {
            new AnimalsShelter(null);

            Assert.Fail("Exception wasn't thrown.");
        }

        [TestMethod]
        [Owner("KobiL")]
        //[Ignore()]
        [Priority(0)]
        [Description("Testing if exception was thrown using the TryAndCatch way")]
        public void ExceptionWasThrownUsingThe_TryAndCatch()
        {
            try
            {
                new AnimalsShelter(null); // run with NULL parameter to get an exception
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Exception wasn't thrown.");
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(1)]
        [Description("Testing Strings using AreEqual for CaseInsensitive")]
        public void TestingStrings_AreEqual_CaseInsensitive_Test()
        {
            string name1 = "Tom";
            string name2 = "tom";

            Assert.AreEqual(name1, name2, true); // adding Third parameter ignores the case
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(1)]
        [Description("Testing Object Types, using AreSame")]
        public void ObjectTypes_AreSame_Test()
        {
            var shelter = new AnimalsShelter();
            var  x = shelter;

            Assert.AreSame(shelter, x);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Description("Testing Object Types, using AreNotSame")]
        public void ObjectTypes_AreNotSame_Test()
        {
            var y = new AnimalsShelter();
            var x = new AnimalsShelter();

            Assert.AreNotSame(y, x);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(1)]
        [Description("Testing Object Types, using IsInstanceOfType")]
        public void ObjectTypes_IsInstanceOfType_Test()
        {
            var y = new AnimalsShelter();

            Assert.IsInstanceOfType(y, typeof(AnimalsShelter));
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(1)]
        [Description("Testing Object Types, using IsNotInstanceOfType")]
        public void ObjectTypes_IsNotInstanceOfType_Test()
        {
            var y = new AnimalsShelter();

            Assert.IsNotInstanceOfType(y, typeof(Animal));
        }

        [TestMethod]
        [Owner("KobiL")]
        [Description("using StringAssert - Contains")]
        public void StringAssert_Contains_Test()
        {
            string name1 = "Tom Hanks";
            string name2 = "ank";

            StringAssert.Contains(name1, name2);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(1)]
        [Description("using StringAssert - StartsWith")]
        public void StringAssert_StartsWith_Test()
        {
            string name1 = "Tom Hanks";
            string name2 = "Tom";

            StringAssert.StartsWith(name1, name2);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(0)]
        [Description("StringAssert - Matches")]
        public void StringAssert_Matches_AllLowerCase_Test()
        {
            var redex = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", redex);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Description("StringAssert - Matches")]
        public void StringAssert_DoesNotMatche_IsNotAllLowerCase_Test()
        {
            var redex = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All lower case", redex);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Priority(0)]
        [Description("CollectionAssert - AreNotEqual")]
        public void CollectionAssert_AreNotEqual_Test()
        {
            var collection1 = new List<Animal>();
            collection1.Add(new Animal(AnimalType.Bear));

            var collection2 = new List<Animal>();
            collection2.Add(new Animal(AnimalType.Bear));

            CollectionAssert.AreNotEqual(collection1, collection2);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Description("CollectionAssert - AreEqual and using the COMPARER!!!")]
        public void CollectionAssert_AreEqual_WithComparer_Test()
        {
            var collection1 = new List<Animal>();
            collection1.Add(new Animal(AnimalType.Bear));

            var collection2 = new List<Animal>();
            collection2.Add(new Animal(AnimalType.Bear));

            CollectionAssert.AreEqual(collection1, collection2, Comparer<Animal>.Create(
                (x, y) => x.AnimalType == y.AnimalType ? 0 : 1));
        }

        [TestMethod]
        [Owner("KobiL")]
        [Description("CollectionAssert - AreEquivalent")]
        public void CollectionAssert_AreEquivalent_Test()
        {
            var list1 = new List<Animal>
                { 
                    new Animal(AnimalType.Bear),
                    new Animal(AnimalType.Deer),
                    new Animal(AnimalType.Snake)
                };

            // Creating another list, adding the same animals but in a different order!
            var list2 = new List<Animal>();
            list2.Add(list1[1]);
            list2.Add(list1[2]);
            list2.Add(list1[0]);

            // Tests to see if it's the same exact object but in whatever order!
            CollectionAssert.AreEquivalent(list1, list2);
        }

        [TestMethod]
        [Owner("KobiL")]
        [Description("CollectionAssert - IsCollectionOfType")]
        public void CollectionAssert_IsCollectionOfType_Test()
        {
            var list1 = new List<Animal>
                {
                    new Animal(AnimalType.Bear),
                    new Animal(AnimalType.Deer),
                    new Animal(AnimalType.Snake)
                };

            // Tests to see if all items are of type Animal!
            CollectionAssert.AllItemsAreInstancesOfType(list1, typeof(Animal));
        }
    }
}
