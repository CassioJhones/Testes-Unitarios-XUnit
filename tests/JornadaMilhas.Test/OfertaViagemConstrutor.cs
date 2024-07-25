using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Fact]
    public void RetornaDadosValidosQuandoDadosValidos()
    {//---PADRÃO AAA
        //--CENARIO = ARRANGE
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        bool validacao = true;

        //--AÇÃO - ACTION
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //--VALIDAÇÃO - ASSERT
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroParaRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroPrecoInvalidoQuandoPrecoMenorQueZero()
    {
        //--CENARIO = ARRANGE
        Rota rota = new Rota("Rio Claro", "Araras");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = -320;

        //--AÇÃO - ACTION
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //--VALIDAÇÃO - ASSERT
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }

    //Permite varios possiveis Cenarios de teste
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-02-02", 0, false)]
    [InlineData("Rondonia", "Santos", "2024-02-01", "2024-02-07", 100, true)]
    [InlineData(null, "Limeira", "2024-02-01", "2024-01-01", 100, false)]
    [InlineData("Vitoria", "Sergipe", "2024-02-01", "2024-02-07", -5, false)]
    [InlineData("Bahia", "Sao Paulo", "2024-02-01", "2024-02-07", 100, true)]
    public void RetornaValidoseInvalidosDeAcordoComEntradas(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        //--CENARIO
        Rota rota = new Rota(origem,destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));
        
        //--AÇÃO
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //--VALIDAÇÃO
        Assert.Equal(validacao, oferta.EhValido);
    }
}
