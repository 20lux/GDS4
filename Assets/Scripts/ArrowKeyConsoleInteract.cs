using Unity.VisualScripting;
using UnityEngine;

public class ArrowKeyConsoleInteract : MonoBehaviour
{
    [SerializeField] private GameObject techLabObject;
    [SerializeField] private GameObject key;
    public Direction direction;
    private float posX;
    private float posZ;
    private bool isActive = true;
    
    void Awake()
    {
        key = gameObject;
        posX = techLabObject.transform.position.x;
        posZ = techLabObject.transform.rotation.z;
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
        if (gameObject.TryGetComponent(out Animator animator))
        {
            animator.SetTrigger("IsPressed");
        }

        if (isActive)
        {
            switch (direction)
            {
                case Direction.Forward:
                    techLabObject.transform.position = new Vector3(0, 0, posZ + 1);
                    posZ = techLabObject.transform.position.z;
                    break;
                case Direction.Backward:
                    techLabObject.transform.position = new Vector3(0, 0, posZ - 1);
                    posZ = techLabObject.transform.position.z;
                    break;
                case Direction.Left:
                    techLabObject.transform.position = new Vector3(posX - 1, 0, 0);
                    posX = techLabObject.transform.position.x;
                    break;
                case Direction.Right:
                    techLabObject.transform.position = new Vector3(posX + 1, 0, 0);
                    posX = techLabObject.transform.position.x;
                    break;
            }
        }
    }
}
