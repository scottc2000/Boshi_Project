namespace Sprint0.Utility
{
    // For content that needs to be loaded and JSON files that are referenced
    public class FileNames
    {
        /*__________ Sprite Sheets ___________________*/
        string blockSheet { get; } = "SpriteImages/blocks";
        string playerSheet { get; } = "SpriteImages/playerssclear";
        string enemySheet { get; } = "marioenemy";
        string itemSheet { get; } = "NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs";
        string terrainSheet { get; } = "level1_1";
        string hudSheet { get; } = "HUD_transparent1";

        /*________________ Music _______________________*/
        string mainTheme { get; } = "01-main-theme-overwold";
        string jumpTheme { get; } = "jumpSmall";
        string oneUpTheme { get; } = "smb_1-up";
        string breakBlockTheme { get; } = "smb_breakblock";
        string coinTheme { get; } = "smb_coin";
        string fireballTheme { get; } = "smb_fireball";
        string flagpoleTheme { get; } = "smb_flagpole";
        string marioDeadTheme { get; } = "smb_mariodie";
        string pipeTheme { get; } = "smb_pipe";
        string powerUpTheme { get; } = "smb_pipe";
        string stompTheme { get; } = "smb_stomp";

        /*________________ JSON Files _______________*/
        string blockData { get; } = "JSON/blockdata.json";
        string enemyData { get; } = "JSON/enemydata.json";
        string hudData { get; } = "JSON/HUDdata.json";
        string itemData { get; } = "JSON/itemdata.json";
        string levelData { get; } = "JSON/level1.json";
        string playerData { get; } = "JSON/playerdata.json";
        string projectileData { get; } = "JSON/projectiledata.json";

    }
}
