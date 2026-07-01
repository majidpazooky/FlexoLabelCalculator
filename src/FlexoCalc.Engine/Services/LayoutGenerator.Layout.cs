using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;
using FlexoCalc.Engine.Internal;

namespace FlexoCalc.Engine.Services;

public sealed partial class LayoutGenerator
{
    partial void GenerateLayout(
        FlexoRequest request,
        MachineProfile machine,
        Gear gear,
        Orientation orientation,
        decimal paperWidth,
        decimal paperDimension,
        decimal repeatDimension,
        int acrossCount,
        int aroundCount,
        List<LayoutOption> layouts)
    {
        decimal repeatLength = gear.Circumference;

        //==========================================================
        // محاسبه فاصله واقعی روی محیط سیلندر
        //==========================================================

        decimal actualAroundGap =
            GeometryHelper.CalculateActualAroundGap(
                repeatLength,
                repeatDimension,
                aroundCount);

        // خارج از بازه مجاز؟
        if (actualAroundGap < request.GapAround.Minimum)
            return;

        if (request.GapAround.Maximum > 0 &&
            actualAroundGap > request.GapAround.Maximum)
            return;

        //==========================================================
        // محاسبه فضای باقی مانده عرض کاغذ
        //==========================================================

        decimal paperMargin =
            GeometryHelper.CalculatePaperMargin(
                paperWidth,
                paperDimension,
                request.GapAcross.Minimum,
                acrossCount);

        //==========================================================
        // تعداد کل لیبل در هر دور
        //==========================================================

        int labelsPerRepeat =
            aroundCount * acrossCount;

        if (labelsPerRepeat <= 0)
            return;

        //==========================================================
        // محاسبه تیراژ
        //==========================================================

        long revolutions =
            (long)Math.Ceiling(
                request.Quantity /
                (decimal)labelsPerRepeat);

        long produced =
            revolutions * labelsPerRepeat;

        long overProduction =
            produced - request.Quantity;

        //==========================================================
        // ادامه محاسبات در فایل بعدی
        //==========================================================

        CreateLayoutOption(
            request,
            machine,
            gear,
            orientation,
            paperWidth,
            repeatLength,
            paperMargin,
            actualAroundGap,
            aroundCount,
            acrossCount,
            labelsPerRepeat,
            revolutions,
            overProduction,
            layouts);
    }

    partial void CreateLayoutOption(
        FlexoRequest request,
        MachineProfile machine,
        Gear gear,
        Orientation orientation,
        decimal paperWidth,
        decimal repeatLength,
        decimal paperMargin,
        decimal actualAroundGap,
        int aroundCount,
        int acrossCount,
        int labelsPerRepeat,
        long revolutions,
        long overProduction,
        List<LayoutOption> layouts);
}
