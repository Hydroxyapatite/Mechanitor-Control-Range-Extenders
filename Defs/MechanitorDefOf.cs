using RimWorld;

namespace Hydroxyapatite_MechCommandRangeExt
{
    [DefOf]
    public static class MechanitorDefOf
    {
        public static StatDef Hydroxyapatite_MechCommandDistance;
        static MechanitorDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MechanitorDefOf));
        }
    }
}
