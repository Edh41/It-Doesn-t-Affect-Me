using UnityEngine;

public class Day2ItemInteraction : MonoBehaviour
{
    private bool crowbar = false;
    private bool trash = false;
    private bool box1 = false;
    private bool box2 = false;
    private bool trashOut = false;
    public float interactDistance = 3.0f;
    
    public GameObject trashPrefab;

    [SerializeField] LayerMask layerMask;


    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, interactDistance, layerMask))
        {
            if(Input.GetButtonDown("Left Click"))
            {
                if(hit.collider.gameObject.name.Equals("Crowbar"))
                {
                    Debug.Log("Crowbar");

                    crowbar = true;

                    hit.collider.gameObject.SetActive(false);

                    // Crowbar is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("TrashBag"))
                {
                    Debug.Log("TrashBag");

                    trash = true;

                    trashPrefab = hit.collider.gameObject;

                    hit.collider.gameObject.SetActive(false);

                    // trash bag is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("SmWoodBox"))
                {
                    Debug.Log("SmWoodBox");

                    if(crowbar)
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    
                    if(box1)
                    {
                        box2 = true;
                    }

                    else
                    {
                        box1 = true;
                    }

                    // opened a box
                }

                if(hit.collider.gameObject.name.Equals("TallWoodBox"))
                {
                    Debug.Log("TallWoodBox");
                    
                    if(crowbar)
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    
                    if(box1)
                    {
                        box2 = true;
                    }

                    else
                    {
                        box1 = true;
                    }

                    // opened another box
                }

                if(hit.collider.gameObject.name.Equals("Dumpster_body"))
                {
                    Debug.Log("Dumpster");
                    
                    if(trash)
                    {
                        trashPrefab.SetActive(true);

                        Instantiate(trashPrefab, new Vector3(31.4f,17.8f,-83.3f), Quaternion.identity);

                        trash = false;

                        trashOut = true;

                        trashPrefab.SetActive(false);
                    }
                    
                    // trash task complete
                }

                if(hit.collider.gameObject.name.Equals("ExitCriteria"))
                {
                    Debug.Log("ExitCriteria");
                    
                    if(box1 && box2 && trashOut)
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    
                    // you can leave now
                }
            }
        }

    }
}
