using FlexoCalc.Domain.Common;
using FlexoCalc.Domain.Requests;
using FlexoCalc.Domain.Responses;
using FlexoCalc.Engine.Internal;

namespace FlexoCalc.Engine.Services;

public sealed partial class LayoutGenerator
{
    partial void GenerateForMachine(
        FlexoRequest request,
        MachineProfile machine,
        List<LayoutOption> layouts)
    {
        IEnumerable<Orientation> orientations =
            request.Orientation switch
            {
                Orientation.Both => new[]
                {
                    Orientation.Portrait,
                    Orientation.Landscape
                },

                _ => new[]
                {
                    request.Orientation
                }
            };

        foreach (var orientation in orientations)
        {
            GenerateForOrientation(
                request,
                machine,
                orientation,
                layouts);
        }
    }

    partial void GenerateForOrientation(
        FlexoRequest request,
        MachineProfile machine,
        Orientation orientation,
        List<LayoutOption> layouts);
}
