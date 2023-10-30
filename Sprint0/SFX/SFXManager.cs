using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.SFX
{
    public class SFXManager
    {
        public Dictionary<string, SoundEffect> soundEffects;
        ContentManager Content;

        public SFXManager(ContentManager content)
        {
            soundEffects = new Dictionary<string, SoundEffect>();
            Content = content;
        }

        public void Load()
        {
            soundEffects.Add("jumpSmall", Content.Load<SoundEffect>("jumpSmall"));
        }

        public void Play(string name)
        {
            bool exists;
            exists = soundEffects.TryGetValue(name, out SoundEffect sound);
            if (exists)
            {
                sound.Play();
            }
        }
    }
}
