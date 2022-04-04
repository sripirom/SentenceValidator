using NUnit.Framework;
using System.Collections.Generic;

namespace ValidateSentences.Tests
{
    public class SynonymSentenceValidatorTests
    {
        [Test]
        public void Validate_ValidResult()
        {
            List<List<string>> synonyms = new List<List<string>>
            {   new List<string> { "rate", "ratings", "rates" },
                new List<string> { "approval", "popularity" }
            };

            IEnumerable<string[]> queries = new List<string[]>
            {
                new string[] { "obama approval rate", "obama popularity ratings" } ,
                new string[] { "obama popularity rates", "obama approval ratings" },
                new string[] { "obama approval rating", "obama TV ratings" },
                new string[] { "obama approval rate", "popularity ratings obama" }
            };

            IValidator service = new SynonymSentenceValidator(' ', synonyms);

            IEnumerable<bool> result = service.Validate(queries);

            TestContext.WriteLine(string.Join(',', result));

            Assert.AreEqual(new List<bool> { true, true, false, true }, result);
        }
    }
}
