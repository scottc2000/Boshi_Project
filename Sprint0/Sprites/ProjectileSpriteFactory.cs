using System;
using static Sprint0.Sprites.PlayerData;
using System.IO;
using System.Text.Json;

namespace Sprint0.Sprites
{
	public class ProjectileSpriteFactory
	{
        private Root deserializedPlayerData;

        public ProjectileSpriteFactory()
		{
            StreamReader r = new StreamReader("playerdata.json");
            string playerdatajson = r.ReadToEnd();

            deserializedPlayerData = JsonSerializer.Deserialize<Root>(playerdatajson);

        }
	}
}

