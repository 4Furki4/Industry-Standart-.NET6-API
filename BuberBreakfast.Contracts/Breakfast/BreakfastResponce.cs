namespace BuberBreakfast.Contracts.Breakfast.BreakfastResponse
{
    public record BreakfastResponse(
        Guid Id,
        string Name,
        string Description,
        DateTime StartDateTime,
        DateTime EndDateTime,
        DateTime LastModifiedDateTime,
        List<string> Savory,
        List<string> Sweet
    );



















}// End of BuberBreakfast.Contracts.Breakfast.CreateBreakFastRequest namespace


 