using System.ComponentModel;

namespace QuickOrder.Core.Domain.Enums
{
    public enum ERole
    {
        [Description("Administrdor")]
        Administrdor = 1,
        [Description("Gerente")]
        Gerente = 2,
        [Description("Atendente")]
        Atendente = 3,
        [Description("Cozinheiro")]
        Cozinheiro = 4,
        [Description("Cliente")]
        Cliente = 4
    }

    public static class ERoleExtensions
    {
        public static string ToDescriptionString(this ERole val)
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
