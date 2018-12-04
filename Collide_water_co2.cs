using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Collide
{
    public class Collide_water_co2 : MonoBehaviour
    {
        public GameObject h2co3;
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
                    if (i.name == "H2CO3(Clone)")
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
            if (collision.gameObject.name == "CO2(Clone)" && !g)
            {
                Debug.Log("Collision happened.");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                UnityEngine.Object.Instantiate(h2co3);
                UnityEngine.Object.Instantiate(h2);
                g = true;
            }
        }
    }
}
