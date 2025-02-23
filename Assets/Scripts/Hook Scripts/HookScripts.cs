using UnityEngine;

public class HookScripts : MonoBehaviour{

    [SerializeField]
    private Transform itemHolder;

    private bool itemAttached;

    private HookMovementScripts hookMovement;

    private PlayerAnimation playerAnimation;

    void Awake(){
        hookMovement = GetComponentInParent<HookMovementScripts>();
        playerAnimation = GetComponentInParent<PlayerAnimation>();
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == Tag.LARGE_GOLD || target.tag == Tag.MEDIUM_GOLD || target.tag == Tag.SMALL_GOLD || target.tag == Tag.LARGE_STONE || target.tag == Tag.MEDIUM_STONE){
            if(!itemAttached){
                itemAttached = true;
                target.gameObject.transform.parent = itemHolder;
                target.gameObject.transform.position = itemHolder.position;

                hookMovement.move_Speed = target.GetComponent<ItemScripts>().hook_Speed;

                hookMovement.HookAttachedItem();

                playerAnimation.PullingItemAnimation();

                if(target.tag == Tag.LARGE_GOLD || target.tag == Tag.SMALL_GOLD || target.tag == Tag.MEDIUM_GOLD){
                    SoundManager.instance.HookGrab_Gold();
                }else if(target.tag == Tag.LARGE_STONE || target.tag == Tag.MEDIUM_STONE){
                    SoundManager.instance.HookGrab_Stone();
                }
            }
            SoundManager.instance.PullSound(true);
        }

        if(target.tag == Tag.DELIVER_ITEM){
            if(itemAttached){
                itemAttached = false;
                Transform objChild = itemHolder.GetChild(0);
                objChild.parent = null;
                objChild.gameObject.SetActive(false);
                playerAnimation.IdleAnimation();
                SoundManager.instance.PullSound(false);


            }
        }
    }
     
}
