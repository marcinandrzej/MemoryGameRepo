using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScriptGM : MonoBehaviour
{
    private const int size = 4;
    private int pairCount;

    private int[,] puzzleTable;

    private IGameStates gameState;

    private GameObject firstClicked;
    private int firstClickedIndex;

    private GameObject secondClicked;
    private int secondClickedIndex;
    // Use this for initialization
    void Start ()
    {
        pairCount = 0;
        SetPuzzleTable();
        ChangeState(new IFirstClickState());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool IsEnd()
    {
        if (pairCount >= size*size/2)
            return true;
        return false;
    }

    public int GetSize()
    {
        return size;
    }

    public void SetPuzzleTable()
    {
        //number of images types
        int numberOfIndexes = size * size / 2;

        //list helping in setting puzzle table
        List<int> indexList = new List<int>();
        for (int i = 0; i < numberOfIndexes; i++)
        {
            indexList.Add(i);
            indexList.Add(i);
        }

        //puzzle table setting
        puzzleTable = new int[size, size];        
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                int index = Random.Range(0, indexList.Count);
                int value = indexList[index];
                puzzleTable[x, y] = value;
                indexList.RemoveAt(index);
            }
        }
    }

    public int GetTableValue(int x, int y)
    {
        return puzzleTable[x, y];
    }

    public void SetFirstClicked(GameObject button, int index)
    {
        firstClicked = button;
        firstClickedIndex = index;
    }

    public void SetSecondClicked(GameObject button, int index)
    {
        secondClicked = button;
        secondClickedIndex = index;
    }

    public GameObject GetFirstClicked()
    {
        return firstClicked;
    }

    public int GetFirstClickedIndex()
    {
        return firstClickedIndex;
    }

    public GameObject GetSecondClicked()
    {
        return secondClicked;
    }

    public int GetSecondClickedIndex()
    {
        return secondClickedIndex;
    }

    public void ButtonClicked(GameObject button, int x, int y)
    {
        gameState.ExecuteState(button, x, y);
    }

    public void ChangeState(IGameStates gs)
    {
        gameState = gs;
        gs.OnStateEnter(transform.gameObject);
    }

    public void Check(GuiScriptGM gui)
    {
        StartCoroutine(CheckTime(gui));
    }

    private IEnumerator CheckTime(GuiScriptGM gui)
    {
        yield return new WaitForSeconds(1.0f);

        if (firstClickedIndex == secondClickedIndex)
        {
            gui.DeleteFromGui(firstClicked);
            gui.DeleteFromGui(secondClicked);
            pairCount++;
        }
        else
        {
            gui.Hide(firstClicked);
            gui.Hide(secondClicked);
        }

        if (!IsEnd())
        {
            ChangeState(new IFirstClickState());
        }
        else
        {
            gui.End();
        }
    }
}
