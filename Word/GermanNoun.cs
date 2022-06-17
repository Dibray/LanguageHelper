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
                return Article.ToString() + " " + base.Value;
            }
        }

        private DefiniteArticle article;
        private DefiniteArticle Article
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

        GermanNoun() { }
    }
}
