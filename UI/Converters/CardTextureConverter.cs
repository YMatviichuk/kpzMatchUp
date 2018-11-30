using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using GameBin;

namespace UI.Converters
{
    public class CardTextureConverter : IValueConverter
    {
        private static BitmapImage texture =
            new BitmapImage(new Uri(@"C:\projects\univer\kpzMatchUp\UI\Resourcers\cardsTexture.jpg"));
        int baseX = 224;
        int baseY = 312;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (CardTypes?)value;

            CroppedBitmap cardTexture;
            switch (type)
            {
                case CardTypes.One:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 0, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Two:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 1, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Three:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 2, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Four:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 3, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Five:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 4, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Six:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 5, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Seven:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 6, baseY * 0, baseX, baseY));
                    break;

                case CardTypes.Eight:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 7, baseY * 0, baseX, baseY));
                    break;

                default:
                    cardTexture = new CroppedBitmap(texture, new Int32Rect(baseX * 0, baseY * 4, baseX, baseY));
                    break;

            }

            return cardTexture;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as object[];
        }
    }
}
