using FlexoCalc.Domain.Enums;
using FlexoCalc.Domain.Machines;
using FlexoCalc.Domain.ValueObjects;

namespace FlexoCalc.Domain.Requests;

/// <summary>
/// درخواست محاسبه قالب چاپ فلکسو.
/// این کلاس تمام ورودی‌های موردنیاز موتور محاسبات را در خود نگه می‌دارد.
/// </summary>
public sealed class FlexoCalculationRequest
{
    /// <summary>
    /// ابعاد لیبل
    /// </summary>
    public required LabelSize Label { get; init; }

    /// <summary>
    /// تیراژ سفارش
    /// </summary>
    public required long Quantity { get; init; }

    /// <summary>
    /// جهت قرارگیری لیبل
    /// </summary>
    public Orientation Orientation { get; init; } = Orientation.Auto;

    /// <summary>
    /// نحوه انتخاب عرض کاغذ
    /// </summary>
    public PaperWidthMode PaperWidthMode { get; init; }
        = PaperWidthMode.Auto;

    /// <summary>
    /// اگر PaperWidthMode برابر Manual باشد،
    /// این مقدار استفاده می‌شود.
    /// </summary>
    public decimal? ManualPaperWidth { get; init; }

    /// <summary>
    /// عرض جامبو رول
    /// </summary>
    public decimal JumboWidth { get; init; } = 1020m;

    /// <summary>
    /// حداکثر تعداد برش جامبو
    /// </summary>
    public int MaxSlits { get; init; } = 20;

    /// <summary>
    /// قوانین فاصله‌گذاری
    /// </summary>
    public GapRule GapRule { get; init; }
        = GapRule.Standard;

    /// <summary>
    /// نحوه رتبه‌بندی نتایج
    /// </summary>
    public SortMode SortMode { get; init; }
        = SortMode.Smart;

    /// <summary>
    /// دستگاه‌های انتخاب‌شده
    /// </summary>
    public IReadOnlyList<MachineProfile> Machines { get; init; }
        = Array.Empty<MachineProfile>();

    /// <summary>
    /// آیا پیشنهاد کوچک‌سازی بررسی شود؟
    /// </summary>
    public bool EnableShrinkSuggestion { get; init; } = true;

    /// <summary>
    /// حداکثر میزان کاهش ابعاد (mm)
    /// </summary>
    public decimal MaxShrink { get; init; } = 5m;

    /// <summary>
    /// نمایش شماتیک مونتاژ
    /// </summary>
    public bool GenerateLayoutDiagram { get; init; } = true;

    /// <summary>
    /// اعتبارسنجی اولیه درخواست
    /// </summary>
    public void Validate()
    {
        if (Quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(Quantity));

        if (Machines.Count == 0)
            throw new InvalidOperationException("حداقل یک دستگاه باید انتخاب شود.");

        if (PaperWidthMode == PaperWidthMode.Manual &&
            (!ManualPaperWidth.HasValue || ManualPaperWidth <= 0))
            throw new InvalidOperationException("عرض کاغذ دستی وارد نشده است.");

        if (JumboWidth <= 0)
            throw new ArgumentOutOfRangeException(nameof(JumboWidth));

        if (MaxSlits <= 0)
            throw new ArgumentOutOfRangeException(nameof(MaxSlits));

        if (MaxShrink < 0)
            throw new ArgumentOutOfRangeException(nameof(MaxShrink));
    }
}
