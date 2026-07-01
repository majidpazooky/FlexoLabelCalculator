using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;
using FlexoCalc.Engine.Internal;

namespace FlexoCalc.Engine.Services;

public sealed partial class LayoutGenerator
{
    partial void GenerateForOrientation(
        FlexoRequest request,
        MachineProfile machine,
        Orientation orientation,
        List<LayoutOption> layouts)
    {
        // ============================================
        // تعیین ابعاد واقعی لیبل بر اساس جهت قرارگیری
        //
        // Portrait
        //      طول لیبل روی عرض کاغذ
        //      عرض لیبل روی محیط سیلندر
        //
        // Landscape
        //      عرض لیبل روی عرض کاغذ
        //      طول لیبل روی محیط سیلندر
        //
        // این دقیقاً همان اصلاحی است که بعد از بررسی
        // مونتاژهای واقعی کارخانه انجام شد.
        // ============================================

        decimal repeatDimension =
            GeometryHelper.GetRepeatDimension(
                request.Label,
                orientation);

        decimal paperDimension =
            GeometryHelper.GetPaperDimension(
                request.Label,
                orientation);

        // تولید تمام عرض‌های قابل بررسی
        foreach (var paperWidth in GetCandidatePaperWidths(request, machine))
        {
            // اگر حتی یک لیبل هم جا نشود
            if (paperWidth < paperDimension)
                continue;

            GenerateForPaperWidth(
                request,
                machine,
                orientation,
                paperWidth,
                paperDimension,
                repeatDimension,
                layouts);
        }
    }

    partial void GenerateForPaperWidth(
        FlexoRequest request,
        MachineProfile machine,
        Orientation orientation,
        decimal paperWidth,
        decimal paperDimension,
        decimal repeatDimension,
        List<LayoutOption> layouts);

    IEnumerable<decimal> GetCandidatePaperWidths(
        FlexoRequest request,
        MachineProfile machine);
}
