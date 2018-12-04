using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {
    public GameObject particle;
    private GameObject cur_touch = null;
    private float h;
    private static double horizontalSpeed = 1.0;
    private float startTime;
    // Use this for initialization
    void Start () {
        startTime = 0;
	}
    private RaycastHit hit;
    private bool clicked = false;

    // Update is called once per frame
   void Update()
    {
        {

            if(clicked){
                var deltaTime = Time.time - startTime;
                if(Input.GetMouseButtonUp(0) && deltaTime <= 1){
                    GameObject[] temp = GameObject.FindGameObjectsWithTag("compound");
                    foreach(GameObject i in temp){
                        Destroy(i.gameObject);
                    }
                    clicked = false;
                }
                if(deltaTime > 1){
                    clicked = false;
                }
            }else{
                if (Input.GetMouseButtonUp(0))
                {
                    clicked = true;
                    startTime = Time.time;
                }

            }

            if (clicked)
            {
                var deltaTime = Time.time - startTime;
                if (Input.touches.Length != 0)
                {
                    if (Input.touches[0].phase == TouchPhase.Ended && deltaTime <= 2000)
                    {
                        GameObject[] temp = GameObject.FindGameObjectsWithTag("compound");
                        foreach (GameObject i in temp)
                        {
                            Destroy(i.gameObject);
                        }
                        clicked = false;
                    }
                    if (deltaTime > 2000)
                    {
                        clicked = false;
                    }
                }
            }
            else
            {
                if (Input.touches.Length != 0)
                {
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        clicked = true;
                        startTime = Time.time;
                    }
                }
            }

            var ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray2, out hit, 10000))
            {
                if (cur_touch == null)
                {
                    cur_touch = hit.transform.gameObject;
                }else
                {
                    cur_touch = null;
                }
            }

            if (Input.GetMouseButton(0))
            {

                if (Physics.Raycast(ray2, out hit, 10000))
                {
                    cur_touch = hit.transform.gameObject;
                }

                if (cur_touch != null)
                {
                    Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                    Vector3 worldPos1 = Camera.main.ScreenToWorldPoint(screenPos);
                    var ray1 = Camera.main.ScreenPointToRay(screenPos);
                    Plane hPlane = new Plane(Vector3.forward, 80);
                    float dis = 0;
                    if (hPlane.Raycast(ray1, out dis))
                    {
                        Vector3 location = ray1.GetPoint(dis);
                        cur_touch.transform.position = location;
                    }
                }
            }
        }


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Ended)
            {
                // Construct a ray from the current touch coordinates

            }

            if(touch.phase == TouchPhase.Moved){
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, 10000))
                {
                    cur_touch = hit.transform.gameObject;
                }

                if (cur_touch != null){
                    Vector3 screenPos = new Vector3(touch.position.x, touch.position.y, 10);
                    Vector3 worldPos1 = Camera.main.ScreenToWorldPoint(screenPos);
                    var ray1 = Camera.main.ScreenPointToRay(screenPos);
                    Plane hPlane = new Plane(Vector3.forward, 80);
                    float dis = 0;
                    if (hPlane.Raycast(ray1, out dis))
                    {
                        Vector3 location = ray1.GetPoint(dis);
                        cur_touch.transform.position = location;
                    }
                }
                else{
                    return;
                }

            }
        }
    }
}
