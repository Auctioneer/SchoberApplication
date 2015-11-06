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

        //private Boolean checkMissing()
        //{
        //    helpMissing.Visible = false;
         
        //    foreach(TextBox in this.Controls)
        //    if (TextName.Text.Length == 0)
        //    {
        //        helpMissingUsernameLabel.Visible = true;
        //        cTextUsername.Focus();
        //        return true;
        //    }

        //    if (cTextPassword.Text.Length == 0)
        //    {
        //        helpMissingPasswordLabel.Visible = true;
        //        cTextPassword.Focus();
        //        return true;
        //    }
        //    return false;
        //}

        public String getName()

        {
            return name;
        }
        public String getColour()
        {
            return colour;
        }
        public String getDimensions()
        {
            return dimensions;
        }
        public String getType()
        {
            return type;
        }
        public String getActivity()
        {
            return activity;
        }


    }
}
