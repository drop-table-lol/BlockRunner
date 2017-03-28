using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {
    public int waitTime; // time before button does action
    public GameObject clickAnimation;

    // Use this for initialization
    void Start ()
    {
	}

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("click!\n");
            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f; //distance of the plane from the camera

            Instantiate(clickAnimation, Camera.main.ScreenToWorldPoint(screenPoint), Quaternion.identity);
        } 
    }

    public void StartPress()
    {
        //yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level01");
    }

    public void ExitPress()
    {
        //yield return new WaitForSeconds(waitTime);

        // cant use Application.Quit() if in unity editor.
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                         Application.Quit();
        #endif
    }


}
