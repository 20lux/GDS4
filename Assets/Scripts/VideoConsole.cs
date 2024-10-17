using UnityEngine;

public class VideoConsole : MonoBehaviour
{
    public PlayVideo videoPlayer;
    public GameObject cartridge;
    public AudioSource consoleAudioSource;
    public AudioClip cartridgeClickSound;
    public AudioClip cartAudio;
    public ClipIndex clipIndex;
    public Material[] materials = new Material[8];

    public enum ClipIndex
    {
        BlueCart = 1,
        GreenCart = 2,
        CreamCart = 3,
        RedCart = 4,
        PurpleCart = 5,
        PinkCart = 6,
        WhiteCart = 7,
        OrangeCart = 8
    }

    void Awake()
    {
        consoleAudioSource = GetComponent<AudioSource>();
        consoleAudioSource.loop = false;
        cartridge.SetActive(false);
    }

    public void PlayCartridge(int i)
    {
        consoleAudioSource.clip = cartridgeClickSound;
        consoleAudioSource.Play();

        switch (clipIndex)
        {
            case ClipIndex.BlueCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[0];
                break;
            case ClipIndex.GreenCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[1];
                break;
            case ClipIndex.CreamCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[2];
                break;
            case ClipIndex.RedCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[3];
                break;
            case ClipIndex.PurpleCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[4];
                break;
            case ClipIndex.PinkCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[5];
                break;
            case ClipIndex.WhiteCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[6];
                break;
            case ClipIndex.OrangeCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[7];
                break;
        }

        cartridge.SetActive(true);
        videoPlayer.LoadClip(i);
        consoleAudioSource.clip = cartAudio;
        consoleAudioSource.Play();
    }
}
