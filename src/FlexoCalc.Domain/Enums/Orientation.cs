namespace FlexoCalc.Domain.Enums;

/// <summary>
/// جهت قرارگیری لیبل روی سیلندر چاپ
/// </summary>
public enum Orientation
{
    /// <summary>
    /// حالت ایستاده
    /// طول لیبل در امتداد حرکت کاغذ (محیط سیلندر) قرار می‌گیرد.
    /// </summary>
    Portrait = 0,

    /// <summary>
    /// حالت خوابیده
    /// عرض لیبل در امتداد حرکت کاغذ (محیط سیلندر) قرار می‌گیرد.
    /// </summary>
    Landscape = 1,

    /// <summary>
    /// هر دو حالت بررسی شوند و بهترین نتیجه انتخاب گردد.
    /// </summary>
    Auto = 2
}
