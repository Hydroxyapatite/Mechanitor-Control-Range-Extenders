using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace Hydroxyapatite_MechCommandRangeExt
{
    [HarmonyPatch(
            typeof(Pawn_MechanitorTracker),
            nameof(Pawn_MechanitorTracker.CanCommandTo),
            new Type[] { typeof(LocalTargetInfo) })]
    internal class PatchMechanitorTracker_CanCommandTo
    {
        static void Postfix(
            Pawn_MechanitorTracker __instance,
            LocalTargetInfo target,
            ref bool __result
            )
        {
            if (!target.Cell.InBounds(__instance.Pawn.MapHeld))
            {
                __result = false;
            }
            float range = (float) Math.Pow(__instance.Pawn.GetStatValue(MechanitorDefOf.Hydroxyapatite_MechCommandDistance, applyPostProcess: true, 60), 2);
            float maxRange = (float)Math.Pow(Math.Floor(GenRadial.MaxRadialPatternRadius), 2);
            __result = __instance.Pawn.Position.DistanceToSquared(target.Cell) < Math.Min(range, maxRange);
        }
    }
}
