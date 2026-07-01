namespace FlexoCalc.Domain.Enums;

/// <summary>
/// نحوه انتخاب عرض کاغذ مصرفی برای چاپ.
/// </summary>
public enum PaperWidthMode
{
    /// <summary>
    /// موتور محاسبات تمام عرض‌های ممکن را بررسی می‌کند
    /// و بهترین گزینه را بر اساس معیار مرتب‌سازی انتخاب می‌کند.
    /// </summary>
    Auto = 0,

    /// <summary>
    /// کاربر عرض کاغذ مصرفی را به صورت مستقیم وارد می‌کند.
    /// </summary>
    Manual = 1,

    /// <summary>
    /// موتور محاسبات فقط عرض‌هایی را بررسی می‌کند
    /// که از تقسیم جامبو رول به دست می‌آیند.
    /// </summary>
    JumboOptimization = 2
}
