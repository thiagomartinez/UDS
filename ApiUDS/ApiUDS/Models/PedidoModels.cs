using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ApiUDS.Data;

namespace ApiUDS.Models
{
    public class PedidoModels
    {
        private Int64 codigo;
        private String tamanho;
        private String sabor;
        private String personalizacao;
        private decimal valorTotal;
        private int tempopreparo;
        private pizzariaEntities db = new pizzariaEntities();


        public long Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Tamanho
        {
            get
            {
                return tamanho;
            }

            set
            {
                tamanho = value;
            }
        }

        public string Sabor
        {
            get
            {
                return sabor;
            }

            set
            {
                sabor = value;
            }
        }

        public string Personalizacao
        {
            get
            {
                return personalizacao;
            }

            set
            {
                personalizacao = value;
            }
        }

        public int Tempopreparo
        {
            get
            {
                return tempopreparo;
            }

            set
            {
                tempopreparo = value;
            }
        }

        public decimal ValorTotal
        {
            get
            {
                return valorTotal;
            }

            set
            {
                valorTotal = value;
            }
        }

        public void Create(PedidoModels  uPedido)
        {
            try
            {
                db.pedido.Add(new pedido
                {
                    personalizacao = uPedido.personalizacao,
                    sabor = uPedido.sabor,
                    tamanho = uPedido.tamanho,
                    tempopreparo = uPedido.tempopreparo,
                    valortotal = uPedido.valorTotal
                });
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(PedidoModels uPedido)
        {
            try
            {
                pedido ped = db.pedido.Where(p => p.codigo == uPedido.codigo).FirstOrDefault();
                if (ped != null)
                {
                    ped.personalizacao = uPedido.personalizacao;
                    ped.sabor = uPedido.sabor;
                    ped.tamanho = uPedido.tamanho;
                    ped.tempopreparo = uPedido.tempopreparo;
                    ped.valortotal = uPedido.valorTotal;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public pedido Details(Int64? id)
        {
            try
            {
                pedido ped = db.pedido.Where(p => p.codigo == id).FirstOrDefault();
                return ped;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}