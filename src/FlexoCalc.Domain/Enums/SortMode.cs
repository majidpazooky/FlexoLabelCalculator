namespace FlexoCalc.Domain.Enums;

/// <summary>
/// مشخص می‌کند نتایج بر اساس چه معیاری رتبه‌بندی شوند.
/// </summary>
public enum SortMode
{
    /// <summary>
    /// کمترین درصد پرتی.
    /// </summary>
    LowestWaste = 0,

    /// <summary>
    /// کمترین متراژ مصرفی کاغذ.
    /// </summary>
    LowestPaperConsumption = 1,

    /// <summary>
    /// کمترین اضافه تولید (Over Production).
    /// </summary>
    LowestOverProduction = 2,

    /// <summary>
    /// امتیاز ترکیبی (هوشمند).
    /// این حالت در آینده می‌تواند با وزن‌دهی به چند معیار توسعه پیدا کند.
    /// </summary>
    Smart = 3
}
