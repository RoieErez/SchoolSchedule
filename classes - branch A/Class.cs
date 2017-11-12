using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_project2
{
    public class Class
    {
        private string id;
        public string Id { get { return id; } }
        private int capacity;
        public int Cacpacity { get { return capacity; } }
        private string accessories;
        public string Accessories { get { return accessories; } set { accessories = value; } }
        private bool lab;
        public bool Lab { get { return lab; } set { lab = value; } }
        public Class(string id, string accessories=null,bool lab = false,int capacity= 0)
        {/*constructor*/
            this.id = id;
            this.capacity = capacity;
            this.lab = lab;
            this.accessories = accessories;
        }
    }
}
