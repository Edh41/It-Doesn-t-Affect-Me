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

                    Destroy(hit.collider.gameObject);

                    // Crowbar is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("TrashBag"))
                {
                    Debug.Log("TrashBag");

                    trash = true;

                    trashPrefab = hit.collider.gameObject;

                    Instantiate(trashPrefab, new Vector3(10.0f,1.5f,127.9f), Quaternion.identity);

                    hit.collider.gameObject.SetActive(false);

                    // trash bag is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("SmWoodBox"))
                {
                    Debug.Log("SmWoodBox");

                    if(crowbar)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    
                    if(box1)
                    {
                        box2 = true;
                    }

                    else
                    {
                        box1 = true;
                    }
                }

                if(hit.collider.gameObject.name.Equals("TallWoodBox"))
                {
                    Debug.Log("TallWoodBox");
                    
                    if(crowbar)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    
                    if(box1)
                    {
                        box2 = true;
                    }

                    else
                    {
                        box1 = true;
                    }
                }

                if(hit.collider.gameObject.name.Equals("Dumpster_body"))
                {
                    Debug.Log("Dumpster");
                    
                    if(trash)
                    {
                        trashPrefab.SetActive(true);

                        Instantiate(trashPrefab, new Vector3(31.4f,17.8f,-83.3f), Quaternion.identity);
                    }
                    // if trash is true, instantiate bag into dumpster
                    // set trash to false
                    // set trashout to true
                }

                if(hit.collider.gameObject.name.Equals("Valve"))
                {
                    Debug.Log("Valve");

                    valve = true;

                    // instantiate valve

                    Destroy(hit.collider.gameObject);

                    // valve is in inventory
                }

                if(hit.collider.gameObject.name.Equals("Machine"))
                {
                    Debug.Log("Machine");

                    if(valve)
                    {

                    }
                    // if valve is true, instantiate valve handle onto machine
                    // set valve to false
                    // set valveplaced to true
                }

                if(hit.collider.gameObject.name.Equals("Cone"))
                {
                    Debug.Log("Cone");
                    
                    cone = true;
                    
                    // Instantiate cone
                    
                    Destroy(hit.collider.gameObject);

                    // cone is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("Electric"))
                {
                    Debug.Log("Electric");
                    
                    if(cone)
                    {

                    }
                    // if cone is true, instantiate cone on ground
                    // set cone to false
                    // set coneplaced to true
                }

                if(hit.collider.gameObject.name.Equals("ExitCriteria"))
                {
                    Debug.Log("ExitCriteria");
                    
                    if(box1 && box2 && valvePlaced && conePlaced && trashOut)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    
                    // you can leave now
                }
            }
        }

    }

    /*
    void OnLeftClick()
    {
        if(itemEquipped == false)
        {
            PickUpItem();
        }

        if(itemEquipped)
        {
            UseItem();
        }
    }

    void PickUpItem()
    {
        Ray ray;

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.tag)
        }
        
    }

    void UseItem()
    {
        
        if(crowbar)
        {

        }

        else if(cone)
        {

        }

        else if(valve)
        {

        }

        else if(trash)
        {

        }
        
    }

    void DropItem()
    {
        if(itemEquipped)
        {

        }
    }

*/
}

