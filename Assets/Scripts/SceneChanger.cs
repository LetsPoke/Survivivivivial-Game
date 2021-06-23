using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void LoadScene(){ 

        if(SceneManager.GetActiveScene().name == "Scene_1"){
            SceneManager.LoadScene("AR_Scene"); 
            Debug.Log("go ar");
        }else if(SceneManager.GetActiveScene().name == "AR_Scene"){
            SceneManager.LoadScene("Scene_1");
            Debug.Log("go 1");
        }
    }
}
