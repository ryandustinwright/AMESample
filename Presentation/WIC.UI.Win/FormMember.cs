﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WIC.UI.Win.Presenters;
using WIC.UI.Win.Views;
using WIC.UI.Process;

namespace WIC.UI.Win
{
    public partial class FormMember : Form, IMemberView
    {
        private MemberPresenter memberPresenter;

        public FormMember()
        {
            InitializeComponent();
            InitializeApply();

            // initialize presenter.
            memberPresenter = new MemberPresenter(this);
        }

        public int MemberId { get; set; }

        public string MemberName
        {
            get { return txtMemberName.Text.Trim(); }
            set { txtMemberName.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text.Trim(); }
            set { txtAddress.Text = value; }
        }

        public string City
        {
            get { return txtCity.Text.Trim(); }
            set { txtCity.Text = value; }
        }

        public string State
        {
            get { return cboState.SelectedValue.ToString(); }
            set { cboState.SelectedValue = value; }
        }

        public string Zip
        {
            get { return txtZIP.Text.Trim(); }
            set { txtZIP.Text = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            memberPresenter.Save();
            btnSave.Enabled = false; // For now, one save only.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void InitializeApply()
        {
            cboState.DataSource = MemberController.GetStates();
        }
    }
}