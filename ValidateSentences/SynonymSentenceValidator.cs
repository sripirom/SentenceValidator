using System.Collections.Generic;
using System.Linq;

namespace ValidateSentences
{
    /// <summary>
    /// This validator will check the QUERIES collection which pairs of sentences have the same meaning. 
    /// When comparing meaning ignore the order and case sensitive
    /// </summary>
    public class SynonymSentenceValidator : IValidator
    {
        private readonly IEnumerable<List<string>> _synonyms;
        private readonly char _splitChar;
        /// <summary>
        /// the constructor need synonyms data for checking sentences
        /// </summary>
        /// <param name="synonyms">SYNONYMS is collections which contains group of same meaning words</param>
        public SynonymSentenceValidator(char splitChar, IEnumerable<List<string>> synonyms)
        {
            _splitChar = splitChar;
            _synonyms = synonyms;
        }

        /// <summary>
        /// synonym sentences validation 
        /// </summary>
        /// <param name="queries">the param contains string array with 2 values</param>
        /// <returns></returns>
        public IEnumerable<bool> Validate(IEnumerable<string[]> queries)
        {
            List<bool> result = new List<bool>();

            foreach (var query in queries)
            {
                result.Add(IsSynoyms(query[0], query[1]));
            }

            return result;
        }

        /// <summary>
        /// pair sentences should be synonym 
        /// </summary>
        /// <param name="sentence1">split sentence1 by space</param>
        /// <param name="sentence2">split sentence2 by space</param>
        /// <returns></returns>
        private bool IsSynoyms(string sentence1, string sentence2)
        {
            List<string> splitSentence1 = sentence1.Split(_splitChar).ToList();
            List<string> splitSentence2 = sentence2.Split(_splitChar).ToList();
            return !_synonyms.Any(synonym => (synonym.Any(x => splitSentence1.FindAll(d => d.Equals(x)).Count > 0)
                                           && synonym.Any(x => splitSentence2.FindAll(d => d.Equals(x)).Count > 0)) == false);
        }
    }
}
