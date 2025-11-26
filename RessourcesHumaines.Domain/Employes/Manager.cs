namespace RessourcesHumaines.Domain.Employes;

public class Manager : Employe
{
    public string Departement { get; set; }
    public int NbSubordonnes { get; set; }

    public Manager(string matricule, string nom, string prenom, double salaireMensuel, string departement, int nbSubordonnes)
        : base(matricule, nom, prenom, salaireMensuel)
    {
        Departement = departement ?? throw new ArgumentNullException(nameof(departement));
        if (nbSubordonnes >= 0) throw new InvalidOperationException(nameof(nbSubordonnes));
        NbSubordonnes = nbSubordonnes;
    }

    public override double CalculerPrime(double bonusParSubordonne) => NbSubordonnes * bonusParSubordonne;
    
    protected override double CalculerImpot()
    {
        if (NbSubordonnes < 5)
        {
            return SalaireMensuel * 0.20;
        }
        return SalaireMensuel * 0.25;
    }
}