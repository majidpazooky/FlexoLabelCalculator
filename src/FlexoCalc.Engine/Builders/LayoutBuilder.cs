using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;

namespace FlexoCalc.Engine.Builders;

/// <summary>
/// مسئول ساخت LayoutOption.
/// این کلاس فقط Object می‌سازد و هیچ تصمیم محاسباتی نمی‌گیرد.
/// </summary>
public sealed class LayoutBuilder
{
    public LayoutOption Build(
        FlexoRequest request,
        MachineProfile machine,
        Gear gear,
        Orientation orientation,
        decimal paperWidth,
        decimal repeatLength,
        decimal paperMargin,
        decimal actualGapAround,
        decimal actualGapAcross,
        int aroundCount,
        int acrossCount,
        int labelsPerRepeat,
        long revolutions,
        long overProduction)
    {
        decimal paperMeters =
            revolutions * repeatLength / 1000m;

        decimal paperArea =
            repeatLength * paperWidth;

        decimal usedArea =
            labelsPerRepeat *
            request.Label.Length *
            request.Label.Width;

        decimal wasteArea =
            Math.Max(0m, paperArea - usedArea);

        decimal wastePercent =
            paperArea == 0
                ? 0
                : wasteArea * 100m / paperArea;

        return new LayoutOption
        {
            Machine = machine,

            Gear = gear,

            Orientation = orientation,

            PaperWidth = paperWidth,

            RepeatLength = repeatLength,

            AroundCount = aroundCount,

            AcrossCount = acrossCount,

            TotalLabelsPerRepeat = labelsPerRepeat,

            ActualGapAround = actualGapAround,

            ActualGapAcross = actualGapAcross,

            MarginAcross = paperMargin,

            Revolutions = revolutions,

            ProducedQuantity =
                revolutions * labelsPerRepeat,

            OverProduction = overProduction,

            PaperMeters =
                decimal.Round(paperMeters,3),

            UsedArea =
                decimal.Round(usedArea,3),

            WasteArea =
                decimal.Round(wasteArea,3),

            WastePercent =
                decimal.Round(wastePercent,3)
        };
    }
}
