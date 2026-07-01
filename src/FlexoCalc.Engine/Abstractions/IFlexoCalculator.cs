using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;

namespace FlexoCalc.Engine.Abstractions;

/// <summary>
/// موتور اصلی محاسبات فلکسو
/// </summary>
public interface IFlexoCalculator
{
    /// <summary>
    /// انجام محاسبات
    /// </summary>
    FlexoResult Calculate(FlexoRequest request);
}
