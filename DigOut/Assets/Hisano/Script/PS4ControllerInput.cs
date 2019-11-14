using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4ControllerInput : MonoBehaviour
{
    [System.Serializable]


    public struct ContorollerState
    {
        public bool leftWalk;
        public bool rightWalk;
        public bool Jump;
<<<<<<< HEAD
=======
        public bool Circle;
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd
        public void reset()
        {
            leftWalk = false;
            rightWalk = false;
            Jump = false;
<<<<<<< HEAD
=======
            Circle = false;
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd
        }
    }

    public ContorollerState contorollerState;
    float Padx;

    static public PS4ControllerInput pS4ControllerInput;

<<<<<<< HEAD
=======
    [SerializeField]
    bool ControllerOn;

>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd
    private void Awake()
    {
        if (pS4ControllerInput == null)
        {
            contorollerState.reset();
            pS4ControllerInput = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Padx = Input.GetAxis("DpadLR");

        contorollerState.rightWalk = Padx > 0.9;
        contorollerState.leftWalk = Padx < -0.9f;
        contorollerState.Jump = Input.GetButton("Fire2");
=======
        if (ControllerOn) {
            Padx = Input.GetAxis("DpadLR");

            contorollerState.rightWalk = Padx > 0.9;
            contorollerState.leftWalk = Padx < -0.9f;
            contorollerState.Jump = Input.GetButton("Fire2");
            contorollerState.Circle = Input.GetButton("Circle");
        }
        else {
            contorollerState.rightWalk = Input.GetKey(KeyCode.RightArrow);
            contorollerState.leftWalk  = Input.GetKey(KeyCode.LeftArrow );
            contorollerState.Jump = Input.GetKey(KeyCode.Space);
        }
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd


    }
}
