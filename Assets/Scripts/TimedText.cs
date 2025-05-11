using UnityEngine;

public class TimedText : MonoBehaviour
{
    public float displayTime = 5.0f;
    void Start()
    {
        Destroy(this.gameObject, displayTime * Time.deltaTime);
    }
}
