
using UnityEngine;

namespace BoardGame {

    // [CreateAssetMenu(fileName = "Command Factory", menuName = "Board Game/Command Factory", order = 0)]
    // public class CommandFactory
    // {
        
    //     // public virtual CommandFactory GetCommand()
    //     // {

    //     // }
    // }

    public class ButtonFactory : Factory<ButtonFactroyProduct>
    {
        
        // public virtual CommandFactory GetCommand()
        // {

        // }
        [Tooltip("The gameobject that newly created buttons will be nested under")]
        [SerializeField] Transform m_ButtonHolder;


        [Tooltip("Prefab of the button to be constructed.")]
        [SerializeField] GameObject ButtonPrefab;

        override public void Make(ButtonFactroyProduct product){
            // make command
            // add to visual view?
            GameObject tmp = Instantiate(ButtonPrefab,m_ButtonHolder);
            ButtonResponder btnResponder = tmp.AddComponent<ButtonResponder>();
            btnResponder.Scheduler = product.Scheduler;
            btnResponder.Command = product.Command;
        }
    }

    public class ButtonFactroyProduct {
        public Command Command;
        public Scheduler Scheduler;

        public ButtonFactroyProduct(Command cmd, Scheduler scheduler)
        {
            Command = cmd;
            Scheduler = scheduler;
        }
    }
}