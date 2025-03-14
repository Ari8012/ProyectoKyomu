﻿using FronEnd.Models;

namespace FronEnd.Helpers.Interfaces
{
    public interface IPedidoHelper
    {
        List<PedidoViewModel> GetPedidos();

        PedidoViewModel GetPedido(int? id);
        PedidoViewModel Add(PedidoViewModel pedido);
        PedidoViewModel Update(PedidoViewModel pedido);
        void Delete(int id);
    }
}
