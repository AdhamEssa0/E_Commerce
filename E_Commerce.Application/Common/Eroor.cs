namespace E_Commerce.Application.Common
{
    public class Eroor
    {
        private string code;
        private string description;
        private ErrorType failure;

        public Eroor(string code, string description, ErrorType failure)
        {
            this.code = code;
            this.description = description;
            this.failure = failure;
        }
    }
}