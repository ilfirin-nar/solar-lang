namespace Solar.Infrastructure.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void InvokeMethod(this object obj, string name, params object[] parameters)
        {
            obj.GetType().GetMethod(name).Invoke(obj, parameters);
        }

        public static TResult InvokeMethod<TResult>(this object obj, string name, params object[] parameters)
        {
            return (TResult) obj.GetType().GetMethod(name).Invoke(obj, parameters);
        }
    }
}