using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //variables
    public GameObject pauseMenu;
    private bool isPaused = false;
    public GameObject player;
    private GameObject newObj;
    private GameObject op;
    private float targets = 0;
    public Text TargetsDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            TargetsDestroyed = GameObject.Find("TextScore").GetComponent<Text>();
        }catch
        {

        }
        
        if (player)
        {
            op = Instantiate(player, new Vector3(-12, 1, -9), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Ball") || hitInfo.collider.CompareTag("Box"))
                {
                    Rigidbody rb = hitInfo.collider.GetComponent<Rigidbody>();

                    if (rb)
                    {
                        rb.AddForce(-hitInfo.normal * 5, ForceMode.Impulse);
                    }
                }
                else if (hitInfo.collider.CompareTag("Target"))
                {
                    Destroy(hitInfo.collider.gameObject);
                    targets++;
                    TargetsDestroyed.text = "Targets Destroyed: " + targets.ToString(); 
                }
            }


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0.0f : 1.0f;
        }
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
