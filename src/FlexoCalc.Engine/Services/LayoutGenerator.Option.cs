using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;

namespace FlexoCalc.Engine.Services;

public sealed partial class LayoutGenerator
{
    partial void CreateLayoutOption(
        FlexoRequest request,
        MachineProfile machine,
        Gear gear,
        Orientation orientation,
        decimal paperWidth,
        decimal repeatLength,
        decimal paperMargin,
        decimal actualAroundGap,
        int aroundCount,
        int acrossCount,
        int labelsPerRepeat,
        long revolutions,
        long overProduction,
        List<LayoutOption> layouts)
    {
        decimal paperMeters =
            revolutions * repeatLength / 1000m;

        decimal paperAreaPerRepeat =
            repeatLength * paperWidth;

        decimal labelArea =
            request.Label.Length *
            request.Label.Width;

        decimal usedArea =
            labelsPerRepeat *
            labelArea;

        decimal wasteArea =
            paperAreaPerRepeat -
            usedArea;

        if (wasteArea < 0)
            wasteArea = 0;

        decimal wastePercent =
            paperAreaPerRepeat == 0
                ? 0
                : wasteArea * 100m / paperAreaPerRepeat;

        layouts.Add(new LayoutOption
        {
            Machine = machine,

            Gear = gear,

            Orientation = orientation,

            PaperWidth = paperWidth,

            AroundCount = aroundCount,

            AcrossCount = acrossCount,

            TotalLabelsPerRepeat = labelsPerRepeat,

            RepeatLength = repeatLength,

            ActualGapAround = actualAroundGap,

            ActualGapAcross = request.GapAcross.Minimum,

            MarginAcross = paperMargin,

            Revolutions = revolutions,

            ProducedQuantity =
                revolutions * labelsPerRepeat,

            OverProduction = overProduction,

            PaperMeters = decimal.Round(
                paperMeters,
                3),

            UsedArea = decimal.Round(
                usedArea,
                3),

            WasteArea = decimal.Round(
                wasteArea,
                3),

            WastePercent = decimal.Round(
                wastePercent,
                3)
        });
    }
}
