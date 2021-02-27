using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace фоторедактор
{
    class ActionHistory
    {
        private List<Image> lastImages = new List<Image>();

        public List<Image> LastImages
        {
            get
            {
                return this.lastImages;
            }
        }
    }
}
