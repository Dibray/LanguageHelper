namespace LanguageHelper
{
    public static class Parser
    {
        private static bool Separator()
        {
            if (TokenStream.Get().Kind == Token.TKind.Separator)
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

                t = TokenStream.Get();
                while (t.Kind == Token.TKind.String)
                {
                    word.Value = word.Value + " " + t.Value;
                    t = TokenStream.Get();
                }

                TokenStream.Putback(t);
                return true;
            }
            else // There is no word
            {
                System.Console.WriteLine("Неправилен синтаксис. (Word)\n");
                return false;
            }
        }

        private static bool ForeignWordProc(in Word word)
        {
            return WordProc(word);
        }

        private static bool TranslationProc(in FullTranslation fullTranslation)
        {
            BulgarianWord word = new BulgarianWord();

            if (!WordProc(word)) // There is no translation
                return false;

            fullTranslation.AddTranslation(word);

            // Parse all remaining translations if exist
            Token t = TokenStream.Get();
            do
            {
                switch (t.Kind)
                {
                    case Token.TKind.Comma:
                        if (WordProc(word = new BulgarianWord()))
                            fullTranslation.AddSimilarTranslation(word);
                        else
                            return true;

                        break;

                    case Token.TKind.Semicolon:
                        if (WordProc(word = new BulgarianWord()))
                            fullTranslation.AddTranslation(word);
                        else
                            return true;

                        break;

                    default:
                        return true;
                        //break;
                }

                t = TokenStream.Get();

            } while (t.Kind != Token.TKind.Dot);

            return true;
        }

        private static bool VerbProc(in FullTranslation fullTranslation)
        {
            fullTranslation.ForeignWord = new GermanWord();
            fullTranslation.ForeignWord.PartOfSpeech = PartOfSpeech.Verb;
            
            return (ForeignWordProc(fullTranslation.ForeignWord) && Separator() && TranslationProc(fullTranslation));
        }

        private static bool NounProc(in FullTranslation fullTranslation)
        {
            GermanNoun noun = new GermanNoun();
            fullTranslation.ForeignWord = noun;
            fullTranslation.ForeignWord.PartOfSpeech = PartOfSpeech.Noun;

            switch (TokenStream.Get().Kind) // Define definite article
            {
                case Token.TKind.DefiniteArticleDer:
                    noun.Article = GermanNoun.DefiniteArticle.Der;
                    break;

                case Token.TKind.DefiniteArticleDie:
                    noun.Article = GermanNoun.DefiniteArticle.Die;
                    break;

                case Token.TKind.DefiniteArticleDas:
                    noun.Article = GermanNoun.DefiniteArticle.Das;
                    break;

                default:
                    System.Console.WriteLine("Няма определителен член.");
                    break;
            }

            return (ForeignWordProc(fullTranslation.ForeignWord) && Separator() && TranslationProc(fullTranslation));
        }

        public static bool FullTranslationProc(in FullTranslation fullTranslation)
        {
            switch (TokenStream.Get().Kind)
            {
                case Token.TKind.Verb:
                    return VerbProc(fullTranslation);
                //break;

                case Token.TKind.Noun:
                    return NounProc(fullTranslation);
                //break;

                default:
                    return false;
                    //break;
            }

            return false;
        }
    }
}
