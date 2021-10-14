using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 2.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 cameraDirection = Vector3.zero;
    private Vector3 bodyDirection = Vector3.zero;
    CharacterController controller;

    public Transform Head;
    public Transform Body;

    public MediaSystem mediaSystem;//中介者系统

    public MapManagerSystem mapManagerSystem;//地图管理系统，强相关

    float GravityRet = 1;//重力影响比率

    PlayerAnimation playerAnimation;//角色动画控制器
    EAnimation CurrAnimation = EAnimation.STOP;//当前动画
    EAnimation TargetAnimation = EAnimation.STOP;//目标动画
    bool isAnimationChange = false;//动画状态是否改变

    bool isBrokingCube = false;//是否正在破坏方块
    /*public GameObject Head;
    public GameObject Head;
    public GameObject Head;*/


    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimation.SetAnimator(GetComponent<Animator>());
        //mediaSystem.SetCursorVisible(false);
        //mediaSystem.SetCursorLock(CursorLockMode.Locked);
    }
    void Update()
    {
        TargetAnimation = EAnimation.STOP;
        /*运动模块*/
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.x += Input.GetAxis("Horizontal") * Time.deltaTime;
            moveDirection.z += Input.GetAxis("Vertical") * Time.deltaTime;
            //Debug.Log(moveDirection.x+" "+ moveDirection.z);
            moveDirection.x = Mathf.Clamp(moveDirection.x, -speed, speed);
            moveDirection.z = Mathf.Clamp(moveDirection.z, -speed, speed);
            //moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime * GravityRet;
        controller.Move(moveDirection * Time.deltaTime);
        if(moveDirection.x!=0f&&moveDirection.z!=0)
        {
            //playerAnimation.SetAnimation(CurrAnimation,EAnimation.MOVE);
            TargetAnimation = EAnimation.MOVE;
            //if(TargetAnimation==CurrAnimation)
            //CurrAnimation = EAnimation.MOVE;
        }


        /*点击模块*/
        if (Input.GetMouseButtonDown(0))
        //输入：点击鼠标 0代表鼠标左键 1是右键 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray 是类 相机和鼠标点击相同
            RaycastHit hit;
            //就有一个list 
            if (Physics.Raycast(ray, out hit))
            {
                GameObject temp = hit.collider.gameObject;
                Vector3 position = temp.transform.localPosition;
                Vector3 parentPosition = temp.transform.parent.localPosition;
                EventManagerSystem.Instance.Invoke<Vector3, GameObject>(
                    "破坏方块",
                    new Vector3(position.x + parentPosition.x , position.y , position.z + parentPosition.z), 
                    temp);
            }
        }


        /*背包功能*/
        if(Input.GetKeyDown(KeyCode.E))
        {

        }

        
    }

    public void SetGravity(float ret)
    {
        GravityRet = ret;
    }

    private void LateUpdate()
    {
        float forward = Input.GetAxis("Mouse X");//左右
        float rotation = Input.GetAxis("Mouse Y");//上下
        cameraDirection.x -= rotation;
        cameraDirection.x = Mathf.Clamp(cameraDirection.x, -60, 60);
        bodyDirection.y += forward;
        Body.localRotation = Quaternion.Euler(bodyDirection);
        Head.localRotation = Quaternion.Euler(cameraDirection);
    }

}