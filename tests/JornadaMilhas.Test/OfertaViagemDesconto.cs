using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;
public class OfertaViagemDesconto
{
    [Fact]
    public void RetornaPrecoAtualizadoQuandoTemDesconto()
    {
        //arrange
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2024, 07, 25), new DateTime(2024, 07, 30));
        double precoOriginal = 100.0;
        double desconto = 20.00;
        double precoComDesconto = precoOriginal - desconto;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

        //act
        oferta.Desconto = desconto;

        //assert
        Assert.Equal(precoComDesconto, oferta.Preco);
    }

    [Fact]
    public void RetornaDescontoMaximoQuandoValorMaiorQuePreco()
    {
        //arrange
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2024, 07, 25), new DateTime(2024, 07, 30));
        double precoOriginal = 100.00;
        double desconto = 120.00;
        double precoComDesconto = 30.00;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

        //act
        oferta.Desconto = desconto;

        //assert
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
}
