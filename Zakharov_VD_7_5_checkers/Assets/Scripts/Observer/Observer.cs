using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Checkers
{
    public class Observer : MonoBehaviour, IObserve
    {
        public event Action<Coordinate> RepeatStep;
        private IRecorder _handler;
        private List<string> _output;
        private WinChecker _winChecker;

        [SerializeField] private bool isNeedRecord;
        [SerializeField] private bool isNeedRepeat;
        [SerializeField] private string _fileName;
        [SerializeField] private float _delayBetweenRepeat;




        private void Awake()
        {
            _handler = GetComponent<IRecorder>();
            _winChecker = GetComponent<WinChecker>();
            
        }
        private void Start()
        {
            if(isNeedRecord && !isNeedRepeat)
            {
                File.Delete(_fileName + ".txt");
                _handler.Step += OnStep;
                _handler.ChipDestroyed += OnChipDestroy;
                _winChecker.GameEnded += OnWin;
            }

            if (!isNeedRecord && isNeedRepeat)
            {
                Repeat();
            }
                

        }
        private void OnDisable()
        {
            _handler.Step -= OnStep;
            _handler.ChipDestroyed -= OnChipDestroy;
            _winChecker.GameEnded -= OnWin;
        }
        private void OnWin(ColorType side)
        {
            string side_num = side == ColorType.White ? "1" : "2";
            Record($"Игрок {side_num} победил");
        }
        private void OnStep(string input)
        {
            Record(input);
        }
        private void OnChipDestroy(ChipComponent Chip)
        {
            CellComponent cell = Chip.Pair as CellComponent;
            Record(Extension.ToSerializable(cell.coordinate.ToString(),
                Chip.color ==ColorType.White ? ColorType.Black: ColorType.White,
                RecordType.Remove));
        }
        public async Task Record(string input)
        {
            if (!isNeedRecord && isNeedRepeat)
            {
                return; 
            }

            await using var fileStream = new FileStream(_fileName + ".txt", FileMode.Append);
            await using var streamWriter = new StreamWriter(fileStream);

            await streamWriter.WriteLineAsync(input);
        }

        private string Deserialize()
        {
            if (!File.Exists(_fileName + ".txt"))
            {
                return null;
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
        private void Repeat()
        {
            var output = Deserialize();
            _output = output.Split(Environment.NewLine).ToList();
            foreach( var outputItem in _output)
            {
                if (outputItem == "\n")
                {
                    Debug.Log("/n");
                    continue;
                }
                if (output == null)
                {
                    Debug.Log("Конец реплея");
                    continue;
                }
                StartCoroutine(RepeatStepCoroutine(outputItem));
            }
        }
        private IEnumerator RepeatStepCoroutine(string input)
        {
            const string playerCommandPattern = @"Игрок (\d+) (передвинул|кликнул|съел|победил)";
            const string pairOfDigitsPattern = @"(\d+),(\d+)";
            _delayBetweenRepeat += _delayBetweenRepeat;
            yield return new WaitForSeconds(_delayBetweenRepeat);
            Coordinate destination = default;

            var playerCommandMatch = Regex.Match(input, playerCommandPattern);
            var command = playerCommandMatch.Groups[2].Value;

            var playerIndex = int.Parse(playerCommandMatch.Groups[1].Value);
            if (command == "победил")
            {
                Debug.Log(input);
            }


            var pairsOfDigits = Regex.Matches(input, pairOfDigitsPattern);

            var origin = (
                int.Parse(pairsOfDigits[0].Groups[1].Value),
                int.Parse(pairsOfDigits[0].Groups[2].Value)).ToCoordinate();

            if (command == "передвинул")
            {
                destination = (
                    int.Parse(pairsOfDigits[1].Groups[1].Value),
                    int.Parse(pairsOfDigits[1].Groups[2].Value)).ToCoordinate();
            }

            switch (command)
            {
                case "кликнул":
                    Debug.Log($"Player {playerIndex} {command} to {origin}");
                    RepeatStep?.Invoke(origin);
                    break;

                case "съел":
                    Debug.Log($"Player {playerIndex} {command} chip at {origin}");
                    RepeatStep?.Invoke(new Coordinate(-1, -1));
                    break;

                case "передвинул":
                    Debug.Log($"Player {playerIndex} {command} from {origin} to {destination}");
                    RepeatStep?.Invoke(destination);
                    break;

                default:
                    throw new NullReferenceException("Action is null");
            }

        }




    }
}

