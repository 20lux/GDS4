using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator grateAnim;

    private void Awake()
    {
        grateAnim = GetComponent<Animator>();
    }

    public void OpenGrate()
    {
        grateAnim.SetBool("openGrate", true);
    }
}
