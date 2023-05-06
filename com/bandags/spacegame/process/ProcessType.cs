using System;
namespace com.bandags.spacegame.process {
    [Serializable]
    public enum ProcessType {
        NOT_SET,
        START_GAME_PROCESS,
        
        LOAD_SYSTEM_PROCESS,
        LOAD_SCENE_PROCESS,
        LOAD_SYSTEM_LAYER_PROCESS,
        
        LAND_ON_PLANET_PROCESS,
        SHRINK_SHIP_PROCESS,
        ATTACK_SHIP_PROCESS,
        FIRE_AT_TARGET_PROCESS,
        AIM_AT_TARGET_PROCESS,
        
        CREATE_PLANET_PROCESS,
        CREATE_PLAYER_PROCESS,
        CREATE_SHIP_PROCESS,
        CREATE_GENERIC_SHIP_PROCESS,
        CREATE_GALAXY_PROCESS,
        
        LOAD_SHIPS_INTO_SYSTEM_PROCESS,
        MANAGE_SHIPS_IN_SYSTEM_PROCESS,
        
        JUMP_SHIP_TO_NEW_SYSTEM_PROCESS,
        
        MOVE_SHIP_AND_STOP_PROCESS
    }
}