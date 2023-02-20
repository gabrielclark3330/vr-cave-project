using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem
{
    public class climbingLogic : MonoBehaviour
    {
        public GameObject vrCamera;
        public Transform playerLAxeTransform;
        public Transform playerRAxeTransform;
        private Vector3 pickaxeOnCollidePosition;
        public ClimberHand RightHand;
        public ClimberHand LeftHand;
        public SteamVR_Action_Boolean triggerAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
        private Hand inputHand;
        public SteamVR_Action_Boolean teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
        public GameObject RightAxe;
        public GameObject LeftAxe;

        private Player player = null;
        private bool lHandTrigger = false;
        private bool rHandTrigger = false;
        private float timeSpentNotGrabbing = 0;
        private bool playerOnGround = true;

        // Start is called before the first frame update
        void Start()
        {
            player = Player.instance;
        }

        // Update is called once per frame
        void Update()
        {
            updateTriggerVariables();

            if (LeftHand.TouchedCount > 0 && !LeftHand.grabbing && lHandTrigger)
            {
                RightHand.grabbing = false;
                LeftHand.grabbing = true;
                pickaxeOnCollidePosition = playerLAxeTransform.position;
            }
            if (RightHand.TouchedCount > 0 && !RightHand.grabbing && rHandTrigger)
            {
                LeftHand.grabbing = false;
                RightHand.grabbing = true;
                pickaxeOnCollidePosition = playerRAxeTransform.position;
            }
            /*
            if (!lHandTrigger)
            {
                LeftHand.grabbing = false;
            }
            if (!rHandTrigger)
            {
                RightHand.grabbing = false;
            }*/

            updateAxeActive();

            if (RightHand.grabbing)
            {
                gameObject.transform.position += (pickaxeOnCollidePosition - playerRAxeTransform.position);
                playerOnGround = false;
            }
            if (LeftHand.grabbing)
            {
                gameObject.transform.position += (pickaxeOnCollidePosition - playerLAxeTransform.position);
                playerOnGround = false;
            }
            /*
            else if (!LeftHand.grabbing && !RightHand.grabbing)
            {
                timeSpentNotGrabbing += Time.deltaTime;
                if (vrCamera.transform.position.y < 1.8288) // 6ft in meters
                {
                    playerOnGround = true;
                }
                if (!playerOnGround)
                {
                    gameObject.transform.position -= new Vector3(0, timeSpentNotGrabbing*-9.81f, 0); // gravitational constant
                }
            }*/
        }

        private void updateAxeActive()
        {
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
            }
            else
            {
                RightAxe.SetActive(true);
                LeftAxe.SetActive(true);
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

        private void updateTriggerVariables()
        {
            if (triggerAction.stateDown) // If holding down trigger
            {
                inputHand = inputChecker();
                if (inputHand == Player.instance.leftHand)
                {
                    lHandTrigger = true;
                }
                if (inputHand == Player.instance.rightHand)
                {
                    rHandTrigger = true;
                }
            }
            if (triggerAction.stateUp)
            {
                inputHand = inputChecker();
                if (inputHand == Player.instance.leftHand)
                {
                    lHandTrigger = false;
                }
                if (inputHand == Player.instance.rightHand)
                {
                    rHandTrigger = false;
                }
            }
        }

        private Hand inputChecker()
        {
            if (triggerAction.activeDevice == SteamVR_Input_Sources.RightHand)
            {
                inputHand = Player.instance.rightHand;
            }
            else if (triggerAction.activeDevice == SteamVR_Input_Sources.LeftHand)
            {
                inputHand = Player.instance.leftHand;
            }
            return inputHand;
        }
    }
}

