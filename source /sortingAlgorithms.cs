using System.ComponentModel;

namespace sortingAlgorithms
{
    public partial class Sorting : Form
    {
        private int[] unsInts = Array.Empty<int>(); // unsorted array
        private int[] sorInts = Array.Empty<int>(); // sorted/to-be-sorted array
        bool busy = false;                          // is any sorting worker running
        int progress;                             // number of operations
        int progressMax;                          // max worst case operationd
        DateTime start;
        DateTime end;

        public Sorting()
        {
            InitializeComponent();
            bwProgress.RunWorkerAsync(); // run progress worker
        }
        private void sorting_Button_Click(object sender, EventArgs e)
        {
            status.Text = "Sorting...";
            // copy array
            sorInts = new int[unsInts.Length];
            unsInts.CopyTo(sorInts, 0);

            // reset progress 
            progress = 0;
            progressMax = sorInts.Length;
            barProgress.Value = 0;

            butOff();

            busy = true;

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
                }
                progress++;
            } while (cbz);
        }
        // INSERTION //
        private void bwInsert_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 1; i < sorInts.Length; i++)
            {
                for (int j = i; j > 0 && sorInts[j - 1] > sorInts[j]; j--)
                {
                    swap(sorInts, j - 1, j);
                }
                progress++;
            }
        }
        // SELECTION //
        private void bwSelect_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int smallest;
            for (int i = 0; i < sorInts.Length; i++)
            {
                smallest = getSmallestIndex(i, sorInts);
                if (smallest != i)
                {
                    swap(sorInts, smallest, i);
                }
                progress++;
            }
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

            progress++;

            mergeSort(left);
            mergeSort(right);

            merge(arr, left, right);
        }
        private void merge(int[] arr, int[] left, int[] right)
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
            }
            progress++;
            if (leftIndex < r)
                quickSort(arr, leftIndex, r);
            if (rightIndex > l)
                quickSort(arr, l, rightIndex);
        }
        // PROGRESS UPDATE //
        private void bwProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            int percent;
            while (true)
            {
                Thread.Sleep(500);
                if (busy)
                {
                    percent = progress * 100 / progressMax;
                    if (percent > 100) percent = 100;
                    if (percent < 0) percent = 0;
                    bwProgress.ReportProgress(percent);
                }
            }
        }
        private void ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            status.Text = "Working... " + e.ProgressPercentage + "%  (" + progress + "/" + progressMax + ") ";
            barProgress.Value = e.ProgressPercentage;
        }
        // SORTING COMPLETE //
        private void RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            busy = false;
            end = DateTime.Now;
            barProgress.Value = 100;
            status.Text = "Sorting done in " + formatTime(start, end);
            updateOutput();
            butOn();
            butSave.Enabled = true;
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
            boxOutput.Text = string.Empty;
        }
        // RANDOM BUTTON //
        private void butRand_Click(object sender, EventArgs e)
        {
            Random random = new();

            unsInts = new int[(int)UDRand.Value];

            for (int i = 0; i < (int)UDRand.Value; i++)
                unsInts[i] = random.Next(0, 9999);

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
            if (sorInts.Length < 75)
            {
                for (int i = 0; i < sorInts.Length; i++)
                {
                    boxOutput.Text += sorInts[i] + " ";
                }
                return;
            }
            boxOutput.Text = "Too many numbers to show here.";
        }
        // SAVE TO FILE //
        private void butSave_Click(object sender, EventArgs e)
        {
            sFile.Filter = "Text file|*.txt";
            sFile.Title = "Save file";
            sFile.ShowDialog();
            using (StreamWriter outputFile = new StreamWriter(sFile.FileName))
            {
                for (int i = 0; i < sorInts.Length; i++)
                    outputFile.Write(sorInts[i] + " ");
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
            butSave.Enabled = false;
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
