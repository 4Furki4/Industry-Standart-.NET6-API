using ErrorOr;
namespace BuberBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error InvalidDescription => Error.Validation(
            code:"Breakfast.InvalidName",
            description: $"Breakfast name must be at least {BuberBreakfast.Models.Breakfast.MinDescriptionLength}"+ 
            $" or at most {BuberBreakfast.Models.Breakfast.MaxDescriptionLength} characters long."
        );
        public static Error InvalidName => Error.Validation(
            code:"Breakfast.InvalidName",
            description: $"Breakfast name must be at least {BuberBreakfast.Models.Breakfast.MinNameLength}"+ 
            $" or at most {BuberBreakfast.Models.Breakfast.MinNameLength} characters long."
        );
        public static Error NotFound => Error.NotFound(
            code:"Breakfast.NotFound",
            description: "Breakfast not found"
        );
    }
}