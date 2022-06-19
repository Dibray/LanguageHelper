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

        private static Token ReleaseBuffer()
        {
            full = false;
            return Buffer;
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

        private static Token DefineToken(string word)
        {
            switch (word)
            {
                case "@гл":
                    return new Token(Token.TKind.Verb);
                //break;

                case "@същ":
                    return new Token(Token.TKind.Noun);
                //break;

                case "ask":
                    return new Token(Token.TKind.Ask);
                //break;

                case "der":
                    return new Token(Token.TKind.DefiniteArticleDer);
                //break;

                case "die":
                    return new Token(Token.TKind.DefiniteArticleDie);
                //break;

                case "das":
                    return new Token(Token.TKind.DefiniteArticleDas);
                //break;

                case ".":
                    return new Token(Token.TKind.Dot);
                //break;

                case ",":
                    return new Token(Token.TKind.Comma);
                //break;

                case ";":
                    return new Token(Token.TKind.Semicolon);
                //break;

                case "-":
                    return new Token(Token.TKind.Separator);
                //break;

                case "@end":
                    return new Token(Token.TKind.End);
                // break;

                case "save":
                    return new Token(Token.TKind.Save);
                //break;

                case "exit":
                    return new Token(Token.TKind.Exit);
                //break;

                default: // Any string
                    int num = 0;

                    if (int.TryParse(word, out num))
                        return new Token(Token.TKind.Number, num);

                    return new Token(Token.TKind.String, word);
                    //break;
            }
        }

        /// <summary>
        /// Get token from standard System.Console input stream
        /// </summary>
        public static Token Get()
        {
            if (full)
                return ReleaseBuffer();

            string word = Read();

            if (word == null)
                return Get();

            return DefineToken(word.ToLower());
        }

        /// <summary>
        /// Define token from recieved word
        /// </summary>
        public static Token Get(in string word)
        {
            return DefineToken(word);
        }
    }
}
