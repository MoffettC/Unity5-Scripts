using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private BeehiveDisplay beehiveDisplay;
    private GameObject parent;
    private GameObject[] defendersOnField;

	// Use this for initialization
	void Start () {
        //Looks for name of class/GameObject
        parent = GameObject.Find("Defenders"); 
        //Looks for gameObject* or component of GameObject, stronger
        beehiveDisplay = GameObject.FindObjectOfType<BeehiveDisplay>(); 
        if (!parent) {
            parent = new GameObject("Defenders");
        }
    }

	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown() {
        //print(SnapToGrid(CalculateWorldPointMouse()));  
        GameObject defender = Button.selectedDefender;

        //Spawn Defender if enough stars are owned
        int defenderCost = defender.GetComponent<Defender>().honeyCost;
        if (beehiveDisplay.UseStars(defenderCost) == BeehiveDisplay.Status.SUCCESS) {
            GameObject newDef = Instantiate(defender, SnapToGrid(CalculateWorldPointMouse()),
                                                    Quaternion.identity) as GameObject;
            //Debug.Log("y pos " + newDef.transform.position.y);
            //newDef.transform.parent = parent.transform; Deprecated?
            newDef.transform.SetParent(parent.transform);
        } else {
            Debug.Log("Not enough stars");
        }
       
    }

    Vector2 SnapToGrid (Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointMouse() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weird = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weird);

        return worldPos;
    }

}
