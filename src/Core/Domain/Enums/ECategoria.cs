using System.ComponentModel;

namespace QuickOrder.Core.Domain.Enums
{
    public enum ECategoria
    {
        [Description("Lanche")]
        Lanche = 1,
        [Description("Acompanhamento")]
        Acompanhamento = 2,
        [Description("Bebida")]
        Bebida = 3,
        [Description("Sobremesa")]
        Sobremesa = 4
    }

    public static class ECategoriaExtensions
    {
        public static string ToDescriptionString(this ECategoria val)
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
