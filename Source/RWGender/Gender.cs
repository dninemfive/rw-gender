using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RWGender
{
    /// <summary>
    /// Representation for premade genders, for pawn generation and the like.
    /// </summary>
    public class GenderDef : Def
    {
        // Because of how the game handles this, the base Gender enum will be treated as physical sex instead.
        Gender traditionalPhenotype = Gender.None;
        Pronouns pronouns;
    }

    /// <summary>
    /// Holds the pronouns for a particular character.
    /// </summary>
    public struct Pronouns
    {
        // TODO: handle other languages' gendered first/second person pronouns. Assuming English for now.
        /// <summary>
        /// Keys for the specified pronouns. dep/indPossessive = dependent and independent, respectively
        /// </summary>
        public string subjective, objective, depPossessive, indPossessive, reflexive;
    }

    /// <summary>
    /// Utility methods for Pronouns, including cached versions of the common ones.
    /// </summary>
    public static class PronounUtility
    {
        public static Pronouns TheyThem, SheHer, HeHim;

        static PronounUtility()
        {
            // I think RW just constructs reflexive with Pro..Obj + "self" - maybe have something reflecting this in a default constructor?
            // Reflexives will need to be added to the dictionary either way.
            TheyThem = new Pronouns { subjective = "Prothey", objective = "ProtheyObj", depPossessive = "Protheir", indPossessive = "Protheirs", reflexive = "Prothemself" };
            // Prohers apparently isn't in the dictionary, will have to be added
            SheHer   = new Pronouns { subjective = "Proshe",  objective = "ProherObj",  depPossessive = "Proher",   indPossessive = "Prohers",   reflexive = "Proherself"  };
            HeHim    = new Pronouns { subjective = "Prohe",   objective = "ProhimObj",  depPossessive = "Prohis",   indPossessive = "Prohis",    reflexive = "Prohimself"  };
        }
    }
}
