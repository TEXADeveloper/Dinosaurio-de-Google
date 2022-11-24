using UnityEngine;
using TMPro;

public class LoadDinoData : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject cara;

    private string dinoName = "";
    private bool tojoCara = false;

    void Update()
    {
        if (!DinoData.DD.DinoName.Equals(dinoName))
        {
            dinoName = DinoData.DD.DinoName;
            updateName();
        }
        if (tojoCara != DinoData.DD.TojoCara)
        {
            tojoCara = DinoData.DD.TojoCara;
            updateCara();
        }
    }

    private void updateName()
    {
        nameText.text = dinoName;
    }

    private void updateCara()
    {
        cara.SetActive(tojoCara);
    }
}
