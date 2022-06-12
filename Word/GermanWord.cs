namespace LanguageHelper
{
    public class GermanWord : Word
    {
        public enum DefiniteArticle : byte
        {
            Der = 0, Die, Das
        }

        private DefiniteArticle article;
        private DefiniteArticle Article
        {
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
