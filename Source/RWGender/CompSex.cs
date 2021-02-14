using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RWGender
{
    /// <summary>
    /// Stores the phenotype of the relevant pawn, to prevent gender changes from causing them to lay eggs and such.
    /// 
    /// Only used internally, should not be added to any XML.
    /// </summary>
    class CompSex : ThingComp
    {

        public Gender agab;

        public override void Initialize(CompProperties props)
        {
            if (parent is Pawn pawn)
            {
                agab = pawn.gender;
            }
            else
            {
                agab = Gender.None;
            }
        }
    }
}
