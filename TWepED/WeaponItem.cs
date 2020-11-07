using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWepED
{
    public partial class WeaponItem : UserControl
    {
        public Weapon curWeapon;
        public int ID;
        public WeaponItem(Weapon wep, int id)
        {
            InitializeComponent();

            label1.Text = wep.Name;
            ID = id;

            curWeapon = wep;
        }

        private void WeaponItem_Load(object sender, EventArgs e)
        {

        }
    }
}
