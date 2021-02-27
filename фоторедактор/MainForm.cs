using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;
using System.Web.Hosting;

namespace фоторедактор
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private readonly string slash = @"\";

        public PictureBox additionalPictureBox;

        //Экземпляр проекта
        private Project project = new Project();

        //Экземпляр истории действий
        private ActionHistory actionHistory = new ActionHistory();

        //Экземпляр и переменные выделения
        private Selection selection = new Selection();
        private Boolean selectMode = false;
        private Boolean onSelectStart = false;
        private Graphics addGraphics;

        //Переменные для рисования линии
        private Line line = new Line();
        private LineWidthSelector lineWidthSelector = new LineWidthSelector();
        private Boolean lineDrawMode = false;
        private Boolean onLineDrawingStart = false;

        //Переменные для рисования круга
        private Circle circle = new Circle();
        private Boolean circleDrawMode = false;
        private Boolean onCircleDrawStart = false;

        //экземпляры диалогов
        private readonly ColorDialog colorDialog = new ColorDialog();
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog();
        private readonly SaveFileDialog saveFileDialog = new SaveFileDialog();

        private void mainForm_Load(object sender, EventArgs e)
        {
            //Все первоначальные настройки интерфейса
            instrumentsPanel.BorderStyle = BorderStyle.Fixed3D;

            mainPictureBox.BorderStyle = BorderStyle.FixedSingle;

            firstColorPictureBox.BackColor = Color.White;
            firstColorPictureBox.BorderStyle = BorderStyle.FixedSingle;

            secondColorPictureBox.BackColor = Color.Black;
            secondColorPictureBox.BorderStyle = BorderStyle.FixedSingle;

            coordLb.Left = 3;
            coordLb.Text = "";

            //Начальные настройки переменных и объектов
            project.FirstColor = Color.White;
            project.SecondColor = Color.Black;

            project.Graphics = mainPictureBox.CreateGraphics();

            //Начальные настройки файлового диалога
            openFileDialog.InitialDirectory = @"c:\\";
            openFileDialog.Filter = "Images (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Открытие изображения";

            saveFileDialog.InitialDirectory = @"c:\\";
            saveFileDialog.Filter = "Images(*.bmp; *.jpg; *.png)| *.bmp; *.jpg; *.png | All files(*.*) | *.* ";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Сохранение изображения";
            
            //Загрузка стандартного белого изображения
            project.OriginalBitmap = (Bitmap) Image.FromFile(@"_common\default image.png");
            loadImage();
        }

        /*
         * Три метода ниже относятся к настройке цветов и смене их
         */
        private void firstColorPictureBox_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                project.FirstColor = colorDialog.Color;
                firstColorPictureBox.BackColor = project.FirstColor;
            }
            else
            {
                project.Errors.Add("Ошибка с установкой цвета");
            }
        }
        private void secondColorPictureBox_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                project.SecondColor = colorDialog.Color;
                secondColorPictureBox.BackColor = project.SecondColor;
            }
            else
            {
                project.Errors.Add("Ошибка с установкой цвета");
            }
        }
        private void changeColorsButton_Click(object sender, EventArgs e)
        {
            Color tmp = project.FirstColor;
            project.FirstColor = project.SecondColor;
            project.SecondColor = tmp;

            firstColorPictureBox.BackColor = project.FirstColor;
            secondColorPictureBox.BackColor = project.SecondColor;
        }

        // Метод выхода из приложения
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
         * Методы для заливки выделенной области
         */
        private void fillButton_Click(object sender, EventArgs e)
        {
            if (selection.IsCreated == true)
            {
                project.Graphics.FillRectangle(new SolidBrush(project.FirstColor),
                    selection.FirstCoord.X * (project.OriginalBitmap.PhysicalDimension.Width / mainPictureBox.ClientSize.Width),
                    selection.FirstCoord.Y * (project.OriginalBitmap.PhysicalDimension.Height / mainPictureBox.ClientSize.Height),
                    Math.Abs(selection.SecondCoord.X - selection.FirstCoord.X) * (project.OriginalBitmap.PhysicalDimension.Width / mainPictureBox.ClientSize.Width),
                    Math.Abs(selection.SecondCoord.Y - selection.FirstCoord.Y) * (project.OriginalBitmap.PhysicalDimension.Height / mainPictureBox.ClientSize.Height));
            }
            else if (selection.IsCreated == false)
            {
                project.Graphics.FillRectangle(new SolidBrush(project.FirstColor), 0, 0, project.OriginalBitmap.PhysicalDimension.Width, project.OriginalBitmap.PhysicalDimension.Height);
            }
            updatePictureBoxImage();
        }

        //Метод для включения выделения
        private void selectModeButton_Click(object sender, EventArgs e)
        {
            select();
        }

        //Метод для включения режима рисования линий
        private void drawLineButton_Click(object sender, EventArgs e)
        {
            drawLine();
        }

        //Метод для включения режима рисования круга
        private void circleDrawModeButton_Click(object sender, EventArgs e)
        {
            drawCircle();
        }

        /*
         * Методы для загрузки изображений из fileDialog
         * И метод загрузки из списка последних изображений
         */
        private void loadImageMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                char[] delimetr = { Convert.ToChar(slash) };
                try
                {
                    project.OriginalBitmap = new Bitmap(openFileDialog.FileName);
                    project.LastImages.Add(openFileDialog.FileName);
                    project.LastImagesMenuItem.Add(new ToolStripMenuItem(@"...\" + openFileDialog.FileName.Split(delimetr)[openFileDialog.FileName.Split(delimetr).Length - 1]));

                    imageToolStripMenu.DropDownItems.Add(project.LastImagesMenuItem[project.LastImagesMenuItem.Count - 1]);
                    project.LastImagesMenuItem[project.LastImagesMenuItem.Count - 1].Click += loadImageFromLastImagesMenuItem_Click;
                    project.LastImagesMenuItem[project.LastImagesMenuItem.Count - 1].Tag = project.LastImagesMenuItem.Count - 1;

                    loadImage();
                }
                catch (IOException error)
                {
                    Console.WriteLine(error.Data);
                }
            }
        }
        private void loadImageFromLastImagesMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem) sender;
            int tmpTag = Convert.ToInt32(menuItem.Tag);

            if (MessageBox.Show("Вы уверены, что хотите загрузить другое изображение", "Загрузка нового изображения", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    project.OriginalBitmap = new Bitmap(project.LastImages[tmpTag]);

                    loadImage();
                }
                catch (IOException error)
                {
                    Console.WriteLine(error.Data);
                }
            }
        }

        /*
         * Методы для обработки мыши на основном PictureBox
         */
        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
            coordLb.Text = "";
        }
        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            coordLb.Text = ("X: " + e.X + ", Y: " + e.Y);
            coordLb.Left = 3;
            coordLb.ForeColor = Color.Black;
            coordLb.BackColor = Color.LightGray;

            if (selection.IsCreated)
            {
                if (selection.XCoordinates.Contains(e.X) && selection.YCoordinates.Contains(e.Y))
                {
                    mainPictureBox.Cursor = Cursors.Cross;
                    coordLb.Text = ("(In selection), X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                }
                else
                {
                    mainPictureBox.Cursor = Cursors.Default;
                }
            }
            
        }

        /*
         * Три методв ниже присваиваются additionalPictureBox для того, чтобы реализовать функцию выделения на изображении
         * Для каждой сложной функции (текст, выделение, рисование и т.д.) будет расширятся возможности
         */
        private void AdditionalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectMode)
            {
                if (onSelectStart)
                {
                    coordLb.Text = ("Selection: X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                    coordLb.ForeColor = Color.White;
                    coordLb.BackColor = Color.Black;

                    selection.SecondCoord = new Point(e.X, e.Y);

                    Point tmp1 = selection.SecondCoord;
                    Point tmp2 = selection.FirstCoord;

                    selection.FirstCoord = new Point(Math.Min(tmp1.X, tmp2.X), Math.Min(tmp2.Y, tmp1.Y));
                    selection.SecondCoord = new Point(Math.Max(tmp1.X, tmp2.X), Math.Max(tmp2.Y, tmp1.Y));
                }
                else
                {
                    coordLb.Text = ("X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                    coordLb.ForeColor = Color.Black;
                    coordLb.BackColor = Color.LightGray;
                }
            }
            else if (lineDrawMode)
            {
                if (onLineDrawingStart)
                {
                    coordLb.Text = ("Line drawing: X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                    coordLb.ForeColor = Color.White;
                    coordLb.BackColor = Color.Black;

                    line.SecondCoord = new Point(e.X, e.Y);
                }
                else
                {
                    coordLb.Text = ("X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                    coordLb.ForeColor = Color.Black;
                    coordLb.BackColor = Color.LightGray;
                }
            }
            else if (circleDrawMode)
            {
                if (onCircleDrawStart)
                {
                    coordLb.Text = ("Line drawing: X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                    coordLb.ForeColor = Color.White;
                    coordLb.BackColor = Color.Black;

                    circle.SecondCoord = new Point(e.X, e.Y);

                    Point tmp1 = circle.SecondCoord;
                    Point tmp2 = circle.FirstCoord;

                    circle.FirstCoord = new Point(Math.Min(tmp1.X, tmp2.X), Math.Min(tmp2.Y, tmp1.Y));
                    circle.SecondCoord = new Point(Math.Max(tmp1.X, tmp2.X), Math.Max(tmp2.Y, tmp1.Y));
                }
                else
                {
                    coordLb.Text = ("X: " + e.X + ", Y: " + e.Y);
                    coordLb.Left = 3;
                    coordLb.ForeColor = Color.Black;
                    coordLb.BackColor = Color.LightGray;
                }
            }
        }
        private void AdditionalPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectMode)
            {
                selection.FirstCoord = new Point(e.X, e.Y);
                selection.SecondCoord = new Point(e.X, e.Y);
                selection.IsCreated = true;

                onSelectStart = true;
                selectionDrawerTimer.Start();
            }
            else if (lineDrawMode)
            {
                line.FirstCoord = new Point(e.X, e.Y);
                line.SecondCoord = new Point(e.X, e.Y);
                line.IsCreated = true;

                onLineDrawingStart = true;
                lineDrawTimer.Start();
            }
            else if (circleDrawMode)
            {
                circle.FirstCoord = new Point(e.X, e.Y);
                circle.SecondCoord = new Point(e.X, e.Y);
                circle.IsCreated = true;

                onCircleDrawStart = true;
                circleDrawTimer.Start();
            }
        }
        private void AdditionalPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectMode)
            {
                selection.SecondCoord = new Point(e.X, e.Y);
                selectionDrawerTimer.Enabled = false;
                onSelectStart = false;

                Pen pen = new Pen(Color.Black, 1);
                pen.DashPattern = new float[] { 5, 2, 5, 2 };

                addGraphics.DrawRectangle(pen, selection.FirstCoord.X, selection.FirstCoord.Y, (Math.Abs(selection.SecondCoord.X - selection.FirstCoord.X)), (Math.Abs(selection.SecondCoord.Y - selection.FirstCoord.Y)));

                selection.XCoordinates = new ArrayList();
                selection.YCoordinates = new ArrayList();
                selection.generateXRange();
                selection.generateYRange();
            }
            else if (lineDrawMode)
            {
                line.SecondCoord = new Point(e.X, e.Y);
                lineDrawTimer.Enabled = false;
                onLineDrawingStart = false;

                Pen pen = new Pen(Color.Black, 1);

                addGraphics.DrawLine(pen, line.FirstCoord, line.SecondCoord);
            }
            else if (circleDrawMode)
            {
                circle.SecondCoord = new Point(e.X, e.Y);
                circleDrawTimer.Enabled = false;
                onCircleDrawStart = false;

                Pen pen = new Pen(Color.Black, 1);

                addGraphics.DrawEllipse(pen, circle.FirstCoord.X, circle.FirstCoord.Y,
                    Math.Abs(circle.SecondCoord.X - circle.FirstCoord.X), Math.Abs(circle.SecondCoord.Y - circle.FirstCoord.Y));
            }
        }

        //Метод таймера для рисования выделения
        private void selectionDrawerTimer_Tick(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);
            pen.DashPattern = new float[] { 5, 2, 5, 2 };
            
            addGraphics.DrawRectangle(pen, selection.FirstCoord.X, selection.FirstCoord.Y, (Math.Abs(selection.SecondCoord.X - selection.FirstCoord.X)), (Math.Abs(selection.SecondCoord.Y - selection.FirstCoord.Y)));
            additionalPictureBox.Refresh();
        }

        //Метод другого таймера для рисования линии
        private void lineDrawTimer_Tick(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 1);

            addGraphics.DrawLine(pen, line.FirstCoord, line.SecondCoord);
            additionalPictureBox.Refresh();
        }

        //Метод таймера для рисования круга
        private void circleDrawTimer_Tick(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 1);

            pen2.DashPattern = new float[] { 5, 2, 5, 2 };

            addGraphics.DrawRectangle(pen1, circle.FirstCoord.X, circle.FirstCoord.Y,
                Math.Abs(circle.SecondCoord.X - circle.FirstCoord.X), Math.Abs(circle.SecondCoord.Y - circle.FirstCoord.Y));
            addGraphics.DrawEllipse(pen2, circle.FirstCoord.X, circle.FirstCoord.Y,
                Math.Abs(circle.SecondCoord.X - circle.FirstCoord.X), Math.Abs(circle.SecondCoord.Y - circle.FirstCoord.Y));
            additionalPictureBox.Refresh();
        }

        /*
         * Следующие строчки относятся к сохранению изображения на компьютер
         * */
        private void savePNGImageMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                FileStream fileStream = ((FileStream)saveFileDialog.OpenFile());

                project.OriginalBitmap.Save(fileStream, ImageFormat.Png);
            }
        }
        private void saveJPGImageMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                FileStream fileStream = ((FileStream)saveFileDialog.OpenFile());

                project.OriginalBitmap.Save(fileStream, ImageFormat.Jpeg);
            }
        }
        private void saveBMPImageMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                FileStream fileStream = ((FileStream)saveFileDialog.OpenFile());

                project.OriginalBitmap.Save(fileStream, ImageFormat.Bmp);
            }
        }

        /*
         * Далее идут собственные методы
         * */

        //Методы для реализации отдельных функций
        private void select()
        {
            if (selectMode == true)
            {
                selectMode = false;
                additionalPictureBox.Dispose();
                setInactiveStyle(null);
                selectModeButton.Text = "Выделение";

                if (selection.FirstCoord != selection.defaultPoint && selection.SecondCoord != selection.defaultPoint)
                {
                    selection.IsCreated = true;
                }
                else
                {
                    selection.IsCreated = false;
                }

                addGraphics.Clear(Color.Transparent);
            }
            else
            {
                selection = new Selection();
                selectMode = true;
                setInactiveStyle("selectModeButton");

                additionalPictureBox = new PictureBox();

                additionalPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                additionalPictureBox.Image = project.OriginalBitmap;
                additionalPictureBox.BorderStyle = BorderStyle.FixedSingle;
                additionalPictureBox.Width = mainPictureBox.Width;
                additionalPictureBox.Height = mainPictureBox.Height;
                additionalPictureBox.Left = mainPictureBox.Left;
                additionalPictureBox.Top = mainPictureBox.Top;
                additionalPictureBox.MouseUp += AdditionalPictureBox_MouseUp;
                additionalPictureBox.MouseDown += AdditionalPictureBox_MouseDown;
                additionalPictureBox.MouseMove += AdditionalPictureBox_MouseMove;
                mainPanel.Controls.Add(additionalPictureBox);
                additionalPictureBox.BringToFront();
                addGraphics = additionalPictureBox.CreateGraphics();
                selectModeButton.Text = "Готово";
            }
        }
        private void drawLine()
        {
            if (lineDrawMode == true)
            {
                if (lineWidthSelector.ShowDialog() == DialogResult.OK)
                {
                    line.Width = lineWidthSelector.WidthFinal;
                    Console.WriteLine("Width selected!");
                }

                lineDrawMode = false;
                additionalPictureBox.Dispose();
                setInactiveStyle(null);
                drawLineButton.Text = "Нарисовать линию";

                if (line.FirstCoord != line.defaultPoint || line.SecondCoord != line.defaultPoint)
                {
                    line.IsCreated = true;
                    project.Graphics.DrawLine(new Pen(project.FirstColor, line.Width), line.FirstCoord.X * (project.OriginalBitmap.PhysicalDimension.Width / mainPictureBox.ClientSize.Width),
                        line.FirstCoord.Y * (project.OriginalBitmap.PhysicalDimension.Height / mainPictureBox.ClientSize.Height),
                        line.SecondCoord.X * (project.OriginalBitmap.PhysicalDimension.Width / mainPictureBox.ClientSize.Width),
                        line.SecondCoord.Y * (project.OriginalBitmap.PhysicalDimension.Height / mainPictureBox.ClientSize.Height));
                }
                else
                {
                    line.IsCreated = false;
                }
                updatePictureBoxImage();
            }
            else
            {
                line = new Line();
                lineDrawMode = true;
                setInactiveStyle("drawLineButton");

                additionalPictureBox = new PictureBox();

                additionalPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                additionalPictureBox.Image = project.OriginalBitmap;
                additionalPictureBox.BorderStyle = BorderStyle.FixedSingle;
                additionalPictureBox.Width = mainPictureBox.Width;
                additionalPictureBox.Height = mainPictureBox.Height;
                additionalPictureBox.Left = mainPictureBox.Left;
                additionalPictureBox.Top = mainPictureBox.Top;
                additionalPictureBox.MouseUp += AdditionalPictureBox_MouseUp;
                additionalPictureBox.MouseDown += AdditionalPictureBox_MouseDown;
                additionalPictureBox.MouseMove += AdditionalPictureBox_MouseMove;
                mainPanel.Controls.Add(additionalPictureBox);
                additionalPictureBox.BringToFront();
                addGraphics = additionalPictureBox.CreateGraphics();
                addGraphics = additionalPictureBox.CreateGraphics();
                drawLineButton.Text = "Готово";
            }
        }
        private void drawCircle()
        {
            if (circleDrawMode == true)
            {
                circleDrawMode = false;
                additionalPictureBox.Dispose();
                setInactiveStyle(null);
                circleDrawModeButton.Text = "Нарисовать круг";

                if (circle.FirstCoord != circle.defaultPoint || circle.SecondCoord == circle.defaultPoint)
                {
                    circle.IsCreated = true;

                    project.Graphics.FillEllipse(new SolidBrush(project.FirstColor),
                        circle.FirstCoord.X * (project.OriginalBitmap.PhysicalDimension.Width / mainPictureBox.ClientSize.Width),
                        circle.FirstCoord.Y * (project.OriginalBitmap.PhysicalDimension.Height / mainPictureBox.ClientSize.Height),
                        (project.OriginalBitmap.PhysicalDimension.Width / mainPictureBox.ClientSize.Width) * Math.Abs(circle.SecondCoord.X - circle.FirstCoord.X),
                        (project.OriginalBitmap.PhysicalDimension.Height / mainPictureBox.ClientSize.Height) * Math.Abs(circle.SecondCoord.Y - circle.FirstCoord.Y));


                }
            }
            else
            {
                circle = new Circle();
                circleDrawMode = true;
                setInactiveStyle("circleDrawModeButton");

                circle.FirstCoord = new Point(0, 0);
                circle.SecondCoord = new Point(0, 0);

                additionalPictureBox = new PictureBox();

                additionalPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                additionalPictureBox.Image = project.OriginalBitmap;
                additionalPictureBox.BorderStyle = BorderStyle.FixedSingle;
                additionalPictureBox.Width = mainPictureBox.Width;
                additionalPictureBox.Height = mainPictureBox.Height;
                additionalPictureBox.Left = mainPictureBox.Left;
                additionalPictureBox.Top = mainPictureBox.Top;
                additionalPictureBox.MouseUp += AdditionalPictureBox_MouseUp;
                additionalPictureBox.MouseDown += AdditionalPictureBox_MouseDown;
                additionalPictureBox.MouseMove += AdditionalPictureBox_MouseMove;
                mainPanel.Controls.Add(additionalPictureBox);
                additionalPictureBox.BringToFront();
                addGraphics = additionalPictureBox.CreateGraphics();
                addGraphics = additionalPictureBox.CreateGraphics();

                circleDrawModeButton.Text = "Готово";
            }
        }

        private void updatePictureBoxImage()
        {
            project.writeBitmapToImg();
            mainPictureBox.Image = project.OriginalImage;
            actionHistory.LastImages.Add(project.OriginalImage);
        }

        private void loadImage()
        {
            project.writeBitmapToImg();

            float k = project.OriginalBitmap.PhysicalDimension.Width / project.OriginalBitmap.PhysicalDimension.Height;
            float defaultK = (float)(16.0 / 9.0);
            Console.WriteLine("{0} {1}", k, defaultK);
            
            if (k != defaultK)
            {
                MessageBox.Show("К сожалению на данном этапе разработки поддерживаются только форматы 16:9. Позже будут доступны другие форматы.", "Ошибка загрузки изображения", MessageBoxButtons.OK);
            }
            else
            {
                project.Graphics = Graphics.FromImage(project.OriginalImage);
                project.Graphics.DrawImage(project.OriginalImage, new Point(0, 0));
                updatePictureBoxImage();
            }
        }

        private void setInactiveStyle(string nameSelected)
        {
            if (nameSelected == null)
            {
                foreach (var control in instrumentsPanel.Controls)
                {
                    if (control is Button)
                    {
                        ((Button)control).Enabled = true;
                    }
                }
            }
            else
            {
                foreach (var control in instrumentsPanel.Controls)
                {
                    if (control is Button)
                    {
                        if (((Button)control).Name == nameSelected)
                        {
                            continue;
                        }
                        else
                        {
                            ((Button)control).Enabled = false;
                        }
                    }
                }
            }
        }
    }
}