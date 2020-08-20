using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Enums
{
    public enum UnitTypes
    {
        MassGram = 1,
        MassDecagram = 2,
        MassKilogram = 3,
        MassMiligram = 4,
        MassPound = 5,
        MassOunce = 6,

        Piece = 7,

        VolumeMilliliter = 8,
        VolumeLiter = 9,
        VolumeDeciliter = 10,
        VolumeTeaspoon = 11,
        VolumeTablespoon = 12,
        VolumeCup = 13,
        VolumePint = 14,
        VolumeFluidOunce = 15
    }
}
