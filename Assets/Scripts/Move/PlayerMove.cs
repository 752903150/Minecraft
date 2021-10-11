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

    public MediaSystem mediaSystem;//�н���ϵͳ

    public MapManagerSystem mapManagerSystem;//��ͼ����ϵͳ��ǿ���

    float GravityRet = 1;//����Ӱ�����
    /*public GameObject Head;
    public GameObject Head;
    public GameObject Head;*/


    void Start()
    {
        controller = GetComponent<CharacterController>();
        //mediaSystem.SetCursorVisible(false);
        //mediaSystem.SetCursorLock(CursorLockMode.Locked);
    }
    void Update()
    { 
        /*�˶�ģ��*/
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


        /*���ģ��*/
        if (Input.GetMouseButtonDown(0))
        //���룺������ 0���������� 1���Ҽ� 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Ray ���� ������������ͬ
            RaycastHit hit;
            //����һ��list 
            if (Physics.Raycast(ray, out hit))
            {
                GameObject temp = hit.collider.gameObject;
                Vector3 position = temp.transform.localPosition;
                Vector3 parentPosition = temp.transform.parent.localPosition;
                //Debug.Log(position);
                //Debug.Log(position.x + " " + position.z + " " + position.y);
                //Debug.Log((int)position.x+" "+ (int)position.z+" "+(int)position.y);

                EventManagerSystem.Instance.Invoke<Vector3, GameObject>(
                    "�ƻ�����",
                    new Vector3(position.x + parentPosition.x , position.y , position.z + parentPosition.z), 
                    temp);
            }
        }


        /*��������*/
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
        float forward = Input.GetAxis("Mouse X");//����
        float rotation = Input.GetAxis("Mouse Y");//����
        cameraDirection.x -= rotation;
        cameraDirection.x = Mathf.Clamp(cameraDirection.x, -60, 60);
        bodyDirection.y += forward;
        Body.localRotation = Quaternion.Euler(bodyDirection);
        Head.localRotation = Quaternion.Euler(cameraDirection);
    }

}