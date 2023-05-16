using Models;
using System;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque("Technofutur Bank");
            Personne chuckNorris = new Personne("Norris", "Chuck", new DateTime(1940, 3, 10));
            Courant compte1 = new Courant("00001", 500, chuckNorris);
            Epargne compte2 = new Epargne("00002", chuckNorris);

            banque.Ajouter(compte1);
            banque.Ajouter(compte2);

            try
            {
                compte1.LigneDeCredit = -500;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                banque["00001"].Depot(-500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            banque["00001"].Depot(500);

            try
            {
                banque["00001"].Retrait(-750);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            banque["00001"].Retrait(750);

            try
            {
                banque["00001"].Retrait(750);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            banque["00002"].Depot(500);

            banque["00001"].AppliquerInteret();
            banque["00002"].AppliquerInteret();

            Console.WriteLine($"Solde du compte '{banque["00001"].Numero}' : {banque["00001"].Solde}");
            Console.WriteLine($"Solde du compte '{banque["00002"].Numero}' : {banque["00002"].Solde}");
            Console.WriteLine($"Avoir des comptes de {chuckNorris.Prenom} {chuckNorris.Nom} : {banque.AvoirDesComptes(chuckNorris)}");
        }
    }
}
