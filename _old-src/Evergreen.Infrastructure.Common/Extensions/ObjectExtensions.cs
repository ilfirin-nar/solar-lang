namespace Evergreen.Infrastructure.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void InvokeMethod(this object obj, string name, params object[] parameters)
        {
            obj.GetType().GetMethod(name).Invoke(obj, parameters);
        }
    }
}