using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectCam : MonoBehaviour
{

    private bool disconnected;
    private bool canReconnect;

    public static DisconnectCam instance;

    private void Awake()
    {
        instance = this;
        /*
        GameObject test = GameObject.Find("PlanetaryInformation");
        if(test == null){
            Debug.Log("Could not find planet Info");
        }else{
            PlanetaryInfo pinfo = test.GetComponent<PlanetaryInfo>();
            if(pinfo == null){
                Debug.Log("Could not find info component");
            }else{
                Debug.Log("Sun Mass: " + pinfo.getPlanetMass(0));
            }
            
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        disconnected = false;
        canReconnect = true;
    }

    // Update is called once per frame
    void Update()
    {
        isKeyPressed();
    }

    private void isKeyPressed(){
        if(Input.GetKeyDown(KeyCode.E) && canReconnect){
            disconnected = !disconnected;
            //Debug.Log("E key was pressed.");
        }
    }

    public bool getDisconnected(){
        return disconnected;
    }

    public void setDisconnected(bool val){
        disconnected = val;
        canReconnect = !val;
    }
}
