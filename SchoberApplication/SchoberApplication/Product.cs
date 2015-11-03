using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoberApplication
{
    public partial class Product : Form
    {
        String name, colour, dimensions, type, activity;
        int weight, capacity;
        float price; 
        public Product()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        
    }
}
