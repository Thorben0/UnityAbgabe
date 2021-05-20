using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Zenject;

public class ButtonScript : MonoBehaviour
{
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        // vbBtnObj = GameObject.Find("LacieBtn");
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("VButton"))
        {
            Debug.Log("Registering Vbutton listener for " + obj.name);
            obj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
            obj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        string name = vb.VirtualButtonName;
        UpdateButton(name, true);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        string name = vb.VirtualButtonName;
        UpdateButton(name, false);
    }

    private void UpdateButton(string name, bool pressed)
    {
        Debug.Log("update button " + name + " pressed=" + pressed);
        switch (name)
        {
            case "forwards":
                player.inputMove = pressed ? 1 : 0;
                break;
            case "backwards":
                player.inputMove = pressed ? -1 : 0;
                break;
            case "right":
                player.inputRotate = pressed ? 1 : 0;
                break;
            case "left":
                player.inputRotate = pressed ? -1 : 0;
                break;
        }
    }
}
