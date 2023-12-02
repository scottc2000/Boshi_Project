using static Sprint0.Sprites.Players.PlayerData;
using static System.Net.Mime.MediaTypeNames;

namespace Sprint0.Utility
{
    // For content that needs to be loaded and JSON files that are referenced
    public class FileNames
    {
        /*__________ Sprite Sheets ___________________*/
        public string blockSheet { get; } = "SpriteImages/blocks";
        public string playerSheet { get; } = "SpriteImages/playerssclear";
        public string enemySheet { get; } = "marioenemy";
        public string itemSheet { get; } = "NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs";
        public string terrainSheet { get; } = "level1_1";
        public string hudSheet { get; } = "HUD_transparent1";
        public string titleSheet { get; } = "mario title with text";

        /*________________ MUSIC _______________________*/
        public string mainTheme { get; } = "01-main-theme-overworld";

        /*________________ SFX _______________________*/
        public string jumpSFX { get; } = "smb_jump-small";
        public string deathSFX { get; } = "smb_mariodie";
        public string oneUpSFX { get; } = "smb_1-up";
        public string breakBlockSFX { get; } = "smb_breakblock";
        public string coinSFX { get; } = "smb_coin";
        public string fireballSFX { get; } = "smb_fireball";
        public string flagpoleSFX { get; } = "smb_flagpole";
        public string pipeSFX { get; } = "smb_pipe";
        public string powerUpSFX { get; } = "smb_powerup";
        public string stompSFX { get; } = "smb_stomp";

        /*________________ JSON Files _______________*/
        public string blockData { get; } = "JSON/blockdata.json";
        public string enemyData { get; } = "JSON/enemydata.json";
        public string hudData { get; } = "JSON/HUDdata.json";
        public string itemData { get; } = "JSON/itemdata.json";
        public string levelData { get; } = "JSON/level1.json";
        public string playerData { get; } = "JSON/playerdata.json";
        public string projectileData { get; } = "JSON/projectiledata.json";

        /*________________ Error Messages _______________*/
        public string AudioNF { get; } = "Audio file not found";
    }
}
