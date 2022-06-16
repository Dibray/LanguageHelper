namespace LanguageHelper
{
    public class Word
    {
        private string value = "";
        virtual public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        private PartOfSpeech partOfSpeech;
        public PartOfSpeech PartOfSpeech
        {
            get
            {
                return partOfSpeech;
            }

            set
            {
                partOfSpeech = value;
            }
        }

        public Word() { }

        public Word(in string word)
        {
            Value = word;
        }
    }
}
