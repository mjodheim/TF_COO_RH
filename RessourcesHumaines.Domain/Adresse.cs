namespace RessourcesHumaines.Domain;

public class Adresse
{
    public string Rue { get; set; }
    public string Ville { get; set; }
    public string CodePostal { get; set; }

    public Adresse(string rue, string ville, string codePostal)
    {
        Rue = rue ?? throw new ArgumentNullException(nameof(rue));
        Ville = ville ?? throw new ArgumentNullException(nameof(ville));
        CodePostal = codePostal ?? throw new ArgumentNullException(nameof(codePostal));
    }
}