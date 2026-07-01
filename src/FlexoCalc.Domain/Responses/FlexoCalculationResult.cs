using FlexoCalc.Domain.Machines;

namespace FlexoCalc.Domain.Responses;

/// <summary>
/// نتیجه نهایی محاسبات موتور FlexoCalc.
/// </summary>
public sealed class FlexoCalculationResult
{
    /// <summary>
    /// آیا محاسبه موفق بوده است؟
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// پیام خطا در صورت وجود
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// بهترین گزینه بین تمام دستگاه‌ها
    /// </summary>
    public LayoutOption? BestOption { get; init; }

    /// <summary>
    /// بهترین گزینه هر دستگاه
    /// </summary>
    public IReadOnlyList<LayoutOption> BestPerMachine { get; init; }
        = Array.Empty<LayoutOption>();

    /// <summary>
    /// تمام گزینه‌های معتبر
    /// </summary>
    public IReadOnlyList<LayoutOption> AllOptions { get; init; }
        = Array.Empty<LayoutOption>();

    /// <summary>
    /// پیشنهاد کوچک کردن ابعاد لیبل
    /// </summary>
    public ShrinkSuggestion? ShrinkSuggestion { get; init; }

    /// <summary>
    /// تعداد کل گزینه‌های بررسی شده
    /// </summary>
    public int TotalEvaluatedLayouts { get; init; }

    /// <summary>
    /// مدت زمان محاسبه
    /// </summary>
    public TimeSpan ElapsedTime { get; init; }

    /// <summary>
    /// دستگاه‌هایی که در محاسبه شرکت داشته‌اند.
    /// </summary>
    public IReadOnlyList<MachineProfile> Machines { get; init; }
        = Array.Empty<MachineProfile>();

    /// <summary>
    /// تعداد گزینه‌های معتبر
    /// </summary>
    public int ValidOptions => AllOptions.Count;

    /// <summary>
    /// آیا پیشنهاد کوچک‌سازی وجود دارد؟
    /// </summary>
    public bool HasShrinkSuggestion =>
        ShrinkSuggestion is not null;

    /// <summary>
    /// آیا حداقل یک گزینه معتبر پیدا شده است؟
    /// </summary>
    public bool HasResult =>
        BestOption is not null;

    /// <summary>
    /// ایجاد نتیجه موفق
    /// </summary>
    public static FlexoCalculationResult Ok(
        LayoutOption best,
        IReadOnlyList<LayoutOption> all,
        IReadOnlyList<LayoutOption> bestPerMachine,
        IReadOnlyList<MachineProfile> machines,
        int evaluatedLayouts,
        TimeSpan elapsed,
        ShrinkSuggestion? shrink = null)
    {
        return new FlexoCalculationResult
        {
            Success = true,

            BestOption = best,

            AllOptions = all,

            BestPerMachine = bestPerMachine,

            Machines = machines,

            ShrinkSuggestion = shrink,

            TotalEvaluatedLayouts = evaluatedLayouts,

            ElapsedTime = elapsed
        };
    }

    /// <summary>
    /// ایجاد نتیجه ناموفق
    /// </summary>
    public static FlexoCalculationResult Fail(string error)
    {
        return new FlexoCalculationResult
        {
            Success = false,
            ErrorMessage = error
        };
    }
}
