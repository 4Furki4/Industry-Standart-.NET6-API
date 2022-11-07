using BuberBreakfast.BuberBreakfast.Models;

namespace BuberBreakfast.Services.BreakfastService;

public class BreakfastService : IBreakfastService
{
    private readonly static Dictionary<Guid, Breakfast> _breakfasts = new();
    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast GetBreakfast(Guid id)
    {
        return _breakfasts[id];
    }
}
