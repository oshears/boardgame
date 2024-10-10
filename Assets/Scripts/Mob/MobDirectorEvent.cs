using OSGames.BoardGame.Generic;
using UnityEngine;

namespace OSGames.BoardGame {
    
    [Icon("Packages/com.osgames.boardgame/Assets/Icons/osgames_logo.png")]
    public class MobDirectorEvent<T> : EventData<MobDirector<T>> {
        public MobDirectorEvent(MobDirector<T> sender) : base(sender){

        }
    }
}