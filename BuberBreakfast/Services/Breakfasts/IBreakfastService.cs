using BuberBreakfast.BuberBreakfast.Models;

namespace BuberBreakfast.Services.BreakfastService;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);
}