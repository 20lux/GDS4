using UnityEditor;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 0.25f, 1));
        var direction = transform.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(transform.position, direction);
    }
}
