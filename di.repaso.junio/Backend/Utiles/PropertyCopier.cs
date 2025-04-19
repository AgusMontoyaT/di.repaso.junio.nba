using System.Reflection;

namespace di.repaso.junio.Backend.Utiles
{
    public static class PropertyCopier<T> where T : class
    {
        public static void CopyProperties(T source, T target)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source);
                    property.SetValue(target, value);
                }
            }
        }
    }

}
