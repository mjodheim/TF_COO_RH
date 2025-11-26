namespace RessourcesHumaines.Domain;

public abstract class Employe
{
    public string Matricule { get; private set; }
    public string Nom { get; private set; }
    public string Prenom { get; private set; }
    public double SalaireMensuel  { get; private set; }
    
    protected Employe(string matricule, string nom, string prenom)
    {
        Matricule = matricule ?? throw new ArgumentNullException(nameof(matricule));
        Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
    }

    protected Employe(string matricule, string nom, string prenom, double salaireMensuel)
    {
        Matricule = matricule ?? throw new ArgumentNullException(nameof(matricule));
        Nom = nom ?? throw new ArgumentNullException(nameof(nom));
        Prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
        if (salaireMensuel < 1) throw new ArgumentOutOfRangeException(nameof(SalaireMensuel));
        SalaireMensuel = salaireMensuel;
    }

    public abstract double CalculerPrime(double valeur);

    public virtual void AugmenterSalaire(double montant) // virtual car on effectue la même modification (+=) à montant
    {
        // Vérifier qu'on ne tente pas de diminuer le salaire !
        if (SalaireMensuel < 1) throw new ArgumentOutOfRangeException(nameof(SalaireMensuel));
        SalaireMensuel += montant;
    }

    protected abstract double CalculerImpot();

    public double CalculNetAPayer() => SalaireMensuel -  CalculerImpot();
    
    // Surcharge de l'opérateur + pour calculer le salaire mensuel de deux employés
    public static double operator + (Employe e1, Employe e2)
    {
        if (e1 is null) throw new ArgumentNullException(nameof(e1));
        if (e2 is null) throw new ArgumentNullException(nameof(e2));
        return e1.SalaireMensuel + e2.SalaireMensuel;
    }
    
    public static double operator + (double total, Employe e)
    {
        if (e is null) throw new ArgumentNullException(nameof(e));
        return total + e.SalaireMensuel;
    }
}