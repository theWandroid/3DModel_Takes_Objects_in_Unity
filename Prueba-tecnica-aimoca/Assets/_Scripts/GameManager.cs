using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private CharacterBehaviour charBehave;

    public GameObject pencil;
    public GameObject can;
    public GameObject box;
    public GameObject panel;

    public GameObject mainCamera;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        charBehave = FindObjectOfType<CharacterBehaviour>();
        player.SetActive(false);
    }


    public void PickUpPencil()
    {
        Debug.Log("Has escogido el lapiz");
        ChangeCameraPosRot();
        charBehave.chosenObject = pencil;
        StartGame();
    }

    public void PickUpCan()
    {
        Debug.Log("Has escogido la lata");
        ChangeCameraPosRot();
        charBehave.chosenObject = can;
        StartGame();

    }

    public void PickUpBox()
    {
        Debug.Log("Has escogido la caja");
        ChangeCameraPosRot();
        charBehave.chosenObject = box;
        StartGame();

    }

    public void ChangeCameraPosRot()
    {
        mainCamera.transform.position = new Vector3(0, 12.6f, 15.28f);
        mainCamera.transform.rotation = Quaternion.Euler(16.1f, -177.906f, 0);
    }

    public void StartGame()
    {
        charBehave.chosenObject.transform.position = new Vector3(0, 6.56f, 7f);
        player.SetActive(true);
        panel.SetActive(false);

    }
}
