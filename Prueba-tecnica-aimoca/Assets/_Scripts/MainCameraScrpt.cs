using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScrpt : MonoBehaviour
{

    private Vector3 originPosition = new Vector3(0, 10.22f, 11.35f);
    private Vector3 originRotation = new Vector3(87.25f, -47.037f, 132.415f);

    void Start()
    {
        OriginCamera();
    }

    void OriginCamera()
    {
        this.transform.position = originPosition;
        this.transform.rotation = Quaternion.Euler(originRotation);
    }
}
