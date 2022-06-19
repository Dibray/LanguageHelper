namespace LanguageHelper
{
    using System.Collections.Generic;

    public class Dictionary
    {
        private List<FullTranslation> dictionary = new List<FullTranslation>();

        public FullTranslation this[int index]
        { 
            get
            {
                return dictionary[index];
            }
        }

        public int TranslationsQuantity
        {
            get
            {
                return dictionary.Count;
            }
        }

        public void Add(FullTranslation translation)
        {
            dictionary.Add(translation);
        }

        private string PartOfSpeechToString(PartOfSpeech p)
        {
            string s = "";

            switch (p)
            {
                case PartOfSpeech.Verb:
                    s = "@гл";
                    break;
                    
                case PartOfSpeech.Noun:
                    s = "@същ";
                    break;
                    
                case PartOfSpeech.Adjective:
                    s = "@прил";
                    break;
                    
                case PartOfSpeech.Pronoun:
                    s = "@мест";
                    break;
                    
                case PartOfSpeech.Preposition:
                    s = "@пред";
                    break;
                    
                case PartOfSpeech.Conjunction:
                    s = "@съюз";
                    break;
                    
                default:
                    System.Console.WriteLine("Something went very wrong. (PartOfSpeechToString)\n");
                    break;
            }

            return s;
        }

        private string TranslationToString(List<List<Word>> translation)
        {
            string s = "";

            foreach (List<Word> t in translation)
            {
                foreach (Word w in t)
                    s += (" " + w.Value + ",");

                s = s.Remove(s.Length - 1); // Remove redundant comma
                s += ";";
            }

            s = s.Remove(s.Length - 1); // Remove redundant semicolon
            s += ".";

            return s;
        }

        public void Save()
        {
            string[] arr = new string[dictionary.Count];

            for (int i = 0; i < arr.Length; ++i)
                arr[i] = PartOfSpeechToString(dictionary[i].ForeignWord.PartOfSpeech) + " " +
                    dictionary[i].ForeignWord.Value + " -" +
                    TranslationToString(dictionary[i].WordTranslation);

            System.IO.File.WriteAllLines("Vokabular.txt", arr);
        }
    }
}
