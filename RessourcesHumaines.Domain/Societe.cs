namespace RessourcesHumaines.Domain;

public class Societe<TEmploye> where TEmploye : Employe // Contrainte générique
{
    public Dictionary<string, TEmploye> Employees { get; } = new() ;
    public string NomSociete { get; set; }

    public Societe(string nomSociete)
    {
        NomSociete = nomSociete ?? throw new ArgumentNullException(nameof(nomSociete));;
    }
    
    public TEmploye this[string matricule] => Employees[matricule];

    public void Embaucher(TEmploye e)
    {
        // Gestion des erreurs
        if (e is null) throw new ArgumentNullException(nameof(e));
        if (Employees.ContainsKey(e.Matricule))
            throw new InvalidOperationException($"L'employé {e.Prenom} {e.Nom} existe déjà.");
        
        Employees.Add(e.Matricule, e);
    }

    public void Licencier(string matricule)
    {
        // Gestion des erreurs
        if (matricule is null) throw new ArgumentNullException(nameof(matricule));
        if (!Employees.ContainsKey(matricule)) 
            throw new InvalidOperationException($"L'employé avec le matricule {matricule} n'existe pas.");
        
        Employees.Remove(matricule);
    }
    
    public double MasseSalariale()
    {
        double masseSalariale = 0;

        foreach (Employe e in Employees.Values)
        {
            masseSalariale += e;
        }
        
        return masseSalariale;
    }
}