using HarmonyLib;
using Verse;

namespace Hydroxyapatite_MechCommandRangeExt
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            var harmony = new Harmony("rimworld.hydroxyapatite.MechCommandRangeExt");
            harmony.PatchAll();
        }
    }
}
