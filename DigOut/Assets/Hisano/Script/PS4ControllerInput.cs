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
        public bool upButton;
        public bool downButton;

        public bool Jump;
        public bool Circle;

        public bool singleCircle;
        public bool singleOptions;

        public bool singleLeft;
        public bool singleRight;
        public bool singleDown;
        public bool singleUp;


        public void reset()
        {
            leftWalk = false;
            rightWalk = false;
            upButton = false;
            downButton = false;

            Jump = false;
            Circle = false;

            singleCircle = false;
            singleOptions = false;

            singleLeft = false;
            singleRight = false;
            singleUp = false;
            singleDown = false;
        }
    }

    public ContorollerState contorollerState;
    float Padx;
    float Pady;
    bool oldLeft;
    bool oldRight;
    bool oldDown;
    bool oldUp;

    static public PS4ControllerInput pS4ControllerInput;

    [SerializeField]
    bool ControllerOn;

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
        if (ControllerOn) {
            Padx = Input.GetAxis("DpadLR");
            Pady = Input.GetAxis("DpadUD");
            
            contorollerState.rightWalk = Padx > 0.9f;
            contorollerState.leftWalk = Padx < -0.9f;
            contorollerState.upButton = Pady > 0.9f;
            contorollerState.downButton = Pady < -0.9f;

            contorollerState.singleLeft = oldLeft == false && contorollerState.leftWalk == true;
            contorollerState.singleRight = oldRight == false && contorollerState.rightWalk == true;
            contorollerState.singleDown = oldDown == false && contorollerState.downButton == true;
            contorollerState.singleUp = oldUp == false && contorollerState.upButton == true;

            contorollerState.Jump = Input.GetButton("Cross");
            contorollerState.Circle = Input.GetButton("Circle");

            contorollerState.singleCircle = Input.GetButtonDown("Circle");
            contorollerState.singleOptions = Input.GetButtonDown("Options");
        }
        else {
            contorollerState.rightWalk = Input.GetKey(KeyCode.RightArrow);
            contorollerState.leftWalk  = Input.GetKey(KeyCode.LeftArrow );
            contorollerState.upButton = Input.GetKey(KeyCode.UpArrow);
            contorollerState.downButton = Input.GetKey(KeyCode.DownArrow);

            contorollerState.singleLeft = Input.GetKeyDown(KeyCode.LeftArrow);
            contorollerState.singleRight = Input.GetKeyDown(KeyCode.RightArrow);
            contorollerState.singleDown = Input.GetKeyDown(KeyCode.DownArrow);
            contorollerState.singleUp = Input.GetKeyDown(KeyCode.UpArrow);

            contorollerState.Jump = Input.GetKey(KeyCode.Space);
            contorollerState.Circle = Input.GetKey(KeyCode.Z);

            contorollerState.singleCircle = Input.GetKeyDown(KeyCode.Z);
            contorollerState.singleOptions = Input.GetKeyDown(KeyCode.Q);

        }

        //Debug.Log(contorollerState.singleLeft);

        oldDown = contorollerState.downButton;
        oldLeft = contorollerState.leftWalk;
        oldRight = contorollerState.rightWalk;
        oldUp = contorollerState.upButton;
    }
}
