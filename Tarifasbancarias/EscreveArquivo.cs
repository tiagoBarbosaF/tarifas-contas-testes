namespace Tarifasbancarias;

public class EscreveArquivo
{
    public void CriarEscreveArquivo(string nameFile, string[] linhas)
    {
        var filePath = $@"C:\Users\tiago\Downloads\Tarifasbancarias\{nameFile}.csv";

        try
        {
            using (var writer = new StreamWriter(filePath,true))
            {
                foreach (var linha in linhas) writer.WriteLine(linha);

                Console.WriteLine($"Arquivo {nameFile}.csv criado com sucesso.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao gerar arquivo: {e.Message}");
        }
    }
}