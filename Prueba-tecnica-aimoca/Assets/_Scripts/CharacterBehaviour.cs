using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject ctrlRightElbow;
    public GameObject ctrlLeftElbow;
    public Transform arms;
    public GameObject chosenObject;

    private float rayDistance = 0.3f;
    private int rotationAngleRight = 0;
    private int rotationAngleLeft = 0;

    private Animator _animator;

    private string rightObjectName;
    private string leftObjectName;
    private bool takenRight;
    private bool takenLeft;


    Vector3 originLeftHandRay;
    Vector3 originRightHandRay;

    RaycastHit hitFromLeft;
    RaycastHit hitFromRight;


    //creamos un Raycast
    //con el método Draw se dibuja una línea infinita
    void Start()
    {
        _animator = GetComponent<Animator>();
        originLeftHandRay = new Vector3(leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z);
        originRightHandRay = new Vector3(rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        originLeftHandRay = new Vector3(leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z);
        originRightHandRay = new Vector3(rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z);

        if (Physics.Raycast(originLeftHandRay, Vector3.right, out hitFromLeft, rayDistance))
        {
            if (!takenLeft)
            {
                Debug.Log("La mano izquierda ha notado algo");
                leftObjectName = hitFromLeft.collider.gameObject.name;
                takenLeft = true;
            }
        }
        else if (!Physics.Raycast(originLeftHandRay, Vector3.right, out hitFromLeft, rayDistance))
        {
            Debug.Log("No hay nada en la izquierda");
            MoveLeftArm();
        }

        if (Physics.Raycast(originRightHandRay, Vector3.left, out hitFromRight, rayDistance))
        {
            if (!takenRight)
            {
                Debug.Log("La mano derecha ha notado algo");

                rightObjectName = hitFromLeft.collider.gameObject.name;
                takenRight = true;
            }

        }
        else if (!Physics.Raycast(originRightHandRay, Vector3.left, out hitFromRight, rayDistance))
        {
            Debug.Log("No hay nada en la derecha");
            MoveRightArm();
        }


        Debug.DrawRay(originLeftHandRay, Vector2.right, Color.green);
        Debug.DrawRay(originRightHandRay, Vector2.left, Color.red);

        
        if (rightObjectName == leftObjectName)
        {
            
            chosenObject.transform.SetParent(arms);
            _animator.SetBool("coger", true);
        }
        
        

    }



    private void MoveLeftArm()
    {
        rotationAngleLeft++;
        ctrlLeftElbow.transform.Rotate(new Vector3(0f, 0f, rotationAngleLeft)*Time.deltaTime);
    }

    private void MoveRightArm()
    {
        rotationAngleRight--;
        ctrlRightElbow.transform.Rotate(new Vector3(0f, 0f, rotationAngleRight) * Time.deltaTime);
    }
}
