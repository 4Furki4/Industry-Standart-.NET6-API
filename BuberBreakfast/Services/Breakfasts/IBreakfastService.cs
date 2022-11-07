using BuberBreakfast.BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Services.BreakfastService;

public interface IBreakfastService
{
    ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast);
    ErrorOr<Deleted> DeleteBreakfast(Guid id);
}