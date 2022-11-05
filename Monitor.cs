using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Project_2
{
    class Monitor : product
    {
        private int refreshRate;
        private int responseTime;
        private string panelType;
        public bool hdr;

        public Monitor(string type, string model, string brand, int id, int price, int refreshRate, int responseTime, string panelType, bool hdr)
        {
            this.Type = type;
            this.Model = model;
            this.Brand = brand;
            this.ID = id;
            this.Price = price;
            this.RefreshRate = refreshRate;
            this.ResponseTime = responseTime;
            this.PanelType = panelType;
            this.HDR = hdr;
        }

        public Monitor() { }

        public int RefreshRate
        {
            get { return this.refreshRate; }
            set { this.refreshRate = value; }
        }

        public int ResponseTime
        {
            get { return this.responseTime; }
            set { this.responseTime = value; }
        }

        public string PanelType
        {
            get { return this.panelType; }
            set { this.panelType = value; }
        }

        public bool HDR
        {
            get { return this.hdr; }
            set { this.hdr = value; }
        }

        public string Data()
        {
            string data = $"{this.Type}%{this.Brand}%{this.Model}%{this.ID}%{this.Price} $%{this.RefreshRate} Hz%{this.ResponseTime} ms%{this.PanelType}%{this.HDR}";
            return data;
        }
    }
}
