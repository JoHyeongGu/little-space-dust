using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected bool dontDestroyOnLoad = false; // 씬 내 객체 유지 On, Off
    private static readonly object _lock = new object();

    protected virtual void Awake()
    {
        SetInstance();
    }

    protected void SetInstance()
    {
        lock (_lock) // 스레드 안정성 확보
        {
            if (Instance == null)
            {
                Instance = this as T;
                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
