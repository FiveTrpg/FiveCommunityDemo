using System.Threading.Tasks;

namespace Gaming.API.Utils
{
    public static class ValueTasks
    {
        public static ValueTask<T> Of<T>(T value) => new ValueTask<T>(value);
    }
}
