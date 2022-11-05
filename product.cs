using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Project_2
{
    class product
    {
        string type, model, brand;
        int id, price;

        protected string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        protected string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        protected string Brand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }

        protected int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        protected int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
