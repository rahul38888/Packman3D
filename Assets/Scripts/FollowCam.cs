using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] public GameObject target;

    public Vector3 offset = Vector3.zero;

    void Update()
    {
        transform.position = target.transform.position + offset;
    }

    private void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(target.transform.position, target.transform.position + offset);
            Gizmos.DrawCube(target.transform.position + offset, Vector3.one);
        }
    }
}
