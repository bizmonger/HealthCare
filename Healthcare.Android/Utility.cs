using Microsoft.FSharp.Core;

namespace Healthcare.Android
{
    static class Utility
    {
        public static bool IsSome(this FSharpOption<string> option) => FSharpOption<string>.get_IsSome(option);
        public static bool IsNone(this FSharpOption<string> option) => FSharpOption<string>.get_IsNone(option);
    }
}