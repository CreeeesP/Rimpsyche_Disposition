﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace Maux36.RimPsyche.Disposition
{
    [HarmonyPatch(typeof(Thought), "MoodOffset")]
    public static class Thought_MoodOffset
    {
        static void Postfix(ref float __result, Pawn ___pawn)
        {
            if (___pawn?.compPsyche() is not { } compPsyche || __result == 0f)
                return;
            float optimism = compPsyche.Personality.GetPersonality(PersonalityDefOf.Rimpsyche_Optimism); // -1 ~ 1
            if (__result < 0f)
            {
                __result *= (1f - optimism * 0.45f);
            }
            else
            {
                __result *= (1f + optimism * 0.45f);
            }
        }
    }
}
