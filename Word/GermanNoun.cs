namespace LanguageHelper
{
    class GermanNoun : GermanWord
    {
        public enum DefiniteArticle : byte
        {
            Der = 0, Die, Das
        }

        public override string Value
        {
            get
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder(Article.ToString());
                s[0] = char.ToLower(s[0]);

                return s + " " + base.Value;
            }

            set
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder(value);
                s[0] = char.ToUpper(s[0]);

                base.Value = s.ToString();
            }
        }

        private DefiniteArticle article;
        public DefiniteArticle Article
        {
            get
            {
                return article;
            }

            set
            {
                article = value;
            }
        }

        public GermanNoun() { }
    }
}
