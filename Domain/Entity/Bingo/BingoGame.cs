using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Bingo
{
    public class BingoGame
    {
        private IList<BingoBoard> _boards;

        public BingoGame(IList<BingoBoard> boards)
        {
            _boards = boards;
        }

        public IList<BingoBoard> DrawNumber(BingoNumber number)
        {
            return _boards
                .Where(b => !b.Bingo && b.TryBingo(number))
                .ToList();
        }

    }
}
