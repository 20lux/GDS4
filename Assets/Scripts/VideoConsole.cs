using Unity.VisualScripting;
using UnityEngine;

public class VideoConsole : MonoBehaviour
{
    public PlayVideo videoPlayer;
    public GameObject cartridge;
    public AudioSource audioSource;
    public AudioClip cartridgeClickSound;
    public SoundTrigger soundTrigger;
    public ClipIndex clipIndex;
    public Material[] materials = new Material[8];

    public enum ClipIndex
    {
        BlueCart = 0,
        GreenCart = 1,
        CreamCart = 2,
        RedCart = 3,
        PurpleCart = 4,
        PinkCart = 5,
        WhiteCart = 6,
        OrangeCart = 7
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cartridge.SetActive(false);
    }

    public void PlayCartridge(int i)
    {
        audioSource.clip = cartridgeClickSound;
        audioSource.Play();

        switch (clipIndex)
        {
            case ClipIndex.BlueCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[0];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.GreenCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[1];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.CreamCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[2];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.RedCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[3];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.PurpleCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[4];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.PinkCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[5];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.WhiteCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[6];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
            case ClipIndex.OrangeCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[7];
                Debug.Log("Changing material to: " + materials[0].name);
                break;
        }

        cartridge.SetActive(true);

        var soundTriggerAudioSource = soundTrigger.gameObject.GetComponent<AudioSource>();
        videoPlayer.LoadClip(i, audioSource, soundTriggerAudioSource);
        Debug.Log("Playing clip: " + i.ToString());
    }
}
