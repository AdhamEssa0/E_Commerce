using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common
{
    public record Error(string code , string Description , ErrorType ErrorType = ErrorType.Failure  )
    {
        public static Eroor Failure(string code = "General.Failure", string description = "Failure Error Has Occured")
            => new(code, description, ErrorType.Failure);
        public static Eroor NotFound(string code = "General.NotFound", string description = "NotFound Error Has Occured")
            => new(code, description, ErrorType.NotFound);
        public static Eroor Forbidden(string code = "General.Forbidden", string description = "Forbidden Error Has Occured")
            => new(code, description, ErrorType.Forbidden);
        public static Eroor Unauthorized(string code = "General.Unauthorized", string description = "Unauthorized Error Has Occured")
            => new(code, description, ErrorType.Unauthorized);
        public static Eroor Conflict(string code = "General.Conflict", string description = "Conflict Error Has Occured")
            => new(code, description, ErrorType.Conflict);
        public static Eroor Validation(string code = "General.Validation", string description = "Validation Error Has Occured")
            => new(code, description, ErrorType.Validation);
        public static Eroor InvalidCardentials(string code = "General.InvalidCardentials", string description = "InvalidCardentials Error Has Occured")
            => new(code, description, ErrorType.InvalidCardentials);
    }
        public enum ErrorType
        {
            Failure = 0 ,
            NotFound,
            Forbidden,
            Unauthorized,
            Conflict,
            Validation,
            InvalidCardentials
        }
}
