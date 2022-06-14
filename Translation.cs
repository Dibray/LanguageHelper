namespace LanguageHelper
{
    using System.Collections.Generic;

    public class Translation
    {
        private Word foreignWord;
        private Word ForeignWord
        {
            get
            {
                return foreignWord;
            }

            set
            {
                foreignWord = value;
            }
        }

        /// <summary>
        /// Every internal list - is different meanings of translation of the word (polysemantic words).
        /// Internal list itself contains similar meanings of the one translation.
        /// </summary>
        private List<List<Word>> wordTranslation;
        private List<List<Word>> WordTranslation
        {
            get
            {
                return wordTranslation;
            }
        }

        private void AddTranslation(Word word)
        {
            List<Word> newMeaning = new List<Word>();
            newMeaning.Add(word);

            WordTranslation.Add(newMeaning);
        }

        private void AddSimilarTranslation(Word word, string key = null)
        {
            if (WordTranslation.Count < 1)
            {
                System.Console.WriteLine($"Думата \"{foreignWord.Value}\" няма преводи.");
                return;
            }

            // If there is no similar word translation, add new translation to the last meaning of the foreign word translation
            if (key == null)
                WordTranslation[WordTranslation.Count - 1].Add(word);
            else
                // Add new translation to translations with similar meaning
                foreach (List<Word> l in WordTranslation)
                    foreach (Word w in l)
                        if (key == w.Value)
                        {
                            l.Add(word);
                            return;
                        }
        }
    }
}
