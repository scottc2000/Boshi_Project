﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Utility;

namespace Sprint0
{
    public class AudioManager
    {
        public Dictionary<string, SoundEffect> sfxDictionary;
        public Dictionary<string, SoundEffect> musicDictionary;

        public List<SoundEffect> soundEffects;
        public List<SoundEffect> musicTracks;

        private FileNames FileNames;
        SoundEffectInstance musicLoop;

        private static AudioManager instance;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AudioManager();
                    Instance.FileNames = new FileNames();
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
            sfxDictionary.Add(FileNames.jumpSFX, Content.Load<SoundEffect>(FileNames.jumpSFX));
            sfxDictionary.Add(FileNames.deathSFX, Content.Load<SoundEffect>(FileNames.deathSFX));
            sfxDictionary.Add(FileNames.oneUpSFX, Content.Load<SoundEffect>(FileNames.oneUpSFX));
            sfxDictionary.Add(FileNames.breakBlockSFX, Content.Load<SoundEffect>(FileNames.breakBlockSFX));
            sfxDictionary.Add(FileNames.coinSFX, Content.Load<SoundEffect>(FileNames.coinSFX));
            sfxDictionary.Add(FileNames.fireballSFX, Content.Load<SoundEffect>(FileNames.fireballSFX));
            sfxDictionary.Add(FileNames.flagpoleSFX, Content.Load<SoundEffect>(FileNames.flagpoleSFX));
            sfxDictionary.Add(FileNames.pipeSFX, Content.Load<SoundEffect>(FileNames.pipeSFX));
            sfxDictionary.Add(FileNames.powerUpSFX, Content.Load<SoundEffect>(FileNames.powerUpSFX));
            sfxDictionary.Add(FileNames.stompSFX, Content.Load<SoundEffect>(FileNames.stompSFX));

            musicDictionary.Add(FileNames.mainTheme, Content.Load<SoundEffect>(FileNames.mainTheme));
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
                System.Diagnostics.Debug.WriteLine(FileNames.AudioNF);
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
                System.Diagnostics.Debug.WriteLine(FileNames.AudioNF);
            }
        }

        public void StopMusic() 
        {
            musicLoop.Stop();
        }
    }
}