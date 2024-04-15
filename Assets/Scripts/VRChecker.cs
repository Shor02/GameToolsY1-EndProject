using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRChecker : MonoBehaviour
{
    public bool VRBool;
    public Transform VRWorldPosition;
    public TeleportManager TeleportManager;
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VRBool = true;
            TeleportManager.warpTarget.position = VRWorldPosition.position;
            Debug.Log("EnteredVR");
        }
    }
    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
       //     VRBool = false;
       //     UpdatePosition();
         //   Debug.Log("WHOOLYPOLLY");
       // }
   // }

    //private void //Start()
    //{
       // VRBool = false;
  //  }

   // private IEnumerator UpdatePosition()
  //  {
        //while (VRBool)
      //  {
          //  VRWorldPosition = TeleportManager.warpTarget.position;
          //  yield return new WaitForSeconds(0.5f);
     //   }
   // }
}
