using UnityEngine;

public class HookMovementScripts : MonoBehaviour{

    public float min_Z = -55f, max_Z = 55f;
    public float rotate_Speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;

    public float move_Speed = 3f;
    private float inital_Move_Speed;
    
    private float min_Y = -2.5f;
    private float initial_Y;

    private bool moveDown;

    private RopeRenderer ropeRenderer;

    void Awake(){
        ropeRenderer = GetComponent<RopeRenderer>();
    }


    void Start(){
        initial_Y = transform.position.y;
        inital_Move_Speed = move_Speed;

        canRotate = true;
    }

    void Update(){
        Rotate();
        GetInput();
        moveRope();
    }
    void Rotate(){
        if(!canRotate){
            return;
        }
        if(rotate_Right){
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }else{
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if(rotate_Angle >= max_Z){
            rotate_Right = false;
        }else if(rotate_Angle <= min_Z){
            rotate_Right = true;
        }
    }

    void GetInput(){
        if(Input.GetMouseButtonDown(0)){
           if(canRotate){
               canRotate = false;
               moveDown = true;
           }
        }
    }

    void moveRope(){
        if(canRotate){
            return;
        }
        if(!canRotate){
            Vector3 temp = transform.position;
            if(moveDown){
                temp  -= transform.up * Time.deltaTime * move_Speed;
            }else{
                temp += transform.up * Time.deltaTime * move_Speed;
            }

            transform.position = temp;
            if(temp.y <= min_Y){
                moveDown = false;
            }
            if(temp.y >= initial_Y){
                canRotate = true;
                ropeRenderer.RenderLine(temp, false);
                move_Speed = inital_Move_Speed;

            }

            ropeRenderer.RenderLine(temp, true);
            
            
        }
    }
}


