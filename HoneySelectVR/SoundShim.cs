using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manager;
using UnityEngine;
using VRGIN.Helpers;
using VRGIN.Core;
using Sound;
using System.Collections;

namespace HoneySelectVR
{
    class VoiceShim : Manager.Voice
    {
        private Manager.Voice originalSound;


        public static void Inject()
        {
            var original = Instance;
            if (original && !(original is VoiceShim))
            {
                //var shim = new GameObject().AddComponent<SoundShim>();
                VoiceShim shim = original.gameObject.CopyComponentFrom<Manager.Voice, VoiceShim>(original);
                instance = shim;
                shim.originalSound = original;
                //Destroy(original);
            }
            //new GameObject("VRGIN_SoundShim")
            //Singleton<Manager.Sound>.instance = Singleton<SoundShim>.instance;
        }


        public override AudioSource Create(LoadVoice script)
        {
            var audio = originalSound.Create(script);
            return audio;
        }

        public override List<AudioSource> GetPlayingList(int no)
        {
            return originalSound.GetPlayingList(no);
        }
        public override float GetVolume(int charaNo)
        {
            return originalSound.GetVolume(charaNo);
        }
        public override bool IsVoiceCheck()
        {
            return originalSound.IsVoiceCheck();
        }
        public override bool IsVoiceCheck(int no)
        {
            return originalSound.IsVoiceCheck(no);
        }
        public override bool IsVoiceCheck(int no, Transform voiceTrans)
        {
            return originalSound.IsVoiceCheck(no, voiceTrans);
        }
        public override bool IsVoiceCheck(Transform voiceTrans)
        {
            return originalSound.IsVoiceCheck(voiceTrans);
        }
        public override void Load()
        {
            originalSound.Load();
        }
        public override void LoadSetting(Type type, int settingNo = -1)
        {
            originalSound.LoadSetting(type, settingNo);
        }
        public override void OnDestroy()
        {
            originalSound.OnDestroy();
        }
        public override Transform OnecePlay(int no, string assetBundleName, string assetName, float pitch = 1, float delayTime = 0, bool isAsync = true, Transform voiceTrans = null, Type type = Type.PCM, int settingNo = -1, bool isPlayEndDelete = true, bool isBundleUnload = true, string manifestFileName = "abdata")
        {
            if (voiceTrans == null)
            {
                voiceTrans = GetVoiceTrans();
            }
            return originalSound.OnecePlay(no, assetBundleName, assetName, pitch, delayTime, isAsync, voiceTrans, type, settingNo, isPlayEndDelete, isBundleUnload, manifestFileName);
        }
        public override Transform OnecePlayChara(int no, string assetBundleName, string assetName, float pitch = 1, float delayTime = 0, bool isAsync = true, Transform voiceTrans = null, Type type = Type.PCM, int settingNo = -1, bool isPlayEndDelete = true, bool isBundleUnload = true, string manifestFileName = "abdata")
        {
            if(voiceTrans == null)
            {
                voiceTrans = GetVoiceTrans();
            }
            return originalSound.OnecePlayChara(no, assetBundleName, assetName, pitch, delayTime, isAsync, voiceTrans, type, settingNo, isPlayEndDelete, isBundleUnload, manifestFileName);
        }

        private Transform GetVoiceTrans()
        {
            var actor = VR.Interpreter.Actors.LastOrDefault();
            return actor != null ? actor.Eyes : null;
        }
        public override Transform Play(int no, string assetBundleName, string assetName, float pitch = 1, float delayTime = 0, bool isAsync = true, Transform voiceTrans = null, Type type = Type.PCM, int settingNo = -1, bool isPlayEndDelete = true, bool isBundleUnload = true, string manifestFileName = "abdata")
        {
            return originalSound.Play(no, assetBundleName, assetName, pitch, delayTime, isAsync, voiceTrans, type, settingNo, isPlayEndDelete, isBundleUnload, manifestFileName);
        }
        public override void Reset()
        {
            originalSound.Reset();
        }
        public override void Save()
        {
            originalSound.Save();
        }
        public override void Stop(int no)
        {
            originalSound.Stop(no);
        }
        public override void Stop(int no, Transform voiceTrans)
        {
            originalSound.Stop(no, voiceTrans);
        }
        public override void Stop(Transform voiceTrans)
        {
            originalSound.Stop(voiceTrans);
        }
        public override void StopAll()
        {
            originalSound.StopAll();
        }

        public override void Start()
        {

        }

        protected override void Awake()
        {
            //originalSound.Awake();
        }
    }

    //class SoundShim : Manager.Sound
    //{
    //    private Manager.Sound originalSound;

    //    public static void Inject()
    //    {
    //        var original = Instance;
    //        if(original && !(original is SoundShim))
    //        {
    //            //var shim = new GameObject().AddComponent<SoundShim>();
    //            SoundShim shim = original.gameObject.CopyComponentFrom<Manager.Sound, SoundShim>(original);
    //            instance = shim;
    //            shim.originalSound = original;
    //            //Destroy(original);
    //        }
    //        //new GameObject("VRGIN_SoundShim")
    //        //Singleton<Manager.Sound>.instance = Singleton<SoundShim>.instance;
    //    }

    //    public override Transform Play(Type type, string assetBundleName, string assetName, float fadeOrdelayTime, bool isAsync = true, int settingNo = -1, bool isBundleUnload = true, string manifestFileName = "abdata")
    //    {
    //        VRLog.Info("Play");
    //        return originalSound.Play(type == Type.GameSE2D ? Type.GameSE3D : type, assetBundleName, assetName, fadeOrdelayTime, isAsync, settingNo, isBundleUnload, manifestFileName);
    //    }

    //    public override OutputSettingData AudioSettingData(AudioSource audio, int settingNo)
    //    {
    //        var settings = originalSound.AudioSettingData(audio, settingNo);
    //        audio.spatialBlend = 1f;
    //        audio.spatialize = true;

    //        VRLog.Info("Spatialized {0} at {1}", audio.name, audio.transform.position);

    //        var _3dsettings = originalSound.setting3DDataList.FirstOrDefault();
    //        if(_3dsettings != null)
    //        {
    //            audio.dopplerLevel = _3dsettings.DopplerLevel;
    //            audio.spread = _3dsettings.Spread;
    //            audio.minDistance = _3dsettings.MinDistance;
    //            audio.maxDistance = _3dsettings.MaxDistance;
    //            audio.rolloffMode = (AudioRolloffMode)_3dsettings.AudioRolloffMode;
    //        } 

    //        //audio.spatialize = true;
    //        return settings;
    //    }

    //    public override bool BGM(FadePlayer player, Action<FadePlayer> act)
    //    {
    //        return originalSound.BGM(player, act);
    //    }

    //    public override IEnumerator BGMLoop()
    //    {
    //        return originalSound.BGMLoop();
    //    }

    //    public override AudioSource Create(LoadSound script)
    //    {
    //        var audioSource = originalSound.Create(script);

    //        audioSource.spatialBlend = 1f;
    //        return audioSource;
    //    }

    //    public override List<AudioSource> GetPlayingList(Type type)
    //    {
    //        return originalSound.GetPlayingList(type);
    //    }
    //    public override bool IsCheckParentCreated(Transform script)
    //    {
    //        return originalSound.IsCheckParentCreated(script);
    //    }
    //    public override bool IsPlay(Transform trans)
    //    {
    //        return originalSound.IsPlay(trans);
    //    }
    //    public override bool IsPlay(Type type, string playName = null)
    //    {
    //        return originalSound.IsPlay(type, playName);
    //    }
    //    public override bool IsPlay(Type type, Transform trans)
    //    {
    //        return originalSound.IsPlay(type, trans);
    //    }
    //    public override void LoadSetting(Type type, int settingNo = -1)
    //    {
    //        originalSound.LoadSetting(type, settingNo);
    //    }
    //    public override void LoadSettingData()
    //    {
    //        originalSound.LoadSettingData();
    //    }

    //    public override void PauseBGM()
    //    {
    //        originalSound.PauseBGM();
    //    }

    //    public override void PlayBGM(AudioSource audio, float fadeTime = 0)
    //    {
    //        originalSound.PlayBGM(audio, fadeTime);
    //    }

    //    public override void PlayBGM(float fadeTime = 0)
    //    {
    //        originalSound.PlayBGM(fadeTime);
    //    }

    //    public override void Register(AudioClip clip)
    //    {
    //        originalSound.Register(clip);
    //    }

    //    public override void Remove(AudioClip clip)
    //    {
    //        originalSound.Remove(clip);
    //    }

    //    public override Transform SetParent(Transform parent, Transform script, GameObject settingObject)
    //    {
    //        return originalSound.SetParent(parent, script, settingObject);
    //    }

    //    public override void Stop(Transform trans)
    //    {
    //        originalSound.Stop(trans);
    //    }

    //    public override void Stop(Type type)
    //    {
    //        originalSound.Stop(type);
    //    }

    //    public override void Stop(Type type, Transform trans)
    //    {
    //        originalSound.Stop(type, trans);
    //    }

    //    public override void StopBGM(float fadeTime = 0)
    //    {
    //        originalSound.StopBGM(fadeTime);
    //    }


    //    public override void Start()
    //    {
    //        foreach(var audio in GameObject.FindObjectsOfType<AudioSource>())
    //        {
    //            audio.spatialBlend = 1f;
    //            VRLog.Info("Spatializing {0}", audio.name);
    //        }
    //    }

    //    public override void Update()
    //    {
    //    }

    //    protected override void Awake()
    //    {
    //        //originalSound.Awake();
    //    }
    //}
}
