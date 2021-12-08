using System.Text;

namespace Domain.Entity.Bingo
{
    public class BingoBoard
    {
        private BingoNumber[][] _matrix;
        private BingoNumber? _winingNumber;
        private readonly HashSet<BingoNumber> _numbers;
        private readonly HashSet<BingoNumber> _markedNumbers;
        private readonly HashSet<BingoWinCondition> _winConditions;
        private readonly Dictionary<BingoNumber, List<BingoWinCondition>> _numberWinConditionsMap;
        
        private int UnmarkedNumbersSum { get => _numbers.Except(_markedNumbers).Sum(n => n.Value); }
        public bool Bingo { get; private set; }

        public BingoBoard(BingoNumber[][] boardMatrix)
        {
            _matrix = boardMatrix;
            _numbers = boardMatrix.SelectMany(n => n).ToHashSet();
            _markedNumbers = new HashSet<BingoNumber>();
            _numberWinConditionsMap = _numbers.ToDictionary(n => n, n => new List<BingoWinCondition>());
            _winConditions = new HashSet<BingoWinCondition>(); 
            for (int i = 0; i < boardMatrix.Length; i++)
            {
                var row = new BingoWinCondition(boardMatrix[i]);
                var column = new BingoWinCondition(
                    new[] {
                        boardMatrix[0][i],
                        boardMatrix[1][i],
                        boardMatrix[2][i],
                        boardMatrix[3][i],
                        boardMatrix[4][i],
                    }
                );

                _winConditions.Add(row);
                _winConditions.Add(column);

                _numberWinConditionsMap[boardMatrix[i][0]].Add(row);
                _numberWinConditionsMap[boardMatrix[i][1]].Add(row);
                _numberWinConditionsMap[boardMatrix[i][2]].Add(row);
                _numberWinConditionsMap[boardMatrix[i][3]].Add(row);
                _numberWinConditionsMap[boardMatrix[i][4]].Add(row);
                _numberWinConditionsMap[boardMatrix[0][i]].Add(column);
                _numberWinConditionsMap[boardMatrix[1][i]].Add(column);
                _numberWinConditionsMap[boardMatrix[2][i]].Add(column);
                _numberWinConditionsMap[boardMatrix[3][i]].Add(column);
                _numberWinConditionsMap[boardMatrix[4][i]].Add(column);
            }
        }

        public bool TryBingo(BingoNumber number)
        {
            if (!_numbers.Contains(number))
                return false;

            _markedNumbers.Add(number);

            var winConditions = _numberWinConditionsMap[number];

            if (winConditions.Any(w => w.Check(number)))
            {
                _winingNumber = number;
                Bingo = true;
            }

            return Bingo;
        }

        public int CalculateBoardPonts()
        {
            if (_winingNumber == null || !_winConditions.Any(w => w.IsFulfilled))
                throw new InvalidOperationException("This board has not won yet");

            return _winingNumber.Value * UnmarkedNumbersSum;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            
            foreach (var row in _matrix)
            {
                foreach (var number in row)
                {
                    var markedSymbol = _markedNumbers.Contains(number) ? '*' : ' ';
                    builder.Append($"{ number,2 }{ markedSymbol } ");
                }

                builder.AppendLine();
            }

            builder.AppendLine($"\nWinning Number: { _winingNumber,2 } ");
            builder.AppendLine($"Non-marked Sum: { UnmarkedNumbersSum } ");

            return builder.ToString();
        }
    }
}
