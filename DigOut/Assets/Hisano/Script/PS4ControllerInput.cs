using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4ControllerInput : MonoBehaviour
{
    [System.Serializable]


    public struct ContorollerState
    {
        //十字キー、スティック
        public bool leftWalk;
        public bool rightWalk;
        public bool upButton;
        public bool downButton;
        public bool lSticLeft;
        public bool lSticRight;
        public bool lSticUp;
        public bool lSticDown;
        //×〇□△ボタン
        public bool Jump;
        public bool Circle;
        public bool Square;
        public bool Triangle;
        //単押し
        public bool singleCircle;
        public bool singleOptions;
        public bool singleSquare;
        public bool singleTriangle;
        public bool singleJump;


        public bool singleLeft;
        public bool singleRight;
        public bool singleDown;
        public bool singleUp;
        public bool singleLSticLeft;
        public bool singleLSticRight;
        public bool singleLSticUp;
        public bool singleLSticDown;


        public void reset()
        {
            leftWalk = false;
            rightWalk = false;
            upButton = false;
            downButton = false;
            lSticLeft = false;
            lSticRight = false;
            lSticUp = false;
            lSticDown = false;

            Jump = false;
            Circle = false;
            Square = false;
            Triangle = false;

            singleCircle = false;
            singleOptions = false;
            singleSquare = false;
            singleTriangle = false;
            singleJump = false;

            singleLeft = false;
            singleRight = false;
            singleUp = false;
            singleDown = false;
            singleLSticLeft = false;
            singleLSticRight = false;
            singleLSticUp = false;
            singleLSticDown = false;
        }
    }

    public ContorollerState contorollerState;
    float Padx;
    float Pady;
    float lSticX;
    float lSticY;
    bool oldLeft;
    bool oldRight;
    bool oldDown;
    bool oldUp;
    bool oldLSticLeft;
    bool oldLSticRight;
    bool oldLSticUp;
    bool oldLSticDown;

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
            lSticX = Input.GetAxis("LsticX");
            lSticY = Input.GetAxis("LsticY");
            
            contorollerState.rightWalk = Padx > 0.9f;
            contorollerState.leftWalk = Padx < -0.9f;
            contorollerState.upButton = Pady > 0.9f;
            contorollerState.downButton = Pady < -0.9f;
            contorollerState.lSticRight = lSticX > 0.9f;
            contorollerState.lSticLeft = lSticX < -0.9f;
            contorollerState.lSticUp = lSticY > 0.9f;
            contorollerState.lSticDown = lSticY < -0.9f;

            contorollerState.singleLeft = oldLeft == false && contorollerState.leftWalk == true;
            contorollerState.singleRight = oldRight == false && contorollerState.rightWalk == true;
            contorollerState.singleDown = oldDown == false && contorollerState.downButton == true;
            contorollerState.singleUp = oldUp == false && contorollerState.upButton == true;
            contorollerState.singleLSticLeft = oldLSticLeft == false && contorollerState.lSticLeft == true;
            contorollerState.singleLSticRight = oldLSticRight == false && contorollerState.lSticRight == true;
            contorollerState.singleLSticUp = oldLSticUp == false && contorollerState.lSticUp == true;
            contorollerState.singleLSticDown = oldLSticDown == false && contorollerState.lSticDown == true;

            contorollerState.Jump = Input.GetButton("Cross");
            contorollerState.Circle = Input.GetButton("Circle");
            contorollerState.Square = Input.GetButton("Square");
            contorollerState.Triangle = Input.GetButton("Triangle");

            contorollerState.singleJump = Input.GetButtonDown("Cross");
            contorollerState.singleCircle = Input.GetButtonDown("Circle");
            contorollerState.singleSquare = Input.GetButtonDown("Square");
            contorollerState.singleTriangle = Input.GetButtonDown("Triangle");
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
            contorollerState.Square = Input.GetKey(KeyCode.X);
            contorollerState.Triangle = Input.GetKey(KeyCode.C);

            contorollerState.singleJump = Input.GetKeyDown(KeyCode.Space);
            contorollerState.singleCircle = Input.GetKeyDown(KeyCode.Z);
            contorollerState.singleSquare = Input.GetKeyDown(KeyCode.X);
            contorollerState.singleTriangle = Input.GetKeyDown(KeyCode.C);
            contorollerState.singleOptions = Input.GetKeyDown(KeyCode.Q);

        }

        //Debug.Log(contorollerState.singleLeft);

        oldDown = contorollerState.downButton;
        oldLeft = contorollerState.leftWalk;
        oldRight = contorollerState.rightWalk;
        oldUp = contorollerState.upButton;
        oldLSticLeft = contorollerState.lSticLeft;
        oldLSticRight = contorollerState.lSticRight;
        oldLSticUp = contorollerState.lSticUp;
        oldLSticDown = contorollerState.lSticDown;
    }
}
