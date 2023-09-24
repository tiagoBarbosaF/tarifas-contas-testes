using System.Globalization;

namespace Tarifasbancarias.Classes;

public class Conta
{
    public string CPF { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }

    public double TaxaCambio = 4.98;

    public Conta(string cpf, string nome, double valor)
    {
        CPF = cpf;
        Nome = nome;
        Valor = valor;
    }

    public string DefineTipoMoeda(double conta, string regiao)
    {
        return conta.ToString("C", CultureInfo.GetCultureInfo(regiao));
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, " +
               $"CPF: {CPF}, " +
               $"Conta Corrente: {Valor}";
    }

    public virtual double Tarifa()
    {
        return 0.0;
    }

    public virtual void Saldo()
    {
    }
}