using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUtilities.Utilities
{
    /// <summary>
    /// Набор функций для работы с анаграммами
    /// </summary>
    public static class Anagrams
    {
        /// <summary>
        /// Поиск анаграмм в заданном массиве слов
        /// </summary>
        /// <param name="words">Массив строк</param>
        /// <returns>Двумерный массив сгруппированных анаграмм </returns>
        /// <remarks>Построение массива результата зависит от порядка строк в переданном массиве</remarks>
        public static IEnumerable<string[]> FindAnagrams (IEnumerable<string> words)
        {
            var groups = from string word in words
                         group word by string.Concat(word.ToLower().OrderBy(x => x)) into c
                         select c.ToArray();

            return groups;
        }
    }
}
