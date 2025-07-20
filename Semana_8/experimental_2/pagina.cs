// Representa una página web con una URL

public class Pagina
{
    public string Url { get; set; }

    public Pagina(string url)
    {
        Url = url;
    }

    public override string ToString()
    {
        return Url;
    }
}
