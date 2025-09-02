using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompletion : MonoBehaviour
{
    public List<PuzzleCube> CubeList;

    private void Start()
    {
        CubeList.AddRange(FindObjectsOfType<PuzzleCube>());
    }

    public void CheckForCompletion()
    {
        int totalCubes = CubeList.Count;
        int correctCubes = 0;

        foreach (PuzzleCube cube in CubeList)
        {
            if (cube.IsCorrectColor)
            {
                correctCubes++;
            }    
        }

        if (correctCubes == totalCubes)
        {
            VictoryScreen();
        }
        else
        {
            IncorrectScreen();
        }
    }

    private void VictoryScreen()
    {

    }

    private void IncorrectScreen()
    {

    }
}
