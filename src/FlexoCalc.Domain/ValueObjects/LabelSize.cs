using System;

namespace FlexoCalc.Domain.ValueObjects;

/// <summary>
/// ابعاد واقعی لیبل.
///
/// این کلاس فقط طول و عرض نیست؛
/// تمام مشخصات فیزیکی لیبل که روی قالب‌سازی
/// و محاسبات چاپ اثر دارند در این کلاس قرار می‌گیرند.
///
/// Immutable Value Object
/// </summary>
public sealed record LabelSize
{
    /// <summary>
    /// طول لیبل (در جهت حرکت کاغذ)
    /// </summary>
    public decimal Length { get; }

    /// <summary>
    /// عرض لیبل
    /// </summary>
    public decimal Width { get; }

    /// <summary>
    /// مقدار Bleed
    /// پیش فرض صفر
    /// </summary>
    public decimal Bleed { get; }

    /// <summary>
    /// فاصله Safe Area از لبه
    /// </summary>
    public decimal SafeMargin { get; }

    /// <summary>
    /// شعاع گوشه‌ها
    /// </summary>
    public decimal CornerRadius { get; }

    /// <summary>
    /// فاصله تیغ قالب
    /// </summary>
    public decimal DieClearance { get; }

    /// <summary>
    /// مساحت لیبل
    /// </summary>
    public decimal Area => Length * Width;

    /// <summary>
    /// طول همراه Bleed
    /// </summary>
    public decimal TotalLength => Length + (Bleed * 2);

    /// <summary>
    /// عرض همراه Bleed
    /// </summary>
    public decimal TotalWidth => Width + (Bleed * 2);

    public LabelSize(
        decimal length,
        decimal width,
        decimal bleed = 0,
        decimal safeMargin = 0,
        decimal cornerRadius = 0,
        decimal dieClearance = 0)
    {
        if (length <= 0)
            throw new ArgumentOutOfRangeException(nameof(length));

        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width));

        if (bleed < 0)
            throw new ArgumentOutOfRangeException(nameof(bleed));

        if (safeMargin < 0)
            throw new ArgumentOutOfRangeException(nameof(safeMargin));

        if (cornerRadius < 0)
            throw new ArgumentOutOfRangeException(nameof(cornerRadius));

        if (dieClearance < 0)
            throw new ArgumentOutOfRangeException(nameof(dieClearance));

        Length = length;
        Width = width;
        Bleed = bleed;
        SafeMargin = safeMargin;
        CornerRadius = cornerRadius;
        DieClearance = dieClearance;
    }

    /// <summary>
    /// نسخه ۹۰ درجه چرخیده لیبل
    /// </summary>
    public LabelSize Rotate()
    {
        return new LabelSize(
            Width,
            Length,
            Bleed,
            SafeMargin,
            CornerRadius,
            DieClearance);
    }

    /// <summary>
    /// نسخه کوچک‌تر شده لیبل
    /// (برای موتور پیشنهاد کاهش پرتی)
    /// </summary>
    public LabelSize Shrink(
        decimal reduceLength,
        decimal reduceWidth)
    {
        return new LabelSize(
            Length - reduceLength,
            Width - reduceWidth,
            Bleed,
            SafeMargin,
            CornerRadius,
            DieClearance);
    }

    public override string ToString()
    {
        return $"{Length:0.###} × {Width:0.###} mm";
    }
}
