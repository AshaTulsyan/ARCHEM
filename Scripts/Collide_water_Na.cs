using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide_water_Na : MonoBehaviour {

    // Use this for initialization
    public GameObject naoh;
    public GameObject h2;
    public bool g = false;
    private bool found = false;

    private void Update()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("compound");
        if (obj.Length != 0)
        {
            foreach (GameObject i in obj)
            {
                if (i.name == "NaOH(Clone)")
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                g = true;
                found = false;
            }
            else
            {
                g = false;
            }
        }
        else
        {
            g = false;
        }
    }
    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Na(Clone)" && !g)
        {
            Debug.Log("Collision happened.");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            UnityEngine.Object.Instantiate(naoh);
            UnityEngine.Object.Instantiate(h2);
            g = true;
        }
    }
}
