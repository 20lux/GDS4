using System.Collections;
using UnityEngine;

public class LeverComboCheck : MonoBehaviour
{
    public string leverCombination;
    public PlayerSounds playerSounds;
    public GameController gameController;
    public const string airlockCombination = "201";
    public const string selfdestructCombination = "012";
    public const string SOSCombination = "220";
    public Animator mainLeverAnimator;
    public LeverComboID[] leverComboIDs = new LeverComboID[3];

    void Awake()
    {
        mainLeverAnimator = GetComponent<Animator>();
    }

    public void CheckLeverCombination()
    {
        mainLeverAnimator.SetBool("CheckCombo", true);

        if (leverCombination.Length > 3)
        {
            WrongCombination();
        }

        switch(leverCombination)
        {
            case airlockCombination:
                mainLeverAnimator.SetBool("CheckCombo", false);
                playerSounds.PlayAirlockAccessSound();
                Wait();
                gameController.onAirlockEndingEnable?.Invoke();
                break;
            case selfdestructCombination:
                mainLeverAnimator.SetBool("CheckCombo", false);
                playerSounds.PlaySelfDestructSound();
                Wait();
                gameController.onSelfDestructionEnable?.Invoke();
                break;
            case SOSCombination:
                mainLeverAnimator.SetBool("CheckCombo", false);
                playerSounds.PlaySOSAccessSound();
                Wait();
                gameController.onSOSEnable?.Invoke();
                break;
            default:
                mainLeverAnimator.SetBool("CheckCombo", false);
                WrongCombination();
                break;
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
        Wait();  
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
