using UnityEngine;

public class TojoMode : MonoBehaviour
{
    [SerializeField] private GameObject customizationPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject creditsPanel;

    void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.O) && !DinoData.DD.Configured)
        {
            DinoData.DD.Configured = true;
            customizationPanel.SetActive(true);
            mainPanel.SetActive(false);
            creditsPanel.SetActive(false);
        }   
    }

    public void SetName(string value)
    {
        DinoData.DD.DinoName = value;
    }

    public void ChangeTojoCara(bool value)
    {
        DinoData.DD.TojoCara = value;
    } 
}
