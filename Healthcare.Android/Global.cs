using InteractionLogic;

namespace Healthcare.Android
{
    class Global
    {
        public static Dispatcher Dispatcher = new Dispatcher();
        public static bool IsIntegrated { get; } = false;
    }
}