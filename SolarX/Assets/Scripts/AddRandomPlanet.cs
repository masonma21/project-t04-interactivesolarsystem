using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] celestials;
    readonly static float G = 100f;
    ArrayList randomPlanets = new ArrayList();
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestials");
        if (celestials == null || celestials.Length == 0)
        {

            Debug.LogWarning("This SolarSystem found no celestial objects!", this);

        }
        else
        {

            Debug.Log("Found " + this.celestials.Length.ToString() + " celestial objects at AddRandomPlanet start.", this);

        }
    }

    //private void FixedUpdate()
    //{
    //    // Add gravity
    //    foreach (GameObject randomPlanet in randomPlanets)
    //    {
    //        foreach (GameObject b in celestials)
    //        {
    //            float m1 = randomPlanet.GetComponent<Rigidbody>().mass;
    //            float m2 = b.GetComponent<Rigidbody>().mass;
    //            float r = Vector3.Distance(randomPlanet.transform.position, b.transform.position);

    //            randomPlanet.GetComponent<Rigidbody>().AddForce(SolarSystem.gravForceHelper(randomPlanet.transform.position, b.transform.position, G, m1, m2, r));
    //        }
    //    }
    //}

    public void addRandomPlanet()
    {
        Vector3 pos = new Vector3(0f, 0f, Random.Range(50f, 13000f));
        float mass = Random.Range(1, 100);
        float scale = Random.Range(30, 70);
        Vector3 scaleVec = new Vector3(scale, scale, scale);

        GameObject randomPlanet = buildPlanet(pos, mass, scaleVec);

        randomPlanet.AddComponent<SelfRotation>();
        randomPlanet.SetActive(true);

        randomPlanets.Add(randomPlanet);


        

        GameObject solarSystem = GameObject.Find("SolarSystem");
        solarSystem.GetComponent<SolarSystem>().setCelestials(GameObject.FindGameObjectsWithTag("Celestials"));

        celestials = solarSystem.GetComponent<SolarSystem>().getCelestials();
        float random_mass = randomPlanet.GetComponent<Rigidbody>().mass;
        // Add initial velocity
        foreach (GameObject b in celestials)
        {
            if (!randomPlanet.Equals(b))
            {
                Vector3 b_rotation = new Vector3(b.transform.eulerAngles.x, b.transform.eulerAngles.y, b.transform.eulerAngles.z);

                float m2 = b.GetComponent<Rigidbody>().mass;
                float r = Vector3.Distance(randomPlanet.transform.position, b.transform.position);
                randomPlanet.transform.LookAt(b.transform);
                b.transform.LookAt(randomPlanet.transform);

                randomPlanet.GetComponent<Rigidbody>().velocity += SolarSystem.initialVelocityHelper(randomPlanet.transform.right,
                                                                                G, m2, r);
                b.GetComponent<Rigidbody>().velocity += SolarSystem.initialVelocityHelper(b.transform.right,
                                                                                G, random_mass, r);

                b.transform.eulerAngles = b_rotation;
            }
                
        }


    }

    public GameObject buildPlanet(Vector3 in_pos, float in_mass, Vector3 in_scale, string in_name = "Random")
    {
        GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planet.name = in_name;
        planet.tag = "Celestials";
        planet.transform.position = in_pos;
        planet.transform.localScale = in_scale;

        planet.AddComponent<Rigidbody>();
        planet.AddComponent<SphereCollider>();
        planet.AddComponent<TrailRenderer>();

        planet.GetComponent<Rigidbody>().mass = in_mass;
        planet.GetComponent<Rigidbody>().useGravity = false;


        return planet;
    }

}
