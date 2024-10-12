using UnityEngine;

using OSGames.BoardGame.Generic;

namespace OSGames.BoardGame.Actions {

    // [CreateAssetMenu(fileName = "Room Action", menuName = "Board Game/Room Action", order = 0)]
    [Icon("Assets/Icons/osgames_scriptable_object.png")]
    public class PlayerAction : ScriptableObject {

        // define constraints for this action to be valid

        
        [SerializeField] public string Title;
        // [Multiline]
        [TextAreaAttribute]
        [SerializeField] public string Description;
        [SerializeField] public int Cost;
        [SerializeField] public Sprite Sprite;
        [SerializeField] public Color Color;
        // [SerializeField] public int Level;
        [SerializeField] public ActionRestriction Restriction;

        public virtual ActionType baseActionType {
            get{ return ActionType.Basic; }
        }

        public ActionType BaseActionType {
            get {return GetActionType();}
        }

        public virtual ActionType GetActionType(){
            return ActionType.Basic;
        }

    }

    public enum ActionRestriction {
        None,
        OutsideCombat,
        InCombat,
    }

}