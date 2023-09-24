using Tarifasbancarias.Classes;

namespace Tarifasbancarias;

public class LeitorArquivoConta
{
    public List<Conta> LerArquivoConta(string filePath)
    {
        var contas = new List<Conta>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    var coluna = linha.Split('|');

                    if (coluna.Length == 5)
                    {
                        var contaCorrente = new ContaCorrente(coluna[0], coluna[1],
                            double.Parse(coluna[2].Replace(",", ".")));
                        contas.Add(contaCorrente);
                        
                        var contaInternacional = new ContaInternacional(coluna[0], coluna[1],
                            double.Parse(coluna[3].Replace(",", ".")));
                        contas.Add(contaInternacional);
                        
                        var contaCripto = new ContaCripto(coluna[0], coluna[1],
                            double.Parse(coluna[4].Replace(",", ".")));
                        contas.Add(contaCripto);
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {e.Message}");
        }

        return contas;
    }
}