namespace PandaKaradyUniversity.Models
{
    public class ParsingResult<T>
    {
        public ParsingStatus Status { get; set; }
        public string ErrorReason { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(ErrorReason) ? 
                $"Status: {Status}, Data: [{Data}]" : 
                $"Status: {Status}, ErrorReason: {ErrorReason}";
        }
    }
}