using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://pressstart.vip/tutorials/2018/07/12/44/pan--zoom.html

public class CameraZoom : MonoBehaviour
{
    public float zoomOutMin = 1;
    public float zoomOutMax = 9;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    public float distance = -100;
    private Vector3 previousPosition;


    void Start()
    {
        cam.transform.position = target.position;
        cam.transform.Translate(new Vector3(0,0,distance));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);


            //rotate teil
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(touchZeroPrevPos);
           
            cam.transform.position = target.position;
        
            cam.transform.Rotate(new Vector3(1,0,0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0,1,0), -direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0,0,distance));

            previousPosition = cam.ScreenToViewportPoint(touchZeroPrevPos);
            
        }else{
            cam.transform.position = target.position;
            cam.transform.Translate(new Vector3(0,0,distance));
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));

            
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment*10, zoomOutMin, zoomOutMax);
    }
}
