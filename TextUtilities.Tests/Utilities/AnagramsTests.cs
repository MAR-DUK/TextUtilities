using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TextUtilities.Utilities;

namespace TextUtilities.Tests.Utilities
{
    [TestClass]
    public class AnagramsTests
    {
        /// <summary>
        /// Массив срок на вход => массив массивов анаграмм на выход
        /// </summary>
        [TestMethod]
        public void FindAnagrams_FineIn_FineOut()
        {
            string[][] expected = {
                new string[] {"ток","кот","кто" },
                new string[] {"рост","торс" },
                new string[] {"фывап" },
                new string[] { "рок" }
            };

            var input = new string[] { 
                "ток", "рост", "кот", 
                "торс", "кто", "фывап", "рок" 
            };

            var result = Anagrams.FindAnagrams(input).ToArray();

            Assert.AreEqual(result.Length, expected.Length, 
                $"Длина массива результатов не равна длине ожидаемого массива. {nameof(result)}: {result.Length} | {nameof(expected)}: {expected.Length}");

            for (int set = 0; set < result.Length; set++)
                CollectionAssert.AreEqual(expected[set], result[set]);
        }

        /// <summary>
        /// Пустой вход => пустой результат
        /// </summary>
        [TestMethod]
        public void FindAnagrams_EmptyIn_EmptuOut()
        {
            string[][] expected = {};

            var input = new string[] {};

            var result = Anagrams.FindAnagrams(input).ToArray();

            Assert.AreEqual(result.Length, expected.Length,
                $"Длина массива результатов не равна длине ожидаемого массива. {nameof(result)}: {result.Length} | {nameof(expected)}: {expected.Length}");

            Assert.IsTrue(result == null || result.Length == 0);
            Assert.IsTrue(expected == null || expected.Length == 0);

        }

        /// <summary>
        /// Проверка нечуствительности к регистру
        /// </summary>
        [TestMethod]
        public void FindAnagrams_RegisterInvariant()
        {
            string[][] expected = {
                new string[] {"ток","кот","Кто" },
                new string[] {"рОст","торс" },
                new string[] {"фЫвАп" },
                new string[] { "рОК" }
            };

            var input = new string[] {
                "ток", "рОст", "кот",
                "торс", "Кто", "фЫвАп", "рОК"
            };

            var result = Anagrams.FindAnagrams(input).ToArray();

            Assert.AreEqual(result.Length, expected.Length,
                $"Длина массива результатов не равна длине ожидаемого массива. {nameof(result)}: {result.Length} | {nameof(expected)}: {expected.Length}");

            for (int set = 0; set < result.Length; set++)
                CollectionAssert.AreEqual(expected[set], result[set]);

        }
    }
}
