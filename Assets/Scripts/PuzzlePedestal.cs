using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PuzzlePedestal : MonoBehaviour
{
    public ColorStates pedestalColor;
    private XRSocketInteractor socketInteractor;

    private void Start()
    {
        if (GetComponentInChildren<XRSocketInteractor>() != null)
        {
            socketInteractor = GetComponentInChildren<XRSocketInteractor>();
        }
        else
        {
            Debug.LogError("No Socket Interactors found in pedestal");
        }
    }

    public void CheckIfCorrectColor()
    {
        var interactable = socketInteractor.firstInteractableSelected;
        
        if (interactable.transform.gameObject.TryGetComponent<PuzzleCube>(out var cube))
        {
            if (cube.cubeColor == pedestalColor)
            {
                cube.IsCorrectColor = true;
                Debug.Log("cube color is correct");
            }
        }
    }
}
