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
                    // Set trash to true
                    // Destroy trash bag
                    // trash bag is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("SmWoodBox"))
                {
                    Debug.Log("SmWoodBox");
                    // Check if crowbar is true
                    // if crowbar is true, destroy smwoodbox
                    // set box1 to true
                }

                if(hit.collider.gameObject.name.Equals("TallWoodBox"))
                {
                    Debug.Log("TallWoodBox");
                    // Check if crowbar is true
                    // if crowbar is true, destroy tallwoodbox
                    // set box2 to true
                }

                if(hit.collider.gameObject.name.Equals("Dumpster_body"))
                {
                    Debug.Log("Dumpster");
                    // Check if trash is true
                    // if trash is true, instantiate bag into dumpster
                    // set trash to false
                    // set trashout to true
                }

                if(hit.collider.gameObject.name.Equals("Machine"))
                {
                    Debug.Log("Machine");
                    // check if valve is true
                    // if valve is true, instantiate valve handle onto machine
                    // set valve to false
                    // set valveplaced to true
                }

                if(hit.collider.gameObject.name.Equals("Cone"))
                {
                    Debug.Log("Cone");
                    // set cone to true
                    // destroy cone
                    // cone is now in inventory
                }

                if(hit.collider.gameObject.name.Equals("Electric"))
                {
                    Debug.Log("Electric");
                    // check if cone is true
                    // if cone is true, instantiate cone on ground
                    // set cone to false
                    // set coneplaced to true
                }

                if(hit.collider.gameObject.name.Equals("ExitCriteria"))
                {
                    Debug.Log("ExitCriteria");
                    // check if box1, box2, valveplaced, coneplaced, and trashout are all true
                    // if all are true, destroy exit barrier
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

