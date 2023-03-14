using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private WriteableBitmap writeableBitmap;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderOptions.SetBitmapScalingMode(this.image, BitmapScalingMode.NearestNeighbor);
            RenderOptions.SetEdgeMode(this.image, EdgeMode.Aliased);
            this.writeableBitmap = new WriteableBitmap(
                (int)mainWindow.ActualWidth,
                (int)mainWindow.ActualHeight,
                96,
                96,
                PixelFormats.Bgr32,
                null
            );
            this.image.Source = writeableBitmap;
            this.image.Stretch = Stretch.None;
            this.image.HorizontalAlignment = HorizontalAlignment.Left;
            this.image.VerticalAlignment = VerticalAlignment.Top;

            //WBMDemo(writeableBitmap, (int)mainWindow.ActualWidth / 2, (int)mainWindow.ActualHeight / 2);
            //WBMDemo(writeableBitmap, 5, 5);

            this.image.MouseLeftButtonDown += new MouseButtonEventHandler(image_MouseLeftButtonDown);
            this.image.MouseRightButtonDown += new MouseButtonEventHandler(image_MouseRightButtonDown);

        }
        

        private void DrawSquare(MouseButtonEventArgs e)
        {
            int x = (int)e.GetPosition(this.image).X;
            int y = (int)e.GetPosition(this.image).Y;
            int w = (int)this.image.ActualWidth;
            int h = (int)this.image.ActualHeight;

            int ltrim = 0, rtrim = 0, ttrim = 0, btrim = 0; // left trim, ...
            if (x < 12) ltrim = 12 - x;
            if (x > w - 12) rtrim = w - x;
            if (y < 12) ttrim = 12 - y;
            if (y > h - 12) btrim = h - y;

            int color = 0x00ff00;

            try
            {
                writeableBitmap.Lock();

                unsafe
                {

                    IntPtr bbuff_ptr = writeableBitmap.BackBuffer;

                    for (int i=-(12-ttrim); i<12-btrim; i++)
                    {
                        for(int j=-(12-ltrim); j<12-rtrim; j++)
                        {
                            
                            IntPtr pixel_ptr = bbuff_ptr + (y + i) * writeableBitmap.BackBufferStride + 4 * (x + j);
                            *((int*)pixel_ptr) = color;
                        }
                    }
                    
                }
                writeableBitmap.AddDirtyRect(new Int32Rect(x-(12-ltrim), y-(12-ttrim), 25-ltrim-rtrim, 25-ttrim-btrim));
            }
            finally
            {
                writeableBitmap.Unlock();
            }
        }

        private void DrawCircle(MouseButtonEventArgs e)
        {

            int x = (int)e.GetPosition(this.image).X;
            int y = (int)e.GetPosition(this.image).Y;
            int w = (int)this.image.ActualWidth;
            int h = (int)this.image.ActualHeight;

            int ltrim = 0, rtrim = 0, ttrim = 0, btrim = 0;
            if (x < 12) ltrim = 12 - x;
            if (x > w - 12) rtrim = w - x;
            if (y < 12) ttrim = 12 - y;
            if (y > h - 12) btrim = h - y;

            int color = 0xff0000;

            try
            {
                writeableBitmap.Lock();

                unsafe
                {

                    IntPtr bbuff_ptr = writeableBitmap.BackBuffer;

                    for (int i = -(12 - ttrim); i < 12 - btrim; i++)
                    {
                        for (int j = -(12 - ltrim); j < 12 - rtrim; j++)
                        {
                            if (i * i + j * j > 144) continue;
                            IntPtr pixel_ptr = bbuff_ptr + (y + i) * writeableBitmap.BackBufferStride + 4 * (x + j);
                            *((int*)pixel_ptr) = color;
                        }
                    }

                }
                writeableBitmap.AddDirtyRect(new Int32Rect(x - (12 - ltrim), y - (12 - ttrim), 25 - ltrim - rtrim, 25 - ttrim - btrim));
            }
            finally
            {
                writeableBitmap.Unlock();
            }
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DrawSquare(e);
        }
        private void image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DrawCircle(e);
        }
    }
}
