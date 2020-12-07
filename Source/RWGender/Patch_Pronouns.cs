using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Grammar;

namespace RWGender
{
    [StaticConstructorOnStartup]
    static class Patches_Pronouns
    {
        static Patches_Pronouns()
        {
            new Harmony("com.dninemfive.rwgender").PatchAll();
        }

        /// <summary>
        /// Patches TaleData_Trader.GetRules() to return the pronoun stored in a pawn instead of the gender's pawn, if possible.
        /// </summary>
        /// <remarks>
        /// Should eventually be a transpiler; using a destructive prefix for testing.
        /// </remarks>
        [HarmonyPatch(typeof(TaleData_Trader), nameof(TaleData_Trader.GetRules))]
        public class Patch_TaleData_Trader
        {
            [HarmonyPrefix]
            public bool TaleData_Trader_GetRulesPrefix(string prefix, ref TaleData_Trader __instance, ref IEnumerable<Rule> __result)
            {
                __result = GetRulesInternal(__instance, prefix);
                return false;
            }

            public IEnumerable<Rule> GetRulesInternal(TaleData_Trader inst, string prefix)
            {
                bool isPawn = inst.pawnID >= 0;
                string name = inst.name;
                string output = isPawn ? name : Find.ActiveLanguageWorker.WithIndefiniteArticle(name);
                yield return new Rule_String(prefix + "_nameFull", output);
                string nameShortIndefinite2 = (!isPawn) ? Find.ActiveLanguageWorker.WithIndefiniteArticle(name, false, false) : name;
                yield return new Rule_String(prefix + "_indefinite", nameShortIndefinite2);
                yield return new Rule_String(prefix + "_nameIndef", nameShortIndefinite2);
                nameShortIndefinite2 = ((!isPawn) ? Find.ActiveLanguageWorker.WithDefiniteArticle(name, false, false) : name);
                yield return new Rule_String(prefix + "_definite", nameShortIndefinite2);
                yield return new Rule_String(prefix + "_nameDef", nameShortIndefinite2);
                Pawn pawn; // get this from the thing id number somehow, then get their pronouns
                           // this does not look possible, currently. May need to revert to using Gender with pronouns
                yield return new Rule_String(prefix + "_pronoun", gender.GetPronoun());
                yield return new Rule_String(prefix + "_possessive", gender.GetPossessive());
            }
        }
    }
}
