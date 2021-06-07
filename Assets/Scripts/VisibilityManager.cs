using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    [SerializeField] private GameObject world1;

    [SerializeField] private GameObject world2;
    // Start is called before the first frame update
    void Start()
    {
        world1.SetActive(false);
        world2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
