using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

    private Character m_Character;
    private bool m_Jump;
    private bool crouch;
    private bool moveQ, moveE, moveS;




    private void Awake()
    {
        m_Character = GetComponent<Character>();
        crouch = false;
    }


    private void Update()
    {
        // Read the jump input in Update so button presses aren't missed.
        m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = !crouch;
        }
        moveQ = Input.GetButtonDown("Q");
        moveE = Input.GetButtonDown("E");
        moveS = Input.GetButtonDown("S");


    }


    private void FixedUpdate()
    {

        // Read the inputs.

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump, moveQ, moveE, moveS);
        m_Jump = false;
    }
}
