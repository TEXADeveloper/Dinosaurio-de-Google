using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private Sprite tojoCara;
    [SerializeField] private SpriteRenderer sr;

    void Start()
    {
        if (DinoData.DD.TojoCara)
            sr.sprite = tojoCara;
    }
}
