using System.ComponentModel;

namespace QuickOrder.Core.Domain.Enums
{
    public enum ETipoItem
    {
        [Description("Pão")]
        Pao = 1,
        [Description("Carne")]
        Carne = 2,
        [Description("Queijo")]
        Queijo = 3,
        [Description("Molho")]
        Molho = 4,
        [Description("Administrador")]
        Complemento = 5
    }

    public static class ETipoItemExtensions
    {
        public static string ToDescriptionString(this ETipoItem val)
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
