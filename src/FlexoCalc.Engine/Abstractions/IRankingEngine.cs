using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Responses;

namespace FlexoCalc.Engine.Abstractions;

/// <summary>
/// مسئول رتبه‌بندی Layout ها
/// </summary>
public interface IRankingEngine
{
    /// <summary>
    /// مرتب‌سازی Layout ها بر اساس استراتژی انتخاب‌شده
    /// </summary>
    IReadOnlyList<LayoutOption> Rank(
        IEnumerable<LayoutOption> layouts,
        SortMode sortMode);
}
