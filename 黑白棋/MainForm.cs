using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace 黑白棋
{
    public partial class MainForm : Form
    {
        bool Flag = true;
        Graphics mGraphics = null;
        Brush Black = Brushes.Black;
        Brush White = Brushes.White;
        Type[,] mType = new Type[10, 10];
        Pen mPen = new Pen(Color.Black);
        Rectangle mEllipse = new Rectangle();
        Bitmap mBitmap = new Bitmap(398, 398);
        private enum Type : byte
        {
            Empty, White, Black
        }
        public MainForm()
        {
            InitializeComponent();
            mEllipse.Width = 32;
            mEllipse.Height = 32;
            MainPanel.Image = mBitmap;
            mGraphics = Graphics.FromImage(MainPanel.Image);
            mGraphics.PixelOffsetMode = (PixelOffsetMode)2;
            mGraphics.SmoothingMode = (SmoothingMode)2;
            RefreshScreen();
        }
        private void RefreshScreen()
        {
            MainPanel.Image = mBitmap;
            mGraphics.Clear(Color.BurlyWood);
            for (int i = 39; i < 360; i += 40)
            {
                mGraphics.DrawLine(mPen, 0, i, 398, i);
                mGraphics.DrawLine(mPen, i, 0, i, 398);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mEllipse.X = i * 40 + 3;
                    mEllipse.Y = j * 40 + 3;
                    bool bWhite = mType[i, j] == Type.White;
                    bool bBlack = mType[i, j] == Type.Black;
                    if (bWhite) mGraphics.FillEllipse(White, mEllipse);
                    if (bBlack) mGraphics.FillEllipse(Black, mEllipse);
                }
            }
        }
        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (mType[e.X / 40, e.Y / 40] == Type.Empty)
            {
                Type T = Flag ? Type.Black : Type.White;
                mType[e.X / 40, e.Y / 40] = T;
                Flag = !Flag;
                RefreshScreen();
            }
        }
    }
}