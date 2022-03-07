using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    private Movement playerMovement;
    private Rotation playerRotation;
    private bool isOnGround=false;
    private GameObject leftWeapon;
    private GameObject rightWeapon;
    private GameObject accesory;
    private GameObject leftWeaponMuzzle;
    private GameObject rightWeaponMuzzle;
    
    [Header("Player Value")] 
    [SerializeField] float playerSpeed = 0.01f;
    [SerializeField] float mouseSpeed = 10f;
    [SerializeField] Animator playerAnimator;
    //[SerializeField] Animator gunAnimator;
    [SerializeField] GameObject verticalRotation;
    [SerializeField] GameObject horizontalRotation;

    private void Start()
    {
        if(PlayerBuild.GetWeaponLeft())
        leftWeapon = PlayerBuild.GetWeaponLeft();
        if (PlayerBuild.GetWeaponRight() != null)
            rightWeapon = PlayerBuild.GetWeaponRight();
        accesory = PlayerBuild.GetAccesories();
        //leftWeaponMuzzle = PlayerBuild.GetWeaponLeft() != null ? PlayerBuild.GetWeaponLeft().GetComponent<IWeapon>().WeaponMuzzle() : PlayerBuild.GetArm().GetComponent<IWeapon>().WeaponMuzzle();
        //rightWeaponMuzzle = PlayerBuild.GetWeaponRight() != null ? PlayerBuild.GetWeaponRight().GetComponent<IWeapon>().WeaponMuzzle() : PlayerBuild.GetArm().GetComponent<IWeapon>().WeaponMuzzle();
        playerMovement = ScriptableObject.CreateInstance<Movement>();
        playerRotation = ScriptableObject.CreateInstance<Rotation>();
        
    }
    IEnumerator UseAccesory()
    {
        //accesory.GetComponent<IAccesories>().UseSuperPower();
        yield return null;
    }
    IEnumerator ShootLeftWeapeon()
    {
        //leftWeapon.GetComponent<IWeapon>().Shoot(leftWeaponMuzzle);
        //gunAnimator.SetBool("Shoot", true);
        yield return null;
    }
    IEnumerator ShootRightWeapeon()
    {
        //rightWeapon.GetComponent<IWeapon>().Shoot(rightWeaponMuzzle);
        //gunAnimator.SetBool("Shoot", true);
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement.ActorMovement(this.gameObject, horizontalRotation.transform.rotation, Camera.main, playerSpeed, playerAnimator, isOnGround);
        playerRotation.PlayerRotation(verticalRotation, horizontalRotation, Camera.main, mouseSpeed);
      //  playerRotation.WeaponRotation(leftWeapon, rightWeapon, Camera.main);   //Naprawiæ
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(ShootLeftWeapeon());
            if (Input.GetKey(KeyCode.Mouse1))
            {
                StartCoroutine(ShootRightWeapeon());
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            StartCoroutine(ShootRightWeapeon());
            if (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(ShootLeftWeapeon());
            }
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            StartCoroutine(UseAccesory());
        }

    }
    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 20, 110, QueryTriggerInteraction.Ignore);//ground detect settings

    }


}
