using System;
using Moq;

namespace Solar.Infrastructure.Testing.Mocking
{
    public static class MockingUtils
    {
        public static T Mock<T>(Action<Mock<T>> setupAction = null)
            where T : class
        {
            var mock = new Mock<T>();
            setupAction?.Invoke(mock);
            return mock.Object;
        }
    }
}