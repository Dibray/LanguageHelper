namespace LanguageHelper
{
    public static class TokenStream // Reads System.Console stream
    {
        private static Token buffer;
        private static Token Buffer
        {
            get
            {
                return buffer;
            }

            set
            {
                buffer = value;
            }
        }

        private static bool full = false;

        public static void Putback(in Token t)
        {
            Buffer = t;
            full = true;
        }

        /// <summary>
        /// "Write out" symbol from System.Console stream to specified string
        /// </summary>
        private static void WriteOut(ref string s)
        {
            s += (char)System.Console.Read();
        }

        /// <summary>
        /// Read symbols up to whitespace or indicated symbols
        /// </summary>
        private static string Read()
        {
            int ch = ' ';
            string s = null;

            while (true)
            {
                ch = System.Console.In.Peek();
                
                if (char.IsWhiteSpace((char)ch))
                {
                    System.Console.Read(); // Ignore symbol
                    break;
                }

                if (ch == '.' || ch == ',' || ch == ';')
                {
                    if (s == null) // Indicated symbol is alone
                        WriteOut(ref s);

                    break;
                }

                WriteOut(ref s);
            }

            return s;
        }

        public static Token Get()
        {
            if (full)
            {
                full = false;
                return Buffer;
            }

            string word = Read();

            if (word == null)
                return Get();

            switch (word.ToLower())
            {
                case "@гл":
                    return new Token(Token.TKind.Verb);
                    //break;

                case "der":
                case "die":
                case "das":
                    return new Token(Token.TKind.DefiniteArticle);
                    //break;

                case ".":
                    return new Token(Token.TKind.Dot);
                    //break;

                case ",":
                    return new Token(Token.TKind.Comma);
                //break;

                case ";":
                    return new Token(Token.TKind.Semicolon);

                case "-":
                    return new Token(Token.TKind.Separator);
                    //break;

                case "exit":
                    return new Token(Token.TKind.Exit);
                    //break;

                default: // Any string
                    return new Token(Token.TKind.String, word);
                    //break;
            }
        }
    }
}
