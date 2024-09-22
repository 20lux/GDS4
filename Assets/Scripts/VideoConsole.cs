using UnityEngine;

public class VideoConsole : MonoBehaviour
{
    public PlayVideo videoPlayer;
    public GameObject cartridge;
    public AudioSource audioSource;
    public AudioClip cartridgeClickSound;
    public SoundTrigger soundTrigger;
    public clipIndex clipID;
    public Material[] materials = new Material[8];

    // Only trigger story audio once after video has been played
    private bool hasPlayed = false;

    public enum clipIndex
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

        switch (clipID)
        {
            case clipIndex.BlueCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[0];
                break;
            case clipIndex.GreenCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[1];
                break;
            case clipIndex.CreamCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[2];
                break;
            case clipIndex.RedCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[3];
                break;
            case clipIndex.PurpleCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[4];
                break;
            case clipIndex.PinkCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[5];
                break;
            case clipIndex.WhiteCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[6];
                break;
            case clipIndex.OrangeCart:
                cartridge.GetComponent<MeshRenderer>().material = materials[7];
                break;
        }

        cartridge.SetActive(true);

        audioSource.clip = null;
        videoPlayer.LoadClip(i, audioSource);
        Debug.Log("Playing clip: " + clipID.ToString());

        if (videoPlayer.endClip && !hasPlayed)
        {
            soundTrigger.PlayAudio();
            hasPlayed = true;
            videoPlayer.endClip = false;
        }
    }
}
