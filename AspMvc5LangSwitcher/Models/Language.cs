namespace AspMvc5LangSwitcher.Models
{
    public sealed class Language : TypeSafeEnum<Language>
    {
        public Language(string name, string code) : base(name, code) { }

        public static readonly Language English = new Language("English", "en");
        public static readonly Language Русский = new Language("Русский", "ru");
        public static readonly Language Norsk = new Language("Norsk", "no");
    }
}