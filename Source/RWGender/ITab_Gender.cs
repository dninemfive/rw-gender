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
            if(SelPawn == null)
            {
                return;
            }
            // PlayerKnowledgeDatabase.KnowledgeDemonstrated...
            Func<List<FloatMenuOption>> genderOptions = delegate
            {
                // once defs are added, update this to automatically grab gender defs from database
                List<FloatMenuOption> genders = new List<FloatMenuOption>();
                // if enabled in mod options, add none gender 
                genders.Add(new FloatMenuOption("male gender key", delegate
                {
                    SelPawn.SetGender(Gender.Male);
                })); // todo: add extraPartOnGUI
                genders.Add(new FloatMenuOption("female gender key", delegate
                {
                    SelPawn.SetGender(Gender.Female);
                }));
                return genders;
            };

            // todo
        }

        public static void SetGender(this Pawn pawn, Gender newGender)
        {
            CompSex sex = pawn.TryGetComp<CompSex>();
            if(sex != null)
            {
                sex.agab = pawn.gender;
            }
            else
            {
                // add new CompSex,
                // *then* change gender - creating the compsex first preserves agab
            }
            pawn.gender = newGender;
        }
    }
}
