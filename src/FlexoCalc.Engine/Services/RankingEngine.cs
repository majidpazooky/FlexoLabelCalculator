using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Responses;
using FlexoCalc.Engine.Abstractions;

namespace FlexoCalc.Engine.Services;

/// <summary>
/// رتبه‌بندی Layout ها
/// </summary>
public sealed class RankingEngine : IRankingEngine
{
    public IReadOnlyList<LayoutOption> Rank(
        IEnumerable<LayoutOption> layouts,
        SortMode sortMode)
    {
        return sortMode switch
        {
            SortMode.LowestWaste =>
                layouts
                    .OrderBy(x => x.WastePercent)
                    .ThenBy(x => x.PaperMeters)
                    .ThenBy(x => x.OverProduction)
                    .ToList(),

            SortMode.LowestPaper =>
                layouts
                    .OrderBy(x => x.PaperMeters)
                    .ThenBy(x => x.WastePercent)
                    .ThenBy(x => x.OverProduction)
                    .ToList(),

            SortMode.LowestOverProduction =>
                layouts
                    .OrderBy(x => x.OverProduction)
                    .ThenBy(x => x.WastePercent)
                    .ThenBy(x => x.PaperMeters)
                    .ToList(),

            _ =>
                RankSmart(layouts)
        };
    }

    private static IReadOnlyList<LayoutOption> RankSmart(
        IEnumerable<LayoutOption> layouts)
    {
        return layouts
            .OrderBy(x => x.WastePercent)
            .ThenBy(x => x.PaperMeters)
            .ThenBy(x => x.OverProduction)
            .ThenByDescending(x => x.TotalLabelsPerRepeat)
            .ToList();
    }
}
