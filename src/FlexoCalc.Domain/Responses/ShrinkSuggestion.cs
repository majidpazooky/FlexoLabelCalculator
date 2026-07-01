using FlexoCalc.Domain.ValueObjects;

namespace FlexoCalc.Domain.Responses;

/// <summary>
/// پیشنهاد کوچک‌سازی ابعاد لیبل
/// جهت کاهش پرتی یا کاهش مصرف کاغذ.
/// </summary>
public sealed class ShrinkSuggestion
{
    /// <summary>
    /// ابعاد فعلی
    /// </summary>
    public required LabelSize OriginalSize { get; init; }

    /// <summary>
    /// ابعاد پیشنهادی
    /// </summary>
    public required LabelSize SuggestedSize { get; init; }

    /// <summary>
    /// میزان کاهش طول
    /// </summary>
    public decimal ReducedLength =>
        OriginalSize.Length - SuggestedSize.Length;

    /// <summary>
    /// میزان کاهش عرض
    /// </summary>
    public decimal ReducedWidth =>
        OriginalSize.Width - SuggestedSize.Width;

    /// <summary>
    /// پرتی قبل از اصلاح
    /// </summary>
    public decimal OriginalWastePercent { get; init; }

    /// <summary>
    /// پرتی بعد از اصلاح
    /// </summary>
    public decimal NewWastePercent { get; init; }

    /// <summary>
    /// متراژ قبل
    /// </summary>
    public decimal OriginalPaperMeters { get; init; }

    /// <summary>
    /// متراژ بعد
    /// </summary>
    public decimal NewPaperMeters { get; init; }

    /// <summary>
    /// درصد بهبود
    /// </summary>
    public decimal WasteImprovement =>
        OriginalWastePercent - NewWastePercent;

    /// <summary>
    /// کاهش مصرف کاغذ
    /// </summary>
    public decimal SavedPaperMeters =>
        OriginalPaperMeters - NewPaperMeters;

    /// <summary>
    /// توضیح پیشنهادی
    /// </summary>
    public string Description =>
        $"Length -{ReducedLength:0.###} mm , Width -{ReducedWidth:0.###} mm";
}
