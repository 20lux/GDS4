using UnityEngine;

public class LeverComboID : MonoBehaviour
{
    public int leverID = 0;
    public GameObject consolePart;
    public Material consolePartMaterial;
    public Material defaultMaterial;
    public LeverComboCheck leverComboCheck;

    void Awake()
    {
        defaultMaterial = consolePart.GetComponent<Renderer>().material;
    }

    public void PullLever()
    {
        leverComboCheck.leverCombination += leverID;
        consolePart.GetComponent<Renderer>().material = consolePartMaterial;
    }

    public void ResetConsolePart()
    {
        consolePart.GetComponent<Renderer>().material = defaultMaterial;
    }
}
