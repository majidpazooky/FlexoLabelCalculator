using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;
using FlexoCalc.Engine.Abstractions;

namespace FlexoCalc.Engine.Services;

/// <summary>
/// تولیدکننده تمام Layout های معتبر.
/// این کلاس هسته اصلی موتور FlexoCalc است.
/// </summary>
public sealed partial class LayoutGenerator : ILayoutGenerator
{
    public IReadOnlyList<LayoutOption> Generate(FlexoRequest request)
    {
        var layouts = new List<LayoutOption>();

        foreach (var machine in request.Machines)
        {
            GenerateForMachine(
                request,
                machine,
                layouts);
        }

        return layouts;
    }

    /// <summary>
    /// تولید Layout برای یک دستگاه.
    /// پیاده‌سازی در فایل بعدی انجام می‌شود.
    /// </summary>
    partial void GenerateForMachine(
        FlexoRequest request,
        MachineProfile machine,
        List<LayoutOption> layouts);
}
