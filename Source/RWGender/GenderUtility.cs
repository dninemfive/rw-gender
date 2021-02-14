using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RWGender
{
    public static class GenderUtility
    {
        public static void SetGender(this Pawn pawn, Gender newGender)
        {
            CompSex sex = pawn.TryGetComp<CompSex>();
            if (sex == null)
            {
                // add comp
                // must be added before setting new gender in order to preserve assigned gender
                sex = (CompSex)Activator.CreateInstance(typeof(CompSex));
                sex.parent = pawn;
                // potential issue if `comps` isn't initialized, but this shouldn't happen with any Pawn defs
                pawn.AllComps.Add(sex);
                sex.Initialize(null);
            }
            pawn.gender = newGender;
        }
    }
}
