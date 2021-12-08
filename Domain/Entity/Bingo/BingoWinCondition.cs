using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bingo
{
    public class BingoWinCondition
    {
        private int _boardNumbersSum = 0;
        private HashSet<BingoNumber> _boardNumbersSet;
        
        public bool IsFulfilled { get => _boardNumbersSum == 0; }
        public IList<BingoNumber> BoardNumbers { get; private set; }


        public BingoWinCondition(IList<BingoNumber> boardNumbers)
        {
            if (boardNumbers == null) throw new ArgumentException($"Must not be null: { nameof(boardNumbers) }");
            if (boardNumbers.Count != 5) throw new ArgumentException($"Must contain exactly 5 elements: { nameof(boardNumbers) }");

            BoardNumbers = boardNumbers;
            _boardNumbersSet = boardNumbers.ToHashSet();
            _boardNumbersSum = boardNumbers.Sum(bn => bn.Value);

        }

        public bool Check(BingoNumber number)
        {
            if (_boardNumbersSet.Contains(number))
                _boardNumbersSum -= number.Value;

            return IsFulfilled;
        }
    }
}
