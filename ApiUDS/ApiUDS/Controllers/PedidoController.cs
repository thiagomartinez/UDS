using ApiUDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiUDS.Controllers
{
    [RoutePrefix("api/pedido")]
    public class PedidoController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CadastrarPedido(String tamanho, String sabor, String personalizacao)
        {
            try
            {
                PedidoModels ped = new PedidoModels();
                ped.Sabor = sabor;
                ped.Tamanho = tamanho;
                ped.Personalizacao = personalizacao;
                ped.ValorTotal = ValorItem(tamanho) + ValorItem(personalizacao);
                ped.Tempopreparo = TempoPreparo(tamanho) + TempoPreparo(sabor) + TempoPreparo(personalizacao);

                ped.Create(ped);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage DetalhesPedido(Int64 codigo)
        {
            try
            {
                PedidoModels ped = new PedidoModels();
                return Request.CreateResponse(HttpStatusCode.OK, ped.Details(codigo));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private decimal ValorItem(String item)
        {
            decimal valor = 0;
            switch (item)
            {
                case "pequena":
                    valor = +20;
                    break;
                case "media":
                    valor = +30;
                    break;
                case "grande":
                    valor = +40;
                    break;
                case "extra bacon":
                    valor = +3;
                    break;
                case "borda recheada":
                    valor = +5;
                    break;
            }
          return valor;
        }

        private int TempoPreparo(String item)
        {
            int valor = 0;
            switch (item)
            {
                case "pequena":
                    valor = +15;
                    break;
                case "media":
                    valor = +20;
                    break;
                case "grande":
                    valor = +25;
                    break;
                case "portuguesa":
                    valor = +5;
                    break;
                case "borda recheada":
                    valor = +5;
                    break;
            }
            return valor;
        }
    }
}
