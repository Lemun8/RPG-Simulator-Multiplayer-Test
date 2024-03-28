using UnityEngine;

public class MultiplatformHelper : MonoBehaviour
{
    public static MultiplatformHelper Instances;

    public enum PlatformType
    {
        Android,
        Desktop
    }

    public PlatformType platformType;

    private void Awake()
    {
        if (Instances == null)
        {
            Instances = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

#if !UNITY_EDITOR
        platformType = Application.platform == RuntimePlatform.Android ? PlatformType.Android : PlatformType.Desktop;
#endif
    }
}