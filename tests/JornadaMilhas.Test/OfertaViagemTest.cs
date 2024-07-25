using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
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
    public void TestandoOfertaRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void TestandoPrecoNegativo()
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
}
