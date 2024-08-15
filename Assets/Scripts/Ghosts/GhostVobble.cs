using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVobble : MonoBehaviour
{
    public float wobbleDetla = .12f;
    public float wobbleSpeed = 5f;

    float startY;

    float seed;

    private void Start()
    {
        startY = transform.position.y;
        seed = Random.Range(0, 10);
    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos.y = Mathf.Sin(Time.time*wobbleSpeed + seed) * wobbleDetla + startY;

        transform.position = pos;
    }
}
