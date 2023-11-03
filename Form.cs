using System.Diagnostics.Contracts;
using System.Media;
using System.Security.AccessControl;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        
        // 0 - bubble sort //
        private void bubSortBut_Click(object sender, EventArgs e)   
        {
            sorting(0);
        }
        private void bubbleSort(int[] tab)                                 
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
            return;
        }
        // 1 - selection sort //
        private void selSortBut_Click(object sender, EventArgs e)       
        {
            sorting(1);
        }
        private void selectionSort(int[] tab)
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
            return;
        }

        // 2 - insertion sort //
        private void insertSortBut_Click(object sender, EventArgs e)
        {
            sorting(2);
        }
        private void insertionSort(int[] tab)
        {
            bool cbz;
            do
            {
                cbz = false;
                for (int i = 1; i < tab.Length; i++)
                {
                    if (tab[i-1] > tab[i])
                    {
                        int temp = tab[i];
                        tab[i] = tab[i-1];
                        tab[i-1] = temp;
                        cbz = true;
                    }
                }
            } while (cbz);
            return;
        }

        // 3 - merge sort //
        private void mrgSortBut_Click(object sender, EventArgs e)
        {
            sorting(3);
        }
        private void mergeSort(int[] tab)
        {
            if (tab.Length <= 1) return;

            int mid = tab.Length / 2;

            int[] left = Array.Empty<int>();
            int[] right = Array.Empty<int>();

            left = new int[mid];
            right = new int[tab.Length - mid];

            left = copyArray(tab, 0, mid);
            right = copyArray(tab, mid, tab.Length);

            mergeSort(left);
            mergeSort(right);

            merge(tab, left, right);

            return;
        }
        private void merge(int[] tab, int[] left, int[] right)
        {
            int l = 0;
            int r = 0;
            int i = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l] < right[r])
                {
                    tab[i] = left[l];
                    l++;
                    i++;
                }
                else
                {
                    tab[i] = right[r];
                    r++;
                    i++;
                }
            }
            while (l < left.Length)
            {
                tab[i] = left[l];
                l++;
                i++;
            }
            while (r < right.Length)
            {
                tab[i] = right[r];
                r++;
                i++;
            }
            return;
        }


        // 4 - quick sort //
        private void qkSortBut_Click(object sender, EventArgs e)
        {
            sorting(4);
        }
        int[] quickSort(int[] tab)
        {
            return tab;
        }


        // func called after any sort button click
        // n=0 - bubble
        // n=1 - selection
        // n=2 - insertion
        // n=3 - merge
        // n=4 - quick
        private void sorting(int n)
        {
            int[] tab = new int[randSrc.Count];

            DateTime start;
            DateTime end;

            tab = getInput();

            start = DateTime.Now;

            switch (n)
            {
                case 0:
                    bubbleSort(tab);
                    break;
                case 1:
                    selectionSort(tab);
                    break;
                case 2:
                    insertionSort(tab);
                    break;
                case 3:
                    mergeSort(tab);
                    break;
                case 4:
                    quickSort(tab);
                    break;
                default:
                    Array.Sort(tab);
                    break;
            }
            if (tab.Length == 0) return;

            end = DateTime.Now;

            if (!randCheck.Checked)
                showOutput(tab);

            timeLab.Text = "Sorting took " + formatTime(start, end);
            timeLab.Visible = true;
        }

        // generate button //
        private void genBut_Click(object sender, EventArgs e)
        {
            randSrc.Clear();

            Random rand = new();

            genBut.UseWaitCursor = true;

            for (int i = 0; i < randCountUD.Value; i++)
            {
                randSrc.Add(rand.Next(1, 99));
            }

            genBut.UseWaitCursor = false;

            bubSortBut.Enabled = true;
            selSortBut.Enabled = true;
            insertSortBut.Enabled = true;
            mrgSortBut.Enabled = true;
            //qkSortBut.Enabled = true;
            SystemSounds.Beep.Play();
            //MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }


        // get user input or random array and return //
        int[] getInput()
        {
            if (randCheck.Checked)  // random numbers
            {
                int[] ret = new int[randSrc.Count];
                randSrc.CopyTo(ret, 0);
                return ret;
            }
            else                    // user input
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
                    return Array.Empty<int>();
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
                        return Array.Empty<int>();
                    }
                    ret[i] = Convert.ToInt32(tab[i]);
                }
                return ret;
            }
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
        private int findSmallestIndex(int start, int[] tab)
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
                if (randSrc.Count == 0)
                {
                    bubSortBut.Enabled = false;
                    selSortBut.Enabled = false;
                    insertSortBut.Enabled = false;
                    mrgSortBut.Enabled = false;
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
                insertSortBut.Enabled = true;
                mrgSortBut.Enabled = true;
                //qkSortBut.Enabled = true;
            }
        }

        private int[] copyArray(int[] src, int start, int stop)
        {
            int[] ret = new int[stop - start];
            for(int i = start; i < stop; i++) 
                ret[i - start] = src[i];
            return ret;
        }

        private String formatTime(DateTime start, DateTime end)
        {
            TimeSpan time = end - start;
            if (time.TotalMicroseconds < 1000) return ((int)time.TotalMicroseconds) + " microseconds.";
            else if (time.TotalMilliseconds < 1000) return ((int)time.Milliseconds) + "." + ((int)time.Microseconds) + " milliseconds.";
            else if (time.TotalSeconds < 60) return ((int)time.Seconds) + "." + ((int)time.Milliseconds) + " seconds.";
            else return ((int)time.Minutes) + " minutes and " + ((int)time.Seconds) + " seconds.";
        }
    }
}