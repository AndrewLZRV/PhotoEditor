using System;
using System.Collections;
using System.Drawing;

namespace фоторедактор
{
    class Selection
    {

        public Selection()
        {
            this.firstCoordinate = new Point(0, 0);
            this.secondCoordinate = new Point(0, 0);
            this.xCoordinates = null;
            this.yCoordinates = null;
            isCreated = false;
        }

        /// <summary>
        /// Экземпляр проэкта для работы с ошибками
        /// </summary>
        private Project project = new Project();

        /// <summary>
        /// Массивы для хранения координат выделения
        /// </summary>
        private Point firstCoordinate = new Point(0,0);
        private Point secondCoordinate = new Point(0,0);
        public readonly Point defaultPoint = new Point(0, 0);

        private bool isCreated = false;

        private ArrayList xCoordinates = null;
        private ArrayList yCoordinates = null;

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

        public ArrayList XCoordinates
        {
            get
            {
                return this.xCoordinates;
            }
            set
            {
                this.xCoordinates = value;
            }
        }

        public ArrayList YCoordinates
        {
            get
            {
                return this.yCoordinates;
            }
            set
            {
                this.yCoordinates = value;
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

        public void generateXRange()
        {
            int temp = firstCoordinate.X;
            while (temp <= secondCoordinate.X)
            {
                xCoordinates.Add(temp);
                temp++;
            }
        }

        public void generateYRange()
        {
            int temp = firstCoordinate.Y;
            while (temp <= secondCoordinate.Y)
            {
                yCoordinates.Add(temp);
                temp++;
            }
        }
    }
}
