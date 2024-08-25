using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowKeyConsoleInteract : MonoBehaviour
{
    [SerializeField] private GameObject techLabObject;
    [SerializeField] private GameObject key;
    private Color pressedColor = Color.green;
    private Color idleColor = Color.white;
    private Color currentColor;
    public Direction direction;
    public float speed = 10f;
    public float distance = 0.2f;
    private float posX;
    private float posY;
    private float posZ;
    private Vector3 moveTarget;
    private bool isActive = true;
    private bool isMoving = false;
    
    void Awake()
    {
        key = gameObject;
        posX = techLabObject.transform.position.x;
        posY = techLabObject.transform.position.y;
        posZ = techLabObject.transform.rotation.z;
        currentColor = idleColor;
        key.GetComponent<Renderer>().material.color = currentColor;
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
        posZ = techLabObject.transform.position.z;
        posX = techLabObject.transform.position.x;
        posY = techLabObject.transform.position.y;

        if (gameObject.TryGetComponent(out Animator animator))
        {
            animator.SetTrigger("IsPressed");
        }

        if (isActive)
        {
            // Depending on direction, make new target position
            switch (direction)
            {
                case Direction.Forward:
                    moveTarget = new Vector3(posX, posY, posZ + distance);
                    posZ = techLabObject.transform.position.z;
                    currentColor = pressedColor;
                    isMoving = true;
                    break;
                case Direction.Backward:
                    moveTarget = new Vector3(posX, posY, posZ - distance);
                    posZ = techLabObject.transform.position.z;
                    currentColor = pressedColor;
                    isMoving = true;
                    break;
                case Direction.Left:
                    Debug.Log("Moving left!");
                    moveTarget = new Vector3(posX - distance, posY, posZ);
                    posX = techLabObject.transform.position.x;
                    currentColor = pressedColor;
                    isMoving = true;
                    break;
                case Direction.Right:
                    Debug.Log("Moving right!");
                    moveTarget = new Vector3(posX + distance, posY, posZ);
                    posX = techLabObject.transform.position.x;
                    currentColor = pressedColor;
                    isMoving = true;
                    break;
            }
        }
    }

    public void FixedUpdate()
    {
        // Move towards target position
        if (isActive && isMoving)
        {
            var step = speed * Time.deltaTime;
            techLabObject.transform.position = Vector3.MoveTowards(techLabObject.transform.position, moveTarget, step);
            if (techLabObject.transform.position == moveTarget)
            {
                isMoving = false;
                currentColor = idleColor;
            }
        }
    }
}
