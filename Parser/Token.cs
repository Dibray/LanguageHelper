namespace LanguageHelper
{
    public class Token
    {
        public enum TKind
        {
            Exit = 0,
            Save,
            Ask,
            End,
            Verb,
            String,
            Number,
            DefiniteArticle,
            Dot,
            Comma,
            Semicolon,
            Separator
        }

        private TKind kind;
        public TKind Kind
        {
            get
            {
                return kind;
            }

            private set
            {
                kind = value;
            }
        }

        private string value = null;
        public string Value
        {
            get
            {
                return value;
            }

            private set
            {
                this.value = value;
            }
        }

        private int? number = null;
        public int? Number
        {
            get
            {
                return number;
            }

            private set
            {
                number = value;
            }
        }

        public Token(in TKind kind)
        {
            Kind = kind;
        }

        public Token(in TKind kind, in string value)
        {
            Kind = kind;
            Value = value;
        }

        public Token(in TKind kind, in int value)
        {
            Kind = kind;
            Number = value;
        }
    }
}
