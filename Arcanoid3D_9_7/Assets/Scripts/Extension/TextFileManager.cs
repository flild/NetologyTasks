using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Arcanoid.UI
{
    
    public class TextFileManager : MonoBehaviour
    {
        [SerializeField] private string _fileName;
        public async Task RecordSettings(RecordSettingType settingType, string settingValue)
        {

            GetSettings(out bool _soundOn, out float _soundValue, out Difficult _difficult);
            switch (settingType)
            {
                case RecordSettingType.sound:
                    _soundOn = settingValue == "true" ? true : false;
                    break;
                case RecordSettingType.soundValue:
                    _soundValue = (float)Convert.ToDouble(settingValue); ;
                    break;
                case RecordSettingType.difficutly:
                    _difficult = DeserializeDifficutl(settingValue).GetValueOrDefault();
                    break;
            }
            File.Delete(_fileName + ".txt");
            await using var fileStream = new FileStream(_fileName + ".txt", FileMode.Append);
            await using var streamWriter = new StreamWriter(fileStream);
            await streamWriter.WriteLineAsync(RecordSettingType.sound + "-" + _soundOn);
            await streamWriter.WriteLineAsync(RecordSettingType.soundValue + "-" + _soundValue);
            await streamWriter.WriteLineAsync(RecordSettingType.difficutly + "-" + _difficult);
            Debug.Log("Запиь упешна");
        }

        private string ReadSettings()
        {
            if (!File.Exists(_fileName + ".txt"))
            {
                FileInfo file = new FileInfo(_fileName + ".txt");
                file.Create();
            }
            using var fileStream = new FileStream(_fileName + ".txt", FileMode.Open);
            using var streamReader = new StreamReader(fileStream);

            var builder = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                builder.AppendLine(streamReader.ReadLine());
            }
            return builder.ToString();
        }

        private void DeSerialize(string input,
                                out RecordSettingType? settingType,
                                out bool? soundOn,
                                out float? SoundValue,
                                out Difficult? difficult)
        {
            soundOn = null;
            SoundValue = null;
            difficult = null;
            const string settingTypePattern = @"(sound|soundValue|difficutly)-(\S*)";
            var settingTypesMatch = Regex.Match(input, settingTypePattern);
            var type = settingTypesMatch.Groups[1].Value;
            var value = settingTypesMatch.Groups[2].Value;

            switch(type)
            {
                case "sound":
                    settingType = RecordSettingType.sound;
                    soundOn = value == "true" ? true : false;
                    break;
                case "soundValue":
                    settingType = RecordSettingType.soundValue;
                    SoundValue = (float)Convert.ToDouble(value);
                    break;
                case "difficutly":
                    settingType = RecordSettingType.difficutly;
                    difficult = DeserializeDifficutl(value);
                    break;

            }
            settingType = null;


        }

        private Difficult? DeserializeDifficutl(string input)
        {
            switch(input)
            {
                case "easy":
                    return Difficult.easy;
                case "normal":
                    return Difficult.normal;
                case "hard":
                    return Difficult.hard;
            }
            return null;
        }

        public void GetSettings(out bool soundOn, out float soundValue, out Difficult difficult)
        {
            soundOn = false;
            soundValue = 0;
            difficult = Difficult.normal;

            List<string> settingSaves = new List<string>();
            var output = ReadSettings();
            settingSaves = output.Split(Environment.NewLine).ToList();

           // bool? _soundOn = null;
            //float? _soundValue = null;
           // Difficult? _difficult = null;
            foreach (var setting in settingSaves)
            {
                DeSerialize(setting,
                                out RecordSettingType? _settingType, out bool? _soundOn, out float? _soundValue, out Difficult? _difficult);
                if (_soundOn != null)
                    soundOn = _soundOn.GetValueOrDefault();
                if (_soundValue != null)
                    soundValue = _soundValue.GetValueOrDefault();
                if (_difficult != null)
                    difficult = _difficult.GetValueOrDefault();
            }

        }
    }
}

