using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    //https://www.youtube.com/watch?v=S2mK6KFdv0I&t=586s
    [SerializeField] LayerMask movementMask;
    //public Interactable focus;

    Camera cam;
    PlayerMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, movementMask) && !EventSystem.current.IsPointerOverGameObject()){

                //Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                //Move our player to what we hit
                motor.MoveToPoint(hit.point);

                //Stop focusing any Objects
                //RemoveFocus();

            }
        }

        // if(Input.GetMouseButtonDown(1)){
        //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;

        //     if (Physics.Raycast(ray, out hit, 100)){
        //         //check if we hit an interactable
        //         Interactable interactable = hit.collider.GetComponent<Interactable>();

        //         // if we did set it as our focus
        //         if(interactable != null){
        //             SetFocus(interactable);
        //         }
        //     }
        // }
    }

    // void SetFocus(Interactable newFocus){
        
    //     //change focus
    //     if(newFocus != focus){
    //         if(focus!=null){
    //             focus.OnDefocused();
    //         }
    //         focus = newFocus;
    //         motor.FollowTarget(newFocus);
    //     }
    //     newFocus.OnFocused(transform);
        
    // }

    // void RemoveFocus(){
    //     if(focus!=null){
    //         focus.OnDefocused();
    //     }
    //     focus = null;
    //     motor.StopFollowingTarget();
    // }



}
