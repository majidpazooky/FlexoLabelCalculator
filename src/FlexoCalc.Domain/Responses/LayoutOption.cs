using FlexoCalc.Domain.Enums;
using FlexoCalc.Domain.Machines;
using FlexoCalc.Domain.ValueObjects;

namespace FlexoCalc.Domain.Responses;

/// <summary>
/// یک گزینه معتبر برای چاپ لیبل.
/// هر LayoutOption نتیجه بررسی یک ترکیب مشخص است.
/// </summary>
public sealed class LayoutOption
{
    /// <summary>
    /// دستگاه انتخاب شده
    /// </summary>
    public required MachineProfile Machine { get; init; }

    /// <summary>
    /// دنده انتخاب شده
    /// </summary>
    public required Gear Gear { get; init; }

    /// <summary>
    /// جهت قرارگیری لیبل
    /// </summary>
    public required Orientation Orientation { get; init; }

    /// <summary>
    /// ابعاد واقعی لیبل
    /// </summary>
    public required LabelSize Label { get; init; }

    /// <summary>
    /// عرض واقعی کاغذ مصرفی
    /// </summary>
    public decimal PaperWidth { get; init; }

    /// <summary>
    /// اگر از جامبو استخراج شده باشد،
    /// تعداد برش جامبو
    /// </summary>
    public int JumboSlits { get; init; }

    /// <summary>
    /// تعداد لیبل در امتداد حرکت کاغذ
    /// </summary>
    public int AroundCount { get; init; }

    /// <summary>
    /// تعداد لیبل در عرض کاغذ
    /// </summary>
    public int AcrossCount { get; init; }

    /// <summary>
    /// فاصله واقعی طولی
    /// </summary>
    public decimal AroundGap { get; init; }

    /// <summary>
    /// فاصله واقعی عرضی
    /// </summary>
    public decimal AcrossGap { get; init; }

    /// <summary>
    /// حاشیه آزاد دو طرف کاغذ
    /// </summary>
    public decimal SideMargin { get; init; }

    /// <summary>
    /// تعداد کل لیبل در یک دور سیلندر
    /// </summary>
    public int LabelsPerRevolution =>
        AroundCount * AcrossCount;

    /// <summary>
    /// تعداد دور لازم
    /// </summary>
    public long Revolutions { get; init; }

    /// <summary>
    /// تعداد واقعی تولید
    /// </summary>
    public long ProducedQuantity { get; init; }

    /// <summary>
    /// اضافه تولید
    /// </summary>
    public long OverProduction =>
        ProducedQuantity - RequestedQuantity;

    /// <summary>
    /// تیراژ سفارش
    /// </summary>
    public long RequestedQuantity { get; init; }

    /// <summary>
    /// متراژ کاغذ
    /// </summary>
    public decimal PaperConsumptionMeters { get; init; }

    /// <summary>
    /// درصد پرتی
    /// </summary>
    public decimal WastePercent { get; init; }

    /// <summary>
    /// امتیاز نهایی
    /// بعداً توسط Ranking Engine مقداردهی می‌شود.
    /// </summary>
    public decimal Score { get; init; }

    /// <summary>
    /// خروجی شماتیک مونتاژ
    /// </summary>
    public string? LayoutDiagram { get; init; }

    public override string ToString()
    {
        return
            $"{Machine.Name} | " +
            $"Gear {Gear.Number} | " +
            $"{AroundCount}×{AcrossCount} | " +
            $"{WastePercent:0.##}%";
    }
}
