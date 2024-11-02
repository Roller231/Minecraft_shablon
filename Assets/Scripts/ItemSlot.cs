using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int indexSlot;


    private Building buildingReference;

    private void Awake()
    {
        buildingReference = FindObjectOfType<Building>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buildingReference.SelectCube(indexSlot);
    }
}
