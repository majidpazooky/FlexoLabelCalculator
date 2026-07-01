using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.ValueObjects;

namespace FlexoCalc.Engine.Internal;

/// <summary>
/// توابع هندسی مورد استفاده در موتور محاسبات.
/// این کلاس هیچ وابستگی به UI یا API ندارد.
/// </summary>
internal static class GeometryHelper
{
    /// <summary>
    /// ضریب تبدیل شماره دنده به محیط واقعی سیلندر.
    /// طبق استاندارد دستگاه‌های کارخانه.
    /// </summary>
    public const decimal GearFactor = 3.175m;

    /// <summary>
    /// تبدیل شماره دنده به محیط واقعی سیلندر (mm)
    /// </summary>
    public static decimal GearToRepeat(int gearNumber)
    {
        return gearNumber * GearFactor;
    }

    /// <summary>
    /// بعد قرار گرفته روی محیط سیلندر
    /// </summary>
    public static decimal GetRepeatDimension(
        LabelSize size,
        Orientation orientation)
    {
        return orientation == Orientation.Portrait
            ? size.Width
            : size.Length;
    }

    /// <summary>
    /// بعد قرار گرفته روی عرض کاغذ
    /// </summary>
    public static decimal GetPaperDimension(
        LabelSize size,
        Orientation orientation)
    {
        return orientation == Orientation.Portrait
            ? size.Length
            : size.Width;
    }

    /// <summary>
    /// محاسبه تعداد لیبل قابل قرارگیری روی عرض کاغذ
    /// </summary>
    public static int CalculateAcrossCount(
        decimal paperWidth,
        decimal labelWidth,
        decimal gap)
    {
        if (paperWidth < labelWidth)
            return 0;

        return (int)((paperWidth + gap) /
                     (labelWidth + gap));
    }

    /// <summary>
    /// محاسبه تعداد لیبل قابل قرارگیری روی محیط سیلندر
    /// </summary>
    public static int CalculateAroundCount(
        decimal repeatLength,
        decimal labelLength,
        decimal gap)
    {
        if (repeatLength < labelLength)
            return 0;

        return (int)((repeatLength + gap) /
                     (labelLength + gap));
    }

    /// <summary>
    /// فاصله واقعی بین لیبل‌ها روی محیط سیلندر
    /// </summary>
    public static decimal CalculateActualAroundGap(
        decimal repeatLength,
        decimal labelLength,
        int count)
    {
        if (count <= 0)
            return 0;

        return (repeatLength - (count * labelLength)) / count;
    }

    /// <summary>
    /// فضای باقیمانده عرض کاغذ
    /// </summary>
    public static decimal CalculatePaperMargin(
        decimal paperWidth,
        decimal labelWidth,
        decimal gap,
        int count)
    {
        if (count <= 0)
            return paperWidth;

        return paperWidth -
               (count * labelWidth + (count - 1) * gap);
    }
}
