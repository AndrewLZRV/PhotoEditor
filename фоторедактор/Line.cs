using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фоторедактор
{
    class Line
    {
        /// <summary>
        /// Экземпляр проэкта для работы с ошибками
        /// </summary>
        private Project project = new Project();

        /// <summary>
        /// Массивы для хранения координат линии
        /// </summary>
        private Point firstCoordinate = new Point(0, 0);
        private Point secondCoordinate = new Point(0, 0);
        public readonly Point defaultPoint = new Point(0, 0);

        private byte width = 3;

        private bool isCreated = false;

        public Point FirstCoord
        {
            get
            {
                return this.firstCoordinate;
            }
            set
            {
                if (value is Point)
                {
                    this.firstCoordinate = value;
                }
                else
                {
                    project.Errors.Add("Ошибка установки первой координаты выделенияЫ");
                }
            }
        }

        public Point SecondCoord
        {
            get
            {
                return this.secondCoordinate;
            }
            set
            {
                if (value is Point)
                {
                    this.secondCoordinate = value;
                }
                else
                {
                    project.Errors.Add("Ошибка с установкой второй координаты выделения");
                }
            }
        }

        public Boolean IsCreated
        {
            get
            {
                return this.isCreated;
            }
            set
            {
                if (value is bool)
                {
                    this.isCreated = value;
                }
                else
                {
                    project.Errors.Add("Ошиб");
                }
            }
        }

        public byte Width
        {
            get
            {
                return this.width;
            }           
            set
            {
                if (value is byte)
                {
                    this.width = value;
                }
                else
                {
                    project.Errors.Add("Ошибка установки толщины линии");
                }
            }
        }
    }
}
