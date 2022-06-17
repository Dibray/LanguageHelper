namespace LanguageHelper
{
    public static class Parser
    {
        private static bool Separator()
        {
            Token t = TokenStream.Get();

            if (t.Kind == Token.TKind.Separator)
                return true;

            System.Console.WriteLine("Няма разделител. (Separator)\n");
            return false;
        }

        /// <summary>
        /// Read any word from Token stream.
        /// Parameter is changed in-place.
        /// </summary>
        /// <returns>True if parsing is successful, false otherwise</returns>
        private static bool WordProc(in Word word)
        {
            Token t = TokenStream.Get();

            if (t.Kind == Token.TKind.String)
            {
                word.Value = t.Value;
                return true;
            }

            System.Console.WriteLine("Неправилен синтаксис. (Word)\n");
            return false;
        }

        private static bool ForeignWordProc(in Word word)
        {
            return WordProc(word);
        }

        private static bool VerbProc(in FullTranslation fullTranslation)
        {
            fullTranslation.ForeignWord = new GermanWord();
            fullTranslation.ForeignWord.PartOfSpeech = PartOfSpeech.Verb;

            if (ForeignWordProc(fullTranslation.ForeignWord) && Separator())
            {
                BulgarianWord w = new BulgarianWord();

                if (!WordProc(w)) // There is no translation
                    return false;

                fullTranslation.AddTranslation(w);

                return true;
            }

            return false;
        }

        public static bool FullTranslationProc(in FullTranslation fullTranslation)
        {
            switch (TokenStream.Get().Kind)
            {
                case Token.TKind.Verb:
                    return VerbProc(fullTranslation);
                    //break;

                default:
                    return false;
                    //break;
            }

            return false;
        }
    }
}
