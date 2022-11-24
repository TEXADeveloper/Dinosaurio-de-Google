using UnityEngine;

public class DinoData : MonoBehaviour
{
    public static DinoData DD;
    public bool Configured = false;

    public string DinoName = "";
    public bool TojoCara = false;

    void Awake()
    {
        if (DD != null)
            Destroy(this.gameObject);
        else
            DD = this;
        DontDestroyOnLoad(DD);
    }
}
