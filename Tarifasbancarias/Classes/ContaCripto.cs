namespace Tarifasbancarias.Classes;

public class ContaCripto : Conta
{
    public ContaCripto(string cpf, string nome, double valor) : base(cpf, nome, valor)
    {
    }
    
    public override string ToString()
    {
        return $"Nome: {Nome}, " +
               $"CPF: {CPF}, " +
               $"Conta Cripto: {DefineTipoMoeda(Valor, "en-US")}";
    }

    public override void Saldo()
    {
        Console.WriteLine(
            $"- Valor atual conta cripto em Real: {DefineTipoMoeda(Valor * TaxaCambio, "pt-BR")}");
    }
}