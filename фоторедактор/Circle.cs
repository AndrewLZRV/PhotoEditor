using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace фоторедактор
{
    class Circle
    {
        private Project project = new Project();

        private Point firstCoord;
        private Point secondCoord;
        public readonly Point defaultPoint = new Point(0,0);

        private Boolean isCreated;

        public Point FirstCoord
        {
            get
            {
                return this.firstCoord;
            }
            set
            {
                if (value is Point)
                {
                    this.firstCoord = value;
                }
                else
                {
                    project.Errors.Add("Ошибка установки координаты круга");
                }
            }
        }
        public Point SecondCoord
        {
            get
            {
                return this.secondCoord;
            }
            set
            {
                if (value is Point)
                {
                    this.secondCoord = value;
                }
                else
                {
                    project.Errors.Add("Ошибка установки координаты круга");
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
                if (value is Boolean)
                {
                    this.isCreated = value;
                }
                else
                {
                    project.Errors.Add("Ошибка установки логического значения");
                }
            }
        }
    }
}
