using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Project_2
{
    class Headphone : product
    {
        private int frequency;
        private int impedance;
        private bool wireless;
        private bool noiseCancelling;

        public Headphone(string type, string model, string brand, int id, int price, int frequency, int impedance, bool wireless, bool noiseCancelling)
        {
            this.Type = type;
            this.Model = model;
            this.Brand = brand;
            this.ID = id;
            this.Price = price;
            this.Frequency = frequency;
            this.Impedance = impedance;
            this.Wireless = wireless;
            this.NoiseCancelling = noiseCancelling;
        }

        private int Frequency
        {
            get { return this.frequency; }
            set { this.frequency = value; }
        }

        private int Impedance
        {
            get { return this.impedance; }
            set { this.impedance = value; }
        }

        private bool Wireless
        {
            get { return this.wireless; }
            set { this.wireless = value; }
        }

        private bool NoiseCancelling
        {
            get { return this.noiseCancelling; }
            set { this.noiseCancelling = value; }
        }

        public string Data()
        {
            string data = $"{this.Type}%{this.Brand}%{this.Model}%{this.ID}%{this.Price} $%{this.Frequency} Hz%{this.Impedance} Ohms%{this.Wireless}%{this.NoiseCancelling}";
            return data;
        }
    }
}
