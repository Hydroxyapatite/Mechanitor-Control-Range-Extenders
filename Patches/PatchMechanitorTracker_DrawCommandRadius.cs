using HarmonyLib;
using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace Hydroxyapatite_MechCommandRangeExt
{
    [HarmonyPatch(
            typeof(Pawn_MechanitorTracker),
            nameof(Pawn_MechanitorTracker.DrawCommandRadius))]
    internal class PatchMechanitorTracker_DrawCommandRadius
    {
        static bool Prefix(
            Pawn_MechanitorTracker __instance
            )
        {
            if (__instance.Pawn.Spawned && __instance.AnySelectedDraftedMechs)
            {
                float range = __instance.Pawn.GetStatValue(MechanitorDefOf.Hydroxyapatite_MechCommandDistance, applyPostProcess: true, 60);
                range = Math.Min(range, (float)Math.Floor(GenRadial.MaxRadialPatternRadius));
                GenDraw.DrawRadiusRing(__instance.Pawn.Position, range, Color.white, (IntVec3 c) => __instance.CanCommandTo(c));
            }
            return false;
        }
    }
}
