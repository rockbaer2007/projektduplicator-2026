using System;

namespace Projektduplicator_2017
{
    internal sealed class ModelTranslation
    {
        internal string English, German, French, Polish;

        internal static ModelTranslation Run(string source, string language, Func<string, string, string, string> translate)
        {
            if (string.IsNullOrWhiteSpace(source)) throw new ArgumentException("Source text is empty.");
            if (language != "de" && language != "en") throw new ArgumentException("Unsupported source language.");
            Func<string, string> target = locale =>
            {
                if (locale == language) return source;
                string result = translate(source, language, locale);
                if (string.IsNullOrWhiteSpace(result)) throw new InvalidOperationException("Translation did not complete.");
                return result;
            };
            // Always translate from the original text; never chain DE -> EN -> FR/PL.
            // Prepare all results before changing any model field.
            return new ModelTranslation { English = target("en"), German = target("de"), French = target("fr"), Polish = target("pl") };
        }
    }
}
