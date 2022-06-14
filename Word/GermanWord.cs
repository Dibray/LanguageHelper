namespace LanguageHelper
{
    public class GermanWord : Word
    {
        public enum DefiniteArticle : byte
        {
            Der = 0, Die, Das
        }

        protected internal override string Value
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

        public GermanWord(DefiniteArticle article, string word, PartOfSpeech partOfSpeech)
            : base(word, partOfSpeech)
        {
            Article = article;
        }
    }
}
