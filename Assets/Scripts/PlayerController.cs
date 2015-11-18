using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    #region SCENE REFERENCES
    
    public Transform Block1;
    public Transform Block2;
    public Transform Block3;
    public Transform Block4;
    public Rigidbody PlayerRigidbody;

    #endregion

    public float Force = 5;

    private float[] RotationTable = new float[]{ 0, 90, 180, 270 };

    private int FirstBlockRotationIndex = 0;
    private int SecondBlockRotationIndex = 0;
    private int ThirdBlockRotationIndex = 0;
    private int FourthBlockRotationIndex = 0;

    private void Start () 
    {
        StartCoroutine(aaaa());
	}

    private IEnumerator aaaa()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

        }
    }
	
    private void FixedUpdate()
    {

    }

	private void Update () 
    {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            PlayerRigidbody.AddForce(0, Force, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            PlayerRigidbody.AddForce(0, - Force, 0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            RotateBlock(ref FirstBlockRotationIndex, Block1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RotateBlock(ref SecondBlockRotationIndex, Block2, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RotateBlock(ref ThirdBlockRotationIndex, Block3, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RotateBlock(ref FourthBlockRotationIndex, Block4);
        }
	}

    private void RotateBlock(ref int index, Transform block, bool thirdPositionIsForbidden = false)
    {
        index++;
        index = index == 2 && thirdPositionIsForbidden ? index + 1 : index;
        index = index >= RotationTable.Length ? 0 : index;
        block.localRotation = Quaternion.Euler(new Vector3(0, 0, RotationTable[index]));
    }
}
