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
    public class AudioManager : Game
    {
        public Dictionary<string, SoundEffect> sfxDictionary;
        public Dictionary<string, SoundEffect> musicDictionary;

        private static AudioManager instance;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                }
                return instance;
            }
        }

        private AudioManager()
        {
            sfxDictionary = new Dictionary<string, SoundEffect>();
            musicDictionary = new Dictionary<string, SoundEffect>();
        }

        public void Load()
        {
            sfxDictionary.Add("jumpSmall", Content.Load<SoundEffect>("Content/jumpSmall"));
            musicDictionary.Add("mainTheme", Content.Load<SoundEffect>("Content/01-main-theme"));
        }

        public void PlaySFX(string name)
        {
            bool exists;
            exists = sfxDictionary.TryGetValue(name, out SoundEffect sfx);
            if (exists)
            {
                sfx.Play();
            }
        }

        public void PlayMusic(string name)
        {
            bool exists;
            exists = musicDictionary.TryGetValue(name, out SoundEffect music);
            if (exists)
            {
                
                SoundEffectInstance musicLoop = music.CreateInstance();
                musicLoop.IsLooped = true;
                musicLoop.Play();
            }
        }
    }
}
