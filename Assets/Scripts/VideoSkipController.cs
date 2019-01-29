using UnityEngine;

public class VideoSkipController : MonoBehaviour
{
    public static VideoSkipController instance;

    public bool skipped;
    public static bool created;

    private void Awake()
    {
        if (!created)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            created = true;
        }
    }
}