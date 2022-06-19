namespace LanguageHelper
{
    using System;
    using System.Collections.Generic;

    public class LanguageHelper
    {
        private static bool CheckEnteredTranslation(string word, in LinkedList<Word> translations)
        {
            foreach (Word w in translations)
                if (word == w.Value)
                {
                    translations.Remove(w);
                    return true; ;
                }

            return false;
        }

        /// <summary>
        /// Ask specified word quantity randomly from dictionary
        /// </summary>
        private static void Ask(in Dictionary dict, int? quantity)
        {
            if (quantity == null)
                return;

            Random r = new Random();
            FullTranslation tr = new FullTranslation();
            LinkedList<Word> translations = new LinkedList<Word>();
            string input = null;
            int remainingTranslations = 0;

            for (int i = 0; i < quantity; ++i)
            {
                tr = dict[r.Next(0, dict.TranslationsQuantity - 1)]; // Select random word

                Console.WriteLine(tr.ForeignWord.Value + " -");

                foreach (List<Word> l in tr.WordTranslation) // Get all translations
                    foreach (Word w in l)
                        translations.AddLast(w);

                remainingTranslations = translations.Count;
                do // Input until all translations are entered
                {
                    input = Console.ReadLine();

                    if (CheckEnteredTranslation(input, translations))
                        --remainingTranslations;
                    else
                    {
                        if (TokenStream.Get(input).Kind == Token.TKind.End)
                            break; // If user doesn't know all the translations
                    }

                } while (remainingTranslations > 0);

                if (remainingTranslations == 0)
                    Console.WriteLine($"Всичките преводи на {tr.ForeignWord.Value} са въведени.");
            }
        }

        public static void Main()
        {
            Token t = TokenStream.Get();
            Dictionary dictionary = new Dictionary();
            
            while (t.Kind != Token.TKind.Exit)
            {
                switch (t.Kind)
                {
                    // Part of speech
                    case Token.TKind.Verb:
                    case Token.TKind.Noun:
                    case Token.TKind.Adj:
                    case Token.TKind.Pron:
                    case Token.TKind.Prep:
                    case Token.TKind.Conj:
                        TokenStream.Putback(t);

                        FullTranslation fullTranslation = new FullTranslation();

                        if (Parser.FullTranslationProc(fullTranslation))
                            dictionary.Add(fullTranslation);

                        break;

                    case Token.TKind.Ask:
                        t = TokenStream.Get();

                        if (t.Kind == Token.TKind.Number)
                            Ask(dictionary, t.Number);

                        break;

                    case Token.TKind.Save:
                        dictionary.Save();
                        break;

                    default:
                        break;
                }

                t = TokenStream.Get();
            }
        }
    }
}
