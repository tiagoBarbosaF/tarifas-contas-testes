using Tarifasbancarias.Interfaces;

namespace Tarifasbancarias.Classes;

public class ContaInternacional : Conta, ITarifa
{
    public ContaInternacional(string cpf, string nome, double valor) : base(cpf, nome, valor)
    {
    }
    
    public override string ToString()
    {
        return $"Nome: {Nome}, " +
               $"CPF: {CPF}, " +
               $"Conta Internacional: {DefineTipoMoeda(Valor, "en-US")}";
    }

    public override double Tarifa() => Calcular();

    public double Calcular() => Valor * 0.025;

    public override void Saldo() =>
        Console.WriteLine(
            $"- Valor atual conta internacional em Real: {DefineTipoMoeda(Valor * TaxaCambio, "pt-BR")}");
}