using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    #region Properties
    [Tooltip("Changes how the object works depending on type")]
    [Header("Interactable Object Properties")]
    public ObjectType objectType;
    [SerializeField] private string ObjectName;
    [HideInInspector] public string objectName => ObjectName;

    [Tooltip("Chose object for key to interact with (typically a door)")]
    [Header("Key Properties")]
    [SerializeField] private GameObject objectToInteractWith;
    [SerializeField] private bool IsLocked;
    [HideInInspector] public bool isLocked => IsLocked;

    [Tooltip("Different sounds to call")]
    [Header("Sound Properties")]
    public AudioClip pickUp;
    public AudioClip putDown;
    public AudioClip use;
    public AudioClip error;
    private AudioSource audioSource;
    private Rigidbody objectRigidBody;
    #endregion

    public enum ObjectType 
    {    
        None = 0, 
        Console = 1, 
        Key = 2,
        GrabObject = 3,
        ConsoleCartridge = 4
    }
    
    private void Start()
    {
        if (objectType == ObjectType.Key ||
            objectType == ObjectType.GrabObject ||
            objectType == ObjectType.ConsoleCartridge)
        {
            objectRigidBody = GetComponent<Rigidbody>();
        }

        audioSource = GetComponent<AudioSource>();
    }

    #region Interactions
    public void Grab(GameObject grabCam)
    {
        // Puts object in front of grabcam
        // Shows the object in composite camera
        objectRigidBody.isKinematic = true;
        PickUpSound();
        transform.SetParent(grabCam.transform);
        transform.position = grabCam.transform.position;
        transform.rotation = grabCam.transform.rotation;
    }

    public void Drop(Transform playerCamTransform)
    {
        // Drops object in front of player
        PutDownSound();
        gameObject.transform.SetParent(null);
        gameObject.transform.position = playerCamTransform.position;
        objectRigidBody.isKinematic = false;
    }

    public void UseKey()
    {
        if (objectToInteractWith.TryGetComponent(out DoorController doorController))
        {
            // Only opens door once
            // Door closes after 5 seconds (see animation controller)
            doorController.Open();
            UseSound();
            Destroy(gameObject);
        }
        else if (objectToInteractWith.TryGetComponent(out GrateController grateController))
        {
            grateController.OpenGrate();
            Destroy(gameObject);
        }
        else
        {
            ErrorSound();
        }
        
    }
    #endregion

    #region Sounds

    public void PickUpSound()
    {
        audioSource.PlayOneShot(pickUp);
    }

    public void PutDownSound()
    {
        audioSource.PlayOneShot(putDown);
    }

    public void UseSound()
    {
        audioSource.PlayOneShot(use);
    }

    public void ErrorSound()
    {
        audioSource.PlayOneShot(error);
    }
#endregion

}
