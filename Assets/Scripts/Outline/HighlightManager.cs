using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightManager : MonoBehaviour
{
    private Transform highlightedObj;
    private Transform selectedObj;
    public LayerMask selectableLayer;

    private Outline highlightOutline;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Update()
    {
        HoverHighlight();
    }

    // Update is called once per frame
    void HoverHighlight()
    {
        if (highlightedObj != null)
        {
            highlightOutline.enabled = false;
            highlightedObj = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit, selectableLayer))
        {
            highlightedObj = hit.transform;

            if (highlightedObj.CompareTag("Enemy") && highlightedObj != selectedObj)
            {
                highlightOutline = highlightedObj.GetComponent<Outline>();
                highlightOutline.enabled = true;
            }

            else if(highlightedObj.CompareTag("Items") && highlightedObj != selectedObj)
            {
                highlightOutline = highlightedObj.GetComponent<Outline>();
                highlightOutline.enabled = true;
            }
            else
            {
                highlightedObj = null;
            }
        }
    }

    public void SelectedHighlight()
    {
        if (highlightedObj != null && highlightedObj.CompareTag("Enemy") && highlightedObj != selectedObj)
        {
            if (selectedObj != null)
            {
                selectedObj.GetComponent<Outline>().enabled = false;
            }

            selectedObj = hit.transform;
            selectedObj.GetComponent<Outline>().enabled = true;

            highlightOutline.enabled = true;
            highlightedObj = null;
        }

        if (highlightedObj != null && highlightedObj.CompareTag("Items") && highlightedObj != selectedObj)
        {
            if (selectedObj != null)
            {
                selectedObj.GetComponent<Outline>().enabled = false;
            }

            selectedObj = hit.transform;
            selectedObj.GetComponent<Outline>().enabled = true;

            highlightOutline.enabled = true;
            highlightedObj = null;
        }
    }

    public void DeselectHighlight()
    {
        selectedObj.GetComponent<Outline>().enabled = false;
        selectedObj = null;
    }
}
