using System.Collections;
using Unity.VisualScripting;
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
    public AudioClip error;
    private AudioSource audioSource;
    public LayerMask currentLayer;
    private int layerIgnoreRaycast;
    [HideInInspector] public bool isLocked => IsLocked;

    private void Start()
    {
        if (objectType == ObjectType.Key ||
            objectType == ObjectType.GrabObject)
        {
            objectRigidBody = GetComponent<Rigidbody>();
        }

        audioSource = gameObject.AddComponent<AudioSource>();

        layerIgnoreRaycast = LayerMask.GetMask("Ignore Raycast");
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
            // Only opens door once
            // Door closes after 5 seconds (see animation controller)
            doorController.Open();
            UseSound();
            waitForSound(use);
            Destroy(gameObject);
        }
        else if (objectToInteractWith.TryGetComponent(out GrateController grateController))
        {
            // Disable highlighting when used
            grateController.gameObject.layer = layerIgnoreRaycast;
            grateController.OpenGrate();
            Destroy(gameObject);
        }
        else
        {
            ErrorSound();
        }
        
    }

    IEnumerator waitForSound(AudioClip audio)
    {
        float audioLength = audio.length;
        yield return new WaitForSeconds(audioLength);
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

    public void ErrorSound()
    {
        audioSource.clip = error;
        audioSource.Play();
    }

    public enum ObjectType 
    {    
        None = 0, 
        Console = 1, 
        Key = 2,
        Lock = 3, 
        GrabObject = 4,
        Inventory = 5,
        Button = 6
    }

    public string GetObjectName()
    {
        return ObjectName;
    }
}
