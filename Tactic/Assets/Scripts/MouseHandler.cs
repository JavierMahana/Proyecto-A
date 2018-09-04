using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour {

    public Tile mouseTile { get; private set; }

    private void Update()
    {
        AsignTheMouseTile();  
    }
   
    void AsignTheMouseTile()
        //using the get tile method, we can acces to a tile by giving it his x and y coordinates
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            mouseTile = hit.transform.GetComponent<Map>().GetTile(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
            Debug.Log(mouseTile.terrain_.ToString());
        }
    }

}
