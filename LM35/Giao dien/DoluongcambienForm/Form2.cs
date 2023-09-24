using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;

namespace DoluongcambienForm
{
    public partial class Form2 : Form
    {

        string InputData1 = String.Empty;
        string InputData2 = String.Empty;
        string InputData3 = String.Empty;
        string nhiet_do1;
        string nhiet_do2;
        string  Humidity ;
        int nhietdocaidat1 = 30;
        int nhietdocaidat2 = 40;
        double nhietdochar1 = 0;
        double nhietdochar2 = 0;
        double doamchar = 0;
        int doamcaidat = 80;
        double realtime = 0;
        bool du_lieu = false;
        double ndo1=0, ndo2=0,doam=0;
        SaveFileDialog luufile;
        private DateTime dateTime ;
        


        public Form2()
        {
            InitializeComponent(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] BaudRate = { "9600", "19200", "57600", "115200" };
            combrau.DataSource = BaudRate;
            string[] ports = SerialPort.GetPortNames();
            foreach (String port in ports)
            {
                comcb.Items.Add(port);
            }
            txtnhiet1.Text = Convert.ToString(nhietdocaidat1);
            txtnhiet2.Text = Convert.ToString(nhietdocaidat2);
           txtdoam.Text = Convert.ToString(doamcaidat);

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = InputData1 + "°C";
            textBox2.Text = InputData2 + "°C";
            textBox3.Text = InputData3 + "%";
            
            dateTime = DateTime.Now;
            int demdelay = 0;
            if (demdelay == 0)
            {
                demdelay++;
                ListViewItem item = new ListViewItem(DateTime.Now.ToLongTimeString());
                item.SubItems.Add(nhiet_do1 + "°C");
                item.SubItems.Add(nhiet_do2 + "°C");
                item.SubItems.Add(Humidity + "%");
                listView2.Items.Add(item);
                listView2.Items[listView2.Items.Count - 1].EnsureVisible();

                chart1.Series["LM35_1"].Points.AddXY(realtime, nhietdochar1);
                chart1.Series["LM35_2"].Points.AddXY(realtime, nhietdochar2);
                chart1.Series["Humi"].Points.AddXY(realtime, doamchar);
              
            }

            /* chart1.Series["nhiệt độ 1"].Points.AddXY(time, nhiet_do1);
             chart1.Series["nhiệt độ 2"].Points.AddXY(time, nhiet_do2);
             chart1.Series["độ ẩm"].Points.AddXY(time, Humidity);*/

            double.TryParse(InputData1, out ndo1);
            if( ndo1> nhietdocaidat1 )
            {
                label9.Text = "Nhiệt độ quá cao";
                pictureBox1.BackColor = Color.Red;
            }
            else
            {
                label9.Text = " Nhiệt độ bình thường";
                pictureBox1.BackColor = Color.Green;
            }
            double.TryParse(InputData3, out doam);
            if (doam > doamcaidat )
            {
                label8.Text = " Độ ẩm quá cao";
                pictureBox3.BackColor = Color.Red;
            }
            else
            {
                label8.Text = " Độ ẩm bình thường";
                pictureBox3.BackColor = Color.Green;

            }
            double.TryParse(InputData2, out ndo2);
            if (ndo2> nhietdocaidat2 )
                {
                label5.Text = "Nhiệt độ quá cao";
                pictureBox2.BackColor = Color.Red; 
            }
            else
            {
                label5.Text  = "Nhiệt độ bình thường";
                pictureBox2.BackColor = Color.Green;

            }

        }



        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                InputData1 = serialPort1.ReadLine();     //******** đọc dư liệu từ arduino gửi lên quả cổng serial
                InputData2 = serialPort1.ReadLine();
                InputData3 = serialPort1.ReadLine();
                if ((InputData1 != String.Empty) && (InputData2 != String.Empty) && (InputData3 != String.Empty))
                {
                    nhiet_do1 = InputData1;
                    nhiet_do2 = InputData2;
                    Humidity = InputData3;

                }
                double.TryParse(nhiet_do1, out nhietdochar1 );
                double.TryParse(nhiet_do2, out nhietdochar2);
                double.TryParse(Humidity, out doamchar);
            }
        }
           

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comcb.Text;
                serialPort1.BaudRate = Convert.ToInt32(combrau.Text); 
                serialPort1.Open();
                progressBar1.Value = 100;              
                button1.Text = "Đã kết nối";
                button1.ForeColor = Color.Green;
                button1.BackColor = Color.Red;
                MessageBox.Show("Bạn đã kết nối thành công");                          
                timer1.Start();
                listView2.Items.Clear();
                chart1.Series["LM35_1"].Points.Clear();
                chart1.Series["LM35_2"].Points.Clear();
                chart1.Series["doam"].Points.Clear();



                //*************************              

            }
            catch
            {
                button2.Text = " ngắt kết nối";
                button2.ForeColor = Color.Red;
                button2.BackColor = Color.Yellow;
                MessageBox.Show("Vui Lòng Thử Lại");
            }   


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            timer1.Stop();
           
            progressBar1.Value = 0;
            textBox1.Text = "         ";
            textBox2.Text = "         ";
            textBox3.Text = "          ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comcb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                //XUẤT DỮ LIỆU RA FILE TXT
                DateTime d1 = DateTime.Now;
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "(*.txt)|*.txt";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string path = savefile.FileName;
                    File.AppendAllText(path, " DAY              TIME              LM35_1                  LM35_2                  HUMIDITY" + Environment.NewLine);
                    for (int i = 1; i < listView2.Items.Count; i++)
                    {    
                        File.AppendAllText(path, d1.Day.ToString() + "/" + d1.Month.ToString() + "/" + d1.Year.ToString() + "                " + listView2.Items[i].SubItems[0].Text + "               " + listView2.Items[i].SubItems[1].Text + "             " + listView2.Items[i].SubItems[1].Text + "                 " + listView2.Items[i].SubItems[2].Text + Environment.NewLine);
                    }
                    MessageBox.Show("Lưu file thành công", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                serialPort1.Open();
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Lưu file thất bại","vui lòng kiểm tra lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dlr == DialogResult.OK)
                {

                }
            }


        }
        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
                nhietdocaidat1 = nhietdocaidat1--;
                txtnhiet1.Text = nhietdocaidat1.ToString() + "°C";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                nhietdocaidat2 = nhietdocaidat2--;
                txtnhiet2.Text = nhietdocaidat2.ToString() + "°C";
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            
                doamcaidat = doamcaidat--;
                txtdoam.Text = doamcaidat.ToString() + "%";
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            
                nhietdocaidat1 = nhietdocaidat1++;
                txtnhiet1.Text = nhietdocaidat1.ToString() + "°C";
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            
                nhietdocaidat2 = nhietdocaidat2++;
                txtnhiet2.Text = nhietdocaidat2.ToString() + "°C";
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
                doamcaidat = doamcaidat++;
                txtdoam.Text = doamcaidat.ToString() + "%";
            
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            nhietdocaidat1 = Convert.ToInt32(txtnhiet1.Text);
            nhietdocaidat2 = Convert.ToInt32(txtnhiet2.Text);
            doamcaidat = Convert.ToInt32(txtdoam.Text);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int doamcaidat = 80;
            int nhietdocaidat1 = 40;
            int nhietdocaidat2 = 30;
            txtnhiet1.Text = Convert.ToString(nhietdocaidat1);
            txtnhiet2.Text = Convert.ToString(nhietdocaidat2);
            txtdoam.Text = Convert.ToString(doamcaidat);
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(interval.Text);
        }

        private void chart1_Click_2(object sender, EventArgs e)
        {

        }

        private void combrau_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gui_btn_Click(object sender, EventArgs e)
        {
        }
       
            
        

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
