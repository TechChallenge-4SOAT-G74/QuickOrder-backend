﻿using System.ComponentModel;

namespace QuickOrder.Core.Domain.Enums
{
    public enum EStatusPedido
    {
        [Description("Criado")]
        Criado = 1,

        [Description("Aguardando pagamento")]
        PendentePagamento = 2,

        [Description("Pagamento Aprovado")]
        Pago = 3,

        [Description("Recebido")]
        Recebido = 4,

        [Description("Em preparação")]
        EmPreparacao = 5,

        [Description("Pronto")]
        ProntoParaRetirada = 6,

        [Description("Aguardando Retirada")]
        AguardandoRetirada = 7,

        [Description("Finalizado")]
        Finalizado = 8
    }

    public static class EStatusPedidoExtensions
    {
        public static string ToDescriptionString(this EStatusPedido val)
        {
            var type = val.GetType();
            var attributes = type.GetField(val.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes?.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToDescriptionString(Enum val)
        {
            var type = val.GetType();
            var attributes = type.GetField(val.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes?.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
