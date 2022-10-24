using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputController : BasePlayerController
{
    private void FixedUpdate()
    {

        SideMove(Input.GetAxis("Horizontal"));
        SideMove(Input.GetAxis("Vertical"));
        if (Input.GetAxis("Jump") == 1) Jump();
    }

}
