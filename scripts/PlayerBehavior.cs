using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    public float JumpVelocity = 5f;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;

    private PlayerInfo playerInfo;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private bool _isJumping;


    void Start()
    {
        playerInfo = this.GetComponent<PlayerInfo>();
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        _isJumping |= Input.GetKeyDown(KeyCode.J);
        
        if(playerInfo.health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        /*
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        // 6
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */        
        
    }

    void FixedUpdate()
    {

        float _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        float _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        // forward movement
        _rb.MovePosition (this.transform.position
                    + this.transform.forward * _vInput * Time.fixedDeltaTime);

        // rotational movement
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler (rotation * Time.fixedDeltaTime);
        _rb.MoveRotation (_rb.rotation * angleRot);


        
        // keeps player from falling through Terrain when moving fast
        if (Terrain.activeTerrain)
        {
            float naturalYDistance = Terrain.activeTerrain.transform.position.y;
            float playerPositionCalculatedY = this.transform.position.y
                    - Terrain.activeTerrain.SampleHeight(this.transform.position);

            if (playerPositionCalculatedY < naturalYDistance)
            {
                float pushHeight = naturalYDistance - playerPositionCalculatedY;
                _rb.MovePosition (this.transform.position + Vector3.up * pushHeight);
            }            
        }
        

        // jumping
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }

        _isJumping = false;

        
    }

    public bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3 (_col.bounds.center.x,
                    _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule (_col.bounds.center,
                    capsuleBottom, DistanceToGround, GroundLayer,
                    QueryTriggerInteraction.Ignore);

        return grounded;
    }

}
