using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryInfo : MonoBehaviour
{
    float[] planetMasses;
    bool[] planetsActive;
    //positions only for added planets
    float[] planetPositions;
    int numPlanets = 14;

    public int distSetting;

    // Start is called before the first frame update
    void Awake()
    {
        //Makes sure this will be saved through all the scenes
        DontDestroyOnLoad(gameObject);

        this.name = "PlanetaryInformation";

        //Planet masses, in order of distance from the sun
        planetMasses = new float[numPlanets];
        //If the planet is active (1 is active, 0 is inactive)(could be changed by adding or deleting)
        planetsActive = new bool[numPlanets];

        //only includes new planets soooo
        planetPositions = new float[numPlanets - 9];

        for(int i = 0; i < numPlanets; i ++){
            if(i < 9){
                planetsActive[i] = true;
            }
            else {
                planetsActive[i] = false;
            }
        }

        planetMasses[0] = 333000.0f; //Sun
        planetMasses[1] = 0.5f; //Mercury
        planetMasses[2] = 3f; //Venus
        planetMasses[3] = 1f; //Earth
        planetMasses[4] = 4f; //Mars
        planetMasses[5] = 317f; //Jupiter
        planetMasses[6] = 95f; //Saturn
        planetMasses[7] = 14.5f; //Uranus
        planetMasses[8] = 17.15f; //Neptune
        planetMasses[9] = Random.Range(0.3f, 20.0f); //Random 1
        planetMasses[10] = Random.Range(0.3f, 20.0f); //Random 2
        planetMasses[11] = Random.Range(0.3f, 20.0f); //Random 3
        planetMasses[12] = Random.Range(0.3f, 20.0f); //Random 4
        planetMasses[13] = Random.Range(0.3f, 20.0f); //Random 5

        for(int i =0; i < numPlanets - 9; i ++){
            planetPositions[i] = Random.Range(1080f, 1610f);
        }

        distSetting = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //getters
    public bool getPlanetsActive(int index){
        return planetsActive[index];
    }

    public float getPlanetMass(int index){
        return planetMasses[index];
    }

    public float getPlanetPosition(int index){
        return planetPositions[index];
    }
    
    //setters
    public void setPlanetMass(int index, float mass){
        planetMasses[index] = mass;
        
    }

    public void setPlanetsActive(int index, bool active){
        planetsActive[index] = active;
    }

    public void setPlanetPosition(int index, float position){
        planetPositions[index] = position;
    }
}
