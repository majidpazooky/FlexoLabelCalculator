using FlexoCalc.Domain.ValueObjects;

namespace FlexoCalc.Domain.Machines;

/// <summary>
/// مشخصات کامل یک ماشین چاپ فلکسو.
/// این کلاس تمام ویژگی‌های ثابت هر ماشین را نگهداری می‌کند.
/// </summary>
public sealed class MachineProfile
{
    /// <summary>
    /// شناسه یکتا
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// نام دستگاه
    /// مثال:
    /// Omet
    /// Beta
    /// Alpha
    /// 10 Color
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// حداکثر عرض قابل چاپ (mm)
    /// </summary>
    public decimal MaxPaperWidth { get; init; }

    /// <summary>
    /// حداقل عرض قابل چاپ (mm)
    /// </summary>
    public decimal MinPaperWidth { get; init; }

    /// <summary>
    /// ضریب تبدیل شماره دنده به محیط واقعی
    /// معمولاً 3.175
    /// </summary>
    public decimal GearPitch { get; init; } = Gear.Pitch;

    /// <summary>
    /// لیست دنده‌های موجود روی دستگاه
    /// </summary>
    public IReadOnlyList<Gear> Gears { get; init; } = Array.Empty<Gear>();

    /// <summary>
    /// آیا این دستگاه از محاسبه جامبو پشتیبانی می‌کند؟
    /// </summary>
    public bool SupportsJumboOptimization { get; init; } = true;

    /// <summary>
    /// آیا این دستگاه امکان چاپ پشت و رو دارد؟
    /// </summary>
    public bool SupportsReversePrinting { get; init; }

    /// <summary>
    /// آیا دستگاه امکان چاپ نیم روتاری دارد؟
    /// </summary>
    public bool SupportsSemiRotary { get; init; }

    /// <summary>
    /// آیا دستگاه امکان چاپ تمام روتاری دارد؟
    /// </summary>
    public bool SupportsFullRotary { get; init; } = true;

    /// <summary>
    /// تعداد یونیت‌های چاپ
    /// </summary>
    public int ColorStations { get; init; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// بررسی معتبر بودن عرض کاغذ
    /// </summary>
    public bool IsPaperWidthValid(decimal width)
    {
        return width >= MinPaperWidth &&
               width <= MaxPaperWidth;
    }

    /// <summary>
    /// پیدا کردن دنده از روی شماره
    /// </summary>
    public Gear? FindGear(int number)
    {
        return Gears.FirstOrDefault(x => x.Number == number);
    }

    /// <summary>
    /// بررسی وجود دنده
    /// </summary>
    public bool HasGear(int number)
    {
        return Gears.Any(x => x.Number == number);
    }

    public override string ToString()
    {
        return Name;
    }
}
