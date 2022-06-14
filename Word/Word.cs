namespace LanguageHelper
{
    public abstract class Word
    {
        private string value = "";
        virtual protected internal string Value
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

        private PartOfSpeech partOfSpeech;
        private PartOfSpeech PartOfSpeech
        {
            set
            {
                partOfSpeech = value;
            }
        }

        internal Word(string word, PartOfSpeech partOfSpeech)
        {
            Value = word;
            PartOfSpeech = partOfSpeech;
        }
    }
}
