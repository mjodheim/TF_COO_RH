namespace RessourcesHumaines.Domain.Employes;

public class EmployeSalarie :  Employe
{
    public Adresse LieuDeTravail { get; set; }

    public EmployeSalarie(string matricule, string nom, string prenom, double salaireMensuel, Adresse lieuDeTravail)
        : base(matricule, nom, prenom, salaireMensuel)
    {
        LieuDeTravail = lieuDeTravail ?? throw new ArgumentNullException(nameof(lieuDeTravail));
    }

    public override double CalculerPrime(double pourcentage) => SalaireMensuel * (pourcentage / 100);

    protected override double CalculerImpot() => SalaireMensuel * 0.18;
}