using System.Collections.Generic;

namespace ValidateSentences
{
    public interface IValidator
    {
        IEnumerable<bool> Validate(IEnumerable<string[]> queries);
    }
}
