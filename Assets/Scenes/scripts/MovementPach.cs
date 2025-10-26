using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPach : MonoBehaviour
{
    public enum PatchTypes
    {
        linear,
        loop
    }

    public PatchTypes pathType;
    public int movmnetDirection = 1;
    public int moveingTo = 0;
    public Transform[] PatchElements;

    public void OnDrawGizmos() 
    {
        if (PatchElements == null || PatchElements.Length < 2) {
            return;
        }

        for(var i = 1; i < PatchElements.Length; i++)
        {
            Gizmos.DrawLine(PatchElements[i - 1].position, PatchElements[i].position);

        }

        if(pathType == PatchTypes.loop)
        {
            Gizmos.DrawLine(PatchElements[0].position, PatchElements[PatchElements.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetnextPatcPoint()
    {
        if (PatchElements == null || PatchElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PatchElements[moveingTo];

            if (PatchElements.Length == 1)
            {
                continue;
            }

            if(pathType == PatchTypes.linear)
            {
                if (moveingTo <= 0)
                {
                    movmnetDirection = 1;
                }
                else if(moveingTo >= PatchElements.Length - 1)
                {
                    movmnetDirection = -1;
                }
            }

            moveingTo = moveingTo + movmnetDirection;

            if(pathType == PatchTypes.loop)
            {
                if(moveingTo >= PatchElements.Length)
                {
                    moveingTo = 0;
                }

                if(moveingTo < 0)
                {
                    moveingTo = PatchElements.Length - 1;
                }
            }

        }
    }

    public int getMovmentTo()
    {
        return moveingTo;
    }
}
