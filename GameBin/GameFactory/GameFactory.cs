using System.Collections;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameBin
{
    public abstract class GameFactory
    {
        public abstract Board CreateBoard();
        public abstract Card CreateCard();
    }
}