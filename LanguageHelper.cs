namespace LanguageHelper
{
    class LanguageHelper
    {
        public static void Main()
        {
            Token t = TokenStream.Get();

            while (t.Kind != Token.TKind.Exit)
            {
                t = TokenStream.Get();
            }
        }
    }
}
