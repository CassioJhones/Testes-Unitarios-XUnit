using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;
public class GerenciadorDeOfertasRecuperaMaiorDesconto
{

    [Fact]
    public void RetornaOfertaNulaQuandoListaEstaVazia()
    {
        //arrange
        var lista = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(lista);
        Func<OfertaViagem, bool> filtro = o => o.Rota.Destino.Equals("São Paulo");
        //act
        var oferta = gerenciador.RecuperaMaiorDesconto(filtro);
        //assert
        Assert.Null(oferta);
    }
}
