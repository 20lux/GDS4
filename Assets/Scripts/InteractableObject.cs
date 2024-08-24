using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Interactable Object Properties")]
    public ObjectType objectType;
    [SerializeField] private string ObjectName;
    [HideInInspector] public string objectName => ObjectName;
    [SerializeField] private GameObject objectToInteractWith;
    [SerializeField] private Material newMaterial;
    private Rigidbody objectRigidBody;
    [SerializeField] private bool IsLocked;
    public AudioClip pickUp;
    public AudioClip putDown;
    public AudioClip use;
    private AudioSource audioSource;
    [HideInInspector] public bool isLocked => IsLocked;

    private void Start()
    {
        if (objectType == ObjectType.Key ||
            objectType == ObjectType.GrabObject ||
            objectType == ObjectType.Cartridge)
        {
            objectRigidBody = GetComponent<Rigidbody>();
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Grab(GameObject grabCam)
    {
        // Puts object in front of grab camera
        PickUpSound();
        gameObject.transform.SetParent(grabCam.transform);
        gameObject.transform.position = grabCam.transform.position;
        gameObject.transform.rotation = grabCam.transform.rotation;
        objectRigidBody.isKinematic = true;
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
        //Debug.Log("Interacting with lock");
        if (objectToInteractWith.TryGetComponent(out DoorController doorController))
        {
            if (doorController.isGrate)
            {
                doorController.OpenGrate();
            }
            else
            {
                doorController.isDoorLocked = false;
            }
        }
        UseSound();
        waitForSound(use);
        Destroy(gameObject);
    }

    IEnumerator waitForSound(AudioClip audio)
    {
        float audioLength = audio.length;
        yield return new WaitForSeconds(audioLength);
    }

    public void UseConsole(InteractableObject cartridge)
    {
        UseSound();
        cartridge.gameObject.transform.position = objectToInteractWith.transform.position;
        cartridge.gameObject.transform.rotation = objectToInteractWith.transform.rotation;
    }

    public void PickUpSound()
    {
        audioSource.clip = pickUp;
        audioSource.Play();
    }

    public void PutDownSound()
    {
        audioSource.clip = putDown;
        audioSource.Play();
    }

    public void UseSound()
    {
        audioSource.clip = use;
        audioSource.Play();
    }

    public enum ObjectType 
    {    
        None = 0, 
        Console = 1, 
        Key = 2,
        Lock = 3, 
        GrabObject = 4,
        PlaceObject = 5 ,
        Cartridge = 6
    }

    public string GetObjectName()
    {
        return ObjectName;
    }
}
