using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void LoadScene(){ 

        if(SceneManager.GetActiveScene().name == "Spielwelt"){
            SceneManager.LoadScene("AR_Scene"); 
            //Debug.Log("go ar");
        }else if(SceneManager.GetActiveScene().name == "AR_Scene"){
            SceneManager.LoadScene("Spielwelt");
            //Debug.Log("go 1");
        }
    }
}
