using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text resultsText;
    private float timer = 0;

    [SerializeField] private Animator skyAnimator;
    private bool changed = true;

    void Update()
    {
        timer += Time.deltaTime;
        text.text = Mathf.Floor(timer).ToString();

        if (!changed && Mathf.Floor(timer) % 50 == 0)
        {
            changed = true;
            skyAnimator.SetTrigger("Change");
        } else if (Mathf.Floor(timer) % 50 != 0)
            changed = false;
    }

    void OnDisable()
    {
        resultsText.text = "Score: " + (Mathf.Floor(timer * 100)/100).ToString();
    }
}
