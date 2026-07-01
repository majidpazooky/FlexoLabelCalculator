using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;
using FlexoCalc.Engine.Internal;

namespace FlexoCalc.Engine.Services;

public sealed partial class LayoutGenerator
{
    partial void GenerateForPaperWidth(
        FlexoRequest request,
        MachineProfile machine,
        Orientation orientation,
        decimal paperWidth,
        decimal paperDimension,
        decimal repeatDimension,
        List<LayoutOption> layouts)
    {
        foreach (var gear in machine.Gears.OrderBy(g => g.Number))
        {
            decimal repeatLength = gear.Circumference;

            // تعداد لیبل در عرض
            int acrossCount =
                GeometryHelper.CalculateAcrossCount(
                    paperWidth,
                    paperDimension,
                    request.GapAcross.Minimum);

            if (acrossCount <= 0)
                continue;

            // تعداد لیبل روی محیط سیلندر
            int aroundCount =
                GeometryHelper.CalculateAroundCount(
                    repeatLength,
                    repeatDimension,
                    request.GapAround.Minimum);

            if (aroundCount <= 0)
                continue;

            GenerateLayout(
                request,
                machine,
                gear,
                orientation,
                paperWidth,
                paperDimension,
                repeatDimension,
                acrossCount,
                aroundCount,
                layouts);
        }
    }

    partial void GenerateLayout(
        FlexoRequest request,
        MachineProfile machine,
        Gear gear,
        Orientation orientation,
        decimal paperWidth,
        decimal paperDimension,
        decimal repeatDimension,
        int acrossCount,
        int aroundCount,
        List<LayoutOption> layouts);
}
