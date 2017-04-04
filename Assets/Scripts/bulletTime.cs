using UnityEngine;

public class bulletTime : MonoBehaviour {

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    //float dt = Time.fixedDeltaTime;
    bool isSlow = false;

    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1.5f); //play with this. Maybe a core game element to keep speeding up unless you have near misses. Reward good play
        Time.fixedDeltaTime = Time.timeScale * .02f;
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0.001f, 0.01f);
        if (Time.timeScale == 1)
        {
            //Debug.Log("Normal Speed");
            isSlow = false;
        }

        if (Input.GetMouseButton(0))
        {
            //if (isSlow == false)
            {
                DoSlowMotion();
                FindObjectOfType<Score>().AddScore(-1);
                FindObjectOfType<Score>().isSlow(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        { //user isn't doing slowmo anymore
            FindObjectOfType<Score>().isSlow(false);

        }
        
    }

    void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        //Debug.Log("dt = " + dt);
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                FindObjectOfType<Score>().AddScore(10);
                if (isSlow == false)
                {
                    isSlow = true;
                    //Debug.Log("Doing Slowmo");
                    DoSlowMotion();
                }
            }
        }
    }
}
