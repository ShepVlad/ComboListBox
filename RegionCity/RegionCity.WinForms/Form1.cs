using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity;
using RegionCity.DataLayer.DbLayer;

namespace RegionCity.WinForms
{
    public partial class Form1 : Form
    {
        RegionContext context;// = new RegionContext();

        BindingSource bsCity = new BindingSource();
       

        public Form1(string conString)
        {
            InitializeComponent();
            context = new RegionContext(conString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            context.Regions.Include(c => c.Cities).Load();
            cbRegion.DisplayMember = "RegionName";
            cbRegion.ValueMember = "RegionId";
            cbRegion.DataSource = context.Regions.Local;
         }

        private void cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRegion();

        }

        private void GetRegion()
        {
            int id = Convert.ToInt32(cbRegion.SelectedValue);
            var data = context.Cities.Local
                .Where(r => r.RegionId == id && r.CityName.Contains(txtFindCity.Text))
                .ToList();
            bsCity.DataSource = data;
            dgvCity.DataSource = bsCity;
            dgvCity.Columns["Region"].Visible = false;
            dgvCity.Columns["RegionId"].Visible = false;
            dgvCity.Columns["CityName"].Width = 177;
        }

        private void timerFind_Tick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbRegion.SelectedValue);
            var data = context.Cities.Local
                .Where(r => r.RegionId == id && r.CityName.Contains(txtFindCity.Text)).ToList();
            bsCity.DataSource = data;
            dgvCity.DataSource = bsCity;
            timerFind.Enabled = false;
        }

        private void txtFindCity_TextChanged(object sender, EventArgs e)
        {
            if (txtFindCity.Text.Length >= 2 ||
                txtFindCity.Text.Length == 0) timerFind.Enabled = true;
        }
    }
}
