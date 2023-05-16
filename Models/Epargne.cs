using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne : Compte
    {
        public DateTime DateDernierRetrait { get; private set; }

        public override void Retrait(double montant)
        {
            double oldSolde = Solde;
            base.Retrait(montant);

            if(oldSolde != Solde)
            {
                DateDernierRetrait = DateTime.Now;
            }
        }

        public Epargne(string numero, Personne titulaire)
            : base(numero, titulaire)
        {
        }

        public Epargne(string numero, Personne titulaire, double solde, DateTime dateDernierRetrait)
            : base(numero, titulaire, solde)
        {
        }

        protected override double CalculInteret()
        {
            return Solde * .045;
        }
    }
}
