using UnityEngine;

public class LeverComboCheck : MonoBehaviour
{
    public string leverCombination;
    public GameController gameController;
    public string airlockCombination = "121";
    public string selfdestructCombination = "000";
    public string SOSCombination = "110";
    public LeverComboID[] leverComboIDs = new LeverComboID[3];

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void CheckLeverCombination()
    {
        if (leverCombination.Length > 3)
        {
            WrongCombination();
        }
        
        if (leverCombination == airlockCombination)
        {
            gameController.PlayGrantedSound();
            gameController.onAirlockEndingEnable?.Invoke();
        }
        else if (leverCombination == selfdestructCombination)
        {
            gameController.PlayGrantedSound();
            gameController.onSelfDestructionEnable?.Invoke();
        }
        else if (leverCombination == SOSCombination)
        {
            gameController.PlayGrantedSound();
            gameController.onSOSEnable?.Invoke();
        }
        else
        {
            WrongCombination();
        }
    }

    public void WrongCombination()
    {
        gameController.PlayErrorSound();
        leverCombination = "";
        for (int i = 0; i < leverComboIDs.Length; i++)
        {
            leverComboIDs[i].ResetConsolePart();
        }  
    }
}
