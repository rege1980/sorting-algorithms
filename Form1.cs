using System.Media;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // bubble sort button //
        private void bubSortBut_Click(object sender, EventArgs e)
        {
            int[] tab = new int[randomArray.Length];

            DateTime start;
            DateTime end;

            if (!randCheck.Checked)
                tab = getInput();
            else
                randomArray.CopyTo(tab, 0);

            start = DateTime.Now;

            tab = bubbleSort(tab);

            if (tab.Length == 0) return;

            end = DateTime.Now;

            if (!randCheck.Checked)
                showOutput(tab);

            timeLab.Text = "Sorting took " + formatTime(start, end);
            timeLab.Visible = true;
        }

        // selection sort button //
        private void selSortBut_Click(object sender, EventArgs e)
        {
            int[] tab = new int[randomArray.Length];

            DateTime start;
            DateTime end;

            if (!randCheck.Checked)
                tab = getInput();
            else
                randomArray.CopyTo(tab, 0);

            start = DateTime.Now;

            tab = selectionSort(tab);

            if (tab.Length == 0) return;

            end = DateTime.Now;

            if (!randCheck.Checked)
                showOutput(tab);

            timeLab.Text = "Sorting took " + formatTime(start, end);
            timeLab.Visible = true;
        }

        // insert sort button //
        private void insertSortBut_Click(object sender, EventArgs e)
        {

        }

        // quick sort button //
        private void qkSortBut_Click(object sender, EventArgs e)
        {

        }

        // merge sort button //
        private void mrgSortBut_Click(object sender, EventArgs e)
        {

        }

        // generate button //
        private void genBut_Click(object sender, EventArgs e)
        {
            randomArray = new int[(int)randCountUD.Value];

            Random rand = new Random();

            genBut.UseWaitCursor = true;

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = rand.Next(1, 99);
            }

            genBut.UseWaitCursor = false;

            bubSortBut.Enabled = true;
            selSortBut.Enabled = true;
            //insertSortBut.Enabled = true;
            //mrgSortBut.Enabled = true;
            //qkSortBut.Enabled = true;
        }

        // bubble sort //
        int[] bubbleSort(int[] tab)
        {
            bool cbz = false;
            do
            {
                cbz = false;
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    if (tab[i] > tab[i + 1])
                    {
                        cbz = true;
                        int temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                    }
                }
            } while (cbz);
            return tab;
        }

        // selection sort //
        int[] selectionSort(int[] tab)
        {
            bool cbz;
            do
            {
                cbz = false;
                for (int i = 0; i < tab.Length; i++)
                {
                    int smallest = findSmallestIndex(i, tab);
                    if (smallest != i)
                    {
                        int temp = tab[i];
                        tab[i] = tab[smallest];
                        tab[smallest] = temp;
                        cbz = true;
                    }
                }

            }
            while (cbz);
            return tab;
        }

        // get user input, convert it to int array and return //
        int[] getInput()
        {
            String str = inputBox.Text;
            try
            {
                str.Trim().Split(' ');
            }
            catch
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Wrong formatting! Try: 9 8 7 6 5");
                return new int[0];
            }

            String[] tab = str.Trim().Split(' ');
            int[] ret = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                try
                {
                    Convert.ToInt32(tab[i]);
                }
                catch
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Something is wrong! Try: 9 8 7 6 5");
                    return new int[0];
                }
                ret[i] = Convert.ToInt32(tab[i]);
            }
            return ret;
        }

        // convert int array to string and put it in a outputBox //
        void showOutput(int[] tab)
        {
            if (tab != null && tab.Length > 0)
            {
                String output = "";
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    output += tab[i] + " , ";
                }
                output += tab.Last();

                outputBox.Text = output;
            }
            else outputBox.Text = "";

        }

        // find smallest number in an array starting from index 'start' an return it //
        int findSmallestIndex(int start, int[] tab)
        {
            int temp = tab[start];
            int tempI = start;
            for (int i = start; i < tab.Length; i++)
            {
                if (tab[i] < temp)
                {
                    temp = tab[i];
                    tempI = i;
                }
            }
            return tempI;
        }

        // actions taken when checkbox state is changed //
        private void randCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (randCheck.Checked)
            {
                inputBox.Enabled = false;
                outputBox.Enabled = false;
                randCountUD.Enabled = true;
                genBut.Enabled = true;
                if (randomArray.Length == 0 || randomArray == null)
                {
                    bubSortBut.Enabled = false;
                    selSortBut.Enabled = false;
                    //insertSortBut.Enabled = false;
                    //mrgSortBut.Enabled = false;
                    //qkSortBut.Enabled = false;
                }
            }
            else
            {
                inputBox.Enabled = true;
                outputBox.Enabled = true;
                randCountUD.Enabled = false;
                genBut.Enabled = false;

                bubSortBut.Enabled = true;
                selSortBut.Enabled = true;
                //insertSortBut.Enabled = true;
                //mrgSortBut.Enabled = true;
                //qkSortBut.Enabled = true;
            }
        }

        String formatTime(DateTime start, DateTime end)
        {
            TimeSpan time = end - start;
            if (time.TotalMicroseconds < 2500) return ((int)time.TotalMicroseconds) + " microseconds.";
            else if (time.TotalMilliseconds < 2500) return ((int)time.TotalMilliseconds) + " milliseconds.";
            else if (time.TotalSeconds < 120) return ((int)time.TotalSeconds) + " seconds.";
            else return ((int)time.TotalMinutes) + " minutes.";
        }

        private void outputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void timeLab_Click(object sender, EventArgs e)
        {
        }
    }



}