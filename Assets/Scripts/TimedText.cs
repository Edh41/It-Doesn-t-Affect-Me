using UnityEngine;
using System.Collections;

public class TimedText : MonoBehaviour
{
    public float displayTime = 5.0f;
    void Start()
    {
        StartCoroutine(DisplayRemove());
    }

    IEnumerator DisplayRemove()
    {
        yield return new WaitForSeconds(displayTime);
        this.gameObject.SetActive(false);
    }
}
