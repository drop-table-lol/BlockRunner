
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour {

    public int waitTime = 3; // time to wait between pressing button and starting game/quiting game
    public GameObject startCube;
    public GameObject quitCube;
    public Text textStartGame;
    public Text textQuitGame;
    public GameObject clickAnimation;
    private bool buttonWasClicked = false;
    
    // Update is called once per frame
    void Update () {

        // dont do anything if button is already pressed
        if (buttonWasClicked)
            return;

        // we will use ray casting to see if the user clicks on one of the "button" cubes
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(0))
        {
            // check if user clicks on one of the "buttons"
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Start Cube")
                {
                    buttonWasClicked = true;
                    Debug.Log("Starting game");
                    startCube.SetActive(false);
                    textStartGame.enabled = false;
                    Instantiate(clickAnimation, hit.transform.position, Quaternion.identity);
                    Instantiate(clickAnimation, hit.transform.position + new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), Quaternion.identity);
                    Instantiate(clickAnimation, hit.transform.position + new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), Quaternion.identity);
                    StartCoroutine(StartGame());

                }
                else if (hit.transform.name == "Quit Cube")
                {
                    buttonWasClicked = true;
                    Debug.Log("Quiting game");
                    quitCube.SetActive(false);
                    textQuitGame.enabled = false;
                    Instantiate(clickAnimation, hit.transform.position, Quaternion.identity);
                    Instantiate(clickAnimation, hit.transform.position + new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), Quaternion.identity);
                    Instantiate(clickAnimation, hit.transform.position + new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), Quaternion.identity);
                    StartCoroutine(QuitGame());
                }
            }
            
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(waitTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level01");
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(waitTime);

        // cant use Application.Quit() if in unity editor.
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
