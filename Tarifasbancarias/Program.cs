using System.Globalization;
using Tarifasbancarias;

var filePath = @"C:\Users\tiago\Downloads\Tarifasbancarias\listaClientes.csv";

var leitorArquivoConta = new LeitorArquivoConta().LerArquivoConta(filePath);
var escreverArquivo = new EscreveArquivo();

var saldoPorCliente = new Dictionary<string, double>();
var tarifaPorCliente = new Dictionary<string, double>();
var mergeSaldoTarifa = new Dictionary<string, string>();

foreach (var conta in leitorArquivoConta)
{
    var tipoConta = conta.GetType().Name;

    if (saldoPorCliente.ContainsKey(conta.CPF))
        switch (tipoConta)
        {
            case "ContaCorrente":
                saldoPorCliente[conta.CPF] += conta.Valor;
                tarifaPorCliente[conta.CPF] += conta.Tarifa();
                break;
            case "ContaInternacional":
                saldoPorCliente[conta.CPF] += conta.Valor * conta.TaxaCambio;
                tarifaPorCliente[conta.CPF] += conta.Tarifa() * conta.TaxaCambio;
                break;
            case "ContaCripto":
                saldoPorCliente[conta.CPF] += conta.Valor * conta.TaxaCambio;
                tarifaPorCliente[conta.CPF] += conta.Tarifa() * conta.TaxaCambio;
                break;
        }
    else
        switch (tipoConta)
        {
            case "ContaCorrente":
                saldoPorCliente[conta.CPF] = conta.Valor;
                tarifaPorCliente[conta.CPF] = conta.Tarifa();
                break;
            case "ContaInternacional":
            case "ContaCripto":
                saldoPorCliente[conta.CPF] = conta.Valor * conta.TaxaCambio;
                tarifaPorCliente[conta.CPF] = conta.Tarifa() * conta.TaxaCambio;
                break;
            default:
                saldoPorCliente[conta.CPF] = saldoPorCliente[conta.Nome];
                tarifaPorCliente[conta.CPF] = conta.Tarifa() * conta.TaxaCambio;
                break;
        }

    var contaDetails = conta.ToString();
    escreverArquivo.CriarEscreveArquivo(conta.CPF,new[]{contaDetails});

    Console.WriteLine();
}

Console.WriteLine("\nSaldo de todas as contas por cliente:");
foreach (var saldo in saldoPorCliente)
{
    Console.WriteLine(
        $"CPF: {saldo.Key}, Saldo: {saldo.Value.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
}

Console.WriteLine("\nTarifas de todas as contas por cliente:");
foreach (var tarifa in tarifaPorCliente)
{
    Console.WriteLine(
        $"CPF: {tarifa.Key}, Saldo: {tarifa.Value.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
}

Console.WriteLine("\nAdição Saldo|Tarifa no arquivo do cliente:");
foreach (var saldo in saldoPorCliente.Keys)
{
    if (tarifaPorCliente.TryGetValue(saldo, out var value))
    {
        var valorSaldo = saldoPorCliente[saldo].ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        var tarifa = value.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        var merge = $"Saldo: {valorSaldo}|Tarifa: {tarifa}";
        mergeSaldoTarifa[saldo] = merge;
        escreverArquivo.CriarEscreveArquivo(saldo,new[]{merge});
    }
}