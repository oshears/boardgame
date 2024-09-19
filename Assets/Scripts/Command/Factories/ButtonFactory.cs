
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace OSGames.BoardGame {

    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    // public class CommandFactory
    // {
        
    //     // public virtual CommandFactory GetCommand()
    //     // {

    //     // }
    // }

    public class ButtonFactory : Factory<ButtonFactroyProduct, GameObject>
    {
        
        // public virtual CommandFactory GetCommand()
        // {

        // }
        [Tooltip("The gameobject that newly created buttons will be nested under")]
        [SerializeField] Transform m_ButtonHolder;


        [Tooltip("Prefab of the button to be constructed.")]
        [SerializeField] GameObject ButtonPrefab;

        

        // store initial button for loopback

        public void Initialize(){

        }

        override public GameObject Make(ButtonFactroyProduct product){
            // make command
            // add to visual view?
            GameObject tmp = Instantiate(ButtonPrefab,m_ButtonHolder);
            
            ButtonResponder btnResponder = tmp.AddComponent<ButtonResponder>();
            btnResponder.Scheduler = product.Scheduler;
            btnResponder.Command = new ActionMenuCmd(product.ActionMenu, product.RoomAction);

            TextMeshProUGUI[] textMeshes = tmp.GetComponentsInChildren<TextMeshProUGUI>();
            textMeshes[0].text = product.RoomAction.Title;
            textMeshes[1].text = product.RoomAction.Description;

            Image[] images = tmp.GetComponentsInChildren<Image>();
            images[images.Length - 1].sprite = product.RoomAction.Sprite;
            
            return tmp;
        }
    }

    public class ButtonFactroyProduct {
        public ActionMenuController ActionMenu;
        public RoomAction RoomAction;
        public Scheduler Scheduler;
        public ButtonFactroyProduct(ActionMenuController actionMenu, RoomAction roomAction, Scheduler scheduler)
        {
            ActionMenu = actionMenu;
            RoomAction = roomAction;
            Scheduler = scheduler;
        }
    }
}