public class Singleton<T> where T : class, new()
{
    private static T _instance;
    private static readonly object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null) // 인스턴스가 null일 때만 검사
            {
                lock (_lock) // 스레드 안정성 확보
                {
                    if (_instance == null) // 스레드 확보 후 재확인
                    {
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }

    protected Singleton()
    {
        if (_instance != null)
        {
            throw new System.Exception("Cannot create multiple instances of a Singleton class.");
        }
    }
}
