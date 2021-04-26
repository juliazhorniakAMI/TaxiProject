using NewTaxiProject.AbstractFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxiProject_2._1.Models;
using TaxiProject_2._1.Repository;

namespace UserWinForms
{
    public partial class Form1 : Form
    {
        readonly IRepository<Taxi> taxirepository;
        readonly IRepository<DriverCar> drcarrepository;
        readonly IRepository<Bus> busRepository;


        readonly IRepository<DriverBus> driverBUSRepository;
        BindingSource bindingSource = new BindingSource();
        
        public Form1()

        {
            taxirepository = Choose_Type.ChooseType().TaxiRep();
            drcarrepository = Choose_Type.ChooseType().DriverCarRep();
            busRepository = Choose_Type.ChooseType().BusRep();
            driverBUSRepository = Choose_Type.ChooseType().DriverBusRep();
           

            InitializeComponent();
            textId.Text = "Enter id";
            textMake.Text = "Enter make";
            textNumber.Text = "Enter number";
          

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView6.DataSource = taxirepository.Ent;
            dataGridView5.DataSource = drcarrepository.Ent;
            dataGridView7.DataSource = busRepository.Ent;
            dataGridView8.DataSource = driverBUSRepository.Ent;


        }


     



        private void button2_Click(object sender, EventArgs e)

        {

            var nameoftaxi = TaxiMake.Text;
            var client = Client.Text;
            var address = Address.Text;

            if (radioButton3.Checked)
            {
                for (int i = 0; i < taxirepository.Ent.Count(); i++)
                {

                    if (nameoftaxi == taxirepository.Ent[i].Make)
                    {





                        int rowindex = i;
                        dataGridView6.DataSource = bindingSource.DataSource;
                        bindingSource.DataSource = taxirepository.Ent;
                        
                        bindingSource.RemoveAt(rowindex);
                        dataGridView6.DataSource = taxirepository.Ent;
                        //taxirepository.deleteByIndex(rowindex);
                        dataGridView6.Refresh();
                        dataGridView5.DataSource = bindingSource.DataSource;
                        bindingSource.DataSource = drcarrepository.Ent;
                        bindingSource.RemoveAt(rowindex);
                       
                        dataGridView5.DataSource = drcarrepository.Ent;
                        // drcarrepository.deleteByIndex(rowindex);
                        dataGridView5.Refresh();
                    }
                }
            }
            if (radioButton4.Checked)
            {
                for (int i = 0; i < busRepository.Ent.Count(); i++)
                {

                    if (nameoftaxi == busRepository.Ent[i].Make)
                    {





                        int rowindex = i;
                        dataGridView7.DataSource = bindingSource.DataSource;
                        bindingSource.DataSource = busRepository.Ent;
                        bindingSource.RemoveAt(rowindex);
                        dataGridView7.DataSource = busRepository.Ent;
                        //taxirepository.deleteByIndex(rowindex);
                        dataGridView7.Refresh();
                        dataGridView8.DataSource = bindingSource.DataSource;
                        bindingSource.DataSource = driverBUSRepository.Ent;
                        bindingSource.RemoveAt(rowindex);
                        dataGridView8.DataSource = driverBUSRepository.Ent;
                        // drcarrepository.deleteByIndex(rowindex);
                        dataGridView8.Refresh();
                    }
                }
            }
            try
            {


                using (StreamWriter sw = new StreamWriter(@"C:\c#\NewTaxiProject\TaxiProjectUser\bin\Debug\Client.txt", false))
                {


                    Client c = new Client(0, client, address);
                    sw.WriteLine(client + " " + address);
                    // Console.WriteLine($"- - - - - - >  You: {firstName},on the street {address},have rented a taxi: {nameoftaxi} and been added to base__\n");
                    MessageBox.Show($"- - - {client} have been Successfully added to base");

                }

            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            taxirepository.Ent.Clear();
            drcarrepository.Ent.Clear();
           busRepository.Ent.Clear();
            driverBUSRepository.Ent.Clear();
            taxirepository.ReadFromStorage();
            drcarrepository.ReadFromStorage();
            busRepository.ReadFromStorage();
            driverBUSRepository.ReadFromStorage();

            dataGridView6.DataSource = bindingSource.DataSource;
            bindingSource.DataSource = taxirepository.Ent;
      
            dataGridView6.DataSource = taxirepository.Ent;
            dataGridView6.Refresh();

            dataGridView5.DataSource = bindingSource.DataSource;
            bindingSource.DataSource = drcarrepository.Ent;

            dataGridView5.DataSource = drcarrepository.Ent;
            dataGridView5.Refresh();

            dataGridView7.DataSource = bindingSource.DataSource;
            bindingSource.DataSource = busRepository.Ent;

            dataGridView7.DataSource = busRepository.Ent;

            dataGridView7.Refresh();

            dataGridView8.DataSource = bindingSource.DataSource;
            bindingSource.DataSource = driverBUSRepository.Ent;

            dataGridView8.DataSource = driverBUSRepository.Ent;
            dataGridView8.Refresh();
        }

     

      
      
        private void textId_Enter(object sender, EventArgs e)
        {
            if (textId.Text == "Enter id")
            {

                textId.Text = "";
              
            }
        }

        private void textId_Leave(object sender, EventArgs e)
        {
            if (textId.Text == "")
            {

                textId.Text = "Enter id";
                textId.ForeColor = Color.Gray;
            }
        }

       

        private void textMake_Leave(object sender, EventArgs e)
        {
            if (textMake.Text == "")
            {

                textMake.Text = "Enter make";
                textMake.ForeColor = Color.Gray;
            }
        }

     

      

        private void textMake_Enter(object sender, EventArgs e)
        {
            if (textMake.Text == "Enter make")
            {

                textMake.Text = "";

            }

        }

        private void textNumber_Enter(object sender, EventArgs e)
        {
            if (textNumber.Text == "Enter number")
            {

                textNumber.Text = "";

            }
        }

        private void textNumber_Leave_1(object sender, EventArgs e)
        {
            if (textNumber.Text == "")
            {

                textNumber.Text = "Enter number";
                textNumber.ForeColor = Color.Gray;
            }
        }

     

      

        private void button4_Click_1(object sender, EventArgs e)
        {
            var name = textBox3.Text;
            int rating = Convert.ToInt32(textBox1.Text);



            if (radioButton6.Checked)
            {
                for (int i = 0; i < drcarrepository.Ent.Count(); i++)
                {
                    if ((drcarrepository.Ent[i]).Name == name)
                    {


                        drcarrepository.ChangeRateVehicle(i, rating);


                        // drcarrepository.deleteByIndex(rowindex);
                        dataGridView5.Refresh();
                        break;
                    }
                }
            }
            if (radioButton5.Checked)
            {
                for (int i = 0; i < driverBUSRepository.Ent.Count(); i++)
                {
                    if ((driverBUSRepository.Ent[i]).Name == name)
                    {

                        driverBUSRepository.ChangeRateVehicle(i, rating);
                        dataGridView8.Refresh();
                        break;
                    }
                }

            }
            MessageBox.Show("Successfully changed");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textId.Text == "Enter id" || textId.Text == "")
            {


                MessageBox.Show("Enter id");
                return;
            }
            if (textMake.Text == "Enter make" || textMake.Text == "")
            {


                MessageBox.Show("Enter make");
                return;
            }
            if (textNumber.Text == "Enter number" || textNumber.Text == "")
            {


                MessageBox.Show("Enter number");
                return;
            }

            if (radioButton1.Checked)
            {
                int id = Convert.ToInt32(textId.Text);
                var make = textMake.Text ?? "";
                int number = Convert.ToInt32(textNumber.Text);
                var color = textColor.Text;
                int speed = Convert.ToInt32(textMaxSpeed.Text);
                dataGridView6.DataSource = bindingSource.DataSource;
                bindingSource.DataSource = taxirepository.Ent;

                bindingSource.Add(new Taxi(id, make, number, color, speed));
                dataGridView6.DataSource = taxirepository.Ent;
                //taxirepository.deleteByIndex(rowindex);
                dataGridView6.Refresh();


                var name = textName.Text ?? "";
                int rate = Convert.ToInt32(textNumber.Text);
                int price = Convert.ToInt32(textNumber.Text);
                dataGridView5.DataSource = bindingSource.DataSource;
                bindingSource.DataSource = drcarrepository.Ent;

                bindingSource.Add(new DriverCar(id, name, rate, price));
                dataGridView5.DataSource = drcarrepository.Ent;

                dataGridView5.Refresh();


                MessageBox.Show("Successfully added");



            }

            if (radioButton2.Checked)
            {
                int id = Convert.ToInt32(textId.Text);
                var make = textMake.Text ?? "";
                int number = Convert.ToInt32(textNumber.Text);
                var color = textColor.Text;
                int speed = Convert.ToInt32(textMaxSpeed.Text);
                dataGridView7.DataSource = bindingSource.DataSource;
                bindingSource.DataSource = busRepository.Ent;

                bindingSource.Add(new Bus(id, make, number, color, speed));
                dataGridView7.DataSource = busRepository.Ent;

                dataGridView7.Refresh();



                var name = textName.Text ?? "";
                int rate = Convert.ToInt32(textNumber.Text);
                int price = Convert.ToInt32(textNumber.Text);
                dataGridView8.DataSource = bindingSource.DataSource;
                bindingSource.DataSource = driverBUSRepository.Ent;

                bindingSource.Add(new DriverBus(id, name, rate, price));
                dataGridView8.DataSource = driverBUSRepository.Ent;

                dataGridView8.Refresh();


                MessageBox.Show("Successfully added");



            }




        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
