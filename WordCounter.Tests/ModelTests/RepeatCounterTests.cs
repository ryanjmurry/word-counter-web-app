using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WordCounter.Models;

namespace WordCounter.Tests
{
    [TestClass]
    public class RepeatCounterTest
    {
        [TestMethod]
        public void GetTargetWord_GetsTargetWord_String()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can");

            //Act
            string result = newRepeatCounter.GetTargetWord();

            //Assert
            Assert.AreEqual("can", result);
        }

        [TestMethod]
        public void CheckAllowedCharacters_ChecksForAllowableCharacaters_True()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can");

            //Act
            bool result = newRepeatCounter.CheckAllowedCharacters();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckBookendPunctuation_ChecksForTrailingAndProceedingPunctuation_False()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can");

            //Act
            bool result = newRepeatCounter.CheckBookendPunctuation();

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckBookendPunctuation_ChecksForTrailingAndProceedingPunctuation_True()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("'can'");

            //Act
            bool result = newRepeatCounter.CheckBookendPunctuation();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateTargetWordPunctuation_ValidatesLetterWord_True()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can");

            //Act
            bool result = newRepeatCounter.ValidateTargetWord();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateTargetWord_ValidatesNumericWord_True()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("123");

            //Act
            bool result = newRepeatCounter.ValidateTargetWord();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateTargetWord_ValidatesApostrophes_True()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can't");

            //Act
            bool result = newRepeatCounter.ValidateTargetWord();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateTargetWord_ValidatesDashes_True()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("in-line");

            //Act
            bool result = newRepeatCounter.ValidateTargetWord();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateTargetWord_RejectsQuotes_False()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("'can'");

            //Act
            bool result = newRepeatCounter.ValidateTargetWord();

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateTargetWord_RejectsSpaces_False()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can not");

            //Act
            bool result = newRepeatCounter.ValidateTargetWord();
            string pos = newRepeatCounter.GetTargetWord();
            Console.WriteLine(pos[3]);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetTargetToLower_SetsValidTargetWordToLowerCase_String()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("CAN");

            //Act
            string result = newRepeatCounter.GetTargetWord();

            //Assert
            Assert.AreEqual("can", result);
        }

        [TestMethod]
        public void GetSearchPhrase_GetsSearchPhrase_String()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can", "i can swim!");

            //Act
            string result = newRepeatCounter.GetSearchPhrase();

            //Assert
            Assert.AreEqual("i can swim!", result);
        }

        [TestMethod]
        public void GetSearchPhrase_GetsSearchPhraseInLowerCase_String()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can", "I CAN SWIM!");

            //Act
            string result = newRepeatCounter.GetSearchPhrase();

            //Assert
            Assert.AreEqual("i can swim!", result);
        }

        [TestMethod]
        public void GetSetSearchList_GetsAndSetsSearchListFromSearchPhrase_List()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can", "i can swim!");
            List<string> expected = new List<string>() { "i", "can", "swim!" };

            //Act
            List<string> result = newRepeatCounter.GetSearchList();

            //Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SetSubstringValue_SetsStartValue_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter();

            //Act
            newRepeatCounter.SetSubstringValues("'can'");
            int result = newRepeatCounter.GetStart();

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SetSubstringValue_SetsEndValue_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter();

            //Act
            newRepeatCounter.SetSubstringValues("'can'");
            int result = newRepeatCounter.GetEnd();

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ReplaceWord_ReplacePunctuatedWordWithCleanWord_String()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("", "'can'");

            //Act
            newRepeatCounter.ReplaceWord("'can'", 0);
            List<string> newList = newRepeatCounter.GetSearchList();
            string result = newList[0];

            //Assert
            Assert.AreEqual("can", result);
        }

        [TestMethod]
        public void CleanList_CleanSingleElementSearchListOfAnyBookendPunctuation_List()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("", "'can'");
            List<string> expected = new List<string>() { "can" };

            //Act
            newRepeatCounter.CleanList();
            List<string> actual = newRepeatCounter.GetSearchList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CleanList_CleanSearchListOfAnyBookendPunctuation_List()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("", "i 'can' swim!");
            List<string> expected = new List<string>() { "i", "can", "swim" };

            //Act
            newRepeatCounter.CleanList();
            List<string> actual = newRepeatCounter.GetSearchList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Matches_DeterminesNumberOfMatches1_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can", "i can swim");

            //Act
            int result = newRepeatCounter.Matches();

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Matches_DeterminesNumberOfMatches2_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can", "I CAN SWIM");

            //Act
            int result = newRepeatCounter.Matches();

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Matches_DeterminesNumberOfMatches3_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("can", "I 'can' swim! Can you?");

            //Act
            int result = newRepeatCounter.Matches();

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Matches_DeterminesNumberOfMatches4_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("in-line", "I like to in-line rollerskate.");

            //Act
            int result = newRepeatCounter.Matches();

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Matches_DeterminesNumberOfMatches5_Int()
        {
            //Arrange
            RepeatCounter newRepeatCounter = new RepeatCounter("don't", "Don't go there!");

            //Act
            int result = newRepeatCounter.Matches();

            //Assert
            Assert.AreEqual(1, result);
        }
    }
}
