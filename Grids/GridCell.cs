using System;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    [SerializeField] private int amountClicked;
    [SerializeField] private Vector3 coordinates;

    [SerializeField] private bool isTraversible;
    [SerializeField] private List<GameObject> content;

    private void Awake()
    {
        amountClicked = 0;
        if (content == null) content = new List<GameObject>();
    }

    private void OnMouseDown()
    {
        Debug.Log($"I have been clicked!!!!!!!! I have been clicked {++amountClicked} times");
        Debug.Log($"I am at {coordinates}");
    }


    public int AmountClicked
    {
        get => amountClicked;
        set => amountClicked = value;
    }

    public Vector3 Coordinates
    {
        get => coordinates;
        set => coordinates = value;
    }
}
