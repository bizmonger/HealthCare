using Microsoft.FSharp.Core;
using static Claims;

namespace Healthcare.Android
{
    static class Utility
    {
        public static bool IsSome<T>(this FSharpOption<T> option) => FSharpOption<T>.get_IsSome(option);
        public static bool IsNone<T>(this FSharpOption<T> option) => FSharpOption<T>.get_IsNone(option);
    }
}