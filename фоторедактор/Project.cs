using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace фоторедактор
{   
    [Serializable]
    class Project
    {
        /// <summary>
        /// Основная графика приложения
        /// </summary>
        Graphics mainGraphics;

        /// <summary>
        /// Массив ошибок
        /// </summary>
        private List <string> errors = new List <string> ();

        /// <summary>
        /// Переменные для хранения карт изображений
        /// </summary>
        private Bitmap originalBitmap;

        /// <summary>
        /// Переменные для хранения самих изображений
        /// </summary>
        private Image originalImage;

        private List <String> lastImages = new List <String> ();
        private List<ToolStripMenuItem> lastImagesMenuItem = new List<ToolStripMenuItem>();

        /// <summary>
        /// Переменные для хранения цветов
        /// </summary>
        private Color firstColor = Color.White;
        private Color secondColor = Color.Black;

        /// <summary>
        /// Переменная для обозначения "есть ли выделение"
        /// </summary>
        private Boolean selection = false;

        /// <summary>
        /// Переменная для хранения строкового инструмента
        /// </summary>
        private String usedInstrument = "";

        /// <summary>
        /// Все get и set
        /// </summary>
        
        public Color FirstColor
        {
            get
            {
                return this.firstColor;
            }
            set
            {
                if (value is Color)
                {
                    this.firstColor = value;
                }
                else
                {
                    this.errors.Add("Ошибка установки цвета");
                }
            }
        }

        public Color SecondColor
        {
            get
            {
                return this.secondColor;
            }
            set
            {
                if (value is Color)
                {
                    this.secondColor = value;
                }
                else
                {
                    this.errors.Add("Ошибка установки цвета");
                }
            }
        }

        public List <String> Errors
        {
            get
            {
                return this.errors;
            }
            set
            {
                if (value is List<String>)
                {
                    this.errors = value;
                }
                else
                {
                    this.errors.Add("Ошибка добавления ошибки в error-list");
                }
            }
        }

        public Graphics Graphics
        {
            get
            {
                return this.mainGraphics;
            }
            set
            {
                if (value is Graphics)
                {
                    this.mainGraphics = value;
                }
                else
                {
                    this.errors.Add("Ошибка присваивания основного графического поля");
                }
            }
        }

        public Bitmap OriginalBitmap
        {
            get
            {
                return this.originalBitmap;
            }
            set
            {
                if (value is Bitmap)
                {
                    this.originalBitmap = value;
                    this.originalImage = value;
                }
                else
                {
                    this.errors.Add("Ошибка загрузки битовой карты");
                }
            }
        }

        public Image OriginalImage
        {
            get
            {
                return this.originalImage;
            }
            set
            {
                if (value is Image)
                {
                    this.originalImage = value;
                }
                else
                {
                    this.errors.Add("Ошибка загрузки изображения");
                }
            }
        }

        public Boolean Selection
        {
            get
            {
                return this.selection;
            }
            set
            {
                if (value is Boolean)
                {
                    this.selection = value;
                }
                else
                {
                    this.errors.Add("Ошибка проверки наличия выделения");
                }
            }
        }

        public List <String> LastImages
        {
            get
            {
                return this.lastImages;
            }
            set
            {
                if (value is List<String>)
                {
                    this.lastImages = value;
                }
                else
                {
                    this.errors.Add("Ошибка подгрузки списка последних изображений");
                }
            }
        }

        public List <ToolStripMenuItem> LastImagesMenuItem
        {
            get
            {
                return this.lastImagesMenuItem;
            }
            set
            {
                if (value is List <ToolStripMenuItem>)
                {
                    this.lastImagesMenuItem = value;
                }
                else
                {
                    this.errors.Add("Ошибка подгрузки кнопок для последних изображений");
                }
            }
        }

        public void writeBitmapToImg()
        {
            this.OriginalImage = this.OriginalBitmap;
        }

        public void loadDataFormObject(Project file)
        {
            this.firstColor = file.FirstColor;
            this.secondColor = file.SecondColor;

            this.errors = file.Errors;

            this.mainGraphics = file.Graphics;

            this.originalBitmap = file.OriginalBitmap;
            this.originalImage = file.OriginalImage;

            this.selection = file.Selection;

            this.lastImages = file.LastImages;
            this.lastImagesMenuItem = file.LastImagesMenuItem;
        }
    }
}
