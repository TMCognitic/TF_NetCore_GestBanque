using System;

namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        public event PassageEnNegatifDelegate PassageEnNegatifEvent;

        public static double operator +(double d, Compte compte)
        {
            return ((d < 0) ? 0 : d) + ((compte.Solde < 0) ? 0 : compte.Solde);
        }

        private string _numero;
        private double _solde;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            private set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            private set
            {
                _titulaire = value;
            }
        }

        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde)
            : this(numero, titulaire)
        {
            Solde = solde;
        }

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
                throw new ArgumentOutOfRangeException(nameof(montant));

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0);
        }

        protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
                throw new ArgumentOutOfRangeException(nameof(montant));

            if (Solde - montant < -ligneDeCredit)
                throw new SoldeInsuffisantException("Solde Insuffisant");

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        protected void RaisePassageEnNegatifEvent()
        {
            PassageEnNegatifEvent?.Invoke(this);
        }
    }
}
