using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_album
{
    internal class Album
    {
        private int numOfPages;

        public Album() 
        {
            numOfPages = 16;
        }
        public Album(int numOfPages)
        {
            this.numOfPages = numOfPages;
        }
        public int getNumOfPages()
        {
            return numOfPages;
        }
    }
}
