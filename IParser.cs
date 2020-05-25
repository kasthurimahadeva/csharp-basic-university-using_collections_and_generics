using PandaKaradyUniversity.Models;

namespace PandaKaradyUniversity
{
    public interface IParser<T>
    {
        public ParsingResult<T> Parse(string line);
    }
}