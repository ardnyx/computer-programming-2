namespace Subject_Enlistment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cprogLec, cprogLab, oopLec, oopLab, appDevLec, appDevLab, computing2, uts, pathfit2, theology2;
            cprogLec = Convert.ToInt32(comProgLec.Text);
            cprogLab = Convert.ToInt32(comProgLab.Text);
            oopLec = Convert.ToInt32(oopLecInput.Text);
            oopLab = Convert.ToInt32(oopLabInput.Text);
            appDevLab = Convert.ToInt32(appDevLabInput.Text);
            appDevLec = Convert.ToInt32(appDevLecInput.Text);
            computing2 = Convert.ToInt32(computingTwoInput.Text);
            uts = Convert.ToInt32(utsInput.Text);
            pathfit2 = Convert.ToInt32(peInput.Text);
            theology2 = Convert.ToInt32(theoInput.Text);

            int totalUnits = cprogLec + cprogLab + oopLec + oopLab + appDevLec + appDevLab + computing2 + uts + pathfit2 + theology2;

            if (totalUnits > 18)
            {
                { studentStatus.Text = "REGULAR STUDENT"; studentStatus.Refresh(); }
            }
            else if (totalUnits <= 18) { studentStatus.Text = "IRREGULAR STUDENT"; studentStatus.Refresh(); }

            double tfLecTotal, tfLabTotal, labFeeTotal, totalTuition, assessmentFees, downpayment;
            double[] miscFees = new double[17];
            tfLecTotal = (cprogLec + oopLec + appDevLec + computing2 + uts + pathfit2 + theology2) * 1474;
            tfLabTotal = (cprogLab + oopLab + appDevLab) * 2790;
            labFeeTotal = (cprogLab + oopLab + appDevLab) * 2500;

            tuitionFeeLec.Text = tfLecTotal.ToString("F2");
            tuitionFeeLab.Text = tfLabTotal.ToString("F2");
            laboratoryFee.Text = labFeeTotal.ToString("F2");

            totalTuition = tfLecTotal + tfLabTotal;
            downpayment = totalTuition * 0.3;

            totalTF.Text = totalTuition.ToString("F2");
            DP.Text = downpayment.ToString("F2");

            for (int x = 0; x < 17; x++)
            {
                miscFees[x] = Convert.ToDouble(Controls["misc" + (x + 1)].Text);
            }

            double totalMiscFees = miscFees.Sum();
            feeAssessment.Text = (totalMiscFees + totalTuition).ToString("F2");
            miscFee.Text = totalMiscFees.ToString("F2");

            double payment = (totalMiscFees + totalTuition) - downpayment;
            termPayment = payment;
        }

        double termPayment;
        private void termBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (termBox.SelectedIndex == 0)
            {
                box1.Text = "First Term:";
                box_a1.Text = termPayment.ToString("F2");
                box2.Text = "";
                box_a2.Text = "";
                box3.Text = "";
                box_a3.Text = "";
                box4.Text = "";
                box_a4.Text = "";
                box5.Text = "";
                box_a5.Text = "";
            }
            else if (termBox.SelectedIndex == 1)
            {
                double twoTerms = termPayment / 2;
                box1.Text = "First Term:";
                box_a1.Text = twoTerms.ToString("F2");
                box2.Text = "Second Term:";
                box_a2.Text = twoTerms.ToString("F2");
                box3.Text = "";
                box_a3.Text = "";
                box4.Text = "";
                box_a4.Text = "";
                box5.Text = "";
                box_a5.Text = "";
            }
            else if (termBox.SelectedIndex == 2)
            {
                double threeTerms = termPayment / 3;
                box1.Text = "First Term:";
                box_a1.Text = threeTerms.ToString("F2");
                box2.Text = "Second Term:";
                box_a2.Text = threeTerms.ToString("F2");
                box3.Text = "Third Term:";
                box_a3.Text = threeTerms.ToString("F2");
                box4.Text = "";
                box_a4.Text = "";
                box5.Text = "";
                box_a5.Text = "";
            }
            else if (termBox.SelectedIndex == 3)
            {
                double fourTerms = termPayment / 4;
                box1.Text = "First Term:";
                box_a1.Text = fourTerms.ToString("F2");
                box2.Text = "Second Term:";
                box_a2.Text = fourTerms.ToString("F2");
                box3.Text = "Third Term:";
                box_a3.Text = fourTerms.ToString("F2");
                box4.Text = "Fourth Term:";
                box_a4.Text = fourTerms.ToString("F2");
                box5.Text = "";
                box_a5.Text = "";
            }
            else if (termBox.SelectedIndex == 4)
            {
                double fiveTerms = termPayment / 5;
                box1.Text = "First Term:";
                box_a1.Text = fiveTerms.ToString("F2");
                box2.Text = "Second Term:";
                box_a2.Text = fiveTerms.ToString("F2");
                box3.Text = "Third Term:";
                box_a3.Text = fiveTerms.ToString("F2");
                box4.Text = "Fourth Term:";
                box_a4.Text = fiveTerms.ToString("F2");
                box5.Text = "Fifth Term:";
                box_a5.Text = fiveTerms.ToString("F2");
            }
        }


        private void comProgLab_TextChanged(object sender, EventArgs e)
        {

        }

        private void comProgLec_TextChanged(object sender, EventArgs e)
        {

        }

        private void oopLab_TextChanged(object sender, EventArgs e)
        {

        }

        private void oopLec_TextChanged(object sender, EventArgs e)
        {

        }

        private void appDevLab_TextChanged(object sender, EventArgs e)
        {

        }

        private void appDevLec_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void computingTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void understandingTheSelf_TextChanged(object sender, EventArgs e)
        {

        }

        private void pathfitTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void theologyTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void termTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}