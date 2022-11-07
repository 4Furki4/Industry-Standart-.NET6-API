using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.BuberBreakfast.Models;

public class Breakfast
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public const int MinDescriptionLength = 50;

    public const int MaxDescriptionLength = 150;
    public Guid Id {get;}
    public string Name {get;}
    public string Definition {get;}

    public DateTime StartDateTime {get;}

    public DateTime EndDateTime {get;}

    public DateTime LastModifiedDateTime {get;}

    public List<string> Savory {get;}
    public List<string> Sweet {get;}

    private Breakfast(
        Guid Id,
        string name,
        string definition,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {   
        this.Id = Id;
        Name = name;
        Definition = definition;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }
    public static ErrorOr<Breakfast> Create(
        string name,
        string definition,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null)
        {   //Enfore invariants
            List<Error> errors = new();
            if(name.Length is < MinNameLength or > MaxNameLength)
            {
                errors.Add(Errors.Breakfast.InvalidName);
            }
            if(definition.Length is < MinDescriptionLength or > MaxDescriptionLength)
            {
                errors.Add(Errors.Breakfast.InvalidDescription);
            }
            if(errors.Count > 0 )
                return errors;
            return new Breakfast(
                id ?? Guid.NewGuid(),
                name,
                definition,
                startDateTime,
                endDateTime,
                DateTime.Now,
                savory,
                sweet
            );
        }

        public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet);
        }
        public static ErrorOr<Breakfast> From(Guid? id, UpsertBreakfastRequest request)
        {
            return Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet,
                id);
        }
}