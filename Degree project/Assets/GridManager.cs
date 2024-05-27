using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    
    //[SerializeField] private Transform cubes;

    [SerializeField] private RectTransform panelColumn;
    [SerializeField] private GameObject refPosition;
    [SerializeField] private GameObject cell;
    [SerializeField] private Transform board;

    [SerializeField]private int rowSize;
    [SerializeField]private int columnSize;

    private void Awake()
    {
        CreateBoard();
    }
    

    void ClearBoard()
    {
        for (int i = 0; i < board.childCount; i++)
        {
            Destroy(board.GetChild(i).gameObject);
        }
    }

    void CreateBoard()
    {
        RectTransform colParent;
        
        ClearBoard();

        for (int i = 0; i < columnSize; i++)
        {
            colParent = Instantiate(panelColumn, board);

            for (int j = 0; j < rowSize; j++)
            {
                var position = Instantiate(refPosition, colParent);
                var spawnObject = Instantiate(cell,board);
                spawnObject.GetComponent<RectTransform>().position = position.GetComponent<RectTransform>().position;
                
            }
        }
    }
}
