using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;

namespace FlexoCalc.Engine.Abstractions;

/// <summary>
/// تولید تمام Layout های ممکن برای یک سفارش
/// </summary>
public interface ILayoutGenerator
{
    /// <summary>
    /// تمام Layout های معتبر را تولید می‌کند.
    /// </summary>
    IReadOnlyList<LayoutOption> Generate(FlexoRequest request);
}
