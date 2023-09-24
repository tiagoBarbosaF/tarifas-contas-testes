using Tarifasbancarias.Interfaces;

namespace Tarifasbancarias.Classes;

public class ContaCorrente : Conta, ITarifa
{
    public ContaCorrente(string cpf, string nome, double valor) : base(cpf, nome, valor)
    {
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, " +
               $"CPF: {CPF}, " +
               $"Conta Corrente: {DefineTipoMoeda(Valor, "pt-BR")}";
    }

    public override double Tarifa() => Calcular();

    public double Calcular() => Valor * 0.015;

    public override void Saldo() =>
        Console.WriteLine($"Valor atual conta corrente em Real: {DefineTipoMoeda(Valor, "pt-BR")}");
}