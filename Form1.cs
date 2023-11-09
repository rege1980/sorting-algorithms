

using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;

namespace sortingAlgorithms
{
    public partial class Sorting : Form
    {
        private int[] unsInts = Array.Empty<int>(); // unsorted array
        private int[] sorInts = Array.Empty<int>(); // sorted or to-be-sorted array
        //bool inputValid = false;
        bool busy = false;
        //int progress;
        //int progressMax;
        //bool pgbe;
        DateTime start;
        DateTime end;

        public Sorting()
        {
            InitializeComponent();
        }

        private void sorting_Button_Click(object sender, EventArgs e)
        {
            status.Text = string.Empty;
            status.Text = "Sorting...";

            sorInts = new int[unsInts.Length];
            unsInts.CopyTo(sorInts, 0);
            /*
            progress = 0;
            
            barProgress.Value = 0;
            busy = true;

            if (sender == butBub || sender == butIns || sender == butSel)
                progressMax = (int)Math.Pow(sorInts.Length, 2); // n^2
            else if (sender == butMer)
                progressMax = (int)(sorInts.Length * Math.Log10(sorInts.Length)); // n*logn
            else if (sender == butQui)
                progressMax = (int)(sorInts.Length * Math.Log10(sorInts.Length)); // n*logn

            if (progressMax > 999999)
            {
                barProgress.Style = ProgressBarStyle.Continuous;
                pgbe = false;
            }
            else
            {
                barProgress.Style = ProgressBarStyle.Blocks;
                pgbe = true;
            }
            */
            butOff();

            start = DateTime.Now;

            string butText = ((System.Windows.Forms.Button)sender).Name;

            switch (butText)
            {
                case "butBub":
                    bwBubble.RunWorkerAsync();
                    break;
                case "butIns":
                    bwInsert.RunWorkerAsync();
                    break;
                case "butSel":
                    bwSelect.RunWorkerAsync();
                    break;
                case "butMer":
                    bwMerge.RunWorkerAsync();
                    break;
                case "butQui":
                    bwQuick.RunWorkerAsync();
                    break;
                default:
                    break;
            }
        }
        // BUBBLE //
        private void bwBubble_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool cbz;
            do
            {
                cbz = false;
                for (int i = 0; i < sorInts.Length - 1; i++)
                {
                    if (sorInts[i] > sorInts[i + 1])
                    {
                        cbz = true;
                        swap(sorInts, i, i + 1);
                    }
                    //bwBubble.ReportProgress(1);
                }
            } while (cbz);
        }
        // INSERTION //
        private void bwInsert_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool cbz;
            do
            {
                cbz = false;
                for (int i = 1; i < sorInts.Length; i++)
                {
                    if (sorInts[i - 1] > sorInts[i])
                    {
                        cbz = true;
                        swap(sorInts, i - 1, i);
                    }
                    //bwInsert.ReportProgress(1);
                }
            } while (cbz);
        }
        // SELECTION //
        private void bwSelect_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool cbz;
            do
            {
                cbz = false;
                for (int i = 0; i < sorInts.Length; i++)
                {
                    int smallest = getSmallestIndex(i, sorInts);
                    if (smallest != i)
                    {
                        swap(sorInts, smallest, i);
                        cbz = true;
                    }
                    //bwSelect.ReportProgress(4);
                }
            } while (cbz);
        }
        // MERGE //
        private void bwMerge_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            mergeSort(sorInts);
        }
        private void mergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;

            int[] left = Array.Empty<int>();
            int[] right = Array.Empty<int>();

            left = new int[mid];
            right = new int[arr.Length - mid];
            splitArray(arr, 0, mid, left, mid, arr.Length, right);

            mergeSort(left);
            mergeSort(right);

            //bwMerge.ReportProgress(1);

            merge(arr, left, right);
        }
        private static void merge(int[] arr, int[] left, int[] right)
        {
            int l = 0;
            int r = 0;
            int i = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l] < right[r])
                {
                    arr[i] = left[l];
                    l++;
                    i++;
                }
                else
                {
                    arr[i] = right[r];
                    r++;
                    i++;
                }
            }
            while (l < left.Length)
            {
                arr[i] = left[l];
                l++;
                i++;
            }
            while (r < right.Length)
            {
                arr[i] = right[r];
                r++;
                i++;
            }
        }
        // QUICK //
        private unsafe void bwQuick_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            quickSort(sorInts, 0, sorInts.Length - 1);
        }
        private unsafe void quickSort(int[] arr, int leftIndex, int rightIndex)
        {
            int l = leftIndex;
            int r = rightIndex;
            int pivot = arr[leftIndex];

            while (l <= r)
            {
                while (arr[l] < pivot)
                {
                    l++;
                }
                while (arr[r] > pivot)
                {
                    r--;
                }
                if (l <= r)
                {
                    swap(arr, l, r);
                    l++;
                    r--;
                }
                //bwQuick.ReportProgress(1);
            }
            if (leftIndex < r)
                quickSort(arr, leftIndex, r);
            if (rightIndex > l)
                quickSort(arr, l, rightIndex);
        }
        // PROGRESS UPDATE //
        private void ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            /*
            if (pgbe)
            {
                progress += e.ProgressPercentage;
                int percentage = (int)(progress * 100 / progressMax);

                if (percentage > 100) percentage = 100;
                if (percentage < 0) percentage = 0;

                barProgress.Value = percentage;
                status.Text = "Estimated progress " + percentage + "%";
            }
            */
        }
        // SORTING COMPLETE //
        private void RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //barProgress.Value = 100;
            end = DateTime.Now;
            status.Text = "Done! " + formatTime(start, end);
            updateOutput();
            busy = false;
            butOn();
        }
        // CHECKBOXES //
        private void checkBoxChanged(object sender, EventArgs e)
        {
            bool text = false;
            bool rand = false;
            if (sender == chkBoxText)
            {
                text = (((CheckBox)sender).CheckState == CheckState.Checked);
                rand = !text;
            }
            if (sender == chkBoxRandom)
            {
                rand = (((CheckBox)sender).CheckState == CheckState.Checked);
                text = !rand;
            }
            chkBoxText.Checked = text;
            chkBoxRandom.Checked = rand;
            boxInput.Enabled = text;
            butRand.Enabled = rand;
            labRand.Enabled = rand;
            UDRand.Enabled = rand;
            butOff();
            boxInput.Text = string.Empty;
        }
        // RANDOM BUTTON //
        private void butRand_Click(object sender, EventArgs e)
        {
            Random random = new();
            unsInts = new int[(int)UDRand.Value];
            for (int i = 0; i < (int)UDRand.Value; i++)
            {
                unsInts[i] = random.Next(0, 99);
            }
            butOn();
        }
        private void UDRand_Value_changed(object sender, EventArgs e)
        {
            butOff();
        }
        // INPUT CHANGED //
        private void boxInput_TextChanged(object sender, EventArgs e)
        {
            String str = boxInput.Text;

            String[] tab = str.Trim().Split(' ');

            if (tab.Length == 0 || tab == null) return;

            unsInts = new int[tab.Length];

            for (int i = 0; i < tab.Length; i++)
            {
                try
                {
                    unsInts[i] = Convert.ToInt32(tab[i]);
                }
                catch
                {
                    boxInput.ForeColor = Color.Red;
                    butOff();
                    return;
                }
                unsInts[i] = Convert.ToInt32(tab[i]);
            }
            boxInput.ForeColor = Color.Black;
            butOn();
        }
        // OUTPUT UPDATE //
        private void updateOutput()
        {
            boxOutput.Text = String.Empty;
            for (int i = 0; i < sorInts.Length; i++)
            {
                boxOutput.Text += sorInts[i] + " ";
            }
        }
        // DISABLE/ENABLE BUTTONS //
        private void butOff()
        {
            butBub.Enabled = false;
            butIns.Enabled = false;
            butSel.Enabled = false;
            butMer.Enabled = false;
            butQui.Enabled = false;
        }
        private void butOn()
        {
            if (busy) return;
            butBub.Enabled = true;
            butIns.Enabled = true;
            butSel.Enabled = true;
            butMer.Enabled = true;
            butQui.Enabled = true;
        }
        // SWAP X AND Y IN INT ARRAY //
        private static void swap(int[] tab, int x, int y)
        {
            (tab[y], tab[x]) = (tab[x], tab[y]);
        }
        // FIND SMALLEST INT IN INT ARRAY STARTING AT INDEX START AND RETURN RETURN ITS INDEX //
        private static int getSmallestIndex(int start, int[] tab)
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
        private static void splitArray(int[] tab, int start1, int stop1, int[] tab1, int start2, int stop2, int[] tab2)
        {
            for (int i = start1; i < stop1; i++)
                tab1[i - start1] = tab[i];
            for (int i = start2; i < stop2; i++)
                tab2[i - start2] = tab[i];
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