﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class AudioManager
    {
        public Dictionary<string, SoundEffect> sfxDictionary;
        public Dictionary<string, SoundEffect> musicDictionary;
        SoundEffectInstance musicLoop;

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

        public void Load(ContentManager Content)
        {
            sfxDictionary.Add("jump", Content.Load<SoundEffect>("jumpSmall"));
            sfxDictionary.Add("die", Content.Load<SoundEffect>("smb_mariodie"));
            sfxDictionary.Add("fireball", Content.Load<SoundEffect>("smb_fireball"));
            sfxDictionary.Add("coin", Content.Load<SoundEffect>("smb_coin"));
            sfxDictionary.Add("stomp", Content.Load<SoundEffect>("smb_stomp"));
            sfxDictionary.Add("powerup", Content.Load<SoundEffect>("smb_powerup"));
            sfxDictionary.Add("1up", Content.Load<SoundEffect>("smb_1-up"));
            sfxDictionary.Add("breakblock", Content.Load<SoundEffect>("smb_breakblock"));
            sfxDictionary.Add("falgpole", Content.Load<SoundEffect>("smb_flagpole"));
            musicDictionary.Add("mainTheme", Content.Load<SoundEffect>("01-main-theme-overworld"));
        }

        public void PlaySFX(string name)
        {
            bool exists;
            exists = sfxDictionary.TryGetValue(name, out SoundEffect sfx);
            if (exists)
            {
                sfx.Play();
            } else
            {
                System.Diagnostics.Debug.WriteLine("File not found.");
            }
        }

        public void PlayMusic(string name)
        {
            bool exists;
            exists = musicDictionary.TryGetValue(name, out SoundEffect music);
            if (exists)
            {
                musicLoop = music.CreateInstance();
                musicLoop.IsLooped = true;
                musicLoop.Play();
            } else
            {
                System.Diagnostics.Debug.WriteLine("File not found.");
            }
        }

        public void StopMusic() 
        {
            musicLoop.Stop();
        }
    }
}