namespace LanguageHelper
{
    public class GermanWord : Word
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

        public GermanWord() { }

        public GermanWord(in string word, in DefiniteArticle article)
            : base(word)
        {
            Article = article;
        }
    }
}
