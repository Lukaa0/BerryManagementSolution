using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Libraries
{
    public partial class BreedEditForm : Form
    {
        public long Id;
        private Enums.DataChangeType _DataChangeType;
        private BM_Library_ServiceReference.Breed _Breed;
        public BreedEditForm()
        {
            InitializeComponent();
            this.Text = "ჯიშის დამატება";
            this._DataChangeType = Enums.DataChangeType.Insert;
            this._Breed = new BM_Library_ServiceReference.Breed();
        }

        public BreedEditForm(BM_Library_ServiceReference.Breed breed)
        {
            InitializeComponent();
            this.Text = "ჯიშის რედაქტირება";
            this._DataChangeType = Enums.DataChangeType.Update;
            this._Breed = breed;
            this.BreedNameTextBox.Text = breed.Breed_Name;
            
        }

        public BM_Library_ServiceReference.Breed breedObject
        {
            get { return this._Breed; }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            try
            {
                if (this._Breed == null)
                {
                    this._Breed = new BM_Library_ServiceReference.Breed();
                }
                this._Breed.Breed_Name = this.BreedNameTextBox.Text;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    switch (this._DataChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertBreed(this._Breed, ref errorMessage);
                            this._Breed.Breed_Id = this.Id;
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateBreed(this._Breed, ref errorMessage);
                            break;
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
                return;
            }
        }
    }
 }
