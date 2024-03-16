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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            lines.SwitchLine(Direction.Left);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            lines.SwitchLine(Direction.Right);
    }
}
