namespace LanguageHelper
{
    public abstract class Word
    {
        private string value = "";
        private string Value
        {
            set
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
