using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ConsoleApp1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ConsoleApp1Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [Ignore]
        public void Test_Solve_WhenAtLeastOneItemFits_ReturnsAtLeastOneSelectedItem()
        {
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 5, 5), // Value: 5, Weight: 5
                new Przedmiot(2, 10, 10) // Value: 10, Weight: 10
            };
            int capacity = 6; // Just enough capacity for the first item

            // Act
            Problem problem = new Problem(2, 1);
            var result = problem.Solve(items, capacity);

            // Assert
            Assert.IsTrue(result.SelectedItems.Count > 0);
        }

        [TestMethod]
        [Ignore]
        public void Test_Solve_WhenNoItemFits_ReturnsEmptySelectedItems()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 10, 10), // Value: 10, Weight: 10
                new Przedmiot(2, 8, 8) // Value: 8, Weight: 8
            };
            int capacity = 5;

            // Act
            Problem problem = new Problem(2, 1);
            var result = problem.Solve(items, capacity);

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result.SelectedItems);
        }

        [TestMethod]
        [Ignore]
        public void Test_Solve_WhenOrderOfItemsChanges_ResultStaysSame()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 5, 2), // Value: 5, Weight: 2
                new Przedmiot(2, 10, 5), // Value: 10, Weight: 5
                new Przedmiot(3, 6, 3), // Value: 6, Weight: 3
                new Przedmiot(4, 10, 10) // Value: 10, Weight: 5
            };
            int capacity = 12; // Enough capacity for both items

            // Act
            Problem problem1 = new Problem(2, 1);
            Problem problem2 = new Problem(2, 1);
            var result1 = problem1.Solve(items, capacity);

            items.Reverse(); // Reverse the order of items
            var result2 = problem2.Solve(items, capacity);

            // Assert
            Assert.AreEqual(result1.TotalValue, result2.TotalValue);
            Assert.AreEqual(result1.TotalWeight, result2.TotalWeight);
        }

        [TestMethod]
        [Ignore]
        public void Test_Solve_WithSpecificInstance_ReturnsCorrectResult()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 3, 2),
                new Przedmiot(2, 5, 8),
                new Przedmiot(3, 7, 5),
                new Przedmiot(4, 4, 10),
                new Przedmiot(5, 2, 7),
                new Przedmiot(6, 1, 3),
                new Przedmiot(7, 4, 10),
                new Przedmiot(8, 7, 7),
                new Przedmiot(9, 3, 7),
                new Przedmiot(10, 8, 8)
            };
            int capacity = 20;
            var expectedResult = new Result(new List<int> { 1, 3, 8, 6 }, 18, 17); // Expected result

            // Act
            Problem p = new Problem(10, 1);
            var result = p.Solve(items, capacity);

            // Assert
            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

        /// /////////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void Test_Solve_WhenNoItems_ReturnsEmptyResult()
        {
            // Arrange
            var items = new List<Przedmiot>(); // Empty list of items
            int capacity = 10;

            // Act
            Problem problem = new Problem(0, 1); // Zero items
            var result = problem.Solve(items, capacity);

            // Assert
            Assert.AreEqual(0, result.TotalValue);
            Assert.AreEqual(0, result.TotalWeight);
            CollectionAssert.AreEqual(new List<int>(), result.SelectedItems);
        }


        [TestMethod]
        public void Test_Solve_WithLargeCapacity_ReturnsCorrectResult()
        {
            // Arrange
            var items = new List<Przedmiot>
            {
                new Przedmiot(1, 10, 5), // Value: 10, Weight: 5
                new Przedmiot(2, 8, 8), // Value: 8, Weight: 8
                new Przedmiot(3, 15, 10), // Value: 15, Weight: 10
                new Przedmiot(4, 20, 15), // Value: 20, Weight: 15
                new Przedmiot(5, 30, 20), // Value: 30, Weight: 20
            };
            int capacity = 100; // Large capacity to fit all items

            // Act
            Problem problem = new Problem(5, 1);
            var result = problem.Solve(items, capacity);

            // Assert
            Assert.AreEqual(83, result.TotalValue); // Sum of values of all items
            Assert.AreEqual(58, result.TotalWeight); // Sum of weights of selected items
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4, 5 }, result.SelectedItems); // All items selected
        }
        [TestMethod]
        public void Test_Solve_WithDifferentSeed_ReturnsDifferentResults()
        {
            // Arrange


            int capacity = 20;

            // Act
            Problem problem1 = new Problem(10, 1);
            problem1.GenerateItems(10);
            Problem problem2 = new Problem(10, 10); // Different seed
            var items1 = problem1.GenerateItems(10);
            var items2 = problem1.GenerateItems(10);
            var result1 = problem1.Solve(items1, capacity);
            var result2 = problem2.Solve(items2, capacity);

            // Assert
            Assert.AreNotEqual(result1.TotalValue, result2.TotalValue);
            Assert.AreNotEqual(result1.TotalWeight, result2.TotalWeight);
            CollectionAssert.AreNotEquivalent(result1.SelectedItems, result2.SelectedItems);
        }
        [TestClass]
        public class PrzedmiotTests
        {
            [TestMethod]
            public void Test_Przedmiot_Creation()
            {
                // Arrange
                int id = 1;
                int value = 5;
                int weight = 10;

                // Act
                Przedmiot przedmiot = new Przedmiot(id, value, weight);

                // Assert
                Assert.AreEqual(id, przedmiot.Id);
                Assert.AreEqual(value, przedmiot.Wartosc);
                Assert.AreEqual(weight, przedmiot.Waga);
            }
        }

    }
}
