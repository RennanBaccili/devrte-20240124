using System.ComponentModel;

namespace Sistema_de_Gestão_de_Colaboradores.enums
{
    public enum StatusUser
    {
        [Description("Active")]
        Active = 0,

        [Description("Inactive")]
        Inactive = 1
    }

    public static class StatusUserExtensions
    {
        public static string GetDescription(this StatusUser status)
        {
            var fieldInfo = status.GetType().GetField(status.ToString());

            if (fieldInfo != null)
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : status.ToString();
            }

            return status.ToString();
        }
    }
}
