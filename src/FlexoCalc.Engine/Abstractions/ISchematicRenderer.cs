using FlexoCalc.Domain.Responses;

namespace FlexoCalc.Engine.Abstractions;

/// <summary>
/// تولید شماتیک Layout
/// </summary>
public interface ISchematicRenderer
{
    /// <summary>
    /// شماتیک قابل نمایش برای Layout را تولید می‌کند.
    /// </summary>
    /// <param name="layout">Layout مورد نظر</param>
    /// <returns>شماتیک متنی یا گرافیکی</returns>
    string Render(LayoutOption layout);
}
