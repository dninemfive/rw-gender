using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace RWGender
{
    /// <summary>
    /// Inspect Tab allowing the player to view and change a pawn's gender identity - pronouns (via a dropdown + popout text box), head/body graphic (but not type),
    ///     hair (without VHE), possibly &c
    /// </summary>
    class ITab_Pawn_Gender : ITab
    {
        /// <summary>
        /// Same as the one in the PawnBio ITab, but doesn't display on corpses.
        /// </summary>
        private Pawn PawnToShowInfoAbout
        {
            get
            {
                if (base.SelPawn == null)
                {
                    Log.Error("[Gender] Gender tab found no selected pawn to display.");
                }
                return base.SelPawn;
            }
        }

        public override bool IsVisible => PawnToShowInfoAbout != null;

        public ITab_Pawn_Gender()
        {
            base.labelKey = "D9Gen_TabGender";
            base.tutorTag = "D9Gen_TutGender";
        }

        protected override void UpdateSize()
        {
            base.UpdateSize();
            // todo
        }

        protected override void FillTab()
        {
            UpdateSize();
            throw new NotImplementedException();
            // todo
        }
    }
}
