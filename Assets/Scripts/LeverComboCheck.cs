using System.Collections;
using UnityEngine;

public class LeverComboCheck : MonoBehaviour
{
    public string leverCombination;
    public GameController gameController;
    public string airlockCombination = "121";
    public string selfdestructCombination = "000";
    public string SOSCombination = "110";
    public Animator mainLeverAnimator;
    public LeverComboID[] leverComboIDs = new LeverComboID[3];

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        mainLeverAnimator = GetComponent<Animator>();
    }

    public void CheckLeverCombination()
    {
        mainLeverAnimator.SetBool("CheckCombo", true);

        if (leverCombination.Length > 3)
        {
            WrongCombination();
        }
        
        if (leverCombination == airlockCombination)
        {
            gameController.PlayGrantedSound();
            Wait();
            gameController.onAirlockEndingEnable?.Invoke();
        }
        else if (leverCombination == selfdestructCombination)
        {
            gameController.PlayGrantedSound();
            Wait();
            gameController.onSelfDestructionEnable?.Invoke();
        }
        else if (leverCombination == SOSCombination)
        {
            gameController.PlayGrantedSound();
            Wait();
            gameController.onSOSEnable?.Invoke();
        }
        else
        {
            WrongCombination();
        }

        mainLeverAnimator.SetBool("CheckCombo", false);
    }

    public void WrongCombination()
    {
        gameController.PlayErrorSound();
        leverCombination = "";
        for (int i = 0; i < leverComboIDs.Length; i++)
        {
            leverComboIDs[i].ResetConsolePart();
        }
        Wait();  
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
