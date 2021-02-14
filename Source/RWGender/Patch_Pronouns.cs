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
    /// <summary>
    /// Patches redirecting references which talk about sex instead of gender (e.g. egg laying) to the phenotype rather than the gender.
    /// </summary>
    [StaticConstructorOnStartup]
    static class Patches_Sex
    {
        static Patches_Sex()
        {
            new Harmony("com.dninemfive.rwgender").PatchAll();
        }

        /// <summary>
        /// Patches egg laying to look at CompSex instead of pawn.gender
        /// </summary>
        [HarmonyPatch(typeof(CompEggLayer), "Active", MethodType.Getter)]
        public class Patch_CompEggLayer
        {
            [HarmonyTranspiler]
            public IEnumerable<CodeInstruction> CompEggLayer_ActiveTranspiler(IEnumerable<CodeInstruction> instr)
            {
                List<CodeInstruction> instl = instr.ToList();
                bool found = false;
                for(int i = 1; i < instl.Count; i++)
                {
                }
            }
        }
    }
}
