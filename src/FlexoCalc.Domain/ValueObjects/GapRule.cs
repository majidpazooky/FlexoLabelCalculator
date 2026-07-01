namespace FlexoCalc.Domain.ValueObjects;

/// <summary>
/// قوانین فاصله مجاز بین لیبل‌ها.
/// این کلاس تعیین می‌کند حداقل و حداکثر فاصله قابل قبول
/// در جهت طولی و عرضی چقدر باشد.
/// </summary>
public sealed record GapRule
{
    /// <summary>
    /// حداقل فاصله مجاز در جهت حرکت کاغذ (Around)
    /// </summary>
    public decimal AroundMin { get; init; }

    /// <summary>
    /// حداکثر فاصله مجاز در جهت حرکت کاغذ (Around)
    /// </summary>
    public decimal AroundMax { get; init; }

    /// <summary>
    /// حداقل فاصله مجاز در جهت عرض کاغذ (Across)
    /// </summary>
    public decimal AcrossMin { get; init; }

    /// <summary>
    /// حداکثر فاصله مجاز در جهت عرض کاغذ (Across)
    /// </summary>
    public decimal AcrossMax { get; init; }

    /// <summary>
    /// قوانین استاندارد چاپ فلکسو.
    /// Around : 2 تا 3 میلی‌متر
    /// Across : 2.7 تا 3 میلی‌متر
    /// </summary>
    public static GapRule Standard => new()
    {
        AroundMin = 2.0m,
        AroundMax = 3.0m,
        AcrossMin = 2.7m,
        AcrossMax = 3.0m
    };

    /// <summary>
    /// بدون محدودیت فاصله.
    /// مناسب برای تحلیل و شبیه‌سازی.
    /// </summary>
    public static GapRule Unlimited => new()
    {
        AroundMin = 0,
        AroundMax = decimal.MaxValue,
        AcrossMin = 0,
        AcrossMax = decimal.MaxValue
    };

    /// <summary>
    /// بررسی معتبر بودن فاصله طولی.
    /// </summary>
    public bool IsAroundValid(decimal gap)
        => gap >= AroundMin && gap <= AroundMax;

    /// <summary>
    /// بررسی معتبر بودن فاصله عرضی.
    /// </summary>
    public bool IsAcrossValid(decimal gap)
        => gap >= AcrossMin && gap <= AcrossMax;
}
