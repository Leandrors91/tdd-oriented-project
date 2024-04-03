using Calculadora.Services;
using Microsoft.VisualBasic;
using System;
namespace CalculadoraTeste;

public class UnitTest1
{
    public CalculadoraImp CriarCalculadora()
    {
        DateTime date = DateTime.Now;
        CalculadoraImp res = new CalculadoraImp(date);
        return res;
    }
    [Theory]
    [InlineData(1,2,3)]
    [InlineData(3,4,7)]
    public void TesteSomar(double value1,double value2,double res)
    {
        CalculadoraImp calculadora = CriarCalculadora();
        var resultado = calculadora.Somar(value1, value2);
        Assert.Equal(res, resultado);
    }
    [Theory]
    [InlineData(2,1,1)]
    [InlineData(4,2,2)]
    public void TesteSubtrair(double value1,double value2,double res)
    {
        CalculadoraImp calculadora = CriarCalculadora();
        var resultado = calculadora.Subtrair(value1, value2);
        Assert.Equal(res, resultado);
    }
    [Theory]
    [InlineData(1,2,2)]
    [InlineData(3,4,12)]
    public void TesteMultiplicar(double value1,double value2,double res)
    {
        CalculadoraImp calculadora = CriarCalculadora();
        var resultado = calculadora.Multiplicar(value1, value2);
        Assert.Equal(res, resultado);
    }
    [Theory]
    [InlineData(12,2,6)]
    [InlineData(28,4,7)]
    public void TesteDividir(double value1,double value2,double res)
    {
        CalculadoraImp calculadora = CriarCalculadora();
        var resultado = calculadora.Dividir(value1, value2);
        Assert.Equal(res, resultado);
    }
    [Fact]
    public void TesteHistorico()
    {
        CalculadoraImp calculadora = CriarCalculadora();
        calculadora.Somar(1,1);
        calculadora.Subtrair(1,1);
        calculadora.Multiplicar(1,1);
        calculadora.Dividir(1,1);
        Assert.NotEmpty(calculadora.Historico());
        Assert.Equal(3, calculadora.Historico().Count);
    }
    [Fact]
    public void TesteDivisaoPorZero()
    {
        CalculadoraImp calculadora = CriarCalculadora();
        Assert.Throws<DivideByZeroException>(
            () => calculadora.Dividir(1,0)
        );
    }
}