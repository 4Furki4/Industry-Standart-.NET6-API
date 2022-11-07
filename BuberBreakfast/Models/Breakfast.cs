namespace BuberBreakfast.BuberBreakfast.Models;

public class Breakfast
{
    public Guid Id {get;}
    public string Name {get;}
    public string Definition {get;}

    public DateTime StartDateTime {get;}

    public DateTime EndDateTime {get;}

    public DateTime LastModifiedDateTime {get;}

    public List<string> Savory {get;}
    public List<string> Sweet {get;}

    public Breakfast(
        Guid ıd,
        string name,
        string definition,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {   //Enfore invariants
        Id = ıd;
        Name = name;
        Definition = definition;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }
}