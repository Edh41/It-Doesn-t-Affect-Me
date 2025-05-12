using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit))
        {
            if(Input.GetButtonDown("Left Click"))
            {
                if(hit.collider.gameObject.name.Equals("Screen"))
                {
                    SceneManager.LoadScene("ApartmentDay1");
                }
            }

            if(Input.GetButtonDown("Exit"))
            {
                if(hit.collider.gameObject.name.Equals("Screen"))
                {
                    Debug.Log("Quitting");

                    Application.Quit();
                }
            }
        }
    }
}
