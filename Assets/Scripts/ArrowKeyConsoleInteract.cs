using UnityEngine;

public class ArrowKeyConsoleInteract : MonoBehaviour
{
    [SerializeField] private GameObject droneObject;
    private GameObject key;
    private Color pressedColor = Color.green;
    private Color idleColor = Color.white;
    public Direction direction;
    public float speed = 10f;
    public float distance = 0.2f;
    private float posX;
    private float posY;
    private float posZ;
    private Vector3 moveTarget;
    private bool isActive = true;
    private bool isMoving = false;
    private AudioSource audioSource;
    private Animator animator;
    private int layerIgnoreRaycast;
    
    void Awake()
    {
        key = gameObject;
        layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        key.GetComponent<Renderer>().material.color = idleColor;

        posX = droneObject.transform.position.x;
        posY = droneObject.transform.position.y;
        posZ = droneObject.transform.rotation.z;
    }

    public enum Direction
    {
        Forward,
        Backward,
        Left,
        Right
    }

    public void KeyInteract()
    {
        // Get current position
        posZ = droneObject.transform.position.z;
        posX = droneObject.transform.position.x;
        posY = droneObject.transform.position.y;

        if (isActive)
        {
            // Depending on direction, make new target position
            switch (direction)
            {
                case Direction.Forward:
                    moveTarget = new Vector3(posX, posY, posZ + distance);
                    posZ = droneObject.transform.position.z;
                    break;
                case Direction.Backward:
                    moveTarget = new Vector3(posX, posY, posZ - distance);
                    posZ = droneObject.transform.position.z;
                    break;
                case Direction.Left:
                    moveTarget = new Vector3(posX - distance, posY, posZ);
                    posX = droneObject.transform.position.x;
                    break;
                case Direction.Right:
                    moveTarget = new Vector3(posX + distance, posY, posZ);
                    posX = droneObject.transform.position.x;
                    break;
            }

            key.GetComponent<Renderer>().material.color = pressedColor;
            isMoving = true;
            audioSource.pitch = Random.Range(1f, 1.5f);
            audioSource.Play();
            animator.SetTrigger("IsPressed");
        }
    }

    public void Update()
    {
        // Move towards target position
        if (isActive && isMoving)
        {
            var step = speed * Time.deltaTime;
            droneObject.transform.position = Vector3.MoveTowards(droneObject.transform.position, moveTarget, step);
            if (droneObject.transform.position == moveTarget)
            {
                key.GetComponent<Renderer>().material.color = idleColor;
                animator.ResetTrigger("IsPressed");
                isMoving = false;
            }
        }

        if (droneObject.transform.parent != null)
        {
            isActive = false;
        }
    }

    public void OnPuzzleComplete()
    {
        key.GetComponent<Renderer>().material.color = pressedColor;
        gameObject.layer = layerIgnoreRaycast;
    }
}
