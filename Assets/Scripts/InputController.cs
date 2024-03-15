using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilding;

public class InputController : MonoBehaviour
{
    [SerializeField]
    RunLines lines;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            lines.SwitchLine(Direction.Left);

        if (Input.GetKey(KeyCode.RightArrow))
            lines.SwitchLine(Direction.Right);
    }
}
