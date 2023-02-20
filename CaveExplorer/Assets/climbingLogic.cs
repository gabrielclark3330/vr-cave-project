using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem
{
    public class climbingLogic : MonoBehaviour
    {
        public Transform playerLAxeTransform;
        public Transform playerRAxeTransform;
        private Vector3 pickaxeOnCollidePosition;
        private Vector3 playerOnCollidePosition;
        public ClimberHand RightHand;
        public ClimberHand LeftHand;

        public SteamVR_Action_Boolean teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
        public GameObject RightAxe;
        public GameObject LeftAxe;

        private Player player = null;

        // Start is called before the first frame update
        void Start()
        {
            player = InteractionSystem.Player.instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (LeftHand.TouchedCount > 0 && !LeftHand.grabbing)
            {
                RightHand.grabbing = false;
                LeftHand.grabbing = true;
                pickaxeOnCollidePosition = playerLAxeTransform.position;
                playerOnCollidePosition = gameObject.transform.position;
                Debug.Log("Left");
            }
            if (RightHand.TouchedCount > 0 && !RightHand.grabbing)
            {
                LeftHand.grabbing = false;
                RightHand.grabbing = true;
                pickaxeOnCollidePosition = playerRAxeTransform.position;
                playerOnCollidePosition = gameObject.transform.position;
                Debug.Log("Right");
            }

            bool teleportButtonDown = false;
            foreach (Hand hand in player.hands)
            {
                if (IsTeleportButtonDown(hand))
                {
                    teleportButtonDown = true;
                }
            }
            if (teleportButtonDown)
            {
                RightAxe.SetActive(false);
                LeftAxe.SetActive(false);
                //RightHand.grabbing = false;
                //LeftHand.grabbing = false;
            }
            else
            {
                RightAxe.SetActive(true);
                LeftAxe.SetActive(true);
            }
            
            if (RightHand.grabbing)
            {
                gameObject.transform.position = playerOnCollidePosition + (pickaxeOnCollidePosition - playerRAxeTransform.position);
            }
            if (LeftHand.grabbing)
            {
                gameObject.transform.position = playerOnCollidePosition + (pickaxeOnCollidePosition - playerLAxeTransform.position);
            }
        }

        private bool IsTeleportButtonDown(Hand hand)
        {
            if (hand.noSteamVRFallbackCamera != null)
            {
                return Input.GetKey(KeyCode.T);
            }
            else
            {
                return teleportAction.GetState(hand.handType);
            }
        }
    }
}

