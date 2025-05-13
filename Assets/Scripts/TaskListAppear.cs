using UnityEngine;
using System.Collections;

public class TaskListAppear : MonoBehaviour
{

    void Start()
    {
        this.gameObject.transform.localPosition = new Vector3(2.0f,0.54f,1.0f);

        StartCoroutine(AppearDelay());
    }

    IEnumerator AppearDelay()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.transform.localPosition = new Vector3(0.0f,0.54f,1.0f);
    }
}
