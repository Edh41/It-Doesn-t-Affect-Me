using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private bool crowbar = false;
    private bool cone = false;
    private bool valve = false;
    private bool trash = false;
    private bool box1 = false;
    private bool box2 = false;
    private bool valvePlaced = false;
    private bool trashOut = false;
    private bool conePlaced = false;
    public float interactDistance = 3.0f;
    
    public GameObject trashPrefab, valvePrefab, conePrefab;

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

                if(hit.collider.gameObject.name.Equals("Valve"))
                {
                    Debug.Log("Valve");

                    valve = true;

                    valvePrefab = hit.collider.gameObject;

                    hit.collider.gameObject.SetActive(false);

                    // valve is in inventory
                }

                if(hit.collider.gameObject.name.Equals("Machine"))
                {
                    Debug.Log("Machine");

                    if(valve)
                    {
                        valvePrefab.SetActive(true);

                        Instantiate(valvePrefab, new Vector3(15.48f,5.973f,87.814f), Quaternion.Euler(0.0f,0.0f,90.0f));

                        valve = false;

                        valvePlaced = true;

                        valvePrefab.SetActive(false);
                    }
                }

                if(hit.collider.gameObject.name.Equals("Cone"))
                {
                    Debug.Log("Cone");
                    
                    cone = true;
                    
                    conePrefab = hit.collider.gameObject;
                    
                    hit.collider.gameObject.SetActive(false);

                    // cone is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("Electric"))
                {
                    Debug.Log("Electric");
                    
                    if(cone)
                    {
                        conePrefab.SetActive(true);

                        Instantiate(conePrefab, new Vector3(27.7f,0.7f,52.4f), Quaternion.identity);

                        cone = false;

                        conePlaced = true;

                        conePrefab.SetActive(false);
                    }
                }

                if(hit.collider.gameObject.name.Equals("ExitCriteria"))
                {
                    Debug.Log("ExitCriteria");
                    
                    if(box1 && box2 && valvePlaced && conePlaced && trashOut)
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    
                    // you can leave now
                }
            }
        }

    }
}