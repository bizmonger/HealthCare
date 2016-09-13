using InteractionLogic;

class Global
{
    static Global _member = new Global();

    Global() { }

    public static Global Instance
    {
        get
        {
            if (_member == null)
                _member = new Global();

            return _member;
        }
    }

    public Dispatcher Dispatcher { get; }
}