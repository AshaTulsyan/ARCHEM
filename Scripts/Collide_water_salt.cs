using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collide
{
    public class Collide_water_salt : MonoBehaviour
    {
        public GameObject na_water;
        public GameObject cl_water;
        public bool g = false;
        private bool found = false;

        private void Update()
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("compound");
            if (obj.Length != 0)
            {
                foreach (GameObject i in obj)
                {
                    if (i.name == "Na-Water(Clone)")
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
            else{
                g = false;
            }
        }
        // Use this for initialization
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "NaCl(Clone)" && !g)
            {
                Debug.Log("Collision happened.");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                UnityEngine.Object.Instantiate(na_water);
                UnityEngine.Object.Instantiate(cl_water);
                g = true;
            }
        }
    }
}
