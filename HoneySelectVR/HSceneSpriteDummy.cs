using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Config;
using UnityEngine;
using VRGIN.Helpers;
using VRGIN.Core;

namespace HoneySelectVR
{
    internal class HSceneSpriteDummy : HSceneSprite
    {
        private const float WAIT_BETWEEN_TOUCHES = 0.1f;
        private HSceneSprite _Base;

        public static HSceneSpriteDummy Create(HSceneSprite realSprite)
        {
            var sprite = new GameObject().CopyComponentFrom<HSceneSprite, HSceneSpriteDummy>(realSprite);
            if (!sprite.categoryFinish)
            {
                if (realSprite.categoryFinish)
                {
                    VRLog.Warn("This ain't good man!");
                }
            }
            sprite._Base = realSprite;
            if (!realSprite)
            {
                throw new ArgumentNullException();
            }


            return sprite;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
        }

        public override void LateUpdate()
        {
        }

        public override void OnValidate()
        {
            _Base.OnValidate();
        }

        public override void SetLightInfo(GameObject _objCharaLight, Light _lightFront, Light _lightFrontMap, HMapInfo.MapInfo _info,
            ConfigEffector _configEffector)
        {
            _Base.SetLightInfo(_objCharaLight, _lightFront, _lightFrontMap, _info, _configEffector);
        }

        public override bool IsSpriteOver()
        {
            return (Time.time - PlayTool.LastTouch) > WAIT_BETWEEN_TOUCHES && _Base.IsSpriteOver();
        }

        public override void setAnimationList(List<HScene.AnimationListInfo>[] _lstAnimInfo)
        {
            _Base.setAnimationList(_lstAnimInfo);
        }

        public override void Init(CharFemale _female, int _event)
        {
            _Base.Init(_female, _event);
        }

        public override void SetFinishSelect(int _mode, int _ctrl)
        {
            _Base.SetFinishSelect(_mode, _ctrl);
        }

        public override bool IsFinishVisible(int _num)
        {
            return _Base.IsFinishVisible(_num);
        }

        public override void SetEnableFaintnessRecovery(bool _enable)
        {
            _Base.SetEnableFaintnessRecovery(_enable);
        }

        public override void SetVisibleLeaveItToYou(bool _visible, bool _judgeLeaveItToYou = false)
        {
            _Base.SetVisibleLeaveItToYou(_visible, _judgeLeaveItToYou);
        }

        public override void SetToggleLeaveItToYou(bool _on)
        {
            _Base.SetToggleLeaveItToYou(_on);
        }

        public override void SetEnableCategoryMain(bool _enable, int _array = -1)
        {
            _Base.SetEnableCategoryMain(_enable, _array);
        }

        public override void MainCategoryOfLeaveItToYou(bool _isLeaveItToYou)
        {
            _Base.MainCategoryOfLeaveItToYou(_isLeaveItToYou);
        }

        public override void SetChangePositionEnable(bool _enable)
        {
            _Base.SetChangePositionEnable(_enable);
        }

        public override bool IsEnableLeaveItToYou()
        {
            return _Base.IsEnableLeaveItToYou();
        }

        public override void SetMotonListClickHandler(GameObject clickObj)
        {
            _Base.SetMotonListClickHandler(clickObj);
        }

        public override void OnChangePlaySelect(GameObject objClick)
        {
            _Base.OnChangePlaySelect(objClick);
        }

        public override void OnClickMotion(int _motion)
        {
            _Base.OnClickMotion(_motion);
        }

        public override void SetMotionListDraw(bool _active, int _motion = -1)
        {
            _Base.SetMotionListDraw(_active, _motion);
        }

        public override void OnClickSubMenu(int _menu)
        {
            _Base.OnClickSubMenu(_menu);
        }

        public override void OnClickFinishBefore()
        {
            _Base.OnClickFinishBefore();
        }

        public override void OnClickFinishInSide()
        {
            _Base.OnClickFinishInSide();
        }

        public override void OnClickFinishOutSide()
        {
            _Base.OnClickFinishOutSide();
        }

        public override void OnClickFinishSame()
        {
            _Base.OnClickFinishSame();
        }

        public override void OnClickChangeNormal()
        {
            _Base.OnClickChangeNormal();
        }

        public override void OnClickFinishDrink()
        {
            _Base.OnClickFinishDrink();
        }

        public override void OnClickFinishVomit()
        {
            _Base.OnClickFinishVomit();
        }

        public override void OnClickSpanking()
        {
            _Base.OnClickSpanking();
        }

        public override void OnClickPositionShift(int _shift)
        {
            _Base.OnClickPositionShift(_shift);
        }

        public override void OnClickPositionShiftInit(int _shift)
        {
            _Base.OnClickPositionShiftInit(_shift);
        }

        public override void OnClickPositionInit()
        {
            _Base.OnClickPositionInit();
        }

        public override void OnClickSliderSelect()
        {
            _Base.OnClickSliderSelect();
        }

        public override void OnClickSceneEnd()
        {
            _Base.OnClickSceneEnd();
        }

        public override void OnClickStopFeel(int _sex)
        {
            _Base.OnClickStopFeel(_sex);
        }

        public override void OnClickMovePoint(int _dir)
        {
            _Base.OnClickMovePoint(_dir);
        }

        public override void OnClickLeave()
        {
            _Base.OnClickLeave();
        }

        public override void OnValueRChanged(float _value)
        {
            _Base.OnValueRChanged(_value);
        }

        public override void OnValueGChanged(float _value)
        {
            _Base.OnValueGChanged(_value);
        }

        public override void OnValueBChanged(float _value)
        {
            _Base.OnValueBChanged(_value);
        }

        public override void OnClickLightColorInit()
        {
            _Base.OnClickLightColorInit();
        }

        public override void OnValueVerticalChanged(float _value)
        {
            _Base.OnValueVerticalChanged(_value);
        }

        public override void OnValueHorizonChanged(float _value)
        {
            _Base.OnValueHorizonChanged(_value);
        }

        public override void OnValuePowerChanged(float _value)
        {
            _Base.OnValuePowerChanged(_value);
        }

        public override void OnClickLightDirInit()
        {
            _Base.OnClickLightDirInit();
        }

        public override void OnClickConfig()
        {
            _Base.OnClickConfig();
        }

        public override void OnClickMaleCustom()
        {
            _Base.OnClickMaleCustom();
        }

        public override void OnClickFemaleCustom()
        {
            _Base.OnClickFemaleCustom();
        }

        public override void OnClickClothChangeScene()
        {
            _Base.OnClickClothChangeScene();
        }

        public override void OnClickCloth(int _cloth)
        {
            _Base.OnClickCloth(_cloth);
        }

        public override void OnClickAllCloth(int _cloth)
        {
            _Base.OnClickAllCloth(_cloth);
        }

        public override void OnClickAccessory(int _accessory)
        {
            _Base.OnClickAccessory(_accessory);
        }

        public override void OnClickAllccessory(bool _accessory)
        {
            _Base.OnClickAllccessory(_accessory);
        }

        public override void OnValuePositionMoveSpeed(float _value)
        {
            _Base.OnValuePositionMoveSpeed(_value);
        }

        public override void OnValueSSAOIntensity(float _value)
        {
            _Base.OnValueSSAOIntensity(_value);
        }

        public override void OnValueSSAOColorR(float _value)
        {
            _Base.OnValueSSAOColorR(_value);
        }

        public override void OnValueSSAOColorG(float _value)
        {
            _Base.OnValueSSAOColorG(_value);
        }

        public override void OnValueSSAOColorB(float _value)
        {
            _Base.OnValueSSAOColorB(_value);
        }

        public override void OnValueBloomIntensity(float _value)
        {
            _Base.OnValueBloomIntensity(_value);
        }

        public override void OnValueBloomBlur(float _value)
        {
            _Base.OnValueBloomBlur(_value);
        }

        public override void OnClickInitSSAOIntensity()
        {
            _Base.OnClickInitSSAOIntensity();
        }

        public override void OnClickInitSSAOColor()
        {
            _Base.OnClickInitSSAOColor();
        }

        public override void OnClickInitBloomIntensity()
        {
            _Base.OnClickInitBloomIntensity();
        }

        public override void OnClickInitBloomBlur()
        {
            _Base.OnClickInitBloomBlur();
        }

        public override void OnClickInitEffectCtrl(int _ctrl)
        {
            _Base.OnClickInitEffectCtrl(_ctrl);
        }

        public override void OnClickTide()
        {
            _Base.OnClickTide();
        }

        public override void OnClickUrine()
        {
            _Base.OnClickUrine();
        }

        public override void OnClickMilk()
        {
            _Base.OnClickMilk();
        }

        public override void FadeState(FadeKind _kind, float _timeFade = -1)
        {
            _Base.FadeState(_kind, _timeFade);
        }

        public override FadeKindProc GetFadeKindProc()
        {
            return _Base.GetFadeKindProc();
        }

        public override bool FadeProc()
        {
            return _Base.FadeProc();
        }

        public override bool LoadMotionList(int _motion)
        {
            return _Base.LoadMotionList(_motion);
        }

        public override bool SetAnimationMenu()
        {
            return _Base.SetAnimationMenu();
        }

        public override void SetOption()
        {
            _Base.SetOption();
        }

        public override void SetCloth()
        {
            _Base.SetCloth();
        }

        public override void SetAccessory()
        {
            _Base.SetAccessory();
        }

        public override void SetSystem()
        {
            _Base.SetSystem();
        }

        public override IEnumerator CalcScrollBarHitCoroutine()
        {
            return _Base.CalcScrollBarHitCoroutine();
        }

        public override IEnumerator CalcScrollBarInitCoroutine()
        {
            return _Base.CalcScrollBarInitCoroutine();
        }
    }
}
