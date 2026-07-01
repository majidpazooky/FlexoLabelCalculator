using FlexoCalc.Domain.Requests;

namespace FlexoCalc.Engine.Services;

public sealed partial class LayoutGenerator
{
    /// <summary>
    /// تولید تمام عرض‌های قابل بررسی.
    ///
    /// سه حالت وجود دارد:
    ///
    /// 1) Manual
    ///      فقط همان عرض انتخاب شده کاربر
    ///
    /// 2) Auto + OptimizeJumbo = false
    ///      تمام عرض‌های مجاز دستگاه
    ///
    /// 3) Auto + OptimizeJumbo = true
    ///      تقسیم‌های صحیح جامبو
    /// </summary>
    IEnumerable<decimal> GetCandidatePaperWidths(
        FlexoRequest request,
        MachineProfile machine)
    {
        // -------------------------------
        // حالت Manual
        // -------------------------------

        if (!request.AutoPaperWidth)
        {
            if (request.PaperWidth <= machine.MaxPaperWidth)
                yield return request.PaperWidth;

            yield break;
        }

        // -------------------------------
        // Auto بدون جامبو
        // -------------------------------

        if (!request.OptimizeJumbo)
        {
            decimal width = 10m;

            while (width <= machine.MaxPaperWidth)
            {
                yield return width;
                width += 0.1m;
            }

            yield break;
        }

        // -------------------------------
        // Auto با جامبو
        // -------------------------------

        for (int slit = 1; slit <= request.MaxJumboSlits; slit++)
        {
            decimal paperWidth =
                request.JumboWidth / slit;

            if (paperWidth > machine.MaxPaperWidth)
                continue;

            yield return decimal.Round(
                paperWidth,
                3,
                MidpointRounding.AwayFromZero);
        }
    }
}
