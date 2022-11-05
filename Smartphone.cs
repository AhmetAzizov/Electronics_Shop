using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Project_2
{
    class Smartphone : product
    {
        private string os;
        private int ram;
        private bool dualSim;
        private bool have5G;

        public Smartphone(string type, string model, string brand, int id, int price, string os, int ram, bool dualSim, bool have5G)
        {
            this.Type = type;
            this.Model = model;
            this.Brand = brand;
            this.ID = id;
            this.Price = price;
            this.OS = os;
            this.RAM = ram;
            this.DualSim = dualSim;
            this.Have5G = have5G;
        }

        private string OS
        {
            get { return this.os; }
            set { this.os = value; }
        }

        private int RAM
        {
            get { return this.ram; }
            set { this.ram = value; }
        }

        private bool DualSim
        {
            get { return this.dualSim; }
            set { this.dualSim = value; }
        }

        private bool Have5G
        {
            get { return this.have5G; }
            set { this.have5G = value; }
        }

        public string Data()
        {
            string data = $"{this.Type}%{this.Brand}%{this.Model}%{this.ID}%{this.Price} $%{this.OS}%{this.RAM} GB%{this.DualSim}%{this.Have5G}";
            return data;
        }
    }
}
