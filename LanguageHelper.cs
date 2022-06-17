namespace LanguageHelper
{
    public class LanguageHelper
    {
        public static void Main()
        {
            Token t = TokenStream.Get();
            
            while (t.Kind != Token.TKind.Exit)
            {
                switch (t.Kind)
                {
                    // Part of speech
                    case Token.TKind.Verb:
                        TokenStream.Putback(t);

                        FullTranslation fullTranslation = new FullTranslation();

                        if (Parser.FullTranslationProc(fullTranslation)) // Test
                        {
                            System.Console.WriteLine(fullTranslation.ForeignWord.PartOfSpeech);
                            System.Console.WriteLine(fullTranslation.ForeignWord.Value);

                            foreach (var x in fullTranslation.WordTranslation)
                            {
                                foreach (var z in x)
                                {
                                    System.Console.WriteLine(z.PartOfSpeech);
                                    System.Console.WriteLine(z.Value);
                                }

                                System.Console.WriteLine("------------");
                            }
                        }

                        break;

                    default:
                        break;
                }

                t = TokenStream.Get();
            }
        }
    }
}
