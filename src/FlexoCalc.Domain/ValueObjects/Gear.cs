using System;

namespace FlexoCalc.Domain.ValueObjects;

/// <summary>
/// نماینده یک دنده (Gear Number) در ماشین چاپ فلکسو.
///
/// نکته بسیار مهم:
/// عدد دنده (مثلاً 75 ،93 ،120)
/// محیط واقعی سیلندر نیست.
///
/// محیط واقعی از رابطه زیر به دست می‌آید:
///
/// Circumference(mm) = GearNumber × 3.175
///
/// مثال:
///
/// Gear 75
/// Circumference = 238.125 mm
///
/// Gear 93
/// Circumference = 295.275 mm
///
/// تمام محاسبات مونتاژ، فاصله و تکرار باید
/// بر اساس محیط واقعی انجام شوند نه شماره دنده.
/// </summary>
public sealed record Gear
{
    /// <summary>
    /// ضریب تبدیل شماره دنده به محیط واقعی سیلندر (mm)
    /// </summary>
    public const decimal Pitch = 3.175m;

    /// <summary>
    /// شماره دنده
    /// </summary>
    public int Number { get; }

    /// <summary>
    /// محیط واقعی سیلندر (mm)
    /// </summary>
    public decimal Circumference => Number * Pitch;

    /// <summary>
    /// محیط واقعی (cm)
    /// صرفاً برای نمایش
    /// </summary>
    public decimal CircumferenceCm => Circumference / 10m;

    public Gear(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number));

        Number = number;
    }

    /// <summary>
    /// ایجاد Gear از شماره دنده
    /// </summary>
    public static Gear FromNumber(int number)
        => new(number);

    /// <summary>
    /// تبدیل محیط واقعی به نزدیک‌ترین شماره دنده.
    /// برای کاربردهای مهندسی و تحلیل.
    /// </summary>
    public static Gear FromCircumference(decimal circumference)
    {
        if (circumference <= 0)
            throw new ArgumentOutOfRangeException(nameof(circumference));

        var number = (int)Math.Round(circumference / Pitch);

        return new Gear(number);
    }

    /// <summary>
    /// اختلاف محیط این دنده با دنده دیگر
    /// </summary>
    public decimal Difference(Gear other)
        => Math.Abs(Circumference - other.Circumference);

    public override string ToString()
        => $"Gear {Number} ({Circumference:0.###} mm)";
}
